using SharpShell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Piksel.Dearchiver.IconExtractor;
using static Piksel.Dearchiver.IconExtractor.Interop;

namespace Piksel.Dearchiver.Helpers
{
    public class SystemImageList
    {
        private readonly ShellImageListSize sizeSmall;
        private readonly ShellImageListSize sizeLarge;

        private readonly IImageList imageListSmall;
        public IImageList Small => imageListSmall;

        private readonly IImageList imageListLarge;
        public IImageList Large => imageListLarge;


        private readonly IntPtr handleSmall;
        private readonly IntPtr handleLarge;

        public SystemImageList(ShellImageListSize sizeSmall, ShellImageListSize sizeLarge)
        {
            this.sizeSmall = sizeSmall;
            this.sizeLarge = sizeLarge;

            SHGetImageList((int)sizeSmall, ref IID.IImageList, ref imageListSmall);
            SHGetImageList((int)sizeLarge, ref IID.IImageList, ref imageListLarge);

            handleSmall = Marshal.GetIUnknownForObject(imageListSmall);
            handleLarge = Marshal.GetIUnknownForObject(imageListLarge);
        }

        public void UpdateImageLists(ListView listView)
        {
            SendMessage(listView.Handle, LVM.SETIMAGELIST, LVSIL.LVSIL_SMALL, handleSmall);
            SendMessage(listView.Handle, LVM.SETIMAGELIST, LVSIL.LVSIL_NORMAL, handleLarge);
        }

        public void UpdateImageLists(TreeView treeView)
        {
            SendMessage(treeView.Handle, TVM.SETIMAGELIST, LVSIL.LVSIL_NORMAL, handleSmall);
        }
    }
}
