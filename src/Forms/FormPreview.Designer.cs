namespace Piksel.Dearchiver.Forms
{
    partial class FormPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPreview));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Foo",
            "Bar"}, -1);
            this.tbTextPreview = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbWordWrap = new System.Windows.Forms.ToolStripButton();
            this.tsddbPreviewType = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiTextPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImagePreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAssemblyPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbEncoding = new System.Windows.Forms.ToolStripComboBox();
            this.tsddbImageScaling = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiScalingZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiScalingUnscaled = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pException = new System.Windows.Forms.Panel();
            this.tbStackTrace = new System.Windows.Forms.TextBox();
            this.lErrorMessage = new System.Windows.Forms.Label();
            this.lPreviewError = new System.Windows.Forms.Label();
            this.pbImagePreview = new System.Windows.Forms.PictureBox();
            this.lvAssemblyPreview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pException.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tbTextPreview
            // 
            this.tbTextPreview.BackColor = System.Drawing.SystemColors.Window;
            this.tbTextPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTextPreview.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTextPreview.Location = new System.Drawing.Point(0, 0);
            this.tbTextPreview.Multiline = true;
            this.tbTextPreview.Name = "tbTextPreview";
            this.tbTextPreview.ReadOnly = true;
            this.tbTextPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTextPreview.Size = new System.Drawing.Size(804, 426);
            this.tbTextPreview.TabIndex = 0;
            this.tbTextPreview.TextChanged += new System.EventHandler(this.tbTextPreview_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbWordWrap,
            this.tsddbPreviewType,
            this.tscbEncoding,
            this.tsddbImageScaling});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbWordWrap
            // 
            this.tsbWordWrap.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbWordWrap.Checked = true;
            this.tsbWordWrap.CheckOnClick = true;
            this.tsbWordWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbWordWrap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbWordWrap.Image = ((System.Drawing.Image)(resources.GetObject("tsbWordWrap.Image")));
            this.tsbWordWrap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbWordWrap.Name = "tsbWordWrap";
            this.tsbWordWrap.Size = new System.Drawing.Size(69, 22);
            this.tsbWordWrap.Text = "Word wrap";
            this.tsbWordWrap.Click += new System.EventHandler(this.tsbWordWrap_Click);
            // 
            // tsddbPreviewType
            // 
            this.tsddbPreviewType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbPreviewType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTextPreview,
            this.tsmiImagePreview,
            this.tsmiAssemblyPreview});
            this.tsddbPreviewType.Image = ((System.Drawing.Image)(resources.GetObject("tsddbPreviewType.Image")));
            this.tsddbPreviewType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbPreviewType.Name = "tsddbPreviewType";
            this.tsddbPreviewType.Size = new System.Drawing.Size(85, 22);
            this.tsddbPreviewType.Text = "Text preview";
            // 
            // tsmiTextPreview
            // 
            this.tsmiTextPreview.Checked = true;
            this.tsmiTextPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiTextPreview.Name = "tsmiTextPreview";
            this.tsmiTextPreview.Size = new System.Drawing.Size(169, 22);
            this.tsmiTextPreview.Text = "Text preview";
            this.tsmiTextPreview.Click += new System.EventHandler(this.previewTypeMenuItem_Click);
            // 
            // tsmiImagePreview
            // 
            this.tsmiImagePreview.Name = "tsmiImagePreview";
            this.tsmiImagePreview.Size = new System.Drawing.Size(169, 22);
            this.tsmiImagePreview.Text = "Image preview";
            this.tsmiImagePreview.Click += new System.EventHandler(this.previewTypeMenuItem_Click);
            // 
            // tsmiAssemblyPreview
            // 
            this.tsmiAssemblyPreview.Name = "tsmiAssemblyPreview";
            this.tsmiAssemblyPreview.Size = new System.Drawing.Size(180, 22);
            this.tsmiAssemblyPreview.Text = "FileInfo preview";
            this.tsmiAssemblyPreview.Click += new System.EventHandler(this.previewTypeMenuItem_Click);
            // 
            // tscbEncoding
            // 
            this.tscbEncoding.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscbEncoding.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tscbEncoding.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tscbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbEncoding.Name = "tscbEncoding";
            this.tscbEncoding.Size = new System.Drawing.Size(260, 25);
            this.tscbEncoding.SelectedIndexChanged += new System.EventHandler(this.tscbEncoding_SelectedIndexChanged);
            // 
            // tsddbImageScaling
            // 
            this.tsddbImageScaling.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsddbImageScaling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbImageScaling.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiScalingZoom,
            this.tsmiScalingUnscaled});
            this.tsddbImageScaling.Image = ((System.Drawing.Image)(resources.GetObject("tsddbImageScaling.Image")));
            this.tsddbImageScaling.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbImageScaling.Name = "tsddbImageScaling";
            this.tsddbImageScaling.Size = new System.Drawing.Size(96, 22);
            this.tsddbImageScaling.Text = "Scaling: Zoom";
            // 
            // tsmiScalingZoom
            // 
            this.tsmiScalingZoom.Checked = true;
            this.tsmiScalingZoom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiScalingZoom.Name = "tsmiScalingZoom";
            this.tsmiScalingZoom.Size = new System.Drawing.Size(122, 22);
            this.tsmiScalingZoom.Text = "Zoom";
            this.tsmiScalingZoom.Click += new System.EventHandler(this.ScalingMenuItem_Click);
            // 
            // tsmiScalingUnscaled
            // 
            this.tsmiScalingUnscaled.Name = "tsmiScalingUnscaled";
            this.tsmiScalingUnscaled.Size = new System.Drawing.Size(122, 22);
            this.tsmiScalingUnscaled.Text = "Unscaled";
            this.tsmiScalingUnscaled.Click += new System.EventHandler(this.ScalingMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lvAssemblyPreview);
            this.panel1.Controls.Add(this.pException);
            this.panel1.Controls.Add(this.pbImagePreview);
            this.panel1.Controls.Add(this.tbTextPreview);
            this.panel1.Location = new System.Drawing.Point(-3, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 428);
            this.panel1.TabIndex = 3;
            // 
            // pException
            // 
            this.pException.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pException.Controls.Add(this.tbStackTrace);
            this.pException.Controls.Add(this.lErrorMessage);
            this.pException.Controls.Add(this.lPreviewError);
            this.pException.Location = new System.Drawing.Point(2, 1);
            this.pException.Name = "pException";
            this.pException.Size = new System.Drawing.Size(800, 424);
            this.pException.TabIndex = 2;
            this.pException.Visible = false;
            // 
            // tbStackTrace
            // 
            this.tbStackTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStackTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStackTrace.Location = new System.Drawing.Point(21, 69);
            this.tbStackTrace.Margin = new System.Windows.Forms.Padding(6);
            this.tbStackTrace.Multiline = true;
            this.tbStackTrace.Name = "tbStackTrace";
            this.tbStackTrace.ReadOnly = true;
            this.tbStackTrace.Size = new System.Drawing.Size(764, 340);
            this.tbStackTrace.TabIndex = 2;
            this.tbStackTrace.Text = "(Stacktrace)";
            // 
            // lErrorMessage
            // 
            this.lErrorMessage.AutoSize = true;
            this.lErrorMessage.Location = new System.Drawing.Point(18, 44);
            this.lErrorMessage.Margin = new System.Windows.Forms.Padding(6);
            this.lErrorMessage.Name = "lErrorMessage";
            this.lErrorMessage.Size = new System.Drawing.Size(81, 13);
            this.lErrorMessage.TabIndex = 1;
            this.lErrorMessage.Text = "(Error Message)";
            // 
            // lPreviewError
            // 
            this.lPreviewError.AutoSize = true;
            this.lPreviewError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPreviewError.Location = new System.Drawing.Point(18, 19);
            this.lPreviewError.Margin = new System.Windows.Forms.Padding(6);
            this.lPreviewError.Name = "lPreviewError";
            this.lPreviewError.Size = new System.Drawing.Size(114, 13);
            this.lPreviewError.TabIndex = 0;
            this.lPreviewError.Text = "File preview failed!";
            // 
            // pbImagePreview
            // 
            this.pbImagePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImagePreview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pbImagePreview.Location = new System.Drawing.Point(2, 0);
            this.pbImagePreview.Name = "pbImagePreview";
            this.pbImagePreview.Size = new System.Drawing.Size(800, 425);
            this.pbImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagePreview.TabIndex = 1;
            this.pbImagePreview.TabStop = false;
            this.pbImagePreview.DoubleClick += new System.EventHandler(this.pbImagePreview_DoubleClick);
            // 
            // lvAssemblyPreview
            // 
            this.lvAssemblyPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAssemblyPreview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvAssemblyPreview.FullRowSelect = true;
            this.lvAssemblyPreview.GridLines = true;
            this.lvAssemblyPreview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvAssemblyPreview.HideSelection = false;
            this.lvAssemblyPreview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3});
            this.lvAssemblyPreview.Location = new System.Drawing.Point(1, -2);
            this.lvAssemblyPreview.MultiSelect = false;
            this.lvAssemblyPreview.Name = "lvAssemblyPreview";
            this.lvAssemblyPreview.ShowGroups = false;
            this.lvAssemblyPreview.Size = new System.Drawing.Size(798, 426);
            this.lvAssemblyPreview.TabIndex = 28;
            this.lvAssemblyPreview.UseCompatibleStateImageBehavior = false;
            this.lvAssemblyPreview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 450;
            // 
            // FormPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormPreview";
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.FormPreview_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pException.ResumeLayout(false);
            this.pException.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTextPreview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbWordWrap;
        private System.Windows.Forms.ToolStripDropDownButton tsddbPreviewType;
        private System.Windows.Forms.ToolStripMenuItem tsmiTextPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmiImagePreview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbImagePreview;
        private System.Windows.Forms.Panel pException;
        private System.Windows.Forms.TextBox tbStackTrace;
        private System.Windows.Forms.Label lErrorMessage;
        private System.Windows.Forms.Label lPreviewError;
        private System.Windows.Forms.ToolStripDropDownButton tsddbImageScaling;
        private System.Windows.Forms.ToolStripMenuItem tsmiScalingZoom;
        private System.Windows.Forms.ToolStripMenuItem tsmiScalingUnscaled;
        private System.Windows.Forms.ToolStripComboBox tscbEncoding;
        private System.Windows.Forms.ListView lvAssemblyPreview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem tsmiAssemblyPreview;
    }
}