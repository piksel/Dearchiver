using Microsoft.Win32;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Piksel.Dearchiver.Helpers;
using Piksel.Dearchiver.Settings;
using Ionic.Utils;
using Piksel.Dearchiver.Forms;

namespace Piksel.Dearchiver
{
    public partial class FormMain : Form
    {
        private const string defaultWorkAreaPath = @"C:\Work";

        private Extractor Extractor;
        private ushort currWaNum = 0;
        private bool useWorkingArea;
        private string extArchiverPath; 
        private string extArchiverName;
        private string extArchiverArgs = "%1";
        private Extractor.DirectoryWindow directoryWindow;
        private readonly SystemImageList systemImageList;
        private TreeNode rootNode;
        private int directoryIconIndex;

        private Properties.Settings Settings { get; } = Properties.Settings.Default;

        public string WorkingAreaPath() => Path.Combine(Settings.WorkingAreaBasePath, currWaNum.ToString("d3"));

        public FormMain()
        {
            InitializeComponent();

            lvFiles.Dock = DockStyle.Fill;
            tvFiles.Dock = DockStyle.Fill;
            lvDetails.Dock = DockStyle.Fill;
            tvFiles.Visible = false;

            lvDetails.Visible = false;

            systemImageList = new SystemImageList(IconExtractor.ShellImageListSize.Small,
                IconExtractor.ShellImageListSize.ExtraLarge);

            systemImageList.UpdateImageLists(lvFiles);
            systemImageList.UpdateImageLists(tvFiles);

            //listView2.Columns[0].TextAlign = HorizontalAlignment.Right;

            folderBrowserDialog = new FolderBrowserDialogEx();
            folderBrowserDialog.NewStyle = true;
            folderBrowserDialog.ShowFullPathInEditBox = true;
            
            folderBrowserDialog.ShowEditBox = true;
            folderBrowserDialog.ShowNewFolderButton = true;

            tlpActionButtons.Height = 100;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateWorkAreaControls();

                var args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                {
                    var inputFile = Path.GetFullPath(args[1]);
                    if (!File.Exists(inputFile))
                    {
                        MessageBox.Show($"Input file \"{inputFile}\" does not exist!",
                            "Dearchiver", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error, 
                            MessageBoxDefaultButton.Button1);
                        Close();
                        return;
                    }

                    UpdateExtArchiver();

                    Extractor = new Extractor(this, inputFile)
                    {
                        ButtonCallback = extracting =>
                        {
                            lFileName.Visible = extracting;
                            lPercent.Visible = extracting;
                            pbExtraction.Visible = extracting;
                            bCancel.Visible = extracting;

                            tlpActionButtons.Visible = !extracting;
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
                        CompletionCallback = close =>
                        {
                            lFileName.Text = "Done!";
                            pbExtraction.Value = pbExtraction.Maximum;
                            lPercent.Visible = false;
                            bCancel.Enabled = false;

                            if (close) Close();
                        }
                    };

                    var archiveName = Extractor.ArchiveName;
                    Text = archiveName + " - Dearchiver";

                    excerptLabel1.Text = Extractor.ArchivePath;
                    toolTipHandler.SetToolTip(statusStrip, Extractor.ArchivePath);
                    textBox2.Text = $"{Extractor.FileCount} file(s) in {Extractor.DirCount} folder(s).";

                    directoryWindow = Extractor.GetRootWindow();

                    rootNode = GetTreeNode(NodeInfo.CreateRootNode(archiveName, directoryWindow.Contents));
                    directoryIconIndex = IconExtractor.GetFileIconIndex("", FileAttributes.Directory);

                    UpdateDirectoryListing();

                    tvFiles.Nodes.Clear();

                    tvFiles.Nodes.Add(rootNode);

                    rootNode.Expand();

                    //tbInfo.AppendText(Extractor.GetDetails());
                    lvDetails.Items.Clear();
                    lvDetails.Items.AddRange(Extractor.GetDetails().Select(sa => new ListViewItem(sa)).ToArray());
                }
            }
            catch (Exception x)
            {
                Visible = false;
                if (MessageBox.Show("Could not open archive:\n" + x.Message, "Dearchiver", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Close();
                }
            }
        }

        private void UpdateDirectoryListing()
        {

            lvFiles.Invoke(() =>
            {
                using (lvFiles.UpdateToken())
                {

                    lvFiles.Items.Clear();

                    if (!directoryWindow.InRoot)
                        lvFiles.Items.Add("..", directoryIconIndex);

                    directoryWindow.Contents
                        .Select(NodeInfo.FromNode)
                        .Select(GetListViewItemFromEntry)
                        .ForEach(lvi => lvFiles.Items.Add(lvi));

                }
            });

            tsbParentDir.Enabled = !directoryWindow.InRoot;

            tstLocation.Text = directoryWindow.CurrentPath;
        }

        const int maxChildNodes = 20;

        private TreeNode GetTreeNode(NodeInfo nodeInfo)
        {
            if (nodeInfo.Node.IsDirectory)
            {
                var childNodes = (nodeInfo.ChildNodes.Count() > maxChildNodes
                    ? nodeInfo.ChildNodes.TakeWhile((_, i) => i < maxChildNodes)
                        .Concat(new[] { Extractor.DirectoryWindow.EntryNode.EllipsisNode })
                    : nodeInfo.ChildNodes)
                    .Select(NodeInfo.FromNode).Select(GetTreeNode);

                return new TreeNode(nodeInfo.Name, nodeInfo.IconIndex, nodeInfo.IconIndex, 
                    childNodes.ToArray());
            }
            else
            {
                return new TreeNode(nodeInfo.Name, nodeInfo.IconIndex, nodeInfo.IconIndex);
            }
        }

        private ListViewItem GetListViewItemFromEntry(NodeInfo fileInfo)
        {
            return new ListViewItem(new[] {
                fileInfo.Name,
                fileInfo.FileSize,
                fileInfo.TypeName,
                fileInfo.CompressedSize,
                fileInfo.DateTime,
                fileInfo.Node.IsDirectory ? "d" : "f"
            }, fileInfo.IconIndex);
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

        private void UpdateWorkAreaControls()
        {
            var haveWA = !string.IsNullOrEmpty(Settings.WorkingAreaBasePath);
            if (haveWA)
            {
                Directory.CreateDirectory(Settings.WorkingAreaBasePath);

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
                toolTipHandler.SetToolTip(linkLabel1, waPath);

                if (currWaNum == 0)
                {
                    IncrementWorkAreaNum();
                }
            }
            else
            {
                toolTipHandler.SetToolTip(linkLabel1, "No working area base path has been set.\nClick to set it!");
            }

            tbWorkAreaNum.Enabled = haveWA;
            bIncWrkArea.Enabled = haveWA;
        }

        private void BeginExtraction(bool useWorkingArea = false, string launchTarget = null)
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

            BeginExtraction(outDir, deleteAfterExtract, launchTarget);
        }

        private void BeginExtraction(string outDir, bool deleteAfterExtract, string launchTarget = null)
        {
            var postActions = PostExtractActions.None;
            if (launchTarget != null)
            {
                postActions |= PostExtractActions.Launch;
            }
            else
            {
                if (Settings.CloseAppAfterExtract) postActions |= PostExtractActions.Close;
                if (Settings.OpenFolderAfterExtract) postActions |= PostExtractActions.Open;
                if (deleteAfterExtract) postActions |= PostExtractActions.Delete;
            }

            Extractor.Extract(outDir, postActions, launchTarget);
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
                        var fbd = new FolderBrowserDialogEx
                        {
                            NewStyle = true,
                            ShowFullPathInEditBox = true,

                            ShowEditBox = true,
                            ShowNewFolderButton = true,
                            Description = "Select work area path"
                        };
                        
                        if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
                        {
                            Settings.WorkingAreaBasePath = folderBrowserDialog.SelectedPath;
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
        {
            if(new FormSettings().ShowDialog(this) == DialogResult.OK)
            {
                UpdateWorkAreaControls();
            }

        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            lvFiles.View = (View)((1 + (int)lvFiles.View) % 4);
            //button1.Text = listView1.View.ToString();
        }

        private void lvFiles_MouseDoubleClick(object sender, MouseEventArgs e) => ArchiveItemDefaultAction();

        private void ArchiveItemDefaultAction()
        {
            if (lvFiles.SelectedItems.Count < 1) return;
            var si = lvFiles.SelectedItems[0];

            var target = si.SubItems[0].Text;
            if (target == "..")
            {
                directoryWindow.Ascend();
            }
            else
            {
                if (si.SubItems[5].Text == "d")
                {
                    directoryWindow.Descend(target);
                }
                else
                {
                    var data = directoryWindow.ExtractItemInCurrentPath(target);
                    var previewForm = new FormPreview();

                    IntPtr icon = IntPtr.Zero;
                    systemImageList.Large.GetIcon(si.ImageIndex, 0, ref icon);

                    previewForm.Show(data, target, icon);
                    return;
                }
            }
            UpdateDirectoryListing();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tsbTree.Checked = sender == tsbTree;
            tvFiles.Visible = sender == tsbTree;

            lvFiles.Visible = sender == tsbDetails || sender == tsbIcons;
            tsbDetails.Checked = sender == tsbDetails;
            tsbIcons.Checked = sender == tsbIcons;

            if (sender == tsbDetails) lvFiles.View = View.Details;
            if (sender == tsbIcons) lvFiles.View = View.Tile;

            tsbArchiveInfo.Checked = sender == tsbArchiveInfo;
            lvDetails.Visible = sender == tsbArchiveInfo;

            tsbParentDir.Enabled = lvFiles.Visible && !directoryWindow.InRoot;

        }

        private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //e.Node.ImageKey = "dir-open";
            //e.Node.SelectedImageKey = e.Node.ImageKey;
        }

        private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            //e.Node.ImageKey = "dir";
            //e.Node.SelectedImageKey = e.Node.ImageKey;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var dirNode = e.Node.Parent ?? rootNode;
            tstLocation.Text = dirNode.FullPath.Substring(rootNode.Text.Length) + "/";
        }

        private void tsbParentDir_Click(object sender, EventArgs e)
        {
            if (!directoryWindow.InRoot)
            {
                directoryWindow.Ascend();
                UpdateDirectoryListing();
            }
        }

        private void extractTonewWorkAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncrementWorkAreaNum();
            BeginExtraction(true);
        }

        private void extractTopathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialogEx
            {
                NewStyle = true,
                ShowFullPathInEditBox = true,

                ShowEditBox = true,
                ShowNewFolderButton = true,
                Description = "Extract to path..."
            };

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                BeginExtraction(fbd.SelectedPath, false);
            }
        }

        private void cmsArchiveItem_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            if (!(lvFiles.SelectedItems.Cast<ListViewItem>().FirstOrDefault() is ListViewItem selected))
            {
                e.Cancel = true;
                return;
            }

            var isDir = selected.SubItems.Count < 6 || selected.SubItems[5].Text == "d";

            tsmiPreview.Enabled = !isDir;
            tsmiExtractAndOpen.Enabled = !isDir;
            tsmiExtractAllAndOpen.Enabled = !isDir;

        }

        private void tsmiPreview_Click(object sender, EventArgs e) => ArchiveItemDefaultAction();

        private void tsmiExtractAndOpen_Click(object sender, EventArgs e) 
            => ExtractAndOpenCurrentItem(extractAll: false);
        
        private void tsmiExtractAllAndOpen_Click(object sender, EventArgs e)
            => ExtractAndOpenCurrentItem(extractAll: true);

        private void ExtractAndOpenCurrentItem(bool extractAll)
        {
            if (!(lvFiles.SelectedItems.Cast<ListViewItem>().FirstOrDefault() is ListViewItem selected && selected.SubItems.Count > 0))
            {
                return;
            }

            var target = selected.SubItems[0].Text;
            if (target == "..") return;

            var targetPath = directoryWindow.GetCurrentPathItemFullPath(target);

            if(extractAll)
            {
                BeginExtraction(true, targetPath);
            }
            else
            {
                var extractFile = new FileInfo(Path.Combine(WorkingAreaPath(), target));
                using (var fs = extractFile.Create()) 
                {
                    if(!directoryWindow.ExtractItem(targetPath, fs))
                    {
                        return;
                    }
                }

                Process.Start(extractFile.FullName);
            }
        }

    }
}
