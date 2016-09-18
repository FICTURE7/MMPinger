using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MMPinger.Controls.Component
{
    public class MoverComponent : ElComponent
    {
        public MoverComponent(ElForm form) : base(form)
        {
            Form.MouseDown += OnMouseDown;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

    }
}
