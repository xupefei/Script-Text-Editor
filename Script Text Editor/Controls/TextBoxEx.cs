/*TextBox with user-defined background Image
 *
 * Usage:
 * Add the following code to your Form.
 *
        const int WM_CTLCOLOREDIT = 0x0133;
        const int TRANSPARENT = 0x1;
        const int NULL_BRUSH = 0x5;

        [DllImport("gdi32")]
        private static extern int SetBkMode(IntPtr hdc, int bkMode);

        [DllImport("gdi32")]
        private static extern int SetTextColor(IntPtr hdc, int color);

        [DllImport("gdi32")]
        private static extern IntPtr GetStockObject(int fnobject);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CTLCOLOREDIT && m.LParam == textBox1.Handle)
            {
                SetBkMode(m.WParam, TRANSPARENT);
                m.Result = GetStockObject(NULL_BRUSH);
                return;
            }
            else base.WndProc(ref m);
        }
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Script_Text_Editor.Controls
{
    internal class TextBoxEx : TextBox
    {
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_HSCROLL = 0x0114;
        private const int WM_VSCROLL = 0x0115;
        private const int WM_MOUSEWHEEL = 0x020A;

        private const int WM_ERASEBKGND = 0x0014;

        public TextBoxEx()
        {
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        public Image BackImage { get; set; }

        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                base.SelectionStart = Utilities.SelectTextBox(value)[0];
                base.SelectionLength = Utilities.SelectTextBox(value)[1];
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            SetBackImage();
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetBackImage();
            base.OnSizeChanged(e);
        }

        public void SetBackImage()
        {
            try
            {
                using (Bitmap bitmap = (new Bitmap(Parent.BackgroundImage, Parent.ClientSize)).Clone(
                    new Rectangle(
                        Location.X,
                        Location.Y,
                        Size.Width,
                        Size.Height),
                    PixelFormat.Format32bppPArgb))
                {
                    var temp = new Bitmap(Size.Width, Size.Height);
                    Graphics g = Graphics.FromImage(temp);
                    g.DrawImage(bitmap, 0, 0);

                    g.FillRectangle(new SolidBrush(Color.FromArgb(173, Color.White)),
                                    new Rectangle(0, 0, temp.Width, temp.Height));
                    BackImage = temp;
                }
            }
            catch
            {
                return;
            }
        }

        protected void OnEraseBkgnd(Graphics gs)
        {
            if (BackImage != null)
                gs.DrawImage(BackImage, 0, 0);
            else
                gs.FillRectangle(Brushes.White, 0, 0, Width, Height);
            gs.Dispose();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Invalidate();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true,
            CallingConvention = CallingConvention.Winapi)]
        internal static extern bool LockWindowUpdate(IntPtr hWndLock);

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_HSCROLL:
                case WM_VSCROLL:
                case WM_MOUSEWHEEL:
                    Invalidate();
                    break;

                case WM_ERASEBKGND:
                    OnEraseBkgnd(Graphics.FromHdc(m.WParam));
                    m.Result = (IntPtr)1;
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}