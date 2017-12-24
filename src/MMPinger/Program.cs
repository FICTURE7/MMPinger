using MMPinger.Views;
using System;
using System.Windows.Forms;

namespace MMPinger
{
    public static class Program
    {
        public static Manager Manager => _manager;

        private static Manager _manager;

        [STAThread]
        public static void Main()
        {
            _manager = new Manager();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
