using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using Piksel.Dearchiver.Settings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using NodeEntries = System.Collections.Generic.Dictionary<string, Piksel.Dearchiver.Extractor.DirectoryWindow.EntryNode>;

namespace Piksel.Dearchiver
{
    public class Extractor
    {

        private ZipFile zf;
        private string archiveFullPath;

        long fileCount = 0;
        long dirCount = 0;
        long rootDirCount = 0;
        long processedFiles = 0;
        private long totalSizeUnc = 0;
        private long totalSizeCmp = 0;

        private object lockCancel = new object();
        private object lockProcessed = new object();

        private bool cancel = false;

        private string outputDirectory;
        private PostExtractActions postExtractActions;
        private Control gui;

        public Action<bool> ButtonCallback { get; set; }
        public Action<double> ProgressCallback { get; set; }
        public Action<string> FilenameCallback { get; set; }
        public Action<bool> CompletionCallback { get; set; }

        private Thread thread;
        private FastZip fz;

        public string ArchiveName => Path.GetFileName(archiveFullPath);

        public double CompressionRate { get; }
        public string ArchivePath => Path.GetDirectoryName(archiveFullPath);
        public string ArchiveFile => archiveFullPath;

        public long DirCount => dirCount;
        public long RootDirCount => rootDirCount;
        public bool SingleRoot => rootDirCount < 2;

        public long ProcessedFiles
        {
            get
            {
                lock (lockProcessed) {
                    return processedFiles;
                }
            }
        }

        public long FileCount => fileCount;
        public string ArchiveComment => zf.ZipFileComment;

        public Extractor(Control gui, string archiveFullPath)
        {
            this.gui = gui;
            this.archiveFullPath = archiveFullPath;

            zf = new ZipFile(archiveFullPath);

            foreach (ZipEntry ze in zf)
            {
                if (ze.IsFile)
                {
                    fileCount++;
                    totalSizeUnc += ze.Size;
                    totalSizeCmp += ze.CompressedSize;
                }
                else if (ze.IsDirectory)
                {
                    if (ze.Name.Length - ze.Name.IndexOf('/') <= 1)
                        rootDirCount++;
                    dirCount++;
                }

            }

            CompressionRate = (((double)totalSizeCmp) / totalSizeUnc) * 100;


            zf.Close();


        }

        internal void OpenOutputDirectory()
        {
            Process.Start(outputDirectory);
        }

        private void Run()
        {
            fz = new FastZip(new FastZipEvents()
            {
                ProcessFile = ProcessFileHandler,
                CompletedFile = CompletedFileHandler,
                
                FileFailure = FileFailureHandler
            });
            fz.ExtractZip(archiveFullPath, outputDirectory, "");
        }

        private void UpdateButtonState(bool extracting)
        {
            Invoke(ButtonCallback, extracting);
        }

        private void FileFailureHandler(object sender, ScanFailureEventArgs e)
        {
            MessageBox.Show(e.Exception.Message + "\n\nStacktrace:\n" + e.Exception.StackTrace, 
                e.Exception.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        internal void Extract(string outputDirectory, PostExtractActions postExtractActions)
        {
            this.outputDirectory = outputDirectory;
            this.postExtractActions = postExtractActions;

            UpdateButtonState(true);
            thread = new Thread(Run);
            thread.Start();
        }

        private void ProcessDirectoryHandler(object sender, ScanEventArgs e)
        {

        }

        private void CompletedFileHandler(object sender, ScanEventArgs e)
        {
            processedFiles++;
            var progress = (((double)processedFiles) / fileCount) * 100;

            if (processedFiles == fileCount)
            {
                progress = 100;

                new Thread(() =>
                {
                    if ((postExtractActions & PostExtractActions.Delete) != 0)
                    {
                        int attempts = 0;
                        do
                        {
                            try
                            {
                                File.Delete(ArchiveFile);
                                break;
                            }
                            catch
                            {
                                Thread.Sleep(500);
                            }
                        }
                        while (attempts++ <= 6);

                        if (attempts >= 6)
                        {
                            MessageBox.Show($"Failed to delete archive \"{ArchiveName}\"", "Failed to delete archive", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }

                    if ((postExtractActions & PostExtractActions.Open) != 0)
                        OpenOutputDirectory();

  
                    Invoke(CompletionCallback, (postExtractActions & PostExtractActions.Close) != 0);

                }).Start();
            }

            else
            {
                Invoke(ProgressCallback, progress);
            }

        }

        /*
         
                internal string GetDetails()
            => new StringBuilder()
                .AppendLine($"Archive name: {Path.GetFileName(archiveFullPath)}")
                .AppendLine($"Archive path: {ArchivePath}")
                .AppendLine($"Content: {FileCount} file(s) in {DirCount} folder(s).")
                .AppendLine($"Root folders: {RootDirCount} folder(s), single root archive: {SingleRoot}.")
                .AppendLine($"Compresssion rate: {CompressionRate:F2}%")
                .AppendLine(string.IsNullOrEmpty(ArchiveComment) ? $"Comment: {ArchiveComment}" : "")
                .ToString();
            
        */

        internal IEnumerable<string[]> GetDetails()
        {
            yield return new string[] { "Archive name", Path.GetFileName(archiveFullPath) };
            yield return new string[] { "Archive path", ArchivePath };
            yield return new string[] { "Content", $"{FileCount} file(s) in {DirCount} folder(s)." };
            yield return new string[] { "Root folders", $"{RootDirCount} folder(s), single root archive: {SingleRoot}." };
            yield return new string[] { "Compresssion rate", $"{CompressionRate:F2}%" };
            if (string.IsNullOrEmpty(ArchiveComment))
                yield return new string[] { $"Comment", ArchiveComment };
        }

        private void Invoke<T>(Action<T> callback, T argument)
        {
            if(callback != null && gui?.IsDisposed == false)
            {
                gui.Invoke((Action)(() => callback(argument)));
            }
        }
        

        private void ProcessFileHandler(object sender, ScanEventArgs e)
        {
            Invoke(FilenameCallback, e.Name);

            lock (lockCancel)
            {
                if (!cancel) return;
            }

            e.ContinueRunning = false;
            UpdateButtonState(false);
            
        }

        internal DirectoryWindow GetRootWindow()
        {
            return new DirectoryWindow(this);
        }

        internal void Cancel()
        {
            lock(lockCancel)
            {
                cancel = true;
            }
        }

        internal class DirectoryWindow
        {
            private Extractor extractor;
            private string path;

            public string CurrentPath => path;

            public bool InRoot => currentNode.Parent == null;

            EntryNode currentNode;

            EntryNode rootNode = EntryNode.RootNode;

            IEnumerable<EntryNode> sortedEnumerator;

            public DirectoryWindow(Extractor extractor)
            {
                this.extractor = extractor;
                this.path = "";

                using (var zf = new ZipFile(extractor.archiveFullPath))
                {
                    foreach (ZipEntry ze in zf)
                    {
                        var parts = ze.Name.Split('/');
                        var name = parts[parts.Length - 1];
                        var parentNode = CreateDirNodes(rootNode, parts.Take(parts.Length - 1).OfType<string>().GetEnumerator());
                        if (!ze.IsDirectory)
                        {
                            parentNode.AddFile(name, ze.Size, ze.CompressedSize, ze.DateTime);
                        }

                    }

                }

                rootNode.UpdateSizes();
                currentNode = rootNode;
                UpdateSort();
            }

            private void UpdateSort()
            {
                sortedEnumerator = currentNode.ChildNodes.Values.OrderByDescending(n => n.IsDirectory).ThenBy(n => n.Name).ToArray();
                path = currentNode.GetPath();
            }

            private EntryNode CreateDirNodes(EntryNode parent, IEnumerator<string> parts)
            {
                return parts.MoveNext() ? CreateDirNodes(parent.GetOrCreateDirectory(parts.Current), parts) : parent;
            }

            public static string ParentDirectory(string path)
            {
                if (string.IsNullOrEmpty(path))
                    return "";

                var parts = path.Split('/').Reverse().ToArray();

                if (parts.Length < 2)
                    return "";

                int offset = parts.Length > 2 && string.IsNullOrEmpty(parts[0]) ? 2 : 1;
                return string.Join("/", parts.Skip(offset).Reverse().ToArray());

            }

            public IEnumerable<EntryNode> Contents => sortedEnumerator;

            private IEnumerable<EntryNode> GetContents()
            {
                foreach (var node in currentNode.ChildNodes.Values)
                {
                    yield return node;
                }
            }

            internal void Descend(string text)
            {
                if (currentNode.GetDirectory(text) is EntryNode dirNode)
                {
                    currentNode = dirNode;
                    UpdateSort();
                }
            }

            internal void Ascend()
            {
                if (!InRoot)
                {
                    currentNode = currentNode.Parent;
                    UpdateSort();
                }
            }

            public class EntryNode
            {
                public string Name { get; }
                public bool IsDirectory { get; }
                public long Size { get; private set; }
                public long CompressedSize { get; private set; }
                public Dictionary<string, EntryNode> ChildNodes { get; }
                public EntryNode Parent { get; }

                public static EntryNode RootNode => new EntryNode(null, true, null);
                public static EntryNode CreateRootNode(string name) => new EntryNode(name, true, null);

                public DateTime DateTime { get; private set; }

                private EntryNode(string name, bool directory, EntryNode parent, long size = 0, long compSize = 0, DateTime? dateTime = null)
                {
                    Name = name;
                    IsDirectory = directory;
                    Parent = parent;
                    Size = size;
                    CompressedSize = compSize;
                    ChildNodes = directory ? new Dictionary<string, EntryNode>() : null;
                    DateTime = dateTime ?? DateTime.MinValue;
                }

                public EntryNode AddFile(string name, long size, long compSize, DateTime dateTime)
                {
                    var node = new EntryNode(name, false, this, size, compSize, dateTime);
                    ChildNodes.Add(name, node);
                    return node;
                }

                public EntryNode AddDirectory(string name)
                {
                    var node = new EntryNode(name, true, this);
                    ChildNodes.Add(name, node);
                    return node;
                }

                public EntryNode GetOrCreateDirectory(string name)
                    => (ChildNodes.ContainsKey(name)) ? ChildNodes[name] : AddDirectory(name);

                public bool ContainsKey(string name)
                    => ChildNodes.ContainsKey(name);

                public EntryNode GetDirectory(string name)
                    => ChildNodes.ContainsKey(name) ? ChildNodes[name] : null;

                public override string ToString()
                    => $"{Name} [{(IsDirectory?'D':'F')}] {Size}";

                internal void UpdateSizes()
                {
                    if (!IsDirectory) return;

                    Size = 0;
                    CompressedSize = 0;
                    DateTime = DateTime.MinValue;

                    foreach (var node in ChildNodes.Values)
                    {
                        node.UpdateSizes();
                        if (node.DateTime.CompareTo(DateTime) > 0)
                            DateTime = node.DateTime;
                        Size += node.Size;
                        CompressedSize += node.CompressedSize;
                    }
                }

                internal string GetPath()
                {
                    return Parent == null ? "/" : (Parent.GetPath() + Name + "/");
                }
            }
        }
    }
}
