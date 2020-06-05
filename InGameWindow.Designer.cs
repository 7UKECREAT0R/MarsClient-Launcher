namespace MarsClientLauncher
{
    partial class InGameWindow
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
            this.sizeUpdater = new System.Windows.Forms.Timer(this.components);
            this.friendsList = new System.Windows.Forms.ListView();
            this.friendsFetcher = new System.ComponentModel.BackgroundWorker();
            this.friendUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // sizeUpdater
            // 
            this.sizeUpdater.Interval = 16;
            this.sizeUpdater.Tick += new System.EventHandler(this.SizeUpdater_Tick);
            // 
            // friendsList
            // 
            this.friendsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.friendsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.friendsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendsList.HideSelection = false;
            this.friendsList.Location = new System.Drawing.Point(20, 42);
            this.friendsList.Name = "friendsList";
            this.friendsList.Size = new System.Drawing.Size(580, 323);
            this.friendsList.TabIndex = 0;
            this.friendsList.UseCompatibleStateImageBehavior = false;
            // 
            // friendUpdateTimer
            // 
            this.friendUpdateTimer.Enabled = true;
            this.friendUpdateTimer.Interval = 1200;
            this.friendUpdateTimer.Tick += new System.EventHandler(this.FriendUpdateTimer_Tick);
            // 
            // InGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1198, 720);
            this.Controls.Add(this.friendsList);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InGameWindow";
            this.Text = "InGameWindow";
            this.Resize += new System.EventHandler(this.InGameWindow_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer sizeUpdater;
        private System.Windows.Forms.ListView friendsList;
        private System.ComponentModel.BackgroundWorker friendsFetcher;
        private System.Windows.Forms.Timer friendUpdateTimer;
    }
}