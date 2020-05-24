using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitanixClient___Forms
{
    public partial class SettingsMenu : Form
    {
        public const int SETTINGS_TAB_WIDTH = 568;
        public const int SETTINGS_TAB_HEIGHT = 609;
        public SettingsMenu()
        {
            InitializeComponent();
            Form1.SetBorderCurve(10, this);
        }

        private void SettingsMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form1.ReleaseCapture();
                Form1.SendMessage(Handle, Form1.WM_NCLBUTTONDOWN, Form1.HT_CAPTION, 0);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void otherOptions_Click(object sender, EventArgs e)
        {
            other.BringToFront();
            other.enabled = true;
            version.enabled = false;
            keybinds.enabled = false;
        }
        private void versionOptions_Click(object sender, EventArgs e)
        {
            version.BringToFront();
            other.enabled = false;
            version.enabled = true;
            keybinds.enabled = false;
        }
        private void keybindsOptions_Click(object sender, EventArgs e)
        {
            keybinds.BringToFront();
            other.enabled = false;
            version.enabled = false;
            keybinds.enabled = true;
        }
    }
}
