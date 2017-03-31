using System;
using System.Windows.Forms;

namespace MMPinger.UI
{
    public class dForm : Form
    {
        public bool IsFading => _fading;
        public bool Fade { get; set; }
        public float FadeSpeed { get; set; }

        private bool _disposed;
        private bool _fading;
        private readonly Timer _fadeTimer;

        public dForm()
        {
            SuspendLayout();
            MouseDown += FormMouseDown;

            Fade = true;
            FadeSpeed = 0.1f;

            if (Fade)
            {
                Opacity = 0.1f;

                _fadeTimer = new Timer();
                _fadeTimer.Interval = 10;
                _fadeTimer.Tick += FadeTimerTick;
                _fadeTimer.Start();
            }
            ResumeLayout();
        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                User32.ReleaseCapture();
                User32.SendMessage(Handle, User32.WM_NCLBUTTONDOWN, User32.HT_CAPTION, 0);
            }
        }

        private void FadeTimerTick(object sender, EventArgs e)
        {
            if (!_fading)
            {
                var oldOpacity = Opacity;
                Opacity = Utils.Lerp((float)oldOpacity, 1f, FadeSpeed);
                if (Opacity > 0.9)
                {
                    Opacity = 1;
                    _fading = false;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Just in case.
                MouseDown -= FormMouseDown;

                _fadeTimer?.Dispose();
            }

            _disposed = true;

            Dispose();
        }
    }
}
