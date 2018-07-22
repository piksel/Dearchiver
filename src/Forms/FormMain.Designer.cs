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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("/file/path");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Foo",
            "Bar"}, -1);
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
            this.tbWorkAreaNum = new System.Windows.Forms.MaskedTextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bOpen = new System.Windows.Forms.Button();
            this.bWorkingArea = new System.Windows.Forms.Button();
            this.bConvert = new System.Windows.Forms.Button();
            this.ilBottomButtons = new System.Windows.Forms.ImageList(this.components);
            this.lvFiles = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTypeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSizeCompr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.lvDetails = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new Microsoft.Samples.TableLayoutToolStrip();
            this.tsbParentDir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tstLocation = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTree = new System.Windows.Forms.ToolStripButton();
            this.tsbDetails = new System.Windows.Forms.ToolStripButton();
            this.tsbIcons = new System.Windows.Forms.ToolStripButton();
            this.tsbArchiveInfo = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.textBox2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.excerptLabel1 = new Piksel.Dearchiver.ToolStripStatusExcerptLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbExtraction
            // 
            this.pbExtraction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbExtraction.Location = new System.Drawing.Point(12, 426);
            this.pbExtraction.Name = "pbExtraction";
            this.pbExtraction.Size = new System.Drawing.Size(455, 23);
            this.pbExtraction.TabIndex = 6;
            this.pbExtraction.Visible = false;
            // 
            // lFileName
            // 
            this.lFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lFileName.AutoSize = true;
            this.lFileName.Location = new System.Drawing.Point(12, 400);
            this.lFileName.Name = "lFileName";
            this.lFileName.Size = new System.Drawing.Size(52, 13);
            this.lFileName.TabIndex = 7;
            this.lFileName.Text = "fileName";
            this.lFileName.Visible = false;
            // 
            // lPercent
            // 
            this.lPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lPercent.Location = new System.Drawing.Point(460, 400);
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
            this.bSettings.Location = new System.Drawing.Point(12, 467);
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
            this.llCredits.Location = new System.Drawing.Point(225, 499);
            this.llCredits.Name = "llCredits";
            this.llCredits.Size = new System.Drawing.Size(85, 13);
            this.llCredits.TabIndex = 10;
            this.llCredits.TabStop = true;
            this.llCredits.Text = "piksel bitworks";
            this.llCredits.Visible = false;
            // 
            // bCancel
            // 
            this.bCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bCancel.Location = new System.Drawing.Point(473, 426);
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
            this.bIncWrkArea.Location = new System.Drawing.Point(492, 468);
            this.bIncWrkArea.Name = "bIncWrkArea";
            this.bIncWrkArea.Size = new System.Drawing.Size(75, 23);
            this.bIncWrkArea.TabIndex = 14;
            this.bIncWrkArea.Text = "&Increment";
            this.bIncWrkArea.UseVisualStyleBackColor = true;
            this.bIncWrkArea.Click += new System.EventHandler(this.bIncWrkArea_Click);
            // 
            // tbWorkAreaNum
            // 
            this.tbWorkAreaNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWorkAreaNum.AsciiOnly = true;
            this.tbWorkAreaNum.Location = new System.Drawing.Point(437, 470);
            this.tbWorkAreaNum.Mask = "000";
            this.tbWorkAreaNum.Name = "tbWorkAreaNum";
            this.tbWorkAreaNum.Size = new System.Drawing.Size(49, 22);
            this.tbWorkAreaNum.SkipLiterals = false;
            this.tbWorkAreaNum.TabIndex = 16;
            this.tbWorkAreaNum.Text = "001";
            this.tbWorkAreaNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbWorkAreaNum.ValidatingType = typeof(int);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(310, 472);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(120, 13);
            this.linkLabel1.TabIndex = 21;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Current working area:";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelLinkClicked);
            // 
            // bOpen
            // 
            this.bOpen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bOpen.Image = global::Piksel.Dearchiver.Properties.Resources.missing;
            this.bOpen.Location = new System.Drawing.Point(235, 349);
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
            this.bWorkingArea.Location = new System.Drawing.Point(399, 349);
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
            this.bConvert.Location = new System.Drawing.Point(12, 349);
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
            // ilBottomButtons
            // 
            this.ilBottomButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilBottomButtons.ImageStream")));
            this.ilBottomButtons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilBottomButtons.Images.SetKeyName(0, "7ziplogo.png");
            this.ilBottomButtons.Images.SetKeyName(1, "dearchiver-logo_opened-48px.png");
            // 
            // lvFiles
            // 
            this.lvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chSize,
            this.chTypeName,
            this.chSizeCompr,
            this.chTime,
            this.chType});
            this.lvFiles.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvFiles.Location = new System.Drawing.Point(1, 73);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(576, 117);
            this.lvFiles.TabIndex = 25;
            this.lvFiles.TileSize = new System.Drawing.Size(200, 48);
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.lvFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 200;
            // 
            // chSize
            // 
            this.chSize.Text = "Size";
            this.chSize.Width = 70;
            // 
            // chTypeName
            // 
            this.chTypeName.DisplayIndex = 3;
            this.chTypeName.Text = "Type";
            this.chTypeName.Width = 120;
            // 
            // chSizeCompr
            // 
            this.chSizeCompr.DisplayIndex = 2;
            this.chSizeCompr.Text = "Size Compr.";
            this.chSizeCompr.Width = 70;
            // 
            // chTime
            // 
            this.chTime.Text = "Time";
            this.chTime.Width = 110;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chType.Width = 0;
            // 
            // tvFiles
            // 
            this.tvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFiles.FullRowSelect = true;
            this.tvFiles.Location = new System.Drawing.Point(3, 3);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.PathSeparator = "/";
            this.tvFiles.ShowPlusMinus = false;
            this.tvFiles.ShowRootLines = false;
            this.tvFiles.Size = new System.Drawing.Size(577, 67);
            this.tvFiles.TabIndex = 26;
            this.tvFiles.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
            this.tvFiles.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
            this.tvFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // toolStripContainer1
            // 
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lvDetails);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.lvFiles);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tvFiles);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(581, 293);
            this.toolStripContainer1.Location = new System.Drawing.Point(-1, 3);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(581, 333);
            this.toolStripContainer1.TabIndex = 27;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // lvDetails
            // 
            this.lvDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvDetails.FullRowSelect = true;
            this.lvDetails.GridLines = true;
            this.lvDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvDetails.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvDetails.Location = new System.Drawing.Point(-1, 193);
            this.lvDetails.MultiSelect = false;
            this.lvDetails.Name = "lvDetails";
            this.lvDetails.ShowGroups = false;
            this.lvDetails.Size = new System.Drawing.Size(579, 97);
            this.lvDetails.TabIndex = 27;
            this.lvDetails.UseCompatibleStateImageBehavior = false;
            this.lvDetails.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 450;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ColumnCount = 8;
            this.toolStrip1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.toolStrip1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.toolStrip1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.toolStrip1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.toolStrip1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.toolStrip1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.toolStrip1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.toolStrip1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbParentDir,
            this.toolStripSeparator2,
            this.tstLocation,
            this.toolStripSeparator1,
            this.tsbTree,
            this.tsbDetails,
            this.tsbIcons,
            this.tsbArchiveInfo});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RowCount = 1;
            this.toolStrip1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.toolStrip1.Size = new System.Drawing.Size(581, 40);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbParentDir
            // 
            this.tsbParentDir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbParentDir.Image = ((System.Drawing.Image)(resources.GetObject("tsbParentDir.Image")));
            this.tsbParentDir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbParentDir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbParentDir.Margin = new System.Windows.Forms.Padding(2);
            this.tsbParentDir.Name = "tsbParentDir";
            this.tsbParentDir.Size = new System.Drawing.Size(36, 36);
            this.tsbParentDir.Text = "..";
            this.tsbParentDir.Click += new System.EventHandler(this.tsbParentDir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tstLocation
            // 
            this.tstLocation.BackColor = System.Drawing.SystemColors.Window;
            this.tstLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tstLocation.Name = "tstLocation";
            this.tstLocation.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tstLocation.ReadOnly = true;
            this.tstLocation.Size = new System.Drawing.Size(366, 40);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsbTree
            // 
            this.tsbTree.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTree.Image = ((System.Drawing.Image)(resources.GetObject("tsbTree.Image")));
            this.tsbTree.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbTree.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTree.Margin = new System.Windows.Forms.Padding(2);
            this.tsbTree.Name = "tsbTree";
            this.tsbTree.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbTree.Size = new System.Drawing.Size(36, 36);
            this.tsbTree.Text = "Tree";
            this.tsbTree.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tsbDetails
            // 
            this.tsbDetails.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbDetails.Checked = true;
            this.tsbDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDetails.Image = ((System.Drawing.Image)(resources.GetObject("tsbDetails.Image")));
            this.tsbDetails.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbDetails.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDetails.Margin = new System.Windows.Forms.Padding(2);
            this.tsbDetails.Name = "tsbDetails";
            this.tsbDetails.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbDetails.Size = new System.Drawing.Size(36, 36);
            this.tsbDetails.Text = "Details";
            this.tsbDetails.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tsbIcons
            // 
            this.tsbIcons.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbIcons.Image = ((System.Drawing.Image)(resources.GetObject("tsbIcons.Image")));
            this.tsbIcons.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIcons.Margin = new System.Windows.Forms.Padding(2);
            this.tsbIcons.Name = "tsbIcons";
            this.tsbIcons.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbIcons.Size = new System.Drawing.Size(36, 36);
            this.tsbIcons.Text = "Tiles";
            this.tsbIcons.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tsbArchiveInfo
            // 
            this.tsbArchiveInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbArchiveInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbArchiveInfo.Image")));
            this.tsbArchiveInfo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbArchiveInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbArchiveInfo.Margin = new System.Windows.Forms.Padding(2);
            this.tsbArchiveInfo.Name = "tsbArchiveInfo";
            this.tsbArchiveInfo.Size = new System.Drawing.Size(36, 36);
            this.tsbArchiveInfo.Text = "Archive Information";
            this.tsbArchiveInfo.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textBox2,
            this.toolStripStatusLabel1,
            this.excerptLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 503);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(579, 22);
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(89, 17);
            this.textBox2.Text = "<FileContents>";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "   ";
            // 
            // excerptLabel1
            // 
            this.excerptLabel1.DotsOnLeft = true;
            this.excerptLabel1.Name = "excerptLabel1";
            this.excerptLabel1.Size = new System.Drawing.Size(428, 17);
            this.excerptLabel1.Spring = true;
            this.excerptLabel1.Text = "<ArchivePath>";
            this.excerptLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 525);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tbWorkAreaNum);
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
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "FormMain";
            this.Text = "Dearchiver";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConvert;
        private System.Windows.Forms.Button bWorkingArea;
        private System.Windows.Forms.Button bOpen;
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
        private System.Windows.Forms.MaskedTextBox tbWorkAreaNum;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ImageList ilBottomButtons;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ColumnHeader chSizeCompr;
        private System.Windows.Forms.ColumnHeader chTime;
        private System.Windows.Forms.TreeView tvFiles;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private Microsoft.Samples.TableLayoutToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbTree;
        private System.Windows.Forms.ToolStripButton tsbDetails;
        private System.Windows.Forms.ToolStripButton tsbIcons;
        private System.Windows.Forms.ToolStripButton tsbParentDir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tstLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel textBox2;
        private Piksel.Dearchiver.ToolStripStatusExcerptLabel excerptLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripButton tsbArchiveInfo;
        private System.Windows.Forms.ColumnHeader chTypeName;
        private System.Windows.Forms.ListView lvDetails;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

