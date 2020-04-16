using Ionic.Utils;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Piksel.Dearchiver.Forms
{
    public partial class FormInstall : Form
    {
        public FormInstall()
        {
            InitializeComponent();

            gbDropAccepted.Left = 12;
            //gbDropAccepted.Dock = DockStyle.Fill;

            tabControl1.Top = -30;
            Height = 360;

#if !PORTABLE_APP
            tabControl1.SelectTab(1);
            rtbUsage.Lines[0] = "Usage:";
            Text = lTitle.Text = "Dearchiver";
            llBackToInstall.Visible = false;
#endif
        }

        private void FormInstall_DragOver(object sender, DragEventArgs e)
        {
            var accept = e.Data.GetDataPresent(DataFormats.FileDrop, false);

            e.Effect = accept ? DragDropEffects.Copy : DragDropEffects.None;
            gbDropAccepted.Visible = true;

            lDropTarget.Text = accept ? "Open archive with dearchiver" : "Invalid drop type!";
            pbDropMessage.Enabled = accept;

        }

        private void FormInstall_Load(object sender, EventArgs e)
        {
            tbInstallPath.Text = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "dearchiver");
        }

        private void FormInstall_DragLeave(object sender, EventArgs e)
        {
            gbDropAccepted.Visible = false;
        }

        private void FormInstall_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);

            if (data is string[] files)
            {
                foreach (var file in files)
                {
                    Program.OpenArchive(file);
                }

                Close();
            }
            else
            {
                lDropTarget.Text = "Invalid drop!";
            }
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            var fbdx = new FolderBrowserDialogEx();
            fbdx.SelectedPath = tbInstallPath.Text;
            fbdx.ShowEditBox = true;
            fbdx.ShowFullPathInEditBox = true;
            fbdx.ShowNewFolderButton = true;
            

            if (fbdx.ShowDialog(this) == DialogResult.OK)
            {
                tbInstallPath.Text = fbdx.SelectedPath;
            }
        }

        private void bOpenArchive_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                foreach (var file in openFileDialog1.FileNames)
                {
                    Program.OpenArchive(file);
                }

                Close();
            }

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectTab(1);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectTab(0);
        }

        private void bInstall_Click(object sender, EventArgs e)
        {
            var currentFile = Process.GetCurrentProcess().MainModule.FileName;
            var newFile = Path.Combine(tbInstallPath.Text, Path.GetFileName(currentFile));

            Directory.CreateDirectory(tbInstallPath.Text);

            File.Copy(currentFile, newFile, true);

            var classesRoot = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Classes", true);

            var pidKey = classesRoot.CreateSubKey(Program.ProgID);

            pidKey.SetValue("", "ZIP Archive");

            var iconKey = pidKey.CreateSubKey("DefaultIcon");
            iconKey.SetValue("", $"{newFile},0");

            classesRoot
                .CreateSubKey(".zip")
                .CreateSubKey("OpenWithProgids")
                .SetValue(Program.ProgID, "");

            Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts", true)
                .CreateSubKey(".zip")
                .CreateSubKey("OpenWithProgids")
                .SetValue(Program.ProgID, new byte[0], RegistryValueKind.None);

            MessageBox.Show("Dearchiver was installed and should now be listed as a zip file handler.", "Installed!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
