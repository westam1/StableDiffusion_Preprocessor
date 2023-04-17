using System.Text.Json;
using System.Text;

namespace Embedding_Reimage_Utility {
	public partial class MainForm : Form {
		[Flags]
		private enum ReimgStatus : byte { NotReady = 0x00, PtReady = 0x01, ImgReady = 0x02, }

		private ReimgStatus m_Status = ReimgStatus.NotReady;
		private string m_Pt = "", m_DecodedPt = "";
		TextualInversionData m_TIDat;

		public MainForm() {
			InitializeComponent();
		}

		public static UInt32 ReadUInt32BigEndian(BinaryReader Reader) {
			byte[] data = new byte[4];
			Reader.Read(data, 0, 4);
			return (UInt32)(data[0] << 24 | data[1] << 16 | data[2] << 8 | data[3]);
		}
		private void ParseA1111Chunk(byte[] Data) {
			// Note PNG: 4byte len, 4byte type, 4byte crc, len data. chunks repeat. tEXt chunk is the one a1111 uses
			bool parsing = true;
			using (BinaryReader reader = new BinaryReader(new MemoryStream(Data))) {
				byte[] tag = reader.ReadBytes(8);														// Read and
				if (tag[0] != 0x89 || tag[1] != 0x50 || tag[2] != 0x4e || tag[3] != 0x47) { return; }	// check PNG tag

				try {
					while (parsing) {
						int len = (int)ReadUInt32BigEndian(reader), type = (int)ReadUInt32BigEndian(reader), crc = (int)ReadUInt32BigEndian(reader);
						byte[] buf = new byte[len];
						reader.Read(buf, 0, len);
						if (type == 0x74455874) {
							reader.BaseStream.Position -= len + 4; // Note: For some reason, no CRC here so have to read again. Do I misunderstand png format?
							buf = new byte[len];
							reader.Read(buf, 0, len);
							m_Pt = Encoding.ASCII.GetString(buf, 0, len);
							m_DecodedPt = Encoding.ASCII.GetString(System.Convert.FromBase64String(m_Pt.Split('\0')[1]));

							m_TIDat = JsonSerializer.Deserialize<TextualInversionData>(m_DecodedPt)!;
							m_Status |= ReimgStatus.PtReady;
						}
						if (len == 0) { parsing = false; }
					}
				}
				catch { parsing = false; /* Note: Exception here could be bug, or could be not A1111 tEXt chunk. */ }
			}
		}

		private bool LoadEmbed(string FName) {
			if (!File.Exists(FName)) { return false; }

			using (FileStream fStream = File.Open(FName, FileMode.Open, FileAccess.Read)) {
				byte[] data = new byte[fStream.Length];
				fStream.Read(data, 0, data.Length);
				ParseA1111Chunk(data);
				fStream.Position = 0;
				PbxOld.BackgroundImage = Image.FromStream(fStream);
				return true;
			}
		}
		private bool LoadImg(string FName) {
			if (!File.Exists(FName)) { return false; }

			PbxNew.BackgroundImage = Image.FromFile(FName);
			m_Status |= ReimgStatus.ImgReady;
			return true;
		}
		private void SaveNewEmbed(string FName) {

		}

		private void BtnLoadEmb_Click(object sender, EventArgs e) {
			using (OpenFileDialog ofd = new()) {
				if (ofd.ShowDialog() == DialogResult.OK) {
					if (LoadEmbed(ofd.FileName)) {
						BtnLoadEmb.BackColor = Color.LightGreen;
					}
				}
			}
		}
		private void BtnLoadImg_Click(object sender, EventArgs e) {
			using (OpenFileDialog ofd = new()) {
				if (ofd.ShowDialog() == DialogResult.OK) {
					if (LoadImg(ofd.FileName)) {
						BtnLoadImg.BackColor = Color.LightGreen;
					}
				}
			}
		}
		private void BtnCommit_Click(object sender, EventArgs e) {
			using (SaveFileDialog sfd = new()) {
				if (sfd.ShowDialog() == DialogResult.OK) {
					SaveNewEmbed(sfd.FileName);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			using (OpenFileDialog ofd = new()) {
				if (ofd.ShowDialog() == DialogResult.OK) {
					using (FileStream fStream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read)) {
						byte[] data = new byte[fStream.Length];
						fStream.Read(data, 0, data.Length);
						string b64Test = System.Convert.ToBase64String(data);
						bool result = b64Test == m_Pt.Split('\0')[1];
					}
				}
			}
		}
	}
}