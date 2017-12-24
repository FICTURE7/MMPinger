using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MMPinger.Views.UI
{
    public partial class dVScrollBar : Control
    {
        public dVScrollBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public ScrollableControl WrapControl
        {
            get { return _wrapControl; }
            set
            {
                if (_wrapControl != null)
                {
                    _wrapControl.Scroll -= OnWrapControlScroll;
                    _wrapControl.MouseWheel -= OnWrapControlMouseWheel;
                }

                _wrapControl = value;
                if (_wrapControl != null)
                {
                    _wrapControl.Scroll += OnWrapControlScroll;
                    _wrapControl.MouseWheel += OnWrapControlMouseWheel;
                }
            }
        }

        // Figure out if the mouse is down on the control currently.
        private bool _mouseDown;
        // Figure out if the mouse is over the knob.
        private bool _mouseOverKnob;
        // Figure out if the mouse is down on the knob.
        private bool _mouseDownKnob;

        // Rect of knob of the scroll.
        private Rectangle _knobRect;
        // ScrollableControl which we're wrapping.
        private ScrollableControl _wrapControl;

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush gray = new SolidBrush(Color.FromArgb(33, 33, 33));

            // Height of the content inside of the ScrollableControl.
            float contentHeight = WrapControl.DisplayRectangle.Height;
            // Height of the ScrollableControl.
            float visibleHeight = WrapControl.Size.Height;

            int width = Size.Width;
            int height = (int)((visibleHeight / contentHeight) * visibleHeight);

            // X value of the custom scroll rectangle.
            int x = WrapControl == null ? 0 : (int)((WrapControl.VerticalScroll.Value / (float)(WrapControl.VerticalScroll.Maximum - WrapControl.VerticalScroll.LargeChange)) * (visibleHeight - height));

            _knobRect = new Rectangle(0, x, width, height);

            FillRoundedRectangle(gray, _knobRect, e.Graphics);
            base.OnPaint(e);
        }

        private void FillRoundedRectangle(Brush brush, Rectangle rect, Graphics graphics)
        {
            int radius = rect.Width / 2;

            int x = rect.X;
            int y = rect.Y;
            int width = rect.Width;
            int height = rect.Height;

            graphics.FillEllipse(brush, x, y, width, width);
            graphics.FillRectangle(brush, x, y + radius, width, height - width);
            graphics.FillEllipse(brush, x, y + height - width, width, width);
        }

        private void OnWrapControlMouseWheel(object sender, MouseEventArgs e)
        {
            Invalidate();
        }

        private void OnWrapControlScroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _mouseDown = true;
            _mouseDownKnob = _mouseOverKnob;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _mouseDown = false;
            _mouseDownKnob = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Location.Y >= _knobRect.Y && e.Location.Y <= _knobRect.Y + _knobRect.Height &&
                e.Location.X >= _knobRect.X && e.Location.X <= _knobRect.X + _knobRect.Width)
                _mouseOverKnob = true;
            else
                _mouseOverKnob = false;

            if (_mouseDownKnob)
            {
                int max = WrapControl.VerticalScroll.Maximum;
                int min = WrapControl.VerticalScroll.Minimum;
                int value = Utils.Clamp(e.Y, min, max);

                WrapControl.VerticalScroll.Value = value;

                // Force a redraw of the control.
                Invalidate();
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int max = WrapControl.VerticalScroll.Maximum;
            int min = WrapControl.VerticalScroll.Minimum;
            int value = Utils.Clamp(WrapControl.VerticalScroll.Value - (e.Delta), min, max);

            WrapControl.VerticalScroll.Value = value;

            // Force a redraw of the control.
            Invalidate();

            base.OnMouseWheel(e);
        }
    }
}
