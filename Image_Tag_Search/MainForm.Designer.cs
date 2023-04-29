namespace Image_Tag_Search {
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
			this.components = new System.ComponentModel.Container();
			this.TlpMain = new System.Windows.Forms.TableLayoutPanel();
			this.BtnSearch = new System.Windows.Forms.Button();
			this.TbxTag = new System.Windows.Forms.TextBox();
			this.FlpFiles = new System.Windows.Forms.FlowLayoutPanel();
			this.TlpTemplate = new System.Windows.Forms.TableLayoutPanel();
			this.LblFNameTemplate = new System.Windows.Forms.Label();
			this.PbxTemplate = new System.Windows.Forms.PictureBox();
			this.BtnSelectFolder = new System.Windows.Forms.Button();
			this.Opt128 = new System.Windows.Forms.RadioButton();
			this.Opt256 = new System.Windows.Forms.RadioButton();
			this.Opt512 = new System.Windows.Forms.RadioButton();
			this.PbrLoading = new System.Windows.Forms.ProgressBar();
			this.CmsTag = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.CmsiAssign = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsiRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsiVisible = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsiShow = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsiHide = new System.Windows.Forms.ToolStripMenuItem();
			this.CmsiSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.CmsiRemoveImg = new System.Windows.Forms.ToolStripMenuItem();
			this.TlpMain.SuspendLayout();
			this.FlpFiles.SuspendLayout();
			this.TlpTemplate.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PbxTemplate)).BeginInit();
			this.CmsTag.SuspendLayout();
			this.SuspendLayout();
			// 
			// TlpMain
			// 
			this.TlpMain.ColumnCount = 4;
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TlpMain.Controls.Add(this.BtnSearch, 2, 2);
			this.TlpMain.Controls.Add(this.TbxTag, 0, 2);
			this.TlpMain.Controls.Add(this.FlpFiles, 3, 0);
			this.TlpMain.Controls.Add(this.BtnSelectFolder, 0, 0);
			this.TlpMain.Controls.Add(this.Opt128, 0, 1);
			this.TlpMain.Controls.Add(this.Opt256, 1, 1);
			this.TlpMain.Controls.Add(this.Opt512, 2, 1);
			this.TlpMain.Controls.Add(this.PbrLoading, 0, 3);
			this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TlpMain.Location = new System.Drawing.Point(0, 0);
			this.TlpMain.Name = "TlpMain";
			this.TlpMain.RowCount = 12;
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TlpMain.Size = new System.Drawing.Size(1440, 787);
			this.TlpMain.TabIndex = 0;
			// 
			// BtnSearch
			// 
			this.BtnSearch.BackColor = System.Drawing.Color.Black;
			this.BtnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnSearch.ForeColor = System.Drawing.Color.White;
			this.BtnSearch.Location = new System.Drawing.Point(201, 83);
			this.BtnSearch.Margin = new System.Windows.Forms.Padding(1);
			this.BtnSearch.Name = "BtnSearch";
			this.BtnSearch.Size = new System.Drawing.Size(98, 26);
			this.BtnSearch.TabIndex = 7;
			this.BtnSearch.Text = "Search Folder";
			this.BtnSearch.UseVisualStyleBackColor = false;
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// TbxTag
			// 
			this.TbxTag.AutoCompleteCustomSource.AddRange(new string[] {
            "test",
            "test1",
            "test2"});
			this.TbxTag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.TbxTag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.TlpMain.SetColumnSpan(this.TbxTag, 2);
			this.TbxTag.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TbxTag.Location = new System.Drawing.Point(2, 85);
			this.TbxTag.Margin = new System.Windows.Forms.Padding(2, 3, 1, 2);
			this.TbxTag.Name = "TbxTag";
			this.TbxTag.PlaceholderText = "search for or add tags";
			this.TbxTag.Size = new System.Drawing.Size(197, 23);
			this.TbxTag.TabIndex = 8;
			this.TbxTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxTag_KeyDown);
			// 
			// FlpFiles
			// 
			this.FlpFiles.AutoScroll = true;
			this.FlpFiles.BackColor = System.Drawing.Color.Black;
			this.FlpFiles.Controls.Add(this.TlpTemplate);
			this.FlpFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FlpFiles.Location = new System.Drawing.Point(300, 0);
			this.FlpFiles.Margin = new System.Windows.Forms.Padding(0);
			this.FlpFiles.Name = "FlpFiles";
			this.TlpMain.SetRowSpan(this.FlpFiles, 11);
			this.FlpFiles.Size = new System.Drawing.Size(1140, 767);
			this.FlpFiles.TabIndex = 0;
			// 
			// TlpTemplate
			// 
			this.TlpTemplate.ColumnCount = 1;
			this.TlpTemplate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
			this.TlpTemplate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TlpTemplate.Controls.Add(this.LblFNameTemplate, 0, 0);
			this.TlpTemplate.Controls.Add(this.PbxTemplate, 0, 1);
			this.TlpTemplate.Location = new System.Drawing.Point(3, 3);
			this.TlpTemplate.Name = "TlpTemplate";
			this.TlpTemplate.RowCount = 2;
			this.TlpTemplate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TlpTemplate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
			this.TlpTemplate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TlpTemplate.Size = new System.Drawing.Size(128, 148);
			this.TlpTemplate.TabIndex = 0;
			this.TlpTemplate.Visible = false;
			// 
			// LblFNameTemplate
			// 
			this.LblFNameTemplate.AutoSize = true;
			this.LblFNameTemplate.BackColor = System.Drawing.Color.Aqua;
			this.LblFNameTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LblFNameTemplate.Location = new System.Drawing.Point(0, 0);
			this.LblFNameTemplate.Margin = new System.Windows.Forms.Padding(0);
			this.LblFNameTemplate.Name = "LblFNameTemplate";
			this.LblFNameTemplate.Size = new System.Drawing.Size(128, 20);
			this.LblFNameTemplate.TabIndex = 0;
			this.LblFNameTemplate.Text = "FileName.png";
			// 
			// PbxTemplate
			// 
			this.PbxTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.PbxTemplate.Location = new System.Drawing.Point(0, 20);
			this.PbxTemplate.Margin = new System.Windows.Forms.Padding(0);
			this.PbxTemplate.Name = "PbxTemplate";
			this.PbxTemplate.Size = new System.Drawing.Size(128, 128);
			this.PbxTemplate.TabIndex = 1;
			this.PbxTemplate.TabStop = false;
			// 
			// BtnSelectFolder
			// 
			this.BtnSelectFolder.BackColor = System.Drawing.Color.PaleTurquoise;
			this.TlpMain.SetColumnSpan(this.BtnSelectFolder, 3);
			this.BtnSelectFolder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnSelectFolder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.BtnSelectFolder.Location = new System.Drawing.Point(1, 1);
			this.BtnSelectFolder.Margin = new System.Windows.Forms.Padding(1);
			this.BtnSelectFolder.Name = "BtnSelectFolder";
			this.BtnSelectFolder.Size = new System.Drawing.Size(298, 48);
			this.BtnSelectFolder.TabIndex = 2;
			this.BtnSelectFolder.Text = "(click to select folder)\r\n";
			this.BtnSelectFolder.UseVisualStyleBackColor = false;
			this.BtnSelectFolder.Click += new System.EventHandler(this.BtnSelectFolder_Click);
			// 
			// Opt128
			// 
			this.Opt128.Appearance = System.Windows.Forms.Appearance.Button;
			this.Opt128.AutoSize = true;
			this.Opt128.Checked = true;
			this.Opt128.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Opt128.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
			this.Opt128.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Opt128.Location = new System.Drawing.Point(1, 51);
			this.Opt128.Margin = new System.Windows.Forms.Padding(1);
			this.Opt128.Name = "Opt128";
			this.Opt128.Size = new System.Drawing.Size(98, 30);
			this.Opt128.TabIndex = 15;
			this.Opt128.TabStop = true;
			this.Opt128.Text = "128x128";
			this.Opt128.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Opt128.UseVisualStyleBackColor = true;
			this.Opt128.Click += new System.EventHandler(this.OptViewSize_Click);
			// 
			// Opt256
			// 
			this.Opt256.Appearance = System.Windows.Forms.Appearance.Button;
			this.Opt256.AutoSize = true;
			this.Opt256.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Opt256.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
			this.Opt256.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Opt256.Location = new System.Drawing.Point(101, 51);
			this.Opt256.Margin = new System.Windows.Forms.Padding(1);
			this.Opt256.Name = "Opt256";
			this.Opt256.Size = new System.Drawing.Size(98, 30);
			this.Opt256.TabIndex = 15;
			this.Opt256.Text = "256x256";
			this.Opt256.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Opt256.UseVisualStyleBackColor = true;
			this.Opt256.Click += new System.EventHandler(this.OptViewSize_Click);
			// 
			// Opt512
			// 
			this.Opt512.Appearance = System.Windows.Forms.Appearance.Button;
			this.Opt512.AutoSize = true;
			this.Opt512.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Opt512.FlatAppearance.CheckedBackColor = System.Drawing.Color.PaleGreen;
			this.Opt512.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Opt512.Location = new System.Drawing.Point(201, 51);
			this.Opt512.Margin = new System.Windows.Forms.Padding(1);
			this.Opt512.Name = "Opt512";
			this.Opt512.Size = new System.Drawing.Size(98, 30);
			this.Opt512.TabIndex = 15;
			this.Opt512.Text = "512x512";
			this.Opt512.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.Opt512.UseVisualStyleBackColor = true;
			this.Opt512.Click += new System.EventHandler(this.OptViewSize_Click);
			// 
			// PbrLoading
			// 
			this.TlpMain.SetColumnSpan(this.PbrLoading, 3);
			this.PbrLoading.Dock = System.Windows.Forms.DockStyle.Fill;
			this.PbrLoading.Location = new System.Drawing.Point(3, 113);
			this.PbrLoading.Name = "PbrLoading";
			this.PbrLoading.Size = new System.Drawing.Size(294, 22);
			this.PbrLoading.Step = 1;
			this.PbrLoading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.PbrLoading.TabIndex = 16;
			this.PbrLoading.Visible = false;
			// 
			// CmsTag
			// 
			this.CmsTag.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsiAssign,
            this.CmsiRemove,
            this.toolStripSeparator1,
            this.CmsiVisible,
            this.CmsiSeparator2,
            this.CmsiRemoveImg});
			this.CmsTag.Name = "CmsTag";
			this.CmsTag.Size = new System.Drawing.Size(183, 104);
			// 
			// CmsiAssign
			// 
			this.CmsiAssign.Name = "CmsiAssign";
			this.CmsiAssign.Size = new System.Drawing.Size(182, 22);
			this.CmsiAssign.Text = "Assign to All";
			// 
			// CmsiRemove
			// 
			this.CmsiRemove.Name = "CmsiRemove";
			this.CmsiRemove.Size = new System.Drawing.Size(182, 22);
			this.CmsiRemove.Text = "Remove from All";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
			// 
			// CmsiVisible
			// 
			this.CmsiVisible.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CmsiShow,
            this.CmsiHide});
			this.CmsiVisible.Name = "CmsiVisible";
			this.CmsiVisible.Size = new System.Drawing.Size(182, 22);
			this.CmsiVisible.Text = "Visibility";
			// 
			// CmsiShow
			// 
			this.CmsiShow.Name = "CmsiShow";
			this.CmsiShow.Size = new System.Drawing.Size(103, 22);
			this.CmsiShow.Text = "Show";
			// 
			// CmsiHide
			// 
			this.CmsiHide.Name = "CmsiHide";
			this.CmsiHide.Size = new System.Drawing.Size(103, 22);
			this.CmsiHide.Text = "Hide";
			// 
			// CmsiSeparator2
			// 
			this.CmsiSeparator2.Name = "CmsiSeparator2";
			this.CmsiSeparator2.Size = new System.Drawing.Size(179, 6);
			// 
			// CmsiRemoveImg
			// 
			this.CmsiRemoveImg.Name = "CmsiRemoveImg";
			this.CmsiRemoveImg.Size = new System.Drawing.Size(182, 22);
			this.CmsiRemoveImg.Text = "Remove from Image";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1440, 787);
			this.Controls.Add(this.TlpMain);
			this.Name = "MainForm";
			this.Text = "Stable Diffusion A1111 Bulk Image Search Utility v1.0.0.0";
			this.TlpMain.ResumeLayout(false);
			this.TlpMain.PerformLayout();
			this.FlpFiles.ResumeLayout(false);
			this.TlpTemplate.ResumeLayout(false);
			this.TlpTemplate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PbxTemplate)).EndInit();
			this.CmsTag.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel TlpMain;
		private System.Windows.Forms.FlowLayoutPanel FlpFiles;
		private System.Windows.Forms.Button BtnSelectFolder;
		private System.Windows.Forms.TableLayoutPanel TlpTemplate;
		private System.Windows.Forms.Label LblFNameTemplate;
		private System.Windows.Forms.PictureBox PbxTemplate;
		private System.Windows.Forms.ToolStripMenuItem CmsiAssign;
		private System.Windows.Forms.ToolStripMenuItem CmsiRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem CmsiVisible;
		private System.Windows.Forms.ToolStripMenuItem CmsiShow;
		private System.Windows.Forms.ToolStripMenuItem CmsiHide;
		internal System.Windows.Forms.ContextMenuStrip CmsTag;
		private System.Windows.Forms.ToolStripSeparator CmsiSeparator2;
		private System.Windows.Forms.ToolStripMenuItem CmsiRemoveImg;
		private System.Windows.Forms.RadioButton Opt128;
		private System.Windows.Forms.RadioButton Opt256;
		private System.Windows.Forms.RadioButton Opt512;
		private TextBox TbxTag;
		private Button BtnSearch;
		private ProgressBar PbrLoading;
	}
}
