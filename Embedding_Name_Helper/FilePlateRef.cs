﻿using System.Drawing;
using System.Windows.Forms;

namespace Embedding_Name_Helper {
	internal class FilePlateRef {
		public TableLayoutPanel m_TLP;
		public Label m_Lbl;
		public PictureBox m_Pbx;
		public FlowLayoutPanel m_Flp;

		public FilePlateRef(TableLayoutPanel Tlp, Label Lbl, PictureBox Pbx, FlowLayoutPanel Flp) {
			m_TLP = Tlp; m_Lbl = Lbl; m_Pbx = Pbx; m_Flp = Flp;
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
			m_Flp = new FlowLayoutPanel() {
				BackColor = ToCopy.m_Flp.BackColor,
				Dock = DockStyle.Fill,
				AutoScroll = true,
				Margin = new Padding(0, 0, 0, 0),
			};

			foreach (RowStyle style in ToCopy.m_TLP.RowStyles) {
				m_TLP.RowStyles.Add(new RowStyle(style.SizeType, style.Height));
			}
			foreach (ColumnStyle style in ToCopy.m_TLP.ColumnStyles) {
				m_TLP.ColumnStyles.Add(new ColumnStyle(style.SizeType, style.Width));
			}

			m_TLP.Controls.Add(m_Lbl);
			m_TLP.Controls.Add(m_Pbx);
			m_TLP.Controls.Add(m_Flp);
			m_TLP.SetRow(m_Lbl, 0);
			m_TLP.SetRow(m_Pbx, 1);
			m_TLP.SetRow(m_Flp, 2);
		}

		public void AddTags(TagRef Tr) {
			m_Flp.Controls.Add(Tr.MakeChildLabel(this));
		}
		public void RemoveTags(Label Lbl) {
			m_Flp.Controls.Remove(Lbl);
		}

		public string Text { get { return m_Lbl.Text; } set { m_Lbl.Text = value; } }
		public Image Image { get { return m_Pbx.BackgroundImage; } set { m_Pbx.BackgroundImage = value; } }
		public TableLayoutPanel Reference { get { return m_TLP; } }
	}
}
