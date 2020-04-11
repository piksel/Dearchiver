using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piksel.Dearchiver.Forms
{
    public partial class FormPreview : Form
    {
        enum PreviewType
        {
            Image,
            Text,
            FileInfo
        }

        private PreviewType previewType = PreviewType.Text;
        private byte[] data;
        private Encoding textEncoding = Encoding.UTF8;

        public FormPreview()
        {
            InitializeComponent();
            pException.Left = 6;
            // UpdatePreviewType(PreviewType.Text);

            
            tscbEncoding.Items.Clear();
            foreach(var ei in Encoding.GetEncodings())
            {
                tscbEncoding.Items.Add(new EncodingProxy(ei));
            }

            tscbEncoding.SelectedItem = tscbEncoding.Items
                .Cast<EncodingProxy>()
                .FirstOrDefault(ep => ep.Name == "utf-8");
        }

        public void Show(byte[] data, string fileName, IntPtr icon)
        {
            var fileExt = fileName.Split('.').Last().ToLowerInvariant();

            this.data = data;

            Text = $"{fileName} - Preview";

            switch (fileExt)
            {
                case "dll":
                case "exe":
                    UpdatePreviewType(PreviewType.FileInfo);
                    break;
                case "jpeg":
                case "jpg":
                case "png":
                case "gif":
                    UpdatePreviewType(PreviewType.Image);
                    break;
                case "txt":
                default:
                    UpdatePreviewType(PreviewType.Text);
                    break;
            }

            if(icon != IntPtr.Zero)
            {
                Icon = Icon.FromHandle(icon);
            }

            Show();
            tbTextPreview.Select(0, 0);
        }

        private void UpdatePreviewType(PreviewType type)
        {
            tsmiImagePreview.Checked = type == PreviewType.Image;
            pbImagePreview.Visible = type == PreviewType.Image;
            tsddbImageScaling.Visible = type == PreviewType.Image;

            tsmiTextPreview.Checked = type == PreviewType.Text;
            tbTextPreview.Visible = type == PreviewType.Text;
            tsbWordWrap.Visible = type == PreviewType.Text;
            tscbEncoding.Visible = type == PreviewType.Text;

            tsmiAssemblyPreview.Checked = type == PreviewType.FileInfo;
            lvAssemblyPreview.Visible = type == PreviewType.FileInfo;



            tsddbPreviewType.Text = $"{type} Preview";

            previewType = type;

            pException.Visible = false;

            try
            {
                if (previewType == PreviewType.Text)
                {
                    tbTextPreview.Text = textEncoding.GetString(data);
                }
                else if(previewType == PreviewType.Image)
                {

                    Image img;
                    using (var ms = new MemoryStream(data)) 
                    {
                        img = Image.FromStream(ms, true, true);
                    }
                    if (img == null) throw new Exception("Could not read file data as an image");
                    pbImagePreview.Image = img;

                }
                else if(previewType == PreviewType.FileInfo)
                {
                    lvAssemblyPreview.Items.Clear();

                    var tempFile = Path.GetTempFileName();
                    File.WriteAllBytes(tempFile, data);
                    FileVersionInfo fvi;
                    try
                    {
                        fvi = FileVersionInfo.GetVersionInfo(tempFile);
                    }
                    finally
                    {
                        File.Delete(tempFile);
                    }

                    var fviRows = GetAssemblyInfo(fvi);

                    lvAssemblyPreview.Items.AddRange(fviRows.Select(ai => new ListViewItem(ai)).ToArray());
                }
            }
            catch (Exception x)
            {
                ShowException(x);
            }
        }

        private IEnumerable<string[]> GetAssemblyInfo(FileVersionInfo fvi)
        {
            if (!string.IsNullOrWhiteSpace(fvi.FileDescription))
            {
                yield return new[] { "Description", fvi.FileDescription };
            }

            if (!string.IsNullOrWhiteSpace(fvi.FileVersion))
            {
                yield return new[] { "Version", fvi.FileVersion };
            }

            if (!string.IsNullOrWhiteSpace(fvi.CompanyName))
            {
                yield return new[] { "Company", fvi.CompanyName };
            }

            if (!string.IsNullOrWhiteSpace(fvi.ProductName))
            {
                yield return new[] { "Product", fvi.ProductName };
            }

            if (!string.IsNullOrWhiteSpace(fvi.OriginalFilename))
            {
                yield return new[] { "OriginalFilename", fvi.OriginalFilename };
            }

            if(!string.IsNullOrWhiteSpace(fvi.Comments))
            {
                yield return new string[] { "Comments", fvi.Comments };
            }
        }

        private void ShowException(Exception x)
        {
            lErrorMessage.Text = "";// x.ToString();
            tbStackTrace.Text = x.ToString();
            pException.Visible = true;
            tbTextPreview.Visible = false;
            pbImagePreview.Visible = false;
            lvAssemblyPreview.Visible = false;
        }

        private void previewTypeMenuItem_Click(object sender, EventArgs e)
        {
            if(sender is ToolStripMenuItem tsmi)
            {
                if (tsmi == tsmiImagePreview)
                {
                    UpdatePreviewType(PreviewType.Image);
                }
                else if(tsmi == tsmiTextPreview)
                {
                    UpdatePreviewType(PreviewType.Text);
                }
                else if (tsmi == tsmiAssemblyPreview)
                {
                    UpdatePreviewType(PreviewType.FileInfo);
                }
            }
        }

        private void tsbWordWrap_Click(object sender, EventArgs e)
        {
            tbTextPreview.WordWrap = tsbWordWrap.Checked;
        }

        private void FormPreview_Load(object sender, EventArgs e)
        {
            tbTextPreview.SelectionLength = 0;
        }

        private void tbTextPreview_TextChanged(object sender, EventArgs e)
        {
            tbTextPreview.Select(0, 0);
        }

        private void pbImagePreview_DoubleClick(object sender, EventArgs e)
        {
            SetImageScaling(pbImagePreview.SizeMode == PictureBoxSizeMode.Zoom 
                ? PictureBoxSizeMode.CenterImage
                : PictureBoxSizeMode.Zoom);
        }

        private void SetImageScaling(PictureBoxSizeMode sizeMode)
        {
            if(sizeMode == PictureBoxSizeMode.Zoom)
            {
                tsddbImageScaling.Text = "Scaling: Zoom";
            }
            else
            {
                tsddbImageScaling.Text = "Scaling: Unscaled";
            }

            pbImagePreview.SizeMode = sizeMode;

            tsmiScalingUnscaled.Checked = sizeMode == PictureBoxSizeMode.CenterImage;
            tsmiScalingZoom.Checked = sizeMode == PictureBoxSizeMode.Zoom;
        }

        private void ScalingMenuItem_Click(object sender, EventArgs e)
        {
            if(sender == tsmiScalingUnscaled)
            {
                SetImageScaling(PictureBoxSizeMode.CenterImage);
            }
            else if(sender == tsmiScalingZoom)
            {
                SetImageScaling(PictureBoxSizeMode.Zoom);
            }
        }

        private void EncodingMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tscbEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbEncoding.SelectedItem is EncodingProxy ep 
                && ep.Encoding is Encoding encoding 
                && encoding != textEncoding)
            {
                textEncoding = encoding;

                if (previewType == PreviewType.Text)
                {
                    UpdatePreviewType(previewType);
                }
            }
        }
    }
}
