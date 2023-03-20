namespace Embedding_Name_Helper {
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
			this.BtnEditTags = new System.Windows.Forms.Button();
			this.FlpFiles = new System.Windows.Forms.FlowLayoutPanel();
			this.TlpTemplate = new System.Windows.Forms.TableLayoutPanel();
			this.LblFNameTemplate = new System.Windows.Forms.Label();
			this.PbxTemplate = new System.Windows.Forms.PictureBox();
			this.FlpTemplate = new System.Windows.Forms.FlowLayoutPanel();
			this.LblTagTemplate = new System.Windows.Forms.Label();
			this.FlpTags = new System.Windows.Forms.FlowLayoutPanel();
			this.BtnSelectFolder = new System.Windows.Forms.Button();
			this.BtnCommit = new System.Windows.Forms.Button();
			this.BtnShowAll = new System.Windows.Forms.Button();
			this.BtnRemoveAll = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.BtnAddTag = new System.Windows.Forms.Button();
			this.TbxTag = new System.Windows.Forms.TextBox();
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
			this.FlpTemplate.SuspendLayout();
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
			this.TlpMain.Controls.Add(this.BtnEditTags, 1, 2);
			this.TlpMain.Controls.Add(this.FlpFiles, 3, 0);
			this.TlpMain.Controls.Add(this.FlpTags, 0, 5);
			this.TlpMain.Controls.Add(this.BtnSelectFolder, 0, 0);
			this.TlpMain.Controls.Add(this.BtnCommit, 0, 1);
			this.TlpMain.Controls.Add(this.BtnShowAll, 0, 2);
			this.TlpMain.Controls.Add(this.BtnRemoveAll, 2, 2);
			this.TlpMain.Controls.Add(this.label1, 0, 3);
			this.TlpMain.Controls.Add(this.BtnAddTag, 2, 6);
			this.TlpMain.Controls.Add(this.TbxTag, 0, 6);
			this.TlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TlpMain.Location = new System.Drawing.Point(0, 0);
			this.TlpMain.Name = "TlpMain";
			this.TlpMain.RowCount = 7;
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.TlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.TlpMain.Size = new System.Drawing.Size(1199, 694);
			this.TlpMain.TabIndex = 0;
			// 
			// BtnEditTags
			// 
			this.BtnEditTags.BackColor = System.Drawing.Color.Black;
			this.BtnEditTags.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnEditTags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnEditTags.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.BtnEditTags.ForeColor = System.Drawing.Color.White;
			this.BtnEditTags.Location = new System.Drawing.Point(101, 101);
			this.BtnEditTags.Margin = new System.Windows.Forms.Padding(1);
			this.BtnEditTags.Name = "BtnEditTags";
			this.BtnEditTags.Size = new System.Drawing.Size(98, 26);
			this.BtnEditTags.TabIndex = 5;
			this.BtnEditTags.Text = "Edit Tags";
			this.BtnEditTags.UseVisualStyleBackColor = false;
			this.BtnEditTags.Click += new System.EventHandler(this.BtnEditTags_Click);
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
			this.TlpMain.SetRowSpan(this.FlpFiles, 7);
			this.FlpFiles.Size = new System.Drawing.Size(899, 694);
			this.FlpFiles.TabIndex = 0;
			// 
			// TlpTemplate
			// 
			this.TlpTemplate.ColumnCount = 1;
			this.TlpTemplate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
			this.TlpTemplate.Controls.Add(this.LblFNameTemplate, 0, 0);
			this.TlpTemplate.Controls.Add(this.PbxTemplate, 0, 1);
			this.TlpTemplate.Controls.Add(this.FlpTemplate, 0, 2);
			this.TlpTemplate.Location = new System.Drawing.Point(3, 3);
			this.TlpTemplate.Name = "TlpTemplate";
			this.TlpTemplate.RowCount = 3;
			this.TlpTemplate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.TlpTemplate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
			this.TlpTemplate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.TlpTemplate.Size = new System.Drawing.Size(128, 217);
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
			// FlpTemplate
			// 
			this.FlpTemplate.AllowDrop = true;
			this.FlpTemplate.BackColor = System.Drawing.Color.DimGray;
			this.FlpTemplate.Controls.Add(this.LblTagTemplate);
			this.FlpTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FlpTemplate.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.FlpTemplate.Location = new System.Drawing.Point(0, 148);
			this.FlpTemplate.Margin = new System.Windows.Forms.Padding(0);
			this.FlpTemplate.Name = "FlpTemplate";
			this.FlpTemplate.Padding = new System.Windows.Forms.Padding(1);
			this.FlpTemplate.Size = new System.Drawing.Size(128, 69);
			this.FlpTemplate.TabIndex = 2;
			// 
			// LblTagTemplate
			// 
			this.LblTagTemplate.AutoSize = true;
			this.LblTagTemplate.BackColor = System.Drawing.Color.LightSkyBlue;
			this.LblTagTemplate.Location = new System.Drawing.Point(4, 1);
			this.LblTagTemplate.Name = "LblTagTemplate";
			this.LblTagTemplate.Size = new System.Drawing.Size(69, 15);
			this.LblTagTemplate.TabIndex = 0;
			this.LblTagTemplate.Text = "TemplateStr";
			// 
			// FlpTags
			// 
			this.FlpTags.AutoScroll = true;
			this.FlpTags.BackColor = System.Drawing.Color.DimGray;
			this.TlpMain.SetColumnSpan(this.FlpTags, 3);
			this.FlpTags.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FlpTags.Location = new System.Drawing.Point(2, 211);
			this.FlpTags.Margin = new System.Windows.Forms.Padding(2, 3, 3, 3);
			this.FlpTags.Name = "FlpTags";
			this.FlpTags.Padding = new System.Windows.Forms.Padding(1);
			this.FlpTags.Size = new System.Drawing.Size(295, 452);
			this.FlpTags.TabIndex = 1;
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
			// BtnCommit
			// 
			this.BtnCommit.BackColor = System.Drawing.Color.LightGreen;
			this.TlpMain.SetColumnSpan(this.BtnCommit, 3);
			this.BtnCommit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnCommit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.BtnCommit.Location = new System.Drawing.Point(1, 51);
			this.BtnCommit.Margin = new System.Windows.Forms.Padding(1);
			this.BtnCommit.Name = "BtnCommit";
			this.BtnCommit.Size = new System.Drawing.Size(298, 48);
			this.BtnCommit.TabIndex = 2;
			this.BtnCommit.Text = "Generate File \r\nDescriptions from Tags";
			this.BtnCommit.UseVisualStyleBackColor = false;
			this.BtnCommit.Click += new System.EventHandler(this.BtnCommit_Click);
			// 
			// BtnShowAll
			// 
			this.BtnShowAll.BackColor = System.Drawing.Color.Black;
			this.BtnShowAll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnShowAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.BtnShowAll.ForeColor = System.Drawing.Color.White;
			this.BtnShowAll.Location = new System.Drawing.Point(1, 101);
			this.BtnShowAll.Margin = new System.Windows.Forms.Padding(1);
			this.BtnShowAll.Name = "BtnShowAll";
			this.BtnShowAll.Size = new System.Drawing.Size(98, 26);
			this.BtnShowAll.TabIndex = 3;
			this.BtnShowAll.Text = "Show All Tags";
			this.BtnShowAll.UseVisualStyleBackColor = false;
			this.BtnShowAll.Click += new System.EventHandler(this.BtnShowAll_Click);
			// 
			// BtnRemoveAll
			// 
			this.BtnRemoveAll.BackColor = System.Drawing.Color.Black;
			this.BtnRemoveAll.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnRemoveAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.BtnRemoveAll.ForeColor = System.Drawing.Color.White;
			this.BtnRemoveAll.Location = new System.Drawing.Point(201, 101);
			this.BtnRemoveAll.Margin = new System.Windows.Forms.Padding(1);
			this.BtnRemoveAll.Name = "BtnRemoveAll";
			this.BtnRemoveAll.Size = new System.Drawing.Size(98, 26);
			this.BtnRemoveAll.TabIndex = 4;
			this.BtnRemoveAll.Text = "Hide All Tags";
			this.BtnRemoveAll.UseVisualStyleBackColor = false;
			this.BtnRemoveAll.Click += new System.EventHandler(this.BtnRemoveAll_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TlpMain.SetColumnSpan(this.label1, 3);
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(2, 129);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.label1.Name = "label1";
			this.TlpMain.SetRowSpan(this.label1, 2);
			this.label1.Size = new System.Drawing.Size(296, 78);
			this.label1.TabIndex = 6;
			this.label1.Text = "-Click tags to select them\r\n-Click and Drag Tags to pictures\r\n-Right-click tags f" +
    "or additional options\r\n-Edit tags to change display order\r\n-Use the interface at" +
    " the bottom to add tags";
			// 
			// BtnAddTag
			// 
			this.BtnAddTag.BackColor = System.Drawing.Color.Black;
			this.BtnAddTag.Dock = System.Windows.Forms.DockStyle.Fill;
			this.BtnAddTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnAddTag.ForeColor = System.Drawing.Color.White;
			this.BtnAddTag.Location = new System.Drawing.Point(201, 667);
			this.BtnAddTag.Margin = new System.Windows.Forms.Padding(1);
			this.BtnAddTag.Name = "BtnAddTag";
			this.BtnAddTag.Size = new System.Drawing.Size(98, 26);
			this.BtnAddTag.TabIndex = 7;
			this.BtnAddTag.Text = "Add Tag";
			this.BtnAddTag.UseVisualStyleBackColor = false;
			this.BtnAddTag.Click += new System.EventHandler(this.BtnAddTag_Click);
			// 
			// TbxTag
			// 
			this.TlpMain.SetColumnSpan(this.TbxTag, 2);
			this.TbxTag.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TbxTag.Location = new System.Drawing.Point(2, 667);
			this.TbxTag.Margin = new System.Windows.Forms.Padding(2, 1, 1, 2);
			this.TbxTag.Multiline = true;
			this.TbxTag.Name = "TbxTag";
			this.TbxTag.Size = new System.Drawing.Size(197, 25);
			this.TbxTag.TabIndex = 8;
			this.TbxTag.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxTag_KeyDown);
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
			this.CmsTag.Opening += new System.ComponentModel.CancelEventHandler(this.CmsTag_Opening);
			// 
			// CmsiAssign
			// 
			this.CmsiAssign.Name = "CmsiAssign";
			this.CmsiAssign.Size = new System.Drawing.Size(182, 22);
			this.CmsiAssign.Text = "Assign to All";
			this.CmsiAssign.Click += new System.EventHandler(this.CmsiAssign_Click);
			// 
			// CmsiRemove
			// 
			this.CmsiRemove.Name = "CmsiRemove";
			this.CmsiRemove.Size = new System.Drawing.Size(182, 22);
			this.CmsiRemove.Text = "Remove from All";
			this.CmsiRemove.Click += new System.EventHandler(this.CmsiRemove_Click);
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
			this.CmsiShow.Click += new System.EventHandler(this.CmsiShow_Click);
			// 
			// CmsiHide
			// 
			this.CmsiHide.Name = "CmsiHide";
			this.CmsiHide.Size = new System.Drawing.Size(103, 22);
			this.CmsiHide.Text = "Hide";
			this.CmsiHide.Click += new System.EventHandler(this.CmsiHide_Click);
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
			this.CmsiRemoveImg.Click += new System.EventHandler(this.CmsiRemoveImg_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1199, 694);
			this.Controls.Add(this.TlpMain);
			this.Name = "MainForm";
			this.Text = "Stable Diffusion Embeddings Image Tag Generation Helper - v1.0.0.0";
			this.TlpMain.ResumeLayout(false);
			this.TlpMain.PerformLayout();
			this.FlpFiles.ResumeLayout(false);
			this.TlpTemplate.ResumeLayout(false);
			this.TlpTemplate.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PbxTemplate)).EndInit();
			this.FlpTemplate.ResumeLayout(false);
			this.FlpTemplate.PerformLayout();
			this.CmsTag.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel TlpMain;
		private System.Windows.Forms.FlowLayoutPanel FlpFiles;
		private System.Windows.Forms.FlowLayoutPanel FlpTags;
		private System.Windows.Forms.Button BtnSelectFolder;
		private System.Windows.Forms.Button BtnCommit;
		private System.Windows.Forms.TableLayoutPanel TlpTemplate;
		private System.Windows.Forms.Label LblFNameTemplate;
		private System.Windows.Forms.PictureBox PbxTemplate;
		private System.Windows.Forms.FlowLayoutPanel FlpTemplate;
		private System.Windows.Forms.Label LblTagTemplate;
		private System.Windows.Forms.ToolStripMenuItem CmsiAssign;
		private System.Windows.Forms.ToolStripMenuItem CmsiRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem CmsiVisible;
		private System.Windows.Forms.ToolStripMenuItem CmsiShow;
		private System.Windows.Forms.ToolStripMenuItem CmsiHide;
		internal System.Windows.Forms.ContextMenuStrip CmsTag;
		private System.Windows.Forms.Button BtnShowAll;
		private System.Windows.Forms.Button BtnRemoveAll;
		private System.Windows.Forms.Button BtnEditTags;
		private System.Windows.Forms.ToolStripSeparator CmsiSeparator2;
		private System.Windows.Forms.ToolStripMenuItem CmsiRemoveImg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button BtnAddTag;
		private System.Windows.Forms.TextBox TbxTag;
	}
}
