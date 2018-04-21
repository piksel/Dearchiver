using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piksel.Dearchiver
{
    class ExcerptLabel: Label
    {
        string _fullText;
        string _excerptText;
        private float dotsWidth;
        private bool paintMode = false;
        private bool _dotsOnLeft;

        [Browsable(true)]
        [DefaultValue(false)]
        public bool DotsOnLeft
        {
            get { return _dotsOnLeft; }
            set { _dotsOnLeft = value; Invalidate(); }
        }

        public override string Text {
            get => paintMode ? _excerptText : _fullText;
            set => _fullText = value.Replace(" ", "_");
 
        }

        /*
        protected override void OnResize(EventArgs e)
        {
            Invalidate();
        }
        */

        protected override void OnPaint(PaintEventArgs e)
        {
            float textWidth = e.Graphics.MeasureString(_fullText, Font).Width;

            _excerptText = _fullText;
            if (textWidth > Width) {
                dotsWidth = e.Graphics.MeasureString("...", Font).Width;
                do
                {
                    textWidth = e.Graphics.MeasureString(_excerptText, Font).Width;
                    _excerptText = _excerptText.Substring(_dotsOnLeft ? 1 : 0, _excerptText.Length - 1);
                }
                while (textWidth + dotsWidth > Width);
                _excerptText = _dotsOnLeft ? "..." + _excerptText : _excerptText + "...";
            }



            paintMode = true;
            base.OnPaint(e);
            paintMode = false;
        }
    }
}
