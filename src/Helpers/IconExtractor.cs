using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Piksel.Dearchiver
{
    using SharpShell.Interop;
    using System.Windows.Forms;
    using static Piksel.Dearchiver.IconExtractor.Interop;

    public static class IconExtractor
    {
        public static class Interop
        {

            #region External Imports

            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpFileName);

            [DllImport("kernel32", SetLastError = true)]
            public static extern IntPtr FreeLibrary(IntPtr hModule);

            [DllImport("kernel32.dll")]
            public static extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, int lpType);

            [DllImport("kernel32.dll")]
            public static extern IntPtr FindResource(IntPtr hModule, int lpName, int lpType);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);

            [DllImport("kernel32.dll")]
            public static extern IntPtr LockResource(IntPtr hResData);

            [DllImport("user32.dll")]
            public static extern int LookupIconIdFromDirectoryEx(byte[] presbits, bool fIcon, int cxDesired, int cyDesired, uint Flags);

            [DllImport("user32.dll")]
            public static extern IntPtr CreateIconFromResourceEx(byte[] pbIconBits, uint cbIconBits, bool fIcon, uint dwVersion, int cxDesired, int cyDesired, uint uFlags);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern uint SizeofResource(IntPtr hModule, IntPtr hResInfo);

            [DllImport("shell32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, LoadLibraryFlags dwFlags);

            [DllImport("kernel32.dll")]
            public static extern bool EnumResourceNames(IntPtr hModule, ResType dwID, EnumResNameProcDelegate lpEnumFunc, IntPtr lParam);

            [DllImport("user32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
            public static extern int DestroyIcon(IntPtr hIcon);

            [DllImport("shell32.dll", EntryPoint = "#727")]
            public extern static int SHGetImageList(int iImageList, ref Guid riid, ref IImageList ppv);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

            #endregion

            #region Overloads / helpers

            public static IntPtr SHGetFileInfo(string path, FileAttributes fileAttributes, ref SHFILEINFO shfi, SHGetFileInfoFlags fileInfoFlags)
                => SHGetFileInfo(path, (uint)fileAttributes, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)fileInfoFlags);


            #endregion

            #region Flags and structs

            [Flags]
            public enum LoadLibraryFlags : uint
            {
                DONT_RESOLVE_DLL_REFERENCES = 0x00000001,
                LOAD_IGNORE_CODE_AUTHZ_LEVEL = 0x00000010,
                LOAD_LIBRARY_AS_DATAFILE = 0x00000002,
                LOAD_LIBRARY_AS_DATAFILE_EXCLUSIVE = 0x00000040,
                LOAD_LIBRARY_AS_IMAGE_RESOURCE = 0x00000020,
                LOAD_LIBRARY_SEARCH_APPLICATION_DIR = 0x00000200,
                LOAD_LIBRARY_SEARCH_DEFAULT_DIRS = 0x00001000,
                LOAD_LIBRARY_SEARCH_DLL_LOAD_DIR = 0x00000100,
                LOAD_LIBRARY_SEARCH_SYSTEM32 = 0x00000800,
                LOAD_LIBRARY_SEARCH_USER_DIRS = 0x00000400,
                LOAD_WITH_ALTERED_SEARCH_PATH = 0x00000008
            }

            public enum ResType : int
            {
                CURSOR = 1,
                BITMAP = 2,
                ICON = 3,
                MENU = 4,
                DIALOG = 5,
                STRING = 6,
                FONTDIR = 7,
                FONT = 8,
                ACCELERATOR = 9,
                RCDATA = 10,
                MESSAGETABLE = 11,
                GROUP_CURSOR = 12,
                GROUP_ICON = 14,
                VERSION = 16,
                DLGINCLUDE = 17,
                PLUGPLAY = 19,
                VXD = 20,
                ANICURSOR = 21,
                ANIICON = 22,
                HTML = 23,
                MANIFEST = 24
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            public struct SHFILEINFO
            {
                public IntPtr IconHandle;
                public int IconIndex;
                public uint Attributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string DisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string TypeName;
            };

            [Flags]
            public enum SHGetFileInfoFlags : int
            {
                /// <summary>get icon</summary>
                Icon = 0x000000100,
                /// <summary>get display name</summary>
                DisplayName = 0x000000200,
                /// <summary>get type name</summary>
                TypeName = 0x000000400,
                /// <summary>get attributes</summary>
                Attributes = 0x000000800,
                /// <summary>get icon location</summary>
                IconLocation = 0x000001000,
                /// <summary>return exe type</summary>
                ExeType = 0x000002000,
                /// <summary>get system icon index</summary>
                SysIconIndex = 0x000004000,
                /// <summary>put a link overlay on icon</summary>
                LinkOverlay = 0x000008000,
                /// <summary>show icon in selected state</summary>
                Selected = 0x000010000,
                /// <summary>get only specified attributes</summary>
                Attr_Specified = 0x000020000,
                /// <summary>get large icon</summary>
                LargeIcon = 0x000000000,
                /// <summary>get small icon</summary>
                SmallIcon = 0x000000001,
                /// <summary>get open icon</summary>
                OpenIcon = 0x000000002,
                /// <summary>get shell size icon</summary>
                ShellIconSize = 0x000000004,
                /// <summary>pszPath is a pidl</summary>
                PIDL = 0x000000008,
                /// <summary>use passed dwFileAttribute</summary>
                UseFileAttributes = 0x000000010,
                /// <summary>apply the appropriate overlays</summary>
                AddOverlays = 0x000000020,
                /// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
                OverlayIndex = 0x000000040,
            }

            public delegate bool EnumResNameProcDelegate(IntPtr hModule, int lpszType, IntPtr lpszName, IntPtr lParam);

            public static class IID {
                public static Guid IImageList = new Guid("46EB5926-582E-4017-9FDF-E8998DAA0950");
            }

            internal static class LVM
            {
                public const int GETIMAGELIST = 0x1002;
                public const int SETIMAGELIST = 0x1003;
            }

            internal static class TVM
            {
                public const int GETIMAGELIST = 0x1108;
                public const int SETIMAGELIST = 0x1109;
            }

            public static class LVSIL
            {
                public const int LVSIL_NORMAL = 0;
                public const int LVSIL_SMALL = 1;
                public const int LVSIL_STATE = 2;
                public const int LVSIL_GROUPHEADER = 3;
            }

            #endregion

        }

        public enum ShellImageListSize
        {
            /// <summary>
            /// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in Display Properties, the image is 48x48 pixels.
            /// </summary>
            Large = 0x0,

            /// <summary>
            /// These images are the Shell standard small icon size of 16x16, but the size can be customized by the user.
            /// </summary>
            Small = 0x1,

            /// <summary>
            /// These images are the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.
            /// </summary>
            ExtraLarge = 0x2,

            /// <summary>
            /// These images are the size specified by GetSystemMetrics called with SM_CXSMICON and GetSystemMetrics called with SM_CYSMICON.
            /// </summary>
            SysSmall = 0x3,

            /// <summary>
            /// Windows Vista and later. The image is normally 256x256 pixels.
            /// </summary>
            Jumbo = 0x4
        }

        public static void SetImageListForListView(ListView control, ShellImageListSize size)
        {
            IImageList imageList = null;
            Interop.SHGetImageList((int)size, ref IID.IImageList, ref imageList);
            var imageListHandle = Marshal.GetIUnknownForObject(imageList);
            SendMessage(control.Handle, LVM.SETIMAGELIST, 0, imageListHandle);
        }

        public static Icon GetIcon(string file, int size)
        {
            IntPtr hExe = LoadLibraryEx(file, IntPtr.Zero, LoadLibraryFlags.LOAD_LIBRARY_AS_DATAFILE);

            if (hExe == IntPtr.Zero)
                return null;
            try
            {
                var resEnum = new ResourceNamesEnumerator(hExe, ResType.GROUP_ICON);

                IntPtr hResource = resEnum.ResourceHandles.FirstOrDefault(p => p != IntPtr.Zero);

                if (hResource == IntPtr.Zero) return null;

                IntPtr hMem = LoadResource(hExe, hResource);

                IntPtr lpResourcePtr = LockResource(hMem);
                uint sz = SizeofResource(hExe, hResource);
                byte[] lpResource = new byte[sz];
                Marshal.Copy(lpResourcePtr, lpResource, 0, (int)sz);

                int nID = LookupIconIdFromDirectoryEx(lpResource, true, size, size, 0x0000);

                hResource = FindResource(hExe, nID, (int)ResType.ICON);

                hMem = LoadResource(hExe, hResource);

                lpResourcePtr = LockResource(hMem);
                sz = SizeofResource(hExe, hResource);
                lpResource = new byte[sz];
                Marshal.Copy(lpResourcePtr, lpResource, 0, (int)sz);

                IntPtr hIcon = CreateIconFromResourceEx(lpResource, sz, true, 0x00030000, size, size, 0);

                return Icon.FromHandle(hIcon);
            }
            finally
            {
                FreeLibrary(hExe);
            }

        }

        private static readonly string ordinaryDirPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        public static Icon GetDirectoryIcon(bool smallIcon, bool linkOverlay)
            => GetFileIcon(ordinaryDirPath, smallIcon, linkOverlay, FileAttributes.Normal | FileAttributes.Directory);

        public static int GetFileIconIndex(string name, FileAttributes fileAttributes = FileAttributes.Normal)
        {
            var shfi = GetFileInfo(name, false, false, fileAttributes);

            return shfi.IconIndex;
        }

        public static Icon GetFileIcon(string name, bool smallIcon, bool linkOverlay, FileAttributes fileAttributes = FileAttributes.Normal)
        {
            var shfi = GetFileInfo(name, smallIcon, linkOverlay, fileAttributes);

            if (shfi.IconHandle == IntPtr.Zero)
            {
                return SystemIcons.Exclamation;
            }

            // Clone the returned icon handle so that it gets properly disposed
            var icon = Icon.FromHandle(shfi.IconHandle).Clone() as Icon;

            // Destroy the unmanaged icon
            DestroyIcon(shfi.IconHandle);

            return icon;
        }

        public static SHFILEINFO GetFileInfo(string name, bool smallIcon, bool linkOverlay, FileAttributes fileAttributes)
        {
            var shfi = new SHFILEINFO();
            var flags = SHGetFileInfoFlags.Icon | SHGetFileInfoFlags.SysIconIndex | SHGetFileInfoFlags.TypeName;

            if ((fileAttributes & FileAttributes.Directory) == 0)
                flags |= SHGetFileInfoFlags.UseFileAttributes;

            if (linkOverlay)
                flags |= SHGetFileInfoFlags.LinkOverlay;


            flags |= smallIcon ? SHGetFileInfoFlags.SmallIcon : SHGetFileInfoFlags.LargeIcon;

            //if ((fileAttributes & FileAttributes.Directory) != 0)
            //    flags |= SHGetFileInfoFlags.OpenIcon;

            SHGetFileInfo(name, fileAttributes, ref shfi, flags);

            return shfi;
        }

        protected class ResourceNamesEnumerator
        {
            private bool success;

            List<IntPtr> groupIds = new List<IntPtr>();

            public List<IntPtr> ResourceHandles => groupIds;

            internal ResourceNamesEnumerator(IntPtr hModule, ResType dwID)
            {
                success = EnumResourceNames(hModule, dwID, EnumCallback, IntPtr.Zero);
            }

            private static bool IsIntResource(IntPtr value)
                => (((uint)value) <= ushort.MaxValue);

            private bool EnumCallback(IntPtr hModule, int lpszType, IntPtr lpszName, IntPtr lParam)
            {
                if(lpszName != null)
                {
                    var res = FindResource(hModule, lpszName, lpszType);
                    groupIds.Add(res);
                    try
                    {
                        string name;
                        if (IsIntResource(lpszName))
                        {
                            name = $"0x{lpszName:x8}";
                        }
                        else
                        {
                            name = Marshal.PtrToStringAnsi(lpszName);
                        }

                        var a = name;
                    }
                    catch { }
                }
                return true;
            }




        }
    }
}
