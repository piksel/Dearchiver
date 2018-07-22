using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Piksel.Dearchiver.Helpers
{
    public static class ControlExtensions
    {
        public static IAsyncResult BeginInvoke(this Control control, Action action)
        {
            return control.BeginInvoke((Delegate)action);
        }
    }
}
