using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitanixClient___Forms
{
    public partial class Settings_KeybindsControl : UserControl
    {
        public Settings_KeybindsControl()
        {
            InitializeComponent();
        }

        public bool enabled = false;
        Point enabledPos, disabledPos;
        Timer timer;

        private void Settings_KeybindsControl_Load(object sender, EventArgs e)
        {
            enabledPos = Location;
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
