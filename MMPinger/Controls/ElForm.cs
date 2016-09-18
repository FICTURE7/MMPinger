using MMPinger.Controls.Component;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MMPinger.Controls
{
    public class ElForm : Form
    {
        public ElForm()
        {
            const int TIMER_INTERVAL = 10;

            _componentTimer = new Timer
            {
                Enabled = true,
                Interval = TIMER_INTERVAL
            };
            _componentTimer.Tick += OnComponentTick;

            _components = new List<ElComponent>();
            _components.Add(new MoverComponent(this));

            var drawer = new FadeDrawerComponent(this);
            _components.Add(drawer);
            drawer.Draw();
        }

        private readonly Timer _componentTimer;

        private readonly List<ElComponent> _components;
        public List<ElComponent> Components
        {
            get
            {
                return _components;
            }
        }

        private void OnComponentTick(object sender, EventArgs e)
        {
            for (int i = 0; i < _components.Count; i++)
                _components[i].Update();
        }
    }
}
