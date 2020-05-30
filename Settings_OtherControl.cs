using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsClientLauncher
{
    public partial class Settings_OtherControl : UserControl
    {
        public Settings_OtherControl()
        {
            InitializeComponent();
            useRichPresence.isChecked = Data._usingRichPresence;
            showHypixelGame.isChecked = Data._showGamePlaying;
            showPartyInfo.isChecked = Data._showPartyInfo;
            showServerIP.isChecked = Data._showServerIP;
            showUsername.isChecked = Data._showUsername;

            useRichPresence.title.Text = "Use Rich Presence";
            useRichPresence.subtitle.Text = "Allow people to see MarsClient on discord!";
            showHypixelGame.title.Text = "Show Game";
            showHypixelGame.subtitle.Text = "Display what game on Hypixel you're playing!";
            showPartyInfo.title.Text = "Show Party Info";
            showPartyInfo.subtitle.Text = "Display who you're in a party with on Hypixel!";
            showServerIP.title.Text = "Show Server IP";
            showServerIP.subtitle.Text = "Display the IP of the server you're playing on!";
            showUsername.title.Text = "Show Username";
            showUsername.subtitle.Text = "Display the username of the account you're playing on!";

            useRichPresence.OnCheckedChanged += UseRichPresence_OnCheckedChanged;
            showHypixelGame.OnCheckedChanged += delegate (bool ic)
            {
                if(!useRichPresence.isChecked)
                {
                    showHypixelGame.isChecked = !ic;
                    return;
                }
                Data._showGamePlaying = ic;
            };
            showPartyInfo.OnCheckedChanged += delegate (bool ic)
            {
                if (!useRichPresence.isChecked)
                {
                    showPartyInfo.isChecked = !ic;
                    return;
                }
                Data._showPartyInfo = ic;
            };
            showServerIP.OnCheckedChanged += delegate (bool ic)
            {
                if (!useRichPresence.isChecked)
                {
                    showServerIP.isChecked = !ic;
                    return;
                }
                Data._showServerIP = ic;
            };
            showUsername.OnCheckedChanged += delegate (bool ic)
            {
                if (!useRichPresence.isChecked)
                {
                    showUsername.isChecked = !ic;
                    return;
                }
                Data._showUsername = ic;
            };
        }

        private void UseRichPresence_OnCheckedChanged(bool isChecked)
        {
            if(!isChecked)
                Data.rpccli?.ClearPresence();

            Data._usingRichPresence = isChecked;
            Data._showGamePlaying = isChecked;
            Data._showPartyInfo = isChecked;
            Data._showServerIP = isChecked;
            Data._showUsername = isChecked;

            showHypixelGame.isChecked = isChecked;
            showPartyInfo.isChecked = isChecked;
            showServerIP.isChecked = isChecked;
            showUsername.isChecked = isChecked;
        }

        public bool enabled = false;
        Point enabledPos, disabledPos;
        Timer timer;

        private void Settings_OtherControl_Load(object sender, EventArgs e)
        {
            enabledPos = new Point(SettingsMenu.SETTINGS_TAB_X, 74);
            disabledPos = enabledPos;
            disabledPos.X += Size.Width;
            Location = disabledPos;
            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += Timer_Tick;

            timer.Start();
        }

        public static int Interpolate(int a, int b, double t)
        {
            return (int)((1 - t) * a + t * b);
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
