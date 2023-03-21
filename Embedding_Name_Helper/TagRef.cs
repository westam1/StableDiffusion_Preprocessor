using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Embedding_Name_Helper {
	public class TagRef : IComparable {
		private static readonly Font TAG_FONT = new("MS Sans Seriff", 8.25f, FontStyle.Regular);
		private const int MASTER_CHARS_LINE = 30, FILE_CHARS_LINE = 15;

		public TagRef(string T, Label L) { Tag = T; Lbl = L; }

		public void MakeMasterLabel() {
			Lbl = MakeTagLabel(Utils.WordWrap(Tag, MASTER_CHARS_LINE));
			string test = Lbl.Text;
			Lbl.Tag = this;
			Lbl.MouseDown += Lbl_MouseDown;
			Lbl.MouseUp += Lbl_MouseUp;
			Lbl.MouseMove += Lbl_MouseMove;
			Lbl.Click -= Utils.Label_Clicked;
		}
		public Label MakeChildLabel(FilePlateRef Plate) {
			Label l = MakeTagLabel(Utils.WordWrap(Tag, FILE_CHARS_LINE));
			l.Tag = this;
			Children.Add((l, Plate));
			return l;
		}
		public Label FindChildInPlate(FilePlateRef Plate) {
			foreach((Label L, FilePlateRef P) in Children) {
				if (P == Plate) { return L; }
			}
			return null;
		}

		public void SetVisibility(bool State) {
			Visible = State;
			foreach ((Label L, _) in Children) {
				L.Visible = State;
			}
			Lbl.BorderStyle = ((Visible) ? BorderStyle.Fixed3D : BorderStyle.None);
		}

		public void CheckLabelStatus() {
			Utils.SetLabelColor(Selected, Uses, Lbl);

			foreach((Label L, _) in Children) {
				Utils.SetLabelColor(Selected, Uses, L);
			}
		}
		public void SortTags() {
			foreach ((Label L, FilePlateRef P) in Children) {
				if (P.m_Flp.Controls.GetChildIndex(L) != ToListPosition(Index)) {
					P.m_Flp.Controls.SetChildIndex(L, ToListPosition(Index));
				}
			}
		}
		public void VerifyNames() {
			string ww = Utils.WordWrap(Tag, MASTER_CHARS_LINE);
			if (Lbl.Text != ww) { Lbl.Text = ww; }

			ww = Utils.WordWrap(Tag, FILE_CHARS_LINE);
			foreach ((Label L, _) in Children) {
				if (L.Text != ww) { L.Text = ww; }
			}
		}
		
		public override bool Equals(object obj) {
			if (obj is TagRef tr) {
				return tr.Tag == this.Tag;
			} else {
				return false;
			}
		}
		public bool Equals(string obj) {
			return obj == this.Tag;
		}
		public override int GetHashCode() {
			return Tag.GetHashCode();
		}

		public static Label MakeTagLabel(string Input) {
			Label lbl = new() {
				Text = Input,
				Font = TAG_FONT,
				BackColor = Color.LightSkyBlue,
				AutoSize = true,
				Size = MainForm.CacheTextMeasure.MeasureString(Input, TAG_FONT).ToSize(),
				ContextMenuStrip = Utils.Parent.CmsTag,
				BorderStyle = BorderStyle.Fixed3D,
				FlatStyle = FlatStyle.Flat,
			};
			lbl.Click += Utils.Label_Clicked;
			return lbl;
		}
		public static int ToListPosition(int TagIndex) {
			return TagIndex < 0 ? (Utils.Parent.TagCount * 2) + TagIndex : TagIndex;
		}

		private void Lbl_MouseDown(object sender, MouseEventArgs e) {
			MousePos = e.Location;
		}
		private void Lbl_MouseUp(object sender, MouseEventArgs e) {
			if (MousePos != Point.Empty && e.Button == MouseButtons.Left) {
				Selected = !Selected;

				CheckLabelStatus();
			}
			MousePos = Point.Empty;
		}
		private void Lbl_MouseMove(object sender, MouseEventArgs e) {
			if (MousePos != Point.Empty && (Math.Abs(e.X - MousePos.X) > 100 || Math.Abs(e.Y - MousePos.Y) > 100)) {
				if (Utils.Parent.GetSelectedTags() is TagRef[] list) {
					Lbl.DoDragDrop(list, DragDropEffects.Copy);
				} else {
					Lbl.DoDragDrop(this, DragDropEffects.Copy);
				}				
				MousePos = Point.Empty;
			}
		}

		public int CompareTo(object obj) {
			if (obj is TagRef t) {
				return ToListPosition(Index) - ToListPosition(t.Index);
			}
			return -1;
		}

		public string Tag { get; set; } = null;
		public int Index { get; set; } = 0;
		public Label Lbl { get; set; } = null;
		public bool Selected { get; set; } = false;
		public int Uses { get; set; } = 0;
		public bool Visible { get; set; } = true;
		private Point MousePos { get; set; } = Point.Empty;
		internal List<(Label L, FilePlateRef P)> Children { get; set; } = new();

		public static bool operator == (TagRef lhs, TagRef rhs) {
			return lhs.Tag == rhs.Tag;
		}
		public static bool operator != (TagRef lhs, TagRef rhs) {
			return lhs.Tag != rhs.Tag;
		}
		public static bool operator == (TagRef lhs, string rhs) {
			return lhs.Tag == rhs;
		}
		public static bool operator != (TagRef lhs, string rhs) {
			return lhs.Tag != rhs;
		}
	}
}
