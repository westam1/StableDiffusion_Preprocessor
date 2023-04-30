using System.Text;

namespace Image_Tag_Search {
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
					case '.':
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
		public static string GetStateSet(string Desired, string BaseStr) {
			int pos = BaseStr.IndexOf(Desired), flags = 0;

			if (pos == -1) { return null; }                                                             // If flag not found, return null
			pos += Desired.Length;
			if (Desired.Contains('{')) { flags = 1; }
			for (int i = pos; i < BaseStr.Length; i++) {
				switch (BaseStr[i]) {
					case '{': flags++; break;
					case '}':
						flags--;
						if (flags == 0) { return BaseStr[(pos + 2)..i].Trim(); }
						break;
				}
			}
			return null;																				// If no }, return null
		}
		public static (string, string)[] ParsePlates(string PlateStr) {
			List<(string, string)> plates = new();
			int pos = 0, flags = 0;
			string f = "", d = "";

			for (int i = 0; i < PlateStr.Length; i++) {
				switch (PlateStr[i]) {
					case '{':
						flags++;
						f = PlateStr[pos..i];
						pos = i + 1;
						break;
					case '}':
						flags--;
						d = PlateStr[pos..i];
						pos = i + 1;
						plates.Add((f, d));
						break;
				}
			}

			return plates.ToArray();
		}
		public static string WordWrap(string Input, int MaxCharsLine) {
			StringBuilder output = new(Input);
			int lSpace = 0, lNl = 0;
			for (int i = 0; i < output.Length; i++) {
				if (output[i] == ' ') { lSpace = i; }
				if (i - lNl >= MaxCharsLine && lSpace != lNl && lSpace != 0) {
					output.Insert((lSpace + 1), "\r\n");
					lNl = lSpace;
				}
			}
			return output.ToString();
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
		//
		// Summary:
		//     Checks the Base string parameter for the Target string at the specified position.
		//     This function is range-safe(will not exceed string indexing).
		//
		// Parameters:
		//   Base:
		//     The base string.
		//
		//   Target:
		//     The target string.
		//
		//   Position:
		//     The position 'Target' should be at
		//
		// Returns:
		//     True if the base string contains the target string at the specified position.
		//     Otherwise returns false.
		public static bool SafeStringCompare(string Base, string Target, int Position) {
			if (Target == null || Base == null || Position < 0 || Target.Length + Position > Base.Length) {
				return false;
			}

			if (Base.Substring(Position, Target.Length) == Target) {
				return true;
			}

			return false;
		}
		//
		// Summary:
		//     Ensures that the specified file extension is found at the end of the Input string.
		//
		// Parameters:
		//   Input:
		//     The Input String.
		//
		//   Ext:
		//     A valid File Extension, minus the preceding '.'
		//
		// Returns:
		//     The Input string, guarunteed to end in the specified extension.
		public static string EnsureExtension(string Input, string Ext) {
			Ext = Ext.Replace(".", "");
			int num = Input.LastIndexOf('.');
			if (num == -1) {
				return Input + "." + Ext;
			}

			if (SafeStringCompare(Input, Ext, num + 1)) {
				return Input;
			}

			return Input.Substring(0, num) + "." + Ext;
		}

		public static MainForm Parent { get; set; } = null;
	}
}
