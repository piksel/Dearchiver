using System;
using System.Windows.Forms;

namespace Piksel.Dearchiver.Helpers
{
    public static class UpdatableControl
    {
        public static UpdatableControl<TControl> Wrap<TControl>(TControl control, Action<TControl> beginUpdate, Action<TControl> endUpdate)
            => new UpdatableControl<TControl>(control, beginUpdate, endUpdate);
    }

    public class UpdatableControl<TControl>: IUpdatableControl
    {
        private readonly TControl control;

        private readonly Action<TControl> beginUpdate;
        public void BeginUpdate()
            => beginUpdate.Invoke(control);

        private readonly Action<TControl> endUpdate;

        public void EndUpdate()
            => endUpdate.Invoke(control);

        public UpdatableControl(TControl control, Action<TControl> beginUpdate, Action<TControl> endUpdate)
        {
            this.beginUpdate = beginUpdate;
            this.endUpdate = endUpdate;
            this.control = control;
        }

        public static implicit operator UpdatableControl<TControl>(ListView control)
            => new UpdatableControl<ListView>(control, c => c.BeginUpdate(), c => c.EndUpdate()) as UpdatableControl<TControl>;
    }

    public interface IUpdatableControl
    {
        void BeginUpdate();
        void EndUpdate();
    }
}