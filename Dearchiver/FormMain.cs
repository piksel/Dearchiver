using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace Piksel.Dearchiver
{
    public partial class FormMain : Form
    {
        const string defaultWorkAreaPath = @"C:\Work";

        private Extractor Extractor;
        private ushort currWaNum = 0;
        private bool useWorkingArea;
        private string extArchiverPath; 
        private string extArchiverName;
        private string extArchiverArgs = "%1";

        private Properties.Settings Settings { get; } = Properties.Settings.Default;

        public string WorkingAreaPath() => Path.Combine(Settings.WorkingAreaBasePath, currWaNum.ToString("d3"));

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            UpdateWorkAreaControls();

            var args = Environment.GetCommandLineArgs();
            if (args.Length>1)
            {
                var inputFile = Path.GetFullPath(args[1]);
                if(!File.Exists(inputFile))
                {
                    MessageBox.Show($"Input file \"{inputFile}\" does not exist!",
    "Dearchiver", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    Close();
                    return;
                }
                Extractor = new Extractor(this, inputFile)
                {
                    ButtonCallback = extracting =>
                    {
                        lFileName.Visible = extracting;
                        lPercent.Visible = extracting;
                        pbExtraction.Visible = extracting;
                        bCancel.Visible = extracting;

                        bConvert.Visible = !extracting;
                        bWorkingArea.Visible = !extracting;
                        bOpen.Visible = !extracting;
                    },
                    ProgressCallback = progress =>
                    {
                        var percent = (int)progress;
                        pbExtraction.Value = percent;
                        lPercent.Text = progress.ToString("F1") + "%";
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal, Handle);
                        TaskbarManager.Instance.SetProgressValue(percent, 100);

                    },
                    FilenameCallback = file =>
                    {
                        lFileName.Text = file;
                    },
                    CompletionCallback = deleteArchive =>
                    {
                        lFileName.Text = "Done!";


                        new Thread(() =>
                        {
                            if(deleteArchive)
                            {
                                int attempts = 0;
                                do
                                {
                                    try
                                    {
                                        File.Delete(Extractor.ArchiveFile);
                                        break;
                                    }
                                    catch
                                    {
                                        Thread.Sleep(500);
                                    }
                                }
                                while (attempts++ <= 6);

                                if(attempts >= 6)
                                {
                                    MessageBox.Show($"Failed to delete archive \"{Extractor.ArchiveName}\"", "Failed to delete archive", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                }
                            }

                            if (Settings.OpenFolderAfterExtract)
                                Extractor.OpenOutputDirectory();

                            if (Settings.CloseAppAfterExtract)
                                Close();

                        }).Start();
                    }
                };

                var archiveName = Extractor.ArchiveName;
                Text = archiveName + " - Dearchiver";

                excerptLabel1.Text = Extractor.ArchivePath;
                toolTip1.SetToolTip(excerptLabel1, Extractor.ArchivePath);
                textBox2.Text = $"{Extractor.FileCount} file(s) in {Extractor.DirCount} folder(s).";
                lArchiveRootDirs.Text = $"Root folders: {Extractor.RootDirCount} folder(s), single root archive: {Extractor.SingleRoot}.";
                lArchiveCompression.Text = $"Compresssion rate: {Extractor.CompressionRate:F2}%";

                /*
                tbInfo.AppendText($"Archive name: {archiveName}\r\n");
                tbInfo.AppendText($"Archive path: {Extractor.ArchivePath}\r\n");
                tbInfo.AppendText($"Content: {Extractor.FileCount} file(s) in {Extractor.DirCount} folder(s).\r\n");
                tbInfo.AppendText($"Root folders: {Extractor.RootDirCount} folder(s), single root archive: {Extractor.SingleRoot}.\r\n");
                tbInfo.AppendText($"Compresssion rate: {Extractor.CompressionRate:F2}%\r\n");
                if (!string.IsNullOrEmpty(Extractor.ArchiveComment))
                    tbInfo.AppendText($"Comment: {Extractor.ArchiveComment}\r\n");
                    */

                UpdateExtArchiver();

                BindTooltips();

            }
        }

        private void UpdateExtArchiver()
        {
            string extIconFile = null;

            if (Settings.ExternalArchiverAutomatic)
            {

                var rk7z = Registry.CurrentUser.OpenSubKey(@"Software\7-Zip");
                if (rk7z != null)
                {
                    var path_raw = rk7z.GetValue("Path", "");

                    if (path_raw is string path && !string.IsNullOrEmpty(path))
                    {
                        extArchiverPath = Path.Combine(path, "7zFM.exe");
                        extArchiverName = "7-Zip";
                        extArchiverArgs = "\"%1\"";
                    }
                }

                if (string.IsNullOrEmpty(extArchiverPath))
                {
                    extArchiverPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "explorer.exe");
                    extArchiverName = "Explorer";
                    extArchiverArgs = "\"%1\"";
                    extIconFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "zipfldr.dll");
                }

            }
            else
            {
                extArchiverPath = Settings.ExternalArchiverPath;
                extArchiverArgs = Settings.ExternalArchiverArgs;
                extArchiverName = Settings.ExternalArchiverName;
            }

            if (string.IsNullOrEmpty(extIconFile))
                extIconFile = extArchiverPath;

            bOpen.Image = IconExtractor.GetIcon(extIconFile, 48)?.ToBitmap() ?? Properties.Resources.missing;
            bOpen.Text = $"{bOpen.Tag} {extArchiverName}";

        }

        private void BindTooltips()
        {
            /*
            foreach (Control ctrl in Controls)
            {
                if (!(ctrl is LinkLabel || ctrl.Tag is string))
                    continue;
                
                ctrl.MouseHover += (o, ea) 
                    =>  toolTip1.SetToolTip(ctrl, ctrl.Tag.ToString());
            }
            */
        }

        private void UpdateWorkAreaControls()
        {
            var haveWA = !string.IsNullOrEmpty(Settings.WorkingAreaBasePath);
            if (haveWA)
            {
                currWaNum = 0;
                foreach (var dir in Directory.GetDirectories(Settings.WorkingAreaBasePath))
                {
                    if(ushort.TryParse(Path.GetFileName(dir), out ushort waNum))
                    {
                        currWaNum = Math.Max(waNum, currWaNum);
                    }
                }
                tbWorkAreaNum.Text = currWaNum.ToString("d3");
                var waPath = WorkingAreaPath();
                linkLabel1.Tag = waPath;
                toolTip1.SetToolTip(linkLabel1, waPath);

                if (currWaNum == 0)
                {
                    IncrementWorkAreaNum();
                }
            }
            else
            {
                toolTip1.SetToolTip(linkLabel1, "No working area base path has been set.\nClick to set it!");
            }

            tbWorkAreaNum.Enabled = haveWA;
            bIncWrkArea.Enabled = haveWA;
        }

        private void BeginExtraction(bool useWorkingArea = false)
        {
            var archiveFile = Extractor.ArchiveFile;

            string outDir = null;
            bool deleteAfterExtract = false;

            if (useWorkingArea)
            {
                if (!WorkAreaPromptSet())
                    return;

                outDir = WorkingAreaPath();

                if (Extractor.SingleRoot)
                {
                    // Add a root folder using the archives name if theres more than one root object
                    outDir = Path.Combine(outDir, Path.GetFileNameWithoutExtension(archiveFile));
                }

                deleteAfterExtract = Settings.ExtWADeleteArchAfterExtract;
            }
            else
            {
                outDir = Path.Combine(Path.GetDirectoryName(archiveFile),
                    Path.GetFileNameWithoutExtension(archiveFile));

                deleteAfterExtract = Settings.ConvertDeleteArchAfterExtract;
            }

            this.useWorkingArea = useWorkingArea;

            Extractor.Extract(outDir, deleteAfterExtract);
        }

        private bool WorkAreaPromptSet()
        {
            if (string.IsNullOrEmpty(Settings.WorkingAreaBasePath))
            {
                switch (MessageBox.Show(this,
                    $"No working area base path selected.\nDo you want to use the default path \"{defaultWorkAreaPath}\"?",
                    "Dearchiver - Working area base path", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.Yes:
                        Settings.WorkingAreaBasePath = defaultWorkAreaPath;
                        break;
                    case DialogResult.No:
                        if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
                        {
                            Settings.WorkingAreaBasePath = folderBrowserDialog1.SelectedPath;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                }
                Settings.Save(); // If we got here without returning false we have a setting to save.
                UpdateWorkAreaControls();
            }
            return true;
        }

        private void IncrementWorkAreaNum()
        {
            currWaNum++;
            Directory.CreateDirectory(WorkingAreaPath());
            UpdateWorkAreaControls();
        }

        private void bConvert_Click(object sender, EventArgs e) 
            => BeginExtraction(false);

        private void bWorkingArea_Click(object sender, EventArgs e) 
            => BeginExtraction(true);

        private void bSettings_Click(object sender, EventArgs e) 
            => new FormSettings().ShowDialog(this);

        private void bIncWrkArea_Click(object sender, EventArgs e)
            => IncrementWorkAreaNum();

        private void bCancel_Click(object sender, EventArgs e)
        {
            Extractor.Cancel();
            bCancel.Enabled = false;
        }

        private void bOpen_Click(object sender, EventArgs e)
        {

            if (File.Exists(extArchiverPath))
            {
                Process.Start(extArchiverPath, $"\"{Extractor.ArchiveFile}\"");
            }
            
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {

        }

        private void LinkLabelLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (sender == linkLabel1 && linkLabel1.Tag == null)
            {
                WorkAreaPromptSet();
                return;
            }

            if (sender is LinkLabel ll && ll.Tag is string url)
            {
                Process.Start(url);
            }
        }
    }
}
