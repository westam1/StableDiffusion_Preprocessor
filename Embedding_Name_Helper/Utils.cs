using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Embedding_Name_Helper {
	internal static class Utils {
		public static UInt32 ReadUInt32BigEndian(BinaryReader Reader) {
			byte[] data = new byte[4];
			Reader.Read(data, 0, 4);
			return (UInt32)(data[0] << 24 | data[1] << 16 | data[2] << 8 | data[3]);
		}
		public static string[] Tokenize(string Input) {
			List<string> tokens = new List<string>();
			int pos = 0, flags = 0;
			for (int i = 0; i < Input.Length; i++) {
				switch(Input[i]) {
					case '[': flags |= 0x01; break;
					case ']': flags &= ~0x01; break;
					case '{': flags |= 0x02; break;
					case '}': flags &= ~0x02f; break;
					case '(': flags |= 0x04f; break;
					case ')': flags &= ~0x04f; break;
					case ',': 
						if (flags == 0) {
							tokens.Add(Input[pos..i].Trim());
							pos = i + 1;
						}
						break;
				}
			}
			if (pos != Input.Length) {
				tokens.Add(Input[pos..].Trim());
			}
			return tokens.ToArray();
		}
		public static string WordWrap(string Input, int MaxCharsLine) {
			StringBuilder output = new(Input);
			int lSpace = 0, lNl = 0;
			for (int i = 0; i < output.Length; i++) {
				if (output[i] == ' ') { lSpace = i + 1; }
				if (i - lNl >= MaxCharsLine && lSpace != lNl + 2) {
					output.Insert(lSpace, "\r\n");
					lNl = lSpace + 2;
				}
			}
			return output.ToString();
		}

		public static void Label_Clicked(object sender, EventArgs e) {
			if (sender is Label lbl && lbl.Tag is TagRef tr) {
				tr.Selected = !tr.Selected;

				tr.CheckLabelStatus();
			}
		}

		public static void SetLabelColor(bool Selected, int Uses, Label Lbl) {
			if (Selected) {
				Lbl.BackColor = Color.Yellow;
			} else if (Uses == MainForm.OpenFileCount) {
				Lbl.BackColor = Color.LightGreen;
			} else if (Uses == 0) {
				Lbl.BackColor = Color.LightPink;
			} else {
				Lbl.BackColor = Color.LightSkyBlue;
			}
		}

		public static MainForm Parent { get; set; } = null;
	}
}
