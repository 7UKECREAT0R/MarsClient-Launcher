using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitanixClient___Forms
{
    public partial class TextBoxCueExtension : TextBox
    {
        private string _cueText;
        private Color _cueColor;
        public string CueText
        {
            get
            {
                return _cueText;
            }

            set
            {
                _cueText = value;
                Invalidate();
            }
        }
        public Color CueColor
        {
            get
            {
                return _cueColor;
            }
            set
            {
                _cueColor = value;
                Invalidate();
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            const int WM_PAINT = 0xF;
            if (m.Msg == WM_PAINT)
            {
                if (!Focused && string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(CueText))
                {
                    using (var graphics = CreateGraphics())
                    {
                        TextRenderer.DrawText(
                            dc: graphics,
                            text: CueText,
                            font: Font,
                            bounds: ClientRectangle,
                            foreColor: CueColor,
                            backColor: Enabled ? BackColor : SystemColors.Control,
                            flags: TextFormatFlags.Top | TextFormatFlags.Left);
                    }
                }
            }
        }
    }
}
