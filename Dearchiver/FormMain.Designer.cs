namespace Piksel.Dearchiver
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tbInfo = new System.Windows.Forms.TextBox();
            this.pbExtraction = new System.Windows.Forms.ProgressBar();
            this.lFileName = new System.Windows.Forms.Label();
            this.lPercent = new System.Windows.Forms.Label();
            this.bSettings = new System.Windows.Forms.Button();
            this.llCredits = new System.Windows.Forms.LinkLabel();
            this.bCancel = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.alwaysUseNewWorkingAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workingAreaBasePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.afterExtractionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDearchiverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteInputconvertToFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteInputextractToWeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setFileAssociationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.bIncWrkArea = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbWorkAreaNum = new System.Windows.Forms.MaskedTextBox();
            this.lArchivePath = new System.Windows.Forms.Label();
            this.lArchiveContents = new System.Windows.Forms.Label();
            this.lArchiveRootDirs = new System.Windows.Forms.Label();
            this.lArchiveCompression = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bOpen = new System.Windows.Forms.Button();
            this.bWorkingArea = new System.Windows.Forms.Button();
            this.bConvert = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.excerptLabel1 = new Piksel.Dearchiver.ExcerptLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbInfo
            // 
            this.tbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tbInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInfo.Location = new System.Drawing.Point(3, 12);
            this.tbInfo.Multiline = true;
            this.tbInfo.Name = "tbInfo";
            this.tbInfo.ReadOnly = true;
            this.tbInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInfo.Size = new System.Drawing.Size(60, 114);
            this.tbInfo.TabIndex = 4;
            // 
            // pbExtraction
            // 
            this.pbExtraction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbExtraction.Location = new System.Drawing.Point(12, 184);
            this.pbExtraction.Name = "pbExtraction";
            this.pbExtraction.Size = new System.Drawing.Size(360, 23);
            this.pbExtraction.TabIndex = 6;
            this.pbExtraction.Visible = false;
            // 
            // lFileName
            // 
            this.lFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lFileName.AutoSize = true;
            this.lFileName.Location = new System.Drawing.Point(12, 167);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(48, 13);
            this.lFileName.TabIndex = 7;
            this.lFileName.Text = "fileName";
            this.lFileName.Visible = false;
            // 
            // lPercent
            // 
            this.lPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lPercent.Location = new System.Drawing.Point(365, 167);
            this.lPercent.Name = "lPercent";
            this.lPercent.Size = new System.Drawing.Size(106, 13);
            this.lPercent.TabIndex = 8;
            this.lPercent.Text = "0 %";
            this.lPercent.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lPercent.Visible = false;
            // 
            // bSettings
            // 
            this.bSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSettings.Location = new System.Drawing.Point(12, 225);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(94, 23);
            this.bSettings.TabIndex = 9;
            this.bSettings.Text = "Settings";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // llCredits
            // 
            this.llCredits.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(171)))), ((int)(((byte)(157)))));
            this.llCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.llCredits.AutoSize = true;
            this.llCredits.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(88)))), ((int)(((byte)(68)))));
            this.llCredits.Location = new System.Drawing.Point(130, 235);
            this.llCredits.Name = "llCredits";
            this.llCredits.Size = new System.Drawing.Size(76, 13);
            this.llCredits.TabIndex = 10;
            this.llCredits.TabStop = true;
            this.llCredits.Text = "piksel bitworks";
            this.llCredits.Visible = false;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(378, 184);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(94, 23);
            this.bCancel.TabIndex = 11;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Visible = false;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysUseNewWorkingAreaToolStripMenuItem,
            this.workingAreaBasePathToolStripMenuItem,
            this.toolStripMenuItem2,
            this.afterExtractionToolStripMenuItem,
            this.setFileAssociationsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(229, 126);
            // 
            // alwaysUseNewWorkingAreaToolStripMenuItem
            // 
            this.alwaysUseNewWorkingAreaToolStripMenuItem.Name = "alwaysUseNewWorkingAreaToolStripMenuItem";
            this.alwaysUseNewWorkingAreaToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.alwaysUseNewWorkingAreaToolStripMenuItem.Text = "Always use new working area";
            // 
            // workingAreaBasePathToolStripMenuItem
            // 
            this.workingAreaBasePathToolStripMenuItem.Name = "workingAreaBasePathToolStripMenuItem";
            this.workingAreaBasePathToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.workingAreaBasePathToolStripMenuItem.Text = "Set working area base path...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(225, 6);
            // 
            // afterExtractionToolStripMenuItem
            // 
            this.afterExtractionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.closeDearchiverToolStripMenuItem,
            this.deleteInputconvertToFolderToolStripMenuItem,
            this.deleteInputextractToWeToolStripMenuItem});
            this.afterExtractionToolStripMenuItem.Name = "afterExtractionToolStripMenuItem";
            this.afterExtractionToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.afterExtractionToolStripMenuItem.Text = "After extraction";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.openFolderToolStripMenuItem.Text = "Open folder";
            // 
            // closeDearchiverToolStripMenuItem
            // 
            this.closeDearchiverToolStripMenuItem.Name = "closeDearchiverToolStripMenuItem";
            this.closeDearchiverToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.closeDearchiverToolStripMenuItem.Text = "Close Dearchiver";
            // 
            // deleteInputconvertToFolderToolStripMenuItem
            // 
            this.deleteInputconvertToFolderToolStripMenuItem.Name = "deleteInputconvertToFolderToolStripMenuItem";
            this.deleteInputconvertToFolderToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.deleteInputconvertToFolderToolStripMenuItem.Text = "Delete input (convert to folder)";
            // 
            // deleteInputextractToWeToolStripMenuItem
            // 
            this.deleteInputextractToWeToolStripMenuItem.Name = "deleteInputextractToWeToolStripMenuItem";
            this.deleteInputextractToWeToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.deleteInputextractToWeToolStripMenuItem.Text = "Delete input (extract to w/e)";
            // 
            // setFileAssociationsToolStripMenuItem
            // 
            this.setFileAssociationsToolStripMenuItem.Name = "setFileAssociationsToolStripMenuItem";
            this.setFileAssociationsToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.setFileAssociationsToolStripMenuItem.Text = "Set file associations...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            // 
            // bIncWrkArea
            // 
            this.bIncWrkArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bIncWrkArea.Enabled = false;
            this.bIncWrkArea.Location = new System.Drawing.Point(397, 226);
            this.bIncWrkArea.Name = "bIncWrkArea";
            this.bIncWrkArea.Size = new System.Drawing.Size(75, 23);
            this.bIncWrkArea.TabIndex = 14;
            this.bIncWrkArea.Text = "&Increment";
            this.bIncWrkArea.UseVisualStyleBackColor = true;
            this.bIncWrkArea.Click += new System.EventHandler(this.bIncWrkArea_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbInfo);
            this.groupBox1.Location = new System.Drawing.Point(186, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(64, 130);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Console: ";
            this.groupBox1.Visible = false;
            // 
            // tbWorkAreaNum
            // 
            this.tbWorkAreaNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkAreaNum.AsciiOnly = true;
            this.tbWorkAreaNum.Location = new System.Drawing.Point(342, 228);
            this.tbWorkAreaNum.Mask = "000";
            this.tbWorkAreaNum.Name = "tbWorkAreaNum";
            this.tbWorkAreaNum.Size = new System.Drawing.Size(49, 20);
            this.tbWorkAreaNum.SkipLiterals = false;
            this.tbWorkAreaNum.TabIndex = 16;
            this.tbWorkAreaNum.Text = "001";
            this.tbWorkAreaNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbWorkAreaNum.ValidatingType = typeof(int);
            // 
            // lArchivePath
            // 
            this.lArchivePath.AutoSize = true;
            this.lArchivePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lArchivePath.Location = new System.Drawing.Point(7, 17);
            this.lArchivePath.Name = "lArchivePath";
            this.lArchivePath.Size = new System.Drawing.Size(41, 13);
            this.lArchivePath.TabIndex = 17;
            this.lArchivePath.Text = "Path: ";
            // 
            // lArchiveContents
            // 
            this.lArchiveContents.AutoSize = true;
            this.lArchiveContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lArchiveContents.Location = new System.Drawing.Point(7, 32);
            this.lArchiveContents.Name = "lArchiveContents";
            this.lArchiveContents.Size = new System.Drawing.Size(61, 13);
            this.lArchiveContents.TabIndex = 18;
            this.lArchiveContents.Text = "Contents:";
            // 
            // lArchiveRootDirs
            // 
            this.lArchiveRootDirs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lArchiveRootDirs.Location = new System.Drawing.Point(7, 47);
            this.lArchiveRootDirs.Name = "lArchiveRootDirs";
            this.lArchiveRootDirs.Size = new System.Drawing.Size(447, 15);
            this.lArchiveRootDirs.TabIndex = 19;
            this.lArchiveRootDirs.Text = "<Root Dirs>";
            // 
            // lArchiveCompression
            // 
            this.lArchiveCompression.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lArchiveCompression.Location = new System.Drawing.Point(7, 62);
            this.lArchiveCompression.Name = "lArchiveCompression";
            this.lArchiveCompression.Size = new System.Drawing.Size(447, 15);
            this.lArchiveCompression.TabIndex = 20;
            this.lArchiveCompression.Text = "<Compression>";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(228, 230);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(108, 13);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Current working area:";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLinkClicked);
            // 
            // bOpen
            // 
            this.bOpen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bOpen.Image = global::Piksel.Dearchiver.Properties.Resources.missing;
            this.bOpen.Location = new System.Drawing.Point(188, 107);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(109, 98);
            this.bOpen.TabIndex = 3;
            this.bOpen.Tag = "&Open with";
            this.bOpen.Text = "&Open with 7zip";
            this.bOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.bOpen, resources.GetString("bOpen.ToolTip"));
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // bWorkingArea
            // 
            this.bWorkingArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bWorkingArea.Image = global::Piksel.Dearchiver.Properties.Resources.dearchiver_logo_opened_48px;
            this.bWorkingArea.Location = new System.Drawing.Point(304, 107);
            this.bWorkingArea.Name = "bWorkingArea";
            this.bWorkingArea.Size = new System.Drawing.Size(168, 98);
            this.bWorkingArea.TabIndex = 2;
            this.bWorkingArea.Text = "E&xtract to working area";
            this.bWorkingArea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.bWorkingArea, resources.GetString("bWorkingArea.ToolTip"));
            this.bWorkingArea.UseVisualStyleBackColor = true;
            this.bWorkingArea.Click += new System.EventHandler(this.bWorkingArea_Click);
            // 
            // bConvert
            // 
            this.bConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bConvert.Image = global::Piksel.Dearchiver.Properties.Resources.dearchiver_logo_opened_48px;
            this.bConvert.Location = new System.Drawing.Point(12, 107);
            this.bConvert.Name = "bConvert";
            this.bConvert.Size = new System.Drawing.Size(168, 98);
            this.bConvert.TabIndex = 0;
            this.bConvert.Text = "&Convert to folder";
            this.bConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.bConvert, "Extract archive contents to a folder with the same name as the archive.\r\n\r\nExampl" +
        "e:\r\n\r\nC:\\Users\\Administrator\\Download\\Foo.zip\r\nwill be extracted to\r\nC:\\Users\\Ad" +
        "ministrator\\Download\\Foo\\");
            this.bConvert.UseVisualStyleBackColor = true;
            this.bConvert.Click += new System.EventHandler(this.bConvert_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(70, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(384, 13);
            this.textBox2.TabIndex = 23;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "<Contents>";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "7ziplogo.png");
            this.imageList1.Images.SetKeyName(1, "dearchiver-logo_opened-48px.png");
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.excerptLabel1);
            this.groupBox2.Controls.Add(this.lArchiveContents);
            this.groupBox2.Controls.Add(this.lArchivePath);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.lArchiveRootDirs);
            this.groupBox2.Controls.Add(this.lArchiveCompression);
            this.groupBox2.Location = new System.Drawing.Point(12, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 100);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            // 
            // excerptLabel1
            // 
            this.excerptLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excerptLabel1.DotsOnLeft = true;
            this.excerptLabel1.Location = new System.Drawing.Point(45, 17);
            this.excerptLabel1.Name = "excerptLabel1";
            this.excerptLabel1.Size = new System.Drawing.Size(409, 15);
            this.excerptLabel1.TabIndex = 24;
            this.excerptLabel1.Text = "<Path>";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tbWorkAreaNum);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bIncWrkArea);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.llCredits);
            this.Controls.Add(this.bSettings);
            this.Controls.Add(this.lPercent);
            this.Controls.Add(this.lFileName);
            this.Controls.Add(this.pbExtraction);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.bWorkingArea);
            this.Controls.Add(this.bConvert);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(8000, 300);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FormMain";
            this.Text = "Dearchiver";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConvert;
        private System.Windows.Forms.Button bWorkingArea;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.TextBox tbInfo;
        private System.Windows.Forms.ProgressBar pbExtraction;
        private System.Windows.Forms.Label lFileName;
        private System.Windows.Forms.Label lPercent;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.LinkLabel llCredits;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem alwaysUseNewWorkingAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workingAreaBasePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem afterExtractionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeDearchiverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteInputconvertToFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteInputextractToWeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setFileAssociationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button bIncWrkArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox tbWorkAreaNum;
        private System.Windows.Forms.Label lArchivePath;
        private System.Windows.Forms.Label lArchiveContents;
        private System.Windows.Forms.Label lArchiveRootDirs;
        private System.Windows.Forms.Label lArchiveCompression;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ExcerptLabel excerptLabel1;
    }
}

