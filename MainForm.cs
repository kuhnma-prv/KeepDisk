using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.Diagnostics;

namespace KeepDisk
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            int.TryParse(ConfigurationManager.AppSettings["CheckInterval"] ?? "5", System.Globalization.NumberStyles.Integer, null, out var checkInterval);

            var userName = UserPrincipal.Current.DisplayName ?? Environment.UserName;
            _timer.Interval = checkInterval * 1000;

            var f = new FileInfo(Application.ExecutablePath);
            _notifyIcon.BalloonTipText = $"Hallo {userName}\nIch prüfe das Laufwerk {f.Directory.Root} alle {checkInterval} Sekunden.";
        }

        private void OnExitApp(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnCheckDisk(object sender, EventArgs e)
        {
            var f = new FileInfo(Application.ExecutablePath);
            Debug.WriteLine(f.Exists);
        }

        private void ShowBallon(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _notifyIcon.ShowBalloonTip(5000);
        }
    }
}
