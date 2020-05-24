namespace TitanixClient___Forms
{
    partial class Login
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.confirmButton = new System.Windows.Forms.Button();
            this.passwordBox = new TitanixClient___Forms.TextBoxCueExtension();
            this.usernameBox = new TitanixClient___Forms.TextBoxCueExtension();
            this.offlineCheckBox = new TitanixClient___Forms.SmoothCheckBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.confirmButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.confirmButton.FlatAppearance.BorderSize = 0;
            this.confirmButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.confirmButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.Font = new System.Drawing.Font("Exo 2", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Location = new System.Drawing.Point(87, 405);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(200, 66);
            this.confirmButton.TabIndex = 2;
            this.confirmButton.Text = "PLAY";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordBox.CueColor = System.Drawing.Color.DarkGray;
            this.passwordBox.CueText = "Password";
            this.passwordBox.Font = new System.Drawing.Font("Nexa Light", 14.25F);
            this.passwordBox.ForeColor = System.Drawing.Color.LightGray;
            this.passwordBox.Location = new System.Drawing.Point(65, 318);
            this.passwordBox.MaxLength = 64;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(235, 24);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordBox_KeyDown);
            // 
            // usernameBox
            // 
            this.usernameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.usernameBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameBox.CueColor = System.Drawing.Color.DarkGray;
            this.usernameBox.CueText = "Email";
            this.usernameBox.Font = new System.Drawing.Font("Nexa Light", 14.25F);
            this.usernameBox.ForeColor = System.Drawing.Color.LightGray;
            this.usernameBox.Location = new System.Drawing.Point(65, 254);
            this.usernameBox.MaxLength = 64;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(235, 24);
            this.usernameBox.TabIndex = 0;
            this.usernameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameBox_KeyDown);
            // 
            // offlineCheckBox
            // 
            this.offlineCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.offlineCheckBox.Location = new System.Drawing.Point(65, 538);
            this.offlineCheckBox.Name = "offlineCheckBox";
            this.offlineCheckBox.Size = new System.Drawing.Size(244, 71);
            this.offlineCheckBox.TabIndex = 3;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TitanixClient___Forms.Properties.Resources.marsSplash1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.offlineCheckBox);
            this.Controls.Add(this.confirmButton);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Login";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button confirmButton;
        private SmoothCheckBox offlineCheckBox;
        private TextBoxCueExtension usernameBox;
        private TextBoxCueExtension passwordBox;
    }
}
