namespace TitanixClient___Forms
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.minimizebutton = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.mainLauncher1 = new TitanixClient___Forms.MainLauncher();
            this.login1 = new TitanixClient___Forms.Login();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // minimizebutton
            // 
            this.minimizebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.minimizebutton.BackgroundImage = global::TitanixClient___Forms.Properties.Resources.titanix_min;
            this.minimizebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minimizebutton.FlatAppearance.BorderSize = 0;
            this.minimizebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizebutton.Location = new System.Drawing.Point(764, 25);
            this.minimizebutton.Name = "minimizebutton";
            this.minimizebutton.Size = new System.Drawing.Size(30, 30);
            this.minimizebutton.TabIndex = 1;
            this.minimizebutton.UseVisualStyleBackColor = false;
            this.minimizebutton.Click += new System.EventHandler(this.minimizebutton_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exitbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitbutton.BackgroundImage")));
            this.exitbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitbutton.FlatAppearance.BorderSize = 0;
            this.exitbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbutton.Location = new System.Drawing.Point(800, 25);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(30, 30);
            this.exitbutton.TabIndex = 1;
            this.exitbutton.UseVisualStyleBackColor = false;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // mainLauncher1
            // 
            this.mainLauncher1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainLauncher1.BackgroundImage")));
            this.mainLauncher1.Location = new System.Drawing.Point(0, 0);
            this.mainLauncher1.Name = "mainLauncher1";
            this.mainLauncher1.Size = new System.Drawing.Size(856, 482);
            this.mainLauncher1.TabIndex = 0;
            this.mainLauncher1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainLauncher1_MouseDown);
            // 
            // login1
            // 
            this.login1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("login1.BackgroundImage")));
            this.login1.ForeColor = System.Drawing.Color.White;
            this.login1.Location = new System.Drawing.Point(0, 0);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(856, 482);
            this.login1.TabIndex = 2;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 482);
            this.ControlBox = false;
            this.Controls.Add(this.minimizebutton);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Button minimizebutton;
        private Login login1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

