using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmlLib.Core;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace MarsClientLauncher
{
    public partial class Settings_VersionControl : UserControl
    {
        public Settings_VersionControl()
        {
            InitializeComponent();
            Form1.SetBorderCurve(10, versionSelector);
            Form1.SetBorderCurve(10, panel1);
        }

        public bool enabled = false;
        Point enabledPos, disabledPos;
        Timer timer;

        private void Settings_VersionControl_Load(object sender, EventArgs e)
        {
            enabledPos = new Point(SettingsMenu.SETTINGS_TAB_X, 74);
            disabledPos = enabledPos;
            disabledPos.X += Size.Width;
            Location = disabledPos;
            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += Timer_Tick;
            timer.Start();

            versionSelector.Items.Clear();

            if (Data.launcher != null)
            foreach (MProfileMetadata md in Data.launcher.Profiles)
            {
                string name = md.Name;
                string comp = name.ToLower();
                if (!comp.Contains('w') &&
                !comp.StartsWith("a") &&
                !comp.StartsWith("b") &&
                !comp.StartsWith("c") &&
                !comp.Contains("pre"))
                {
                    versionSelector.Items.Add(md.Name);
                }
            }

            string vs = Data.versionString;
            if(!string.IsNullOrWhiteSpace(vs))
                versionSelector.SelectedItem = vs;

            string ip = Data.serverIP;
            serverField.Text = ip;
        }
        public static int Interpolate(int a, int b, double t)
        {
            return (int)((1 - t) * a + t * b);
        }
        private void versionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = (string)versionSelector.Items[versionSelector.SelectedIndex];
            Data.versionString = name;
        }
        private void serverField_TextChanged(object sender, EventArgs e)
        {
            string ip = serverField.Text;
            Regex rg = new Regex("\\S+\\.\\S+\\.\\S+");
            if (rg.IsMatch(ip))
                serverField.ForeColor = Color.White;
            else
                serverField.ForeColor = Color.Red;
            Data.serverIP = ip;
        }
        private void textBoxCueExtension1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                versionSelector.Focus();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Animate left or right.
            Point loc = Location;
            int curX = loc.X;
            int goalX;
            if (enabled)
                goalX = enabledPos.X;
            else
                goalX = disabledPos.X;

            int n = Interpolate(curX, goalX, 0.2);
            loc.X = n;
            Location = loc;
        }
    }
}
