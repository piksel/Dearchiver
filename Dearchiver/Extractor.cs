using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        bool cancel = false;

        bool useWorkingArea = false;
        private string outputDirectory;
        private bool deleteAfterExtract;
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
                ProcessDirectory = ProcessDirectoryHandler,
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

        internal void Extract(string outputDirectory, bool deleteAfterExtract)
        {
            this.outputDirectory = outputDirectory;
            this.deleteAfterExtract = deleteAfterExtract;

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
                Invoke(CompletionCallback, deleteAfterExtract);
            }

            else
            {
                Invoke(ProgressCallback, progress);
            }

        }

        private void Invoke<T>(Action<T> callback, T argument)
        {
            if(callback != null && gui != null && !gui.IsDisposed)
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

        internal void Cancel()
        {
            lock(lockCancel)
            {
                cancel = true;
            }
        }
    }
}
