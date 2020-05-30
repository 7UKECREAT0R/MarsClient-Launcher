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
    public partial class SmoothCheckBox : UserControl
    {
        int clicks = 0;
        bool rainbow = false;
        Random rand = new Random();
        public static int Interpolate(int a, int b, double t)
        {
            return (int)((1 - t) * a + t * b);
        }


        int filledWidth;
        double speed = 0.2;
        public bool isChecked;

        public SmoothCheckBox()
        {
            InitializeComponent();
            filledWidth = backPanel.Width;
        }

        private void backPanel_Click(object sender, EventArgs e)
        {
            clicks++;
            isChecked = true;
            OnCheckedChanged?.Invoke(true);

            CheckClicks();
        }
        private void frontPanel_Click(object sender, EventArgs e)
        {
            clicks++;
            isChecked = false;
            OnCheckedChanged?.Invoke(false);

            CheckClicks();
        }
        void CheckClicks()
        {
            if(clicks > 15)
            {
                rainbow = true;
            }
        }

        public delegate void CheckedChangedHandler(bool isChecked);
        public event CheckedChangedHandler OnCheckedChanged;

        private void animator_Tick(object sender, EventArgs e)
        {
            if(isChecked)
            {
                int w = frontPanel.Width;
                w = Interpolate(w, filledWidth+4, speed);
                frontPanel.Width = w;
            } else
            {
                int w = frontPanel.Width;
                w = Interpolate(w, 0, speed);
                frontPanel.Width = w;
            }
        }

        private void doTheRainbow(object sender, EventArgs e)
        {
            if (rainbow)
            {
                byte[] cbytes = new byte[3];
                rand.NextBytes(cbytes);
                Color c = Color.FromArgb(
                    cbytes[0], cbytes[1], cbytes[2]);
                frontPanel.BackColor = c;
            }
        }
    }
}
