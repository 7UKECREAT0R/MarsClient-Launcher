namespace MarsClientLauncher
{
    partial class Settings_OtherControl
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
            this.showHypixelGame = new MarsClientLauncher.SmoothCheckBox();
            this.showServerIP = new MarsClientLauncher.SmoothCheckBox();
            this.showPartyInfo = new MarsClientLauncher.SmoothCheckBox();
            this.useRichPresence = new MarsClientLauncher.SmoothCheckBox();
            this.showUsername = new MarsClientLauncher.SmoothCheckBox();
            this.SuspendLayout();
            // 
            // showHypixelGame
            // 
            this.showHypixelGame.BackColor = System.Drawing.Color.Transparent;
            this.showHypixelGame.Location = new System.Drawing.Point(97, 308);
            this.showHypixelGame.Name = "showHypixelGame";
            this.showHypixelGame.Size = new System.Drawing.Size(468, 71);
            this.showHypixelGame.TabIndex = 0;
            // 
            // showServerIP
            // 
            this.showServerIP.BackColor = System.Drawing.Color.Transparent;
            this.showServerIP.Location = new System.Drawing.Point(97, 211);
            this.showServerIP.Name = "showServerIP";
            this.showServerIP.Size = new System.Drawing.Size(471, 71);
            this.showServerIP.TabIndex = 0;
            // 
            // showPartyInfo
            // 
            this.showPartyInfo.BackColor = System.Drawing.Color.Transparent;
            this.showPartyInfo.Location = new System.Drawing.Point(97, 114);
            this.showPartyInfo.Name = "showPartyInfo";
            this.showPartyInfo.Size = new System.Drawing.Size(468, 71);
            this.showPartyInfo.TabIndex = 0;
            // 
            // useRichPresence
            // 
            this.useRichPresence.BackColor = System.Drawing.Color.Transparent;
            this.useRichPresence.Location = new System.Drawing.Point(19, 19);
            this.useRichPresence.Name = "useRichPresence";
            this.useRichPresence.Size = new System.Drawing.Size(316, 71);
            this.useRichPresence.TabIndex = 0;
            // 
            // showUsername
            // 
            this.showUsername.BackColor = System.Drawing.Color.Transparent;
            this.showUsername.Location = new System.Drawing.Point(97, 405);
            this.showUsername.Name = "showUsername";
            this.showUsername.Size = new System.Drawing.Size(468, 71);
            this.showUsername.TabIndex = 0;
            // 
            // Settings_OtherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.Controls.Add(this.showUsername);
            this.Controls.Add(this.showHypixelGame);
            this.Controls.Add(this.showServerIP);
            this.Controls.Add(this.showPartyInfo);
            this.Controls.Add(this.useRichPresence);
            this.Name = "Settings_OtherControl";
            this.Size = new System.Drawing.Size(568, 609);
            this.Load += new System.EventHandler(this.Settings_OtherControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public SmoothCheckBox useRichPresence;
        public SmoothCheckBox showPartyInfo;
        public SmoothCheckBox showServerIP;
        public SmoothCheckBox showHypixelGame;
        public SmoothCheckBox showUsername;
    }
}
