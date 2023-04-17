using System.Text.Json;
using System.Text;

namespace Embedding_Reimage_Utility {
	public partial class MainForm : Form {
		[Flags]
		private enum ReimgStatus : byte { NotReady = 0x00, PtReady = 0x01, ImgReady = 0x02, Ready = PtReady | ImgReady, }

		private readonly Font NAME_FONT = new("MS Sans Seriff", 27.5f, FontStyle.Regular), MODEL_FONT = new("MS Sans Seriff", 10f, FontStyle.Regular);

		private ReimgStatus m_Status = ReimgStatus.NotReady;
		private string m_Pt = "", m_DecodedPt = "";
		TextualInversionData? m_TIDat;
		//TODO: Add way to control what text and gradient elements are pushed into the img embedding

		public MainForm() {
			InitializeComponent();
		}

		public static UInt32 ReadUInt32BigEndian(BinaryReader Reader) {
			byte[] data = new byte[4];
			Reader.Read(data, 0, 4);
			return (UInt32)(data[0] << 24 | data[1] << 16 | data[2] << 8 | data[3]);
		}
		public static void WriteUInt32BigEndian(BinaryWriter Writer, UInt32 Data) {
			byte[] data = new byte[4];
			data[0] = (byte)((Data >> 24) & 0xFF);
			data[1] = (byte)((Data >> 16) & 0xFF);
			data[2] = (byte)((Data >> 8) & 0xFF);
			data[3] = (byte)(Data & 0xFF);
			Writer.Write(data, 0, 4);
		}
		private void ParseA1111Chunk(byte[] Data) {
			// Note PNG: 4byte len, 4byte type, 4byte crc, len data. chunks repeat. tEXt chunk is the one a1111 uses
			bool parsing = true;
			using (BinaryReader reader = new(new MemoryStream(Data))) {
				byte[] tag = reader.ReadBytes(8);														// Read and
				if (tag[0] != 0x89 || tag[1] != 0x50 || tag[2] != 0x4e || tag[3] != 0x47) { return; }	// check PNG tag

				try {
					while (parsing) {
						int len = (int)ReadUInt32BigEndian(reader), type = (int)ReadUInt32BigEndian(reader);
						byte[] buf = new byte[len];
						reader.Read(buf, 0, len);
						if (type == 0x74455874) {
							m_Pt = Encoding.ASCII.GetString(buf, 0, len);
							m_DecodedPt = Encoding.ASCII.GetString(Convert.FromBase64String(m_Pt.Split('\0')[1]));

							m_TIDat = JsonSerializer.Deserialize<TextualInversionData>(m_DecodedPt)!;
							TbxName.Text = m_TIDat.Name;
							TbxNameHash.Text = m_TIDat.CheckpointName + " [" + m_TIDat.CheckpointHash + "]";
							TbxVectorStep.Text = m_TIDat.Tensors?.Child?.Tensors.Length + "v " + (m_TIDat.StepCount + 1).ToString() + "s";
							m_Status |= ReimgStatus.PtReady;
						}
						int crc = (int)ReadUInt32BigEndian(reader);
						if (len == 0) { parsing = false; }
					}
				}
				catch { parsing = false; /* Note: Exception here could be bug, or could be not A1111 tEXt chunk. */ }
			}
		}
		private void InsertA1111ChunkAndSave(MemoryStream M, FileStream F) {
			long pos;
			bool parsing = true;

			if (m_TIDat == null) { return; }
			M.Position = 0;
			using (BinaryReader reader = new(M))
			using (BinaryWriter writer = new(F)){
				byte[] data = reader.ReadBytes(8);														// read and save PNG tag
				F.Write(data, 0, data.Length);

				try {
					while (parsing) {
						pos = M.Position;

						int len = (int)ReadUInt32BigEndian(reader), type = (int)ReadUInt32BigEndian(reader);
						if (type == 0x49484452) {	// If first chunk, write first chunk, then write text chunk. If not first chunk, write chunk blind.
							M.Position = pos;
							data = new byte[len + 12];
							reader.Read(data, 0, data.Length);
							writer.Write(data, 0, data.Length);

							string output = "sd-ti-embedding\0" + Convert.ToBase64String(Encoding.ASCII.GetBytes(m_DecodedPt.Replace(m_TIDat.Name, TbxName.Text)));
							WriteUInt32BigEndian(writer, (uint)output.Length);
							byte[] chunk = new byte[output.Length + 8];
							using (BinaryWriter chunkWrite = new(new MemoryStream(chunk))) {
								WriteUInt32BigEndian(chunkWrite, (uint)0x74455874);
								chunkWrite.Write(output.ToCharArray());
								WriteUInt32BigEndian(chunkWrite, CRCHelper.Crc32(chunk, 0, output.Length + 4, 0x00000000)); // write CRC

								writer.Write(chunk, 0, chunk.Length);
							}
						} else {
							M.Position = pos;
							data = new byte[len + 12];
							reader.Read(data, 0, data.Length);
							writer.Write(data, 0, data.Length);
						}
						if (len == 0) { parsing = false; }
					}
				}
				catch { parsing = false; /* Note: Exception here could be bug, or could be not A1111 tEXt chunk. */ }
			}
		}
		private void CheckReady() {
			if ((m_Status & ReimgStatus.Ready) != ReimgStatus.Ready) { return; }
			BtnCommit.Enabled = true;
		}

		private bool LoadEmbed(string FName) {
			if (!File.Exists(FName)) { return false; }

			using (FileStream fStream = File.Open(FName, FileMode.Open, FileAccess.Read)) {
				byte[] data = new byte[fStream.Length];
				fStream.Read(data, 0, data.Length);
				ParseA1111Chunk(data);
				fStream.Position = 0;
				PbxOld.BackgroundImage = Image.FromStream(fStream);

				CheckReady();
				return true;
			}
		}
		private bool LoadImg(string FName) {
			if (!File.Exists(FName)) { return false; }

			PbxNew.BackgroundImage = Image.FromFile(FName);
			m_Status |= ReimgStatus.ImgReady;

			CheckReady();
			return true;
		}
		private void SaveNewEmbed(string FName) {
			if ((m_Status & ReimgStatus.Ready) != ReimgStatus.Ready) { return; }
			if (PbxOld.BackgroundImage == null || PbxNew.BackgroundImage == null || m_TIDat == null) { return; }

			using (MemoryStream mem = new()) {
				Bitmap output = new(PbxOld.BackgroundImage);
				Graphics draw = Graphics.FromImage(output);
				SizeF measureHash = draw.MeasureString("[" + m_TIDat.CheckpointHash + "]", MODEL_FONT);
				SizeF measureVS = draw.MeasureString(TbxVectorStep.Text, MODEL_FONT);
				
				draw.DrawImage(PbxNew.BackgroundImage, new Rectangle(95, 0, 512, 512));

				draw.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0), new Point(0, 256), Color.FromArgb(255, 0, 0, 0), Color.FromArgb(50, 0, 0, 0)),
								   new Rectangle(95, 0, 512, 256));
				draw.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 256), new Point(0, 512), Color.FromArgb(50, 0, 0, 0), Color.FromArgb(255, 0, 0, 0)),
								   new Rectangle(95, 256, 512, 512));

				draw.DrawString("<" + TbxName.Text + ">", NAME_FONT, Brushes.White, 95, 10);
				draw.DrawString(m_TIDat.CheckpointName, MODEL_FONT, Brushes.White, 95, 490);
				draw.DrawString("[" + m_TIDat.CheckpointHash + "]", MODEL_FONT, Brushes.White, output.Width / 2 - (measureHash.Width / 2), 490);
				draw.DrawString(TbxVectorStep.Text, MODEL_FONT, Brushes.White, 607 - measureVS.Width, 490);
				
				output.Save(mem, System.Drawing.Imaging.ImageFormat.Png);
				using (FileStream fStream = File.Open(FName, FileMode.OpenOrCreate)) {
					InsertA1111ChunkAndSave(mem, fStream);
				}
			}
		}

		private void BtnLoadEmb_Click(object sender, EventArgs e) {
			using (OpenFileDialog ofd = new()) {
				ofd.Filter = "A1111 Image Embeddings(*.png)|*.png|All Files(*.*)|*.*";
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
				sfd.Filter = "A1111 Image Embeddings(*.png)|*.png|All Files(*.*)|*.*";
				if (sfd.ShowDialog() == DialogResult.OK) {
					SaveNewEmbed(sfd.FileName);
				}
			}
		}
	}
}