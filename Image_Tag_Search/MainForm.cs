using System.Text;

using File = System.IO.File;
namespace Image_Tag_Search {
	public partial class MainForm : Form {
		private readonly List<FilePlateRef> m_Plates;
		private readonly FilePlateRef m_Master;
		private Dictionary<string, List<string>> m_Index;

		//TODO: Image resize doesn't resize the column style or TLP 
		//TODO: Needs too much memory(tied to autocomplete source collection). Also, Profile the load process, see if the time can be trimmed down (tied to addrange on autocomplete strings)

		public MainForm() {
			InitializeComponent();
			m_Plates = new List<FilePlateRef>();
			m_Master = new FilePlateRef(TlpTemplate, LblFNameTemplate, PbxTemplate);
			m_Index = new Dictionary<string, List<string>>();
			DoubleBuffered = true;

			CmsiHide.Tag = CmsTag;
			CmsiShow.Tag = CmsTag;
			Utils.Parent = this;
		}

		private void StartBigUpdate() {
			FlpFiles.SuspendLayout();
			SuspendLayout();
		}
		private void StopBigUpdate() {
			FlpFiles.ResumeLayout();
			ResumeLayout();
		}

		private void IndexString(string Input, string FileName) {
			if (!m_Index.ContainsKey(Input)) {
				m_Index.Add(Input, new List<string>());
			}

			if (m_Index[Input] is List<string> fRef) {
				fRef.Add(FileName);
			}

		}
		private void CheckPlateSize() {
			int baseSize = 128;

			if (Opt512.Checked) { baseSize = 512; }
			if (Opt256.Checked) { baseSize = 256; }

			StartBigUpdate();
			foreach (FilePlateRef plate in m_Plates) {
				plate.m_TLP.ColumnStyles[0].Width = plate.m_TLP.RowStyles[1].Height = plate.m_TLP.Width = baseSize;
				plate.m_TLP.Height = (int)(plate.m_TLP.RowStyles[0].Height + plate.m_TLP.RowStyles[1].Height + plate.m_TLP.RowStyles[2].Height);
			}
			StopBigUpdate();
		}

		private void ParseA1111Chunk(byte[] Data, string FName, AutoCompleteStringCollection ACS) {
			// Note PNG: 4byte len, 4byte type, 4byte crc, len data. chunks repeat. tEXt chunk is the one a1111 uses
			bool parsing = true;
			using (BinaryReader reader = new BinaryReader(new MemoryStream(Data))) {
				byte[] tag = reader.ReadBytes(8);														// Read and
				if (tag[0] != 0x89 || tag[1] != 0x50 || tag[2] != 0x4e || tag[3] != 0x47) { return; }	// check PNG tag

				try {
					while (parsing) {
						byte[] buf = new byte[65535];
						int len = (int)Utils.ReadUInt32BigEndian(reader), type = (int)Utils.ReadUInt32BigEndian(reader), crc = (int)Utils.ReadUInt32BigEndian(reader);
						reader.Read(buf, 0, len);
						if (type == 0x74455874) {
							string[] prms = Utils.Tokenize(Encoding.ASCII.GetString(buf, 0, len).Split('\n')[0][7..]);

							ACS.AddRange(prms);
							foreach (string token in prms) {
								IndexString(token, FName);
							}
							parsing = false;
						}
						if (len == 0) { parsing = false; }
					}
				}
				catch { parsing = false; /* Note: Exception here could be bug, or could be not A1111 tEXt chunk. */ }
			}
		}
		private void IndexFolder(string Folder) {
			if (Folder == null || !Directory.Exists(Folder)) { return; }
			string[] files = Directory.GetFiles(Folder, "*.png");
			TbxTag.AutoCompleteCustomSource.Clear();
			PbrLoading.Maximum = files.Length;
			PbrLoading.Visible = true;
			PbrLoading.Value = 0;
			AutoCompleteStringCollection acSource = new AutoCompleteStringCollection();
			StartBigUpdate();

			foreach (string fName in files) {
				using (FileStream fStream = File.Open(fName, FileMode.Open, FileAccess.Read)) {
					byte[] data = new byte[fStream.Length];
					fStream.Read(data, 0, data.Length);
					ParseA1111Chunk(data, fName, acSource);
				}
				PbrLoading.Value++;
				Application.DoEvents();						// Note: Looks better to see things popping in than to see things frozen by layout suspend. Probably add progress bar.
			}

			PbrLoading.Visible = false;
			TbxTag.AutoCompleteCustomSource = acSource;
			CheckPlateSize();
			StopBigUpdate();
		}
		private void LoadFolder(List<string> Files) {
			FlpFiles.Controls.Clear();
			GC.Collect();
			PbrLoading.Maximum = Files.Count;
			PbrLoading.Visible = true;
			PbrLoading.Value = 0;

			foreach (string fName in Files) {
				if (fName == null || !File.Exists(fName)) { continue; }
				FilePlateRef plate = new(m_Master) {
					Text = fName[(fName.LastIndexOf('\\') + 1)..],
				};
				using (FileStream fStream = File.Open(fName, FileMode.Open, FileAccess.Read)) {
					byte[] data = new byte[fStream.Length];
					fStream.Read(data, 0, data.Length);
					plate.Image = Image.FromStream(fStream);
				}
				m_Plates.Add(plate);
				FlpFiles.Controls.Add(plate.Reference);
				plate.Finalize_Load();
				PbrLoading.Value++;
				Application.DoEvents();						// Note: Looks better to see things popping in than to see things frozen by layout suspend. Probably add progress bar.
			}

			PbrLoading.Visible = false;
			CheckPlateSize();
			StopBigUpdate();
		}
		
		private void BtnSelectFolder_Click(object sender, EventArgs e) {
			using (FolderBrowserDialog fbd = new()) {
				BtnSelectFolder.Text = "(click to select folder)";
				if (fbd.ShowDialog() == DialogResult.OK) {
					BtnSelectFolder.Tag = fbd.SelectedPath;
					BtnSelectFolder.Text += "\r\n" + 
						((fbd.SelectedPath.Length < 50) ? 
						fbd.SelectedPath :
						string.Concat(fbd.SelectedPath.AsSpan()[..10], "...", fbd.SelectedPath.AsSpan(fbd.SelectedPath.Length - 37, 37)));
					IndexFolder(fbd.SelectedPath);
				}
			}
		}
		private void OptViewSize_Click(object sender, EventArgs e) {
			CheckPlateSize();
		}
		private void TbxTag_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				e.SuppressKeyPress = true;
				BtnSearch.PerformClick();
			}
		}
		private void BtnSearch_Click(object sender, EventArgs e) {
			if (BtnSelectFolder.Tag is string folder && m_Index.ContainsKey(TbxTag.Text)) {
				if (m_Index[TbxTag.Text] is List<string> files) {
					LoadFolder(files);
				}
			}
		}
	}
}