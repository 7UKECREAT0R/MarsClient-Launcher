namespace TitanixClient___Forms
{
    partial class MainLauncher
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.launchButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splash = new System.Windows.Forms.PictureBox();
            this.signout = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.versionSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serverPicker = new System.Windows.Forms.TextBox();
            this.rpcTimer = new System.Windows.Forms.Timer(this.components);
            this.mcLaunchThread = new System.ComponentModel.BackgroundWorker();
            this.keybindsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splash)).BeginInit();
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(234)))), ((int)(((byte)(100)))));
            this.launchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(234)))), ((int)(((byte)(100)))));
            this.launchButton.FlatAppearance.BorderSize = 0;
            this.launchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.launchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.launchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchButton.Font = new System.Drawing.Font("Nexa Bold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchButton.ForeColor = System.Drawing.Color.White;
            this.launchButton.Location = new System.Drawing.Point(239, 395);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(379, 64);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "LAUNCH CLIENT";
            this.launchButton.UseVisualStyleBackColor = false;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            this.launchButton.MouseEnter += new System.EventHandler(this.launchButton_MouseEnter);
            this.launchButton.MouseLeave += new System.EventHandler(this.launchButton_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 416);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(856, 66);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // splash
            // 
            this.splash.BackgroundImage = global::TitanixClient___Forms.Properties.Resources.titanix_overlay1;
            this.splash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splash.Location = new System.Drawing.Point(105, 105);
            this.splash.Name = "splash";
            this.splash.Size = new System.Drawing.Size(646, 258);
            this.splash.TabIndex = 2;
            this.splash.TabStop = false;
            // 
            // signout
            // 
            this.signout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(52)))), ((int)(((byte)(72)))));
            this.signout.BackgroundImage = global::TitanixClient___Forms.Properties.Resources.titanix_logout;
            this.signout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.signout.FlatAppearance.BorderSize = 0;
            this.signout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signout.Location = new System.Drawing.Point(13, 383);
            this.signout.Name = "signout";
            this.signout.Size = new System.Drawing.Size(40, 27);
            this.signout.TabIndex = 3;
            this.signout.UseVisualStyleBackColor = false;
            this.signout.Click += new System.EventHandler(this.signout_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // versionSelector
            // 
            this.versionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionSelector.FormattingEnabled = true;
            this.versionSelector.Location = new System.Drawing.Point(623, 448);
            this.versionSelector.Name = "versionSelector";
            this.versionSelector.Size = new System.Drawing.Size(226, 21);
            this.versionSelector.Sorted = true;
            this.versionSelector.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.label1.Font = new System.Drawing.Font("Nexa Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(623, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "VERSION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.label2.Font = new System.Drawing.Font("Nexa Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "(OPTIONAL) SERVER";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serverPicker
            // 
            this.serverPicker.Location = new System.Drawing.Point(8, 449);
            this.serverPicker.Name = "serverPicker";
            this.serverPicker.Size = new System.Drawing.Size(225, 20);
            this.serverPicker.TabIndex = 7;
            // 
            // rpcTimer
            // 
            this.rpcTimer.Enabled = true;
            this.rpcTimer.Interval = 5000;
            this.rpcTimer.Tick += new System.EventHandler(this.RpcTimer_Tick);
            // 
            // mcLaunchThread
            // 
            this.mcLaunchThread.WorkerSupportsCancellation = true;
            this.mcLaunchThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.McLaunchThread_DoWork);
            // 
            // keybindsButton
            // 
            this.keybindsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.keybindsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.keybindsButton.FlatAppearance.BorderSize = 0;
            this.keybindsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keybindsButton.Font = new System.Drawing.Font("Nexa Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keybindsButton.ForeColor = System.Drawing.Color.White;
            this.keybindsButton.Location = new System.Drawing.Point(317, 319);
            this.keybindsButton.Name = "keybindsButton";
            this.keybindsButton.Size = new System.Drawing.Size(222, 34);
            this.keybindsButton.TabIndex = 8;
            this.keybindsButton.Text = "KEYBINDS";
            this.keybindsButton.UseVisualStyleBackColor = false;
            this.keybindsButton.Click += new System.EventHandler(this.keybindsButton_Click);
            // 
            // MainLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TitanixClient___Forms.Properties.Resources.titanix_bg;
            this.Controls.Add(this.keybindsButton);
            this.Controls.Add(this.serverPicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.versionSelector);
            this.Controls.Add(this.signout);
            this.Controls.Add(this.splash);
            this.Controls.Add(this.launchButton);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "MainLauncher";
            this.Size = new System.Drawing.Size(856, 482);
            this.Load += new System.EventHandler(this.MainLauncher_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainLauncher_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox splash;
        private System.Windows.Forms.Button signout;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox versionSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serverPicker;
        private System.Windows.Forms.Timer rpcTimer;
        private System.ComponentModel.BackgroundWorker mcLaunchThread;
        private System.Windows.Forms.Button keybindsButton;
    }
}
