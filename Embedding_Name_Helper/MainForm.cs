using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Embedding_Name_Helper {
	public partial class MainForm : Form {
		private readonly List<FilePlateRef> m_Plates;
		private readonly List<TagRef> m_MasterTags;
		private readonly FilePlateRef m_Master;

		public MainForm() {
			InitializeComponent();
			m_Plates = new List<FilePlateRef>();
			m_MasterTags = new List<TagRef>();
			m_Master = new FilePlateRef(TlpTemplate, LblFNameTemplate, PbxTemplate, FlpTemplate);
			CacheTextMeasure = FlpTags.CreateGraphics();

			CmsiHide.Tag = CmsTag;
			CmsiShow.Tag = CmsTag;
			Utils.Parent = this;
		}

		private TagRef AddMasterTag(string Input) {
			TagRef toAdd = new(Input, null);
			if (!m_MasterTags.Contains(toAdd)) {
				toAdd.Uses = 1;
				toAdd.MakeMasterLabel();
				m_MasterTags.Add(toAdd);

				FlpTags.Controls.Add(toAdd.Lbl);
				return toAdd;
			} else {
				Predicate<TagRef> finder = toAdd.Equals;
				TagRef t = m_MasterTags.Find(finder);
				t.Uses++;
				return t;
			}
		}
		private void AddToAllPlates(TagRef Tag) {
			Tag.Uses = OpenFileCount;

			foreach(FilePlateRef plate in m_Plates) {				// Note: O(N^2)
				if (Tag.FindChildInPlate(plate) == null) {			// ""
					plate.AddTags(Tag);
				}
			}
		}
		private void RemoveFromAllPlates(TagRef Tag) {
			Tag.Uses = 0;

			foreach (FilePlateRef plate in m_Plates) {				// Note: O(N^2)
				if (Tag.FindChildInPlate(plate) is Label l) {		// ""
					plate.RemoveTags(l);
					Tag.Children.Remove((l, plate));				// "" + O(N)
				}
			}
		}
		
		private void CheckTagColors() {
			foreach (TagRef tr in m_MasterTags) {
				Utils.SetLabelColor(tr.Selected, tr.Uses, tr.Lbl);
			}
		}

		private void ParseA1111Chunk(FilePlateRef Plate, byte[] Data) {
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

							foreach (string token in prms) {
								Plate.AddTags(AddMasterTag(token));
							}
							parsing = false;
						}
						if (len == 0) { parsing = false; }
					}
				}
				catch { parsing = false; /* Could be bug, could be not A1111 chunk. */ }
			}
		}
		private void LoadFolder(string Folder) {
			if (Folder == null || !Directory.Exists(Folder)) { return; }
			FlpFiles.Controls.Clear();
			m_MasterTags.Clear();
			FlpTags.Controls.Clear();
			OpenFileCount = 0;

			foreach (string fName in Directory.GetFiles(Folder, "*.png")) {
				FilePlateRef plate = new(m_Master) {
					Text = fName[(fName.LastIndexOf('\\') + 1)..],
				};
				using (FileStream fStream = File.Open(fName, FileMode.Open, FileAccess.Read)) {
					byte[] data = new byte[fStream.Length];
					fStream.Read(data, 0, data.Length);
					ParseA1111Chunk(plate, data);
					fStream.Position = 0;
					plate.Image = Image.FromStream(fStream);
				}
				OpenFileCount++;
				m_Plates.Add(plate);
				FlpFiles.Controls.Add(plate.Reference);
				Application.DoEvents();
			}

			CheckTagColors();
		}

		private void BtnShowAll_Click(object sender, EventArgs e) {
			foreach (TagRef tag in m_MasterTags) {
				tag.SetVisibility(true);
			}
		}
		private void BtnRemoveAll_Click(object sender, EventArgs e) {
			foreach (TagRef tag in m_MasterTags) {
				tag.SetVisibility(false);
			}
		}
		private void BtnSelectFolder_Click(object sender, EventArgs e) {
			using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
				BtnSelectFolder.Text = "(click to select folder)";
				if (fbd.ShowDialog() == DialogResult.OK) {
					BtnSelectFolder.Tag = fbd.SelectedPath;
					BtnSelectFolder.Text += "\r\n" + 
						((fbd.SelectedPath.Length < 50) ? 
						fbd.SelectedPath :
						string.Concat(fbd.SelectedPath.AsSpan()[..10], "...", fbd.SelectedPath.AsSpan(fbd.SelectedPath.Length - 37, 37)));
					LoadFolder(fbd.SelectedPath);
				}
			}
		}

		private void CmsTag_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			if (sender is ContextMenuStrip cms && cms.SourceControl is Label l && l.Tag is TagRef tr) {
				CmsiShow.Checked = tr.Visible;
				CmsiHide.Checked = !tr.Visible;
			}
		}
		private void CmsiAssign_Click(object sender, EventArgs e) {
			if (sender is ToolStripMenuItem item && item.Owner is ContextMenuStrip cms && cms.SourceControl is Label l && l.Tag is TagRef tr) {
				AddToAllPlates(tr);
			}
		}
		private void CmsiRemove_Click(object sender, EventArgs e) {
			if (sender is ToolStripMenuItem item && item.Owner is ContextMenuStrip cms && cms.SourceControl is Label l && l.Tag is TagRef tr) {
				RemoveFromAllPlates(tr);
			}
		}
		private void CmsiShow_Click(object sender, EventArgs e) {
			if (sender is ToolStripMenuItem item && item.Tag is ContextMenuStrip cms && cms.SourceControl is Label l && l.Tag is TagRef tr) {
				tr.SetVisibility(true);
			}
		}
		private void CmsiHide_Click(object sender, EventArgs e) {
			if (sender is ToolStripMenuItem item && item.Tag is ContextMenuStrip cms && cms.SourceControl is Label l && l.Tag is TagRef tr) {
				tr.SetVisibility(false);
			}
		}

		public static int OpenFileCount { get; set; } = 0;
		public static Graphics CacheTextMeasure { get; private set; } = null;
	}
}
