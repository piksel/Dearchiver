namespace Piksel.Dearchiver.Forms
{
    partial class FormInstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInstall));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bBrowse = new System.Windows.Forms.Button();
            this.bInstall = new System.Windows.Forms.Button();
            this.tbInstallPath = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.bOpenArchive = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbDropAccepted = new System.Windows.Forms.GroupBox();
            this.pbDropMessage = new System.Windows.Forms.PictureBox();
            this.lDropTarget = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbDropAccepted.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDropMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(-4, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(472, 176);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(4, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 158);
            this.panel1.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(461, 160);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.bBrowse);
            this.tabPage1.Controls.Add(this.bInstall);
            this.tabPage1.Controls.Add(this.tbInstallPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(453, 131);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Install Options";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(19, 100);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(126, 13);
            this.linkLabel1.TabIndex = 30;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Show portable options";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Note: Installing is optional.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Install path:";
            // 
            // bBrowse
            // 
            this.bBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bBrowse.Location = new System.Drawing.Point(375, 31);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(59, 22);
            this.bBrowse.TabIndex = 28;
            this.bBrowse.Text = "...";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // bInstall
            // 
            this.bInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bInstall.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bInstall.Location = new System.Drawing.Point(327, 79);
            this.bInstall.Name = "bInstall";
            this.bInstall.Size = new System.Drawing.Size(107, 37);
            this.bInstall.TabIndex = 25;
            this.bInstall.Text = "Install";
            this.bInstall.UseVisualStyleBackColor = true;
            this.bInstall.Click += new System.EventHandler(this.bInstall_Click);
            // 
            // tbInstallPath
            // 
            this.tbInstallPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInstallPath.Location = new System.Drawing.Point(22, 32);
            this.tbInstallPath.Name = "tbInstallPath";
            this.tbInstallPath.Size = new System.Drawing.Size(338, 22);
            this.tbInstallPath.TabIndex = 26;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.linkLabel2);
            this.tabPage2.Controls.Add(this.bOpenArchive);
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(453, 131);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Portable Usage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(19, 100);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(106, 13);
            this.linkLabel2.TabIndex = 31;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Back to installation";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // bOpenArchive
            // 
            this.bOpenArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bOpenArchive.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOpenArchive.Location = new System.Drawing.Point(327, 79);
            this.bOpenArchive.Name = "bOpenArchive";
            this.bOpenArchive.Size = new System.Drawing.Size(107, 37);
            this.bOpenArchive.TabIndex = 14;
            this.bOpenArchive.Text = "Open archive";
            this.bOpenArchive.UseVisualStyleBackColor = true;
            this.bOpenArchive.Click += new System.EventHandler(this.bOpenArchive_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(22, 21);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.ShortcutsEnabled = false;
            this.richTextBox1.Size = new System.Drawing.Size(283, 62);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "Portable methods:\n - Open Dearchiver.exe with a .zip-file as its first argument\n " +
    "- Drop an archive onto this window\n - Click the button to the right";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(453, 131);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Installation";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::Piksel.Dearchiver.Properties.Resources.dearchiver_logo_opened;
            this.pictureBox2.Location = new System.Drawing.Point(240, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(209, 111);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dearchiver Installer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Piksel.Dearchiver.Properties.Resources.dearchiver_logo;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(209, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // gbDropAccepted
            // 
            this.gbDropAccepted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDropAccepted.Controls.Add(this.pbDropMessage);
            this.gbDropAccepted.Controls.Add(this.lDropTarget);
            this.gbDropAccepted.Location = new System.Drawing.Point(455, 9);
            this.gbDropAccepted.Name = "gbDropAccepted";
            this.gbDropAccepted.Padding = new System.Windows.Forms.Padding(10);
            this.gbDropAccepted.Size = new System.Drawing.Size(437, 323);
            this.gbDropAccepted.TabIndex = 13;
            this.gbDropAccepted.TabStop = false;
            this.gbDropAccepted.Visible = false;
            // 
            // pbDropMessage
            // 
            this.pbDropMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbDropMessage.Image = global::Piksel.Dearchiver.Properties.Resources.dearchiver_logo_opened;
            this.pbDropMessage.Location = new System.Drawing.Point(10, 25);
            this.pbDropMessage.Name = "pbDropMessage";
            this.pbDropMessage.Size = new System.Drawing.Size(417, 206);
            this.pbDropMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDropMessage.TabIndex = 15;
            this.pbDropMessage.TabStop = false;
            // 
            // lDropTarget
            // 
            this.lDropTarget.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lDropTarget.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDropTarget.Location = new System.Drawing.Point(10, 152);
            this.lDropTarget.Name = "lDropTarget";
            this.lDropTarget.Size = new System.Drawing.Size(417, 161);
            this.lDropTarget.TabIndex = 14;
            this.lDropTarget.Text = "Open archive with dearchiver";
            this.lDropTarget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "zip";
            this.openFileDialog1.Filter = "Zip files|*.zip|All files|*.*";
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            this.openFileDialog1.Title = "Open archive...";
            // 
            // FormInstall
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(462, 344);
            this.Controls.Add(this.gbDropAccepted);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormInstall";
            this.Text = "Dearchiver Installer";
            this.Load += new System.EventHandler(this.FormInstall_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormInstall_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.FormInstall_DragOver);
            this.DragLeave += new System.EventHandler(this.FormInstall_DragLeave);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbDropAccepted.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDropMessage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbDropAccepted;
        private System.Windows.Forms.Label lDropTarget;
        private System.Windows.Forms.PictureBox pbDropMessage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.Button bInstall;
        private System.Windows.Forms.TextBox tbInstallPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button bOpenArchive;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage tabPage3;
    }
}