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

		//
		// Summary:
		//     Checks a form to see if it is currently valid (Open).
		//
		// Parameters:
		//   Target:
		//     The form to check for validity.
		//
		// Returns:
		//     Returns true if a form exists, and is currently not scheduled for garbage collection.
		public static bool FormValid(Form Target) {
			return Target != null && !Target.IsDisposed;
		}
		//
		// Summary:
		//     Creates a new form of the specified type and displays it, using the invokeForm
		//     as a target to join the UI thread if necessary.
		//
		// Parameters:
		//   InvokeForm:
		//     A Form known to be created on the UI thread. This can be null, but if so, will
		//     prevent joining of the UI thread.
		//
		//   ToCreate:
		//     The form to be created.
		//
		//   Prm:
		//     An optional list of parameters for the new form's constructor.
		//
		// Type parameters:
		//   T:
		//     The type of object ToCreate.
		public static Form SafeFormShow<T>(Form InvokeForm, T ToCreate, params object[] Prm) where T : Form {
			if (FormValid(InvokeForm) && InvokeForm.InvokeRequired) {
				InvokeForm.BeginInvoke((MethodInvoker)delegate {
					SafeFormShow(InvokeForm, ToCreate, Prm);
				});
			} else {
				if (!FormValid(ToCreate)) {
					ToCreate = (T)Activator.CreateInstance(typeof(T), Prm);
					ToCreate.Show();
				}

				ToCreate.BringToFront();
				ToCreate.Update();
			}

			return ToCreate;
		}

		public static MainForm Parent { get; set; } = null;
	}
}
