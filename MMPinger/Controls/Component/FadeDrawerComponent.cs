using System;
using System.Windows.Forms;

namespace MMPinger.Controls.Component
{
    public class FadeDrawerComponent : ElComponent
    {
        public FadeDrawerComponent(ElForm form) : base(form)
        {
            Started = false;
        }

        public bool Started { get; private set; }

        public override void Update()
        {
            if (Started)
            {
                var opacity = Form.Opacity;
                Form.Opacity = opacity + (1 - opacity) * 0.1;
                if (Form.Opacity > 0.9)
                {
                    Form.Opacity = 1;
                    Started = false;
                }
            }
        }

        public void Draw()
        {
            Form.Opacity = 0.1;
            Started = true;
        }
    }
}
