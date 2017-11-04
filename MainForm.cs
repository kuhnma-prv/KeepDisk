using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeepDisk
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var f = new FileInfo(Application.ExecutablePath);
            _notifyIcon.BalloonTipText = $"Hallo {Environment.UserName}\nIch prüfe das Laufwerk {f.Directory.Root} alle 5 Sekunden.";
        }

        private void OnExitApp(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnCheckDisk(object sender, EventArgs e)
        {
            var f = new FileInfo(Application.ExecutablePath);
            Console.WriteLine(f.Exists);
        }

        private void ShowBallon(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                _notifyIcon.ShowBalloonTip(5000);
        }
    }
}
