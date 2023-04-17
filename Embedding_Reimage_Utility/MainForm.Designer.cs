namespace Embedding_Reimage_Utility {
	partial class MainForm {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.PbxOld = new System.Windows.Forms.PictureBox();
			this.PbxNew = new System.Windows.Forms.PictureBox();
			this.BtnLoadEmb = new System.Windows.Forms.Button();
			this.BtnLoadImg = new System.Windows.Forms.Button();
			this.BtnCommit = new System.Windows.Forms.Button();
			this.TbxName = new System.Windows.Forms.TextBox();
			this.TbxVectorStep = new System.Windows.Forms.TextBox();
			this.TbxNameHash = new System.Windows.Forms.TextBox();
			this.TlpMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PbxOld)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PbxNew)).BeginInit();
			this.SuspendLayout();
			// 
			// TlpMain
			// 
			this.TlpMain.BackColor = System.Drawing.SystemColors.ControlDark;
			this.TlpMain.ColumnCount = 4;
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 704F));
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 512F));
			this.TlpMain.Controls.Add(this.PbxOld, 1, 0);
			this.TlpMain.Controls.Add(this.PbxNew, 3, 0);
			this.TlpMain.Controls.Add(this.BtnLoadEmb, 0, 0);
			this.TlpMain.Controls.Add(this.BtnLoadImg, 0, 1);
			this.TlpMain.Controls.Add(this.BtnCommit, 0, 2);
			this.TlpMain.Controls.Add(this.TbxName, 0, 3);
			this.TlpMain.Controls.Add(this.TbxVectorStep, 0, 4);
			this.TlpMain.Controls.Add(this.TbxNameHash, 0, 5);
			this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TlpMain.Location = new System.Drawing.Point(0, 0);
			this.TlpMain.Margin = new System.Windows.Forms.Padding(0);
			this.TlpMain.Name = "TlpMain";
			this.TlpMain.RowCount = 8;
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 338F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TlpMain.Size = new System.Drawing.Size(1425, 610);
			this.TlpMain.TabIndex = 0;
			// 
			// PbxOld
			// 
			this.PbxOld.BackColor = System.Drawing.Color.Black;
			this.PbxOld.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.PbxOld.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PbxOld.Location = new System.Drawing.Point(200, 0);
			this.PbxOld.Margin = new System.Windows.Forms.Padding(0);
			this.PbxOld.Name = "PbxOld";
			this.TlpMain.SetRowSpan(this.PbxOld, 7);
			this.PbxOld.Size = new System.Drawing.Size(704, 542);
			this.PbxOld.TabIndex = 0;
			this.PbxOld.TabStop = false;
			// 
			// PbxNew
			// 
			this.PbxNew.BackColor = System.Drawing.Color.Black;
			this.PbxNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.PbxNew.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PbxNew.Location = new System.Drawing.Point(913, 0);
			this.PbxNew.Margin = new System.Windows.Forms.Padding(0);
			this.PbxNew.Name = "PbxNew";
			this.TlpMain.SetRowSpan(this.PbxNew, 7);
			this.PbxNew.Size = new System.Drawing.Size(512, 542);
			this.PbxNew.TabIndex = 0;
			this.PbxNew.TabStop = false;
			// 
			// BtnLoadEmb
			// 
			this.BtnLoadEmb.BackColor = System.Drawing.Color.Salmon;
			this.BtnLoadEmb.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnLoadEmb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnLoadEmb.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.BtnLoadEmb.Location = new System.Drawing.Point(1, 1);
			this.BtnLoadEmb.Margin = new System.Windows.Forms.Padding(1);
			this.BtnLoadEmb.Name = "BtnLoadEmb";
			this.BtnLoadEmb.Size = new System.Drawing.Size(198, 38);
			this.BtnLoadEmb.TabIndex = 1;
			this.BtnLoadEmb.Text = "Load Old Embedding";
			this.BtnLoadEmb.UseVisualStyleBackColor = false;
			this.BtnLoadEmb.Click += new System.EventHandler(this.BtnLoadEmb_Click);
			// 
			// BtnLoadImg
			// 
			this.BtnLoadImg.BackColor = System.Drawing.Color.Salmon;
			this.BtnLoadImg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnLoadImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnLoadImg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.BtnLoadImg.Location = new System.Drawing.Point(1, 41);
			this.BtnLoadImg.Margin = new System.Windows.Forms.Padding(1);
			this.BtnLoadImg.Name = "BtnLoadImg";
			this.BtnLoadImg.Size = new System.Drawing.Size(198, 38);
			this.BtnLoadImg.TabIndex = 2;
			this.BtnLoadImg.Text = "Load New Image";
			this.BtnLoadImg.UseVisualStyleBackColor = false;
			this.BtnLoadImg.Click += new System.EventHandler(this.BtnLoadImg_Click);
			// 
			// BtnCommit
			// 
			this.BtnCommit.BackColor = System.Drawing.Color.LightGreen;
			this.BtnCommit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnCommit.Enabled = false;
			this.BtnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCommit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.BtnCommit.Location = new System.Drawing.Point(1, 81);
			this.BtnCommit.Margin = new System.Windows.Forms.Padding(1);
			this.BtnCommit.Name = "BtnCommit";
			this.BtnCommit.Size = new System.Drawing.Size(198, 38);
			this.BtnCommit.TabIndex = 3;
			this.BtnCommit.Text = "Save New Embedding";
			this.BtnCommit.UseVisualStyleBackColor = false;
			this.BtnCommit.Click += new System.EventHandler(this.BtnCommit_Click);
			// 
			// TbxName
			// 
			this.TbxName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TbxName.Location = new System.Drawing.Point(3, 123);
			this.TbxName.Name = "TbxName";
			this.TbxName.Size = new System.Drawing.Size(194, 23);
			this.TbxName.TabIndex = 4;
			// 
			// TbxVectorStep
			// 
			this.TbxVectorStep.BackColor = System.Drawing.SystemColors.ControlDark;
			this.TbxVectorStep.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TbxVectorStep.Location = new System.Drawing.Point(3, 151);
			this.TbxVectorStep.Name = "TbxVectorStep";
			this.TbxVectorStep.ReadOnly = true;
			this.TbxVectorStep.Size = new System.Drawing.Size(194, 23);
			this.TbxVectorStep.TabIndex = 4;
			// 
			// TbxNameHash
			// 
			this.TbxNameHash.BackColor = System.Drawing.SystemColors.ControlDark;
			this.TbxNameHash.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TbxNameHash.Location = new System.Drawing.Point(3, 179);
			this.TbxNameHash.Name = "TbxNameHash";
			this.TbxNameHash.ReadOnly = true;
			this.TbxNameHash.Size = new System.Drawing.Size(194, 23);
			this.TbxNameHash.TabIndex = 4;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1425, 610);
			this.Controls.Add(this.TlpMain);
			this.Name = "MainForm";
			this.Text = "Textual Inversion Embedding Re-Image Utility - v0.1.0.0";
			this.TlpMain.ResumeLayout(false);
			this.TlpMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PbxOld)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PbxNew)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private TableLayoutPanel TlpMain;
		private PictureBox PbxOld;
		private PictureBox PbxNew;
		private Button BtnLoadEmb;
		private Button BtnLoadImg;
		private Button BtnCommit;
		private TextBox TbxName;
		private TextBox TbxVectorStep;
		private TextBox TbxNameHash;
	}
}