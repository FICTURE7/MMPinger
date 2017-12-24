using MMPinger.Models;
using MMPinger.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MMPinger.Views
{
    public partial class MainForm : dForm
    {
        public MainForm() : base()
        {
            InitializeComponent();
        }

        #region exitButton
        private void exitButtonClick(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush darkerGray = new SolidBrush(Color.FromArgb(11, 11, 11));
            e.Graphics.FillRectangle(darkerGray, new Rectangle(0, 0, Size.Width, 19));
            darkerGray.Dispose();
            base.OnPaint(e);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            Server[] servers = await Program.Manager.LoadIPsAsync();

            innerPanel.SuspendLayout();
            foreach (Server server in servers)
            {
                if (server.IPRanges.Length > 1)
                {
                    for (int i = 0; i < server.IPRanges.Length; i++)
                    {
                        dPinger pinger = new dPinger();
                        pinger.Title = server.Name.ToUpper() + "#" + (i + 1);
                        pinger.Interval = 5000;
                        pinger.HostName = server.IPRanges[i];

                        innerPanel.Controls.Add(pinger);
                    }
                }
                else
                {
                    dPinger pinger = new dPinger();
                    pinger.Title = server.Name.ToUpper();
                    pinger.Interval = 5000;
                    pinger.HostName = server.IPRanges[0];

                    innerPanel.Controls.Add(pinger);
                }
            }
            innerPanel.ResumeLayout();
        }
    }
}
