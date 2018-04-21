using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Piksel.Dearchiver
{
    public static class IconExtractor
    {
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpFileName);

        [DllImport("kernel32", SetLastError = true)]
        static extern IntPtr FreeLibrary(IntPtr hModule);

        [DllImport("kernel32.dll")]
        static extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, int lpType);

        [DllImport("kernel32.dll")]
        static extern IntPtr FindResource(IntPtr hModule, int lpName, int lpType);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);

        [DllImport("kernel32.dll")]
        static extern IntPtr LockResource(IntPtr hResData);

        [DllImport("user32.dll")]
        static extern int LookupIconIdFromDirectoryEx(byte[] presbits, bool fIcon, int cxDesired, int cyDesired, uint Flags);

        [DllImport("user32.dll")]
        static extern IntPtr CreateIconFromResourceEx(byte[] pbIconBits, uint cbIconBits, bool fIcon, uint dwVersion, int cxDesired, int cyDesired, uint uFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint SizeofResource(IntPtr hModule, IntPtr hResInfo);

        [Flags]
        enum LoadLibraryFlags : uint
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

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, LoadLibraryFlags dwFlags);

        protected enum ResType : int
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

            [DllImport("kernel32.dll")]
            static extern bool EnumResourceNames(IntPtr hModule, ResType dwID, EnumResNameProcDelegate lpEnumFunc, IntPtr lParam);

            delegate bool EnumResNameProcDelegate(IntPtr hModule, int lpszType, IntPtr lpszName, IntPtr lParam);



        }
    }
}
