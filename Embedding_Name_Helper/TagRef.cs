using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Embedding_Name_Helper {
	internal class TagRef {
		private static Font TAG_FONT = new Font("MS Sans Seriff", 8.25f, FontStyle.Regular);
		private const int MASTER_CHARS_LINE = 30, FILE_CHARS_LINE = 15;

		public TagRef(string T, Label L) { Tag = T; Lbl = L; }

		public void MakeMasterLabel() {
			Lbl = MakeTagLabel(Utils.WordWrap(Tag, MASTER_CHARS_LINE));
			Lbl.Tag = this;
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
		}

		public void CheckLabelStatus() {
			Utils.SetLabelColor(Selected, Uses, Lbl);

			foreach((Label L, _) in Children) {
				Utils.SetLabelColor(Selected, Uses, L);
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
			};
			lbl.Click += Utils.Label_Clicked;
			return lbl;
		}

		public string Tag { get; set; } = null;
		public Label Lbl { get; set; } = null;
		public bool Selected { get; set; } = false;
		public int Uses { get; set; } = 0;
		public bool Visible { get; set; } = true;

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
