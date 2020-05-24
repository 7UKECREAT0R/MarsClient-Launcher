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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.versionSelector = new System.Windows.Forms.ComboBox();
            this.serverPicker = new System.Windows.Forms.TextBox();
            this.rpcTimer = new System.Windows.Forms.Timer(this.components);
            this.keybindsButton = new System.Windows.Forms.Button();
            this.signout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // launchButton
            // 
            this.launchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(31)))), ((int)(((byte)(42)))));
            this.launchButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(31)))), ((int)(((byte)(42)))));
            this.launchButton.FlatAppearance.BorderSize = 0;
            this.launchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.launchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.launchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.launchButton.Font = new System.Drawing.Font("Exo 2", 32F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.launchButton.ForeColor = System.Drawing.Color.White;
            this.launchButton.Location = new System.Drawing.Point(468, 620);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(345, 94);
            this.launchButton.TabIndex = 0;
            this.launchButton.Text = "LAUNCH";
            this.launchButton.UseVisualStyleBackColor = false;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            this.launchButton.MouseEnter += new System.EventHandler(this.launchButton_MouseEnter);
            this.launchButton.MouseLeave += new System.EventHandler(this.launchButton_MouseLeave);
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
            this.versionSelector.Location = new System.Drawing.Point(527, 567);
            this.versionSelector.Name = "versionSelector";
            this.versionSelector.Size = new System.Drawing.Size(226, 21);
            this.versionSelector.Sorted = true;
            this.versionSelector.TabIndex = 4;
            // 
            // serverPicker
            // 
            this.serverPicker.Location = new System.Drawing.Point(528, 594);
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
            // keybindsButton
            // 
            this.keybindsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.keybindsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.keybindsButton.FlatAppearance.BorderSize = 0;
            this.keybindsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keybindsButton.Font = new System.Drawing.Font("Nexa Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keybindsButton.ForeColor = System.Drawing.Color.White;
            this.keybindsButton.Location = new System.Drawing.Point(640, 0);
            this.keybindsButton.Name = "keybindsButton";
            this.keybindsButton.Size = new System.Drawing.Size(182, 78);
            this.keybindsButton.TabIndex = 8;
            this.keybindsButton.Text = "SETTINGS";
            this.keybindsButton.UseVisualStyleBackColor = false;
            this.keybindsButton.Click += new System.EventHandler(this.keybindsButton_Click);
            // 
            // signout
            // 
            this.signout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.signout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.signout.FlatAppearance.BorderSize = 0;
            this.signout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signout.Font = new System.Drawing.Font("Nexa Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signout.ForeColor = System.Drawing.Color.White;
            this.signout.Location = new System.Drawing.Point(459, 0);
            this.signout.Name = "signout";
            this.signout.Size = new System.Drawing.Size(182, 78);
            this.signout.TabIndex = 8;
            this.signout.Text = "SIGN OUT";
            this.signout.UseVisualStyleBackColor = false;
            this.signout.Click += new System.EventHandler(this.signout_Click);
            // 
            // MainLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TitanixClient___Forms.Properties.Resources.marsSplash2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.signout);
            this.Controls.Add(this.keybindsButton);
            this.Controls.Add(this.serverPicker);
            this.Controls.Add(this.versionSelector);
            this.Controls.Add(this.launchButton);
            this.DoubleBuffered = true;
            this.Name = "MainLauncher";
            this.Size = new System.Drawing.Size(1280, 720);
            this.Load += new System.EventHandler(this.MainLauncher_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainLauncher_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox versionSelector;
        private System.Windows.Forms.TextBox serverPicker;
        private System.Windows.Forms.Timer rpcTimer;
        private System.Windows.Forms.Button keybindsButton;
        private System.Windows.Forms.Button signout;
    }
}
