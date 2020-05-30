namespace MarsClientLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.animator = new System.Windows.Forms.Timer(this.components);
            this.exitbutton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainLauncher1 = new MarsClientLauncher.MainLauncher();
            this.login1 = new MarsClientLauncher.Login();
            this.closingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // animator
            // 
            this.animator.Enabled = true;
            this.animator.Interval = 1000;
            this.animator.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // exitbutton
            // 
            this.exitbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.exitbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitbutton.FlatAppearance.BorderSize = 0;
            this.exitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbutton.Font = new System.Drawing.Font("Exo 2", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.exitbutton.Location = new System.Drawing.Point(1214, 12);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(38, 38);
            this.exitbutton.TabIndex = 1;
            this.exitbutton.Text = "X";
            this.exitbutton.UseVisualStyleBackColor = false;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // mainLauncher1
            // 
            this.mainLauncher1.BackgroundImage = global::MarsClientLauncher.Properties.Resources.marsSplash2;
            this.mainLauncher1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainLauncher1.Location = new System.Drawing.Point(-7, 0);
            this.mainLauncher1.Name = "mainLauncher1";
            this.mainLauncher1.Size = new System.Drawing.Size(1280, 720);
            this.mainLauncher1.TabIndex = 0;
            this.mainLauncher1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainLauncher1_MouseDown);
            // 
            // login1
            // 
            this.login1.BackColor = System.Drawing.Color.Transparent;
            this.login1.BackgroundImage = global::MarsClientLauncher.Properties.Resources.marsSplash1;
            this.login1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.login1.ForeColor = System.Drawing.Color.White;
            this.login1.Location = new System.Drawing.Point(0, 0);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(1280, 720);
            this.login1.TabIndex = 2;
            // 
            // closingTimer
            // 
            this.closingTimer.Enabled = true;
            this.closingTimer.Interval = 250;
            this.closingTimer.Tick += new System.EventHandler(this.closingTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 720);
            this.ControlBox = false;
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.mainLauncher1);
            this.Controls.Add(this.login1);
            this.Name = "Form1";
            this.Text = "Titanix";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MainLauncher mainLauncher1;
        private System.Windows.Forms.Timer animator;
        private System.Windows.Forms.Button exitbutton;
        private Login login1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer closingTimer;
    }
}

