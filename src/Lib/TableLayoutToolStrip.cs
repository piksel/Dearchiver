using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Microsoft.Samples
{
    [ProvideProperty("ColumnSpan", typeof(ToolStripItem))]
    [ProvideProperty("RowSpan", typeof(ToolStripItem))]
    [ProvideProperty("Anchor", typeof(ToolStripItem))]
    [ProvideProperty("Dock", typeof(ToolStripItem))]
    class TableLayoutToolStrip : ToolStrip, IExtenderProvider
    {

        public TableLayoutToolStrip()
        {
            this.LayoutStyle = ToolStripLayoutStyle.Table;
            RowCount = 3;
            ColumnCount = 3;
        }

        private TableLayoutSettings TableLayoutSettings
        {
            get
            {
                return LayoutSettings as TableLayoutSettings;
            }
        }

        [DefaultValue(3)]
        public int RowCount
        {
            get
            {
                if (TableLayoutSettings != null)
                {
                    return TableLayoutSettings.RowCount;
                }
                return -1;
            }
            set
            {
                if (TableLayoutSettings != null)
                {
                    TableLayoutSettings.RowCount = value;
                }
            }
        }

        [DefaultValue(3)]
        public int ColumnCount
        {
            get
            {
                if (TableLayoutSettings != null)
                {
                    return TableLayoutSettings.ColumnCount;
                }
                return -1;
            }
            set
            {
                if (TableLayoutSettings != null)
                {
                    TableLayoutSettings.ColumnCount = value;
                }

            }
        }

        public override System.Drawing.Size GetPreferredSize(System.Drawing.Size proposedSize)
        {
            // be friendly if there's no items left to 
            // pin the control open.

            if (Items.Count == 0)
            {
                return this.DefaultSize;
            }

            return base.GetPreferredSize(proposedSize);
        }

        [DefaultValue(1)]
        [DisplayName("ColumnSpan")]
        public int GetColumnSpan(object target)
        {
            return TableLayoutSettings.GetColumnSpan(target);
        }

        public void SetColumnSpan(object target, int value)
        {
            TableLayoutSettings.SetColumnSpan(target, value);
        }

        [DefaultValue(1)]
        [DisplayName("RowSpan")]
        public int GetRowSpan(object target)
        {
            if (TableLayoutSettings != null)
            {
                return TableLayoutSettings.GetRowSpan(target);
            }
            return 1;
        }

        public void SetRowSpan(object target, int value)
        {
            if (TableLayoutSettings != null)
            {
                TableLayoutSettings.SetRowSpan(target, value);
            }
        }

        [Editor(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TableLayoutColumnStyleCollection ColumnStyles
        {
            get
            {
                if (TableLayoutSettings != null)
                {
                    return TableLayoutSettings.ColumnStyles;
                }
                return null;
            }
        }

        [Editor(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TableLayoutRowStyleCollection RowStyles
        {
            get
            {
                if (TableLayoutSettings != null)
                {
                    return TableLayoutSettings.RowStyles;
                }
                return null;
            }
        }

        [DisplayName("Anchor")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AnchorStyles GetAnchor(object target)
        {
            ToolStripItem tsi = target as ToolStripItem;
            return (tsi != null) ? tsi.Anchor : AnchorStyles.None;

        }

        public void SetAnchor(object target, AnchorStyles value)
        {
            ToolStripItem tsi = target as ToolStripItem;
            if (tsi != null)
            {
                tsi.Anchor = value;
            }
        }

        [DisplayName("Dock")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DockStyle GetDock(object target)
        {
            ToolStripItem tsi = target as ToolStripItem;
            return (tsi != null) ? tsi.Dock : DockStyle.None;

        }

        public void SetDock(object target, DockStyle value)
        {
            ToolStripItem tsi = target as ToolStripItem;
            if (tsi != null)
            {
                tsi.Dock = value;
            }
        }

        bool IExtenderProvider.CanExtend(object extendee)
        {
            ToolStripItem tsi = extendee as ToolStripItem;
            return tsi != null && tsi.Owner == this;
        }
    }
}