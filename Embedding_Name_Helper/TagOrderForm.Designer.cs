namespace Embedding_Name_Helper {
	partial class TagOrderForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.DgvTags = new System.Windows.Forms.DataGridView();
			this.TlpMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgvTags)).BeginInit();
			this.SuspendLayout();
			// 
			// TlpMain
			// 
			this.TlpMain.ColumnCount = 1;
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TlpMain.Controls.Add(this.DgvTags, 0, 0);
			this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TlpMain.Location = new System.Drawing.Point(0, 0);
			this.TlpMain.Name = "TlpMain";
			this.TlpMain.RowCount = 1;
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TlpMain.Size = new System.Drawing.Size(459, 450);
			this.TlpMain.TabIndex = 0;
			// 
			// DgvTags
			// 
			this.DgvTags.AllowUserToDeleteRows = false;
			this.DgvTags.AllowUserToResizeRows = false;
			this.DgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DgvTags.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DgvTags.Location = new System.Drawing.Point(3, 3);
			this.DgvTags.Name = "DgvTags";
			this.DgvTags.RowHeadersVisible = false;
			this.DgvTags.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.DgvTags.RowTemplate.Height = 25;
			this.DgvTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.DgvTags.Size = new System.Drawing.Size(453, 444);
			this.DgvTags.TabIndex = 0;
			this.DgvTags.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTags_CellValueChanged);
			// 
			// TagOrderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 450);
			this.Controls.Add(this.TlpMain);
			this.Name = "TagOrderForm";
			this.Text = "Tag Editor";
			this.TlpMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DgvTags)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel TlpMain;
		private System.Windows.Forms.DataGridView DgvTags;
	}
}