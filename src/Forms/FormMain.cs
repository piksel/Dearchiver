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
                        CompletionCallback = close =>
                        {
                            lFileName.Text = "Done!";

                            if (close) Close();
                        }
                    };

                    var archiveName = Extractor.ArchiveName;
                    Text = archiveName + " - Dearchiver";

                    excerptLabel1.Text = Extractor.ArchivePath;
                    toolTip1.SetToolTip(statusStrip1, Extractor.ArchivePath);
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

                    UpdateExtArchiver();

                }
            }
            catch (Exception x)
            {
                Visible = false;
                MessageBox.Show(this, "Could not open archive:\n" + x.Message, "Dearchiver", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                Close();
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

        private TreeNode GetTreeNode(NodeInfo nodeInfo)
        {
            if (nodeInfo.Node.IsDirectory)
            {
                return new TreeNode(nodeInfo.Name, nodeInfo.IconIndex, nodeInfo.IconIndex, 
                    nodeInfo.ChildNodes.Select(NodeInfo.FromNode).Select(GetTreeNode).ToArray());
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

            var postActions = PostExtractActions.None;
            if (Settings.CloseAppAfterExtract) postActions |= PostExtractActions.Close;
            if (Settings.OpenFolderAfterExtract) postActions |= PostExtractActions.Open;
            if (deleteAfterExtract) postActions |= PostExtractActions.Delete;

            Extractor.Extract(outDir, postActions);
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

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
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
                directoryWindow.Descend(target);
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
    }
}
