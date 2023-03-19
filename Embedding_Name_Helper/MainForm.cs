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
		private TagOrderForm m_TagOrderForm;
		private int m_TagIndex;

		public MainForm() {
			InitializeComponent();
			m_Plates = new List<FilePlateRef>();
			m_MasterTags = new List<TagRef>();
			m_Master = new FilePlateRef(TlpTemplate, LblFNameTemplate, PbxTemplate, FlpTemplate);
			CacheTextMeasure = FlpTags.CreateGraphics();
			this.DoubleBuffered = true;

			CmsiHide.Tag = CmsTag;
			CmsiShow.Tag = CmsTag;
			Utils.Parent = this;
		}

		private TagRef AddMasterTag(string Input) {
			TagRef toAdd = new(Input, null);
			if (!m_MasterTags.Contains(toAdd)) {
				toAdd.Uses = 1;
				toAdd.MakeMasterLabel();
				toAdd.Index = m_TagIndex++;
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
		internal TagRef[] GetSelectedTags() {
			List<TagRef> tags = new();

			foreach(TagRef tr in m_MasterTags) {
				if (tr.Selected) {
					tags.Add(tr);
				}
			}

			if (tags.Count > 0) {
				return tags.ToArray();
			}
			return null;
		}
		internal void SortAllPlates() {
			FlpFiles.SuspendLayout();	// TODO: This is really slow to be called on every change.
			foreach (TagRef tr in m_MasterTags) {
				tr.SortTags();
			}
			FlpFiles.ResumeLayout();
		}
		private void AddToAllPlates(TagRef Tag) {
			Tag.Uses = OpenFileCount;

			foreach(FilePlateRef plate in m_Plates) {				// Note: O(N^2)
				if (Tag.FindChildInPlate(plate) == null) {			// ""
					plate.AddTags(Tag);
				}
			}
			Tag.Selected = false;
			Tag.CheckLabelStatus();
		}
		private void RemoveFromAllPlates(TagRef Tag) {
			Tag.Uses = 0;

			foreach (FilePlateRef plate in m_Plates) {				// Note: O(N^2)
				if (Tag.FindChildInPlate(plate) is Label l) {		// ""
					plate.RemoveTags(l);
					Tag.Children.Remove((l, plate));				// "" + O(N)
				}
			}
			Tag.Selected = false;
			Tag.CheckLabelStatus();
		}
		
		private void CheckTagColors() {
			foreach (TagRef tr in m_MasterTags) {
				tr.CheckLabelStatus();
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
				catch { parsing = false; /* Note: Exception here could be bug, or could be not A1111 tEXt chunk. */ }
			}
		}
		private void LoadFolder(string Folder) {
			if (Folder == null || !Directory.Exists(Folder)) { return; }

			FlpFiles.Controls.Clear();
			m_MasterTags.Clear();
			FlpTags.Controls.Clear();
			OpenFileCount = m_TagIndex = 0;

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
				Application.DoEvents();						// Note: Looks better to see things popping in than to see things frozen by layout suspend. Probably add progress bar.
			}

			CheckTagColors();
		}

		private void CommitStateToFiles() {
			if (!(BtnSelectFolder.Tag is string folder)) { return; }

			foreach (FilePlateRef plate in m_Plates) {
				string fName = Utils.EnsureExtension(folder + "//" + plate.Text, "txt");
				bool first = true;
				using (BinaryWriter writer = new(File.Open(fName, FileMode.OpenOrCreate, FileAccess.Write))) {
					foreach (Label l in plate.m_Flp.Controls) {
						if (l.Tag is TagRef tr) {
							writer.Write(((first ? "" : ",") + tr.Tag).ToCharArray());
							first = false;
						}
					}
				}
			}
		}

		private void BtnShowAll_Click(object sender, EventArgs e) {
			foreach (FilePlateRef plate in m_Plates) {
				plate.m_Flp.SuspendLayout();
			}
			foreach (TagRef tag in m_MasterTags) {
				tag.SetVisibility(true);
			}
			foreach (FilePlateRef plate in m_Plates) {
				plate.m_Flp.ResumeLayout();
			}
		}
		private void BtnRemoveAll_Click(object sender, EventArgs e) {
			foreach (FilePlateRef plate in m_Plates) {
				plate.m_Flp.SuspendLayout();
			}
			foreach (TagRef tag in m_MasterTags) {
				tag.SetVisibility(false);
			}
			foreach (FilePlateRef plate in m_Plates) {
				plate.m_Flp.ResumeLayout();
			}
		}
		private void BtnEditTags_Click(object sender, EventArgs e) {
			m_TagOrderForm = (TagOrderForm)Utils.SafeFormShow(this, m_TagOrderForm, new object[] { m_MasterTags });
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
		private void BtnCommit_Click(object sender, EventArgs e) {
			CommitStateToFiles();
		}
		private void BtnAddTag_Click(object sender, EventArgs e) {
			TagRef tr = AddMasterTag(TbxTag.Text);
			TbxTag.Text = "";
			tr.Uses = 0;
			tr.CheckLabelStatus();
		}

		private void CmsTag_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			if (sender is ContextMenuStrip cms && cms.SourceControl is Label l && l.Tag is TagRef tr) {
				CmsiShow.Checked = tr.Visible;
				CmsiHide.Checked = !tr.Visible;

				CmsiSeparator2.Visible = CmsiRemoveImg.Visible = (l != tr.Lbl);
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
		private void CmsiRemoveImg_Click(object sender, EventArgs e) {
			if (sender is ToolStripMenuItem item && item.Owner is ContextMenuStrip cms && 
				cms.SourceControl is Label l && l.Tag is TagRef tr && 
				l.Parent is FlowLayoutPanel flp && flp.Tag is FilePlateRef plate) {
				plate.RemoveTags(l);
				tr.Children.Remove((l, plate));                             // "" + O(N)
				tr.Uses--;
				tr.CheckLabelStatus();
			}
		}

		public int TagCount { get { return m_MasterTags.Count; } }

		public static int OpenFileCount { get; set; } = 0;
		public static Graphics CacheTextMeasure { get; private set; } = null;
	}
}
