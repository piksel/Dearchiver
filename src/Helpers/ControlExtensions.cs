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
            => control?.BeginInvoke(action);

        public static object Invoke(this Control control, Action action)
            => control?.Invoke(action);

        public static DisposableToken<IUpdatableControl> UpdateToken(this IUpdatableControl control)
        {
            control.BeginUpdate();
            return DisposableToken.FromContent(control, (c, _) => c.EndUpdate());
        }

        public static DisposableToken<ListView> UpdateToken(this ListView control)
        {
            control.BeginUpdate();
            return DisposableToken.FromContent(control, (c, _) => c.EndUpdate());
        }

    }
}
