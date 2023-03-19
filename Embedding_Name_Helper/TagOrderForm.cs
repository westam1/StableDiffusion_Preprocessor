using System.Collections.Generic;
using System.Windows.Forms;

namespace Embedding_Name_Helper {
	public partial class TagOrderForm : Form {
		private readonly List<TagRef> m_Tags;

		public TagOrderForm(List<TagRef> Tags) {
			InitializeComponent();

			m_Tags = Tags;
			m_Tags.Sort();
			DgvTags.DataSource = m_Tags;

			for (int i = 2; i < DgvTags.Columns.Count; i++) {
				DgvTags.Columns[i].Visible = false;
			}

			DgvTags.Columns[0].Width = 325;
			DgvTags.Columns[1].Width = 50;
			DgvTags.Update();
		}

		private void DgvTags_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
			m_Tags.Sort();
			DgvTags.Update();
			DgvTags.Invalidate();
			Utils.Parent.SortAllPlates();			// Note: Lazy
		}
	}
}
