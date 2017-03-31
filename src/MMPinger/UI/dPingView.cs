using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace MMPinger.UI
{
    public partial class dPingView : UserControl
    {
        // Our color template.
        // Most of those colors come from the Material Design color style.
        // Found here: https://material.google.com/style/color.html
        private static readonly Pen s_gray = new Pen(Color.FromArgb(33, 33, 33));

        private static readonly Pen s_green = new Pen(Color.FromArgb(139, 195, 74)); // -> Good
        private static readonly Pen s_yellow = new Pen(Color.FromArgb(255, 235, 59)); // -> Ok
        private static readonly Pen s_orange = new Pen(Color.FromArgb(255, 152, 0)); // -> Bad
        private static readonly Pen s_red = new Pen(Color.FromArgb(239, 83, 80)); // -> Sh*t

        public dPingView()
        {
            // Prevent some nasty flickering.
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // Keep track of when the background color changes.
            BackColorChanged += OnBackgroundColorChanged;

            InitializeComponent();
            Interval = 5000;

            UpdateLastPing();

            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Tick += OnTimerTick;
            _timer.Start();

            _currentIndicatorColor = s_gray;
            _expectedIndicatorColor = s_gray;
            _pinger = new Ping();
        }

        #region Fields & Properties
        // Ping object thats going to send pings to _hostName.
        private readonly Ping _pinger;

        private Pen _currentIndicatorColor;
        private Pen _expectedIndicatorColor;

        private PingReply _pingReply;
        private IPAddress _ip;
        private string _title;
        private string _hostName;

        [Description("Title of the PingerView.")]
        [Category("Data")]
        public string Title
        {
            get
            {
                return _title == null ? "Unset Title" : _title;
            }
            set
            {
                _title = value;
                TitleLabel.Text = Title;
            }
        }

        [Description("Intervals between pings in milliseconds.")]
        [Category("Behavior")]
        public int Interval { get; set; }

        [Description("Host which this view is going pinging.")]
        [Category("Data")]
        public string HostName
        {
            get
            {
                return _hostName;
            }
            set
            {
                _hostName = value;
                if (_hostName != null)
                {
                    IPAddressLabel.Text = _hostName;

                    // Be sort of 'reactive'.
                    PingAndUpdateAsync();
                }
                else
                {
                    IPAddressLabel.Text = "0.0.0.0";

                    _ip = null;
                }
            }
        }

        [Description("IP address which is getting pinged. This IP address was resolved using HostName.")]
        [Category("Misc")]
        public IPAddress IP => _ip;

        [Description("Ping reply from the device at specified IP.")]
        [Category("Misc")]
        public PingReply Reply => _pingReply;
        #endregion

        // To avoid starting a new ping while pinging.
        private bool _pinging;
        // Sends a single ping to HostName asynchronously and updates
        // _pingColor and PingMsLabel and forces a redraw.
        private async void PingAndUpdateAsync()
        {
            // If we're already pinging, we don't need to start another ping.
            if (_pinging)
                return;

            // If we don't have a host to ping, we exit early.
            if (_hostName == null)
            {
                _expectedIndicatorColor = s_gray;
                return;
            }

            // Prevent the timer from calling this method again.
            UpdateLastPing();

            _pinging = true;

            const int TIMEOUT = 1000;
            // Cause non block I/O is fancy af right.
            var reply = await _pinger.SendPingAsync(_hostName, TIMEOUT);

            _pinging = false;

            _ip = reply.Address;
            _pingReply = reply;

            var ms = reply.RoundtripTime;
            // Set the color based on the range.
            if (reply.Status == IPStatus.Success)
            {
                if (ms <= 100)
                    _expectedIndicatorColor = s_green;
                else if (ms <= 150)
                    _expectedIndicatorColor = s_yellow;
                else if (ms <= 200)
                    _expectedIndicatorColor = s_orange;
                else if (ms > 200)
                    _expectedIndicatorColor = s_red;
            }
            else
            {
                _expectedIndicatorColor = s_gray;
            }

            PingMsLabel.Text = ms + "ms";
        }

        private void UpdateLastPing()
        {
            _lastPing = DateTime.Now;
            _nextPing = _lastPing.AddMilliseconds(Interval);
        }

        // Change the BackColor and the label's BackColor to the specified color.
        private void ChangeBackColor(Color color)
        {
            TitleLabel.BackColor = color;
            IPAddressLabel.BackColor = color;
            PingMsLabel.BackColor = color;

            // Prevent the event from firing and messing up the _defaultColor.
            BackColorChanged -= OnBackgroundColorChanged;
            BackColor = color;
            BackColorChanged += OnBackgroundColorChanged;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            // The rectangle in the left which color codes the state of the connection.
            var leftColorIndicator = new Rectangle(0, 0, 10, Size.Height);

            // Draws an outline around the control.
            graphics.DrawRectangle(s_gray, new Rectangle(0, 0, Size.Width - 1, Size.Height - 1));
            // Then we draw the 'connection state rectangle' with the corresponding color code.
            graphics.FillRectangle(_currentIndicatorColor.Brush, leftColorIndicator);

            base.OnPaint(e);
        }

        // Color to which we're going to rest to when the mouse leaves the color.
        // Color should be same as BackColor.
        private Color _defaultColor;
        private void OnBackgroundColorChanged(object sender, EventArgs e) // Should be named OnBackColorChanged but we've got some conflicts.
        {
            _defaultColor = BackColor;

            // Change the colors of the Labels as well.
            ChangeBackColor(_defaultColor);
        }

        private Timer _timer;
        private DateTime _nextPing;
        private DateTime _lastPing;
        private void OnTimerTick(object sender, EventArgs e)
        {
            // Sends a new ping at the expected time.
            if (DateTime.Now >= _nextPing)
                PingAndUpdateAsync(); 

            var backColorLerpTime = (DateTime.Now - _mouseOverTime);
            // A 100 milliseconds lerp;
            var backColorPerc = (float)backColorLerpTime.TotalMilliseconds / 100f;

            var indicatorLerpTime = (DateTime.Now - _lastPing);
            // A 5 seconds lerp.
            var indicatorColorPerc = (float)indicatorLerpTime.TotalMilliseconds / 5000f;

            _currentIndicatorColor = new Pen(Utils.Lerp(_currentIndicatorColor.Color, _expectedIndicatorColor.Color, indicatorColorPerc));

            if (_mouseOver)
            {
                // Turn background color to the gray color using a lerping function.
                ChangeBackColor(Utils.Lerp(BackColor, s_gray.Color, backColorPerc));
            }
            else
            {
                // Turn background color to the default color using a lerping function.
                ChangeBackColor(Utils.Lerp(BackColor, _defaultColor, backColorPerc));
            }

            Refresh();
        }

        // Determine if mouse is over the control
        private bool _mouseOver;
        // Time of when the mouse was over the control
        private DateTime _mouseOverTime;
        private void OnMouseEnter(object sender, EventArgs e)
        {
            _mouseOver = true;
            _mouseOverTime = DateTime.Now;
        }

        private void OnMouseLeave(object sender, EventArgs e) => _mouseOver = false;
    }
}
