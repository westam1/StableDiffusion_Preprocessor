using System.Drawing;
using System.Windows.Forms;

namespace Embedding_Name_Helper {
	public class FilePlateRef {
		public TableLayoutPanel m_TLP;
		public Label m_Lbl;
		public PictureBox m_Pbx, m_Mirror;
		public FlowLayoutPanel m_Flp;

		public FilePlateRef(TableLayoutPanel Tlp, Label Lbl, PictureBox Pbx, PictureBox Mirror, FlowLayoutPanel Flp) {
			m_TLP = Tlp; m_Lbl = Lbl; m_Pbx = Pbx; m_Mirror = Mirror; m_Flp = Flp;
		}
		public FilePlateRef(FilePlateRef ToCopy) {
			m_TLP = new TableLayoutPanel() {
				Size = new Size(ToCopy.m_TLP.Size.Width, ToCopy.m_TLP.Size.Height),
				BackColor = ToCopy.m_TLP.BackColor,
				RowCount = ToCopy.m_TLP.RowCount,
				ColumnCount = ToCopy.m_TLP.ColumnCount,
			};
			m_Lbl = new Label() {
				BackColor = ToCopy.m_Lbl.BackColor,
				Dock = DockStyle.Fill,
				Text = "FName",
				ForeColor = ToCopy.m_Lbl.ForeColor,
				Margin = new Padding(0, 0, 0, 0),
			};
			m_Pbx = new PictureBox() {
				Size = new Size(ToCopy.m_Pbx.Width, ToCopy.m_Pbx.Height),
				Dock = DockStyle.Fill,
				BackgroundImageLayout = ImageLayout.Stretch,
				Margin = new Padding(0, 0, 0, 0),
			};
			m_Mirror = new PictureBox() {
				Size = new Size(ToCopy.m_Mirror.Width, ToCopy.m_Mirror.Height),
				Dock = DockStyle.Fill,
				BackgroundImageLayout = ImageLayout.Stretch,
				Margin = new Padding(0, 0, 0, 0),
			};
			m_Flp = new FlowLayoutPanel() {
				BackColor = ToCopy.m_Flp.BackColor,
				Dock = DockStyle.Fill,
				AutoScroll = true,
				Margin = new Padding(0, 0, 0, 0),
				AllowDrop = true,
				Tag = this,
			};

			m_TLP.SuspendLayout();
			m_Flp.SuspendLayout();

			m_Flp.DragEnter += Flp_DragEnter;
			m_Flp.DragDrop += Flp_DragDrop;
			m_Lbl.Click += Label_Click;

			foreach (RowStyle style in ToCopy.m_TLP.RowStyles) {
				m_TLP.RowStyles.Add(new RowStyle(style.SizeType, style.Height));
			}
			foreach (ColumnStyle style in ToCopy.m_TLP.ColumnStyles) {
				m_TLP.ColumnStyles.Add(new ColumnStyle(style.SizeType, style.Width));
			}

			m_TLP.Controls.Add(m_Lbl);
			m_TLP.Controls.Add(m_Pbx);
			m_TLP.Controls.Add(m_Mirror);
			m_TLP.Controls.Add(m_Flp);
			m_TLP.SetRow(m_Lbl, 0);
			m_TLP.SetColumn(m_Lbl, 0);
			m_TLP.SetColumnSpan(m_Lbl, 2);
			m_TLP.SetRow(m_Pbx, 1);
			m_TLP.SetRow(m_Mirror, 1);
			m_TLP.SetColumn(m_Pbx, 0);
			m_TLP.SetColumn(m_Mirror, 1);
			m_TLP.SetRow(m_Flp, 2);
			m_TLP.SetColumn(m_Flp, 0);
			m_TLP.SetColumnSpan(m_Flp, 2);
		}

		private void Label_Click(object sender, System.EventArgs e) {
			SelectedForCommit = !SelectedForCommit;
			CheckColor();
		}
		public void CheckColor() {
			m_Lbl.BackColor = ((SelectedForCommit) ? Color.Aqua : Color.Gray);
		}

		public void Finalize_Load() {
			m_TLP.ResumeLayout();
			m_Flp.ResumeLayout();
		}

		private void Flp_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(typeof(TagRef)) || e.Data.GetDataPresent(typeof(TagRef[]))) {
				e.Effect = DragDropEffects.Copy;  
			} else {
				e.Effect = DragDropEffects.None; 
			}
		}
		private void Flp_DragDrop(object sender, DragEventArgs e) {
			if (e.Data.GetData(typeof(TagRef[])) is TagRef[] list) {	// Note: Could factor the add if Uses is cleaned up a bit on load
				foreach (TagRef t in list) {
					if (t.FindChildInPlate(this) == null) {
						AddTags(t);
						t.Uses++;
						t.Selected = false;
						t.CheckLabelStatus();
					}
				}
			} else if (e.Data.GetData(typeof(TagRef)) is TagRef tr) {
				if (tr.FindChildInPlate(this) == null) {
					AddTags(tr);
					tr.Uses++;
					tr.Selected = false;
					tr.CheckLabelStatus();
				}
			}
		}

		public void AddTags(TagRef Tr) {
			Label lbl = Tr.MakeChildLabel(this);
			m_Flp.Controls.Add(lbl);
			m_Flp.Controls.SetChildIndex(lbl, TagRef.ToListPosition(Tr.Index));
		}
		public void RemoveTags(Label Lbl) {
			m_Flp.Controls.Remove(Lbl);
		}
		public void ClearChildTags() {
			foreach (Control ctrl in m_Flp.Controls) { ctrl.Dispose(); }
			m_Flp.Controls.Clear();
		}

		public string Text { get { return m_Lbl.Text; } set { m_Lbl.Text = value; } }
		public bool SelectedForCommit { get; set; } = true;
		public Image Image { get { return m_Pbx.BackgroundImage; } set { m_Pbx.BackgroundImage = value; } }
		public TableLayoutPanel Reference { get { return m_TLP; } }
	}
}
