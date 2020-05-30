namespace MarsClientLauncher
{
    partial class SettingsMenu
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
            this.exitButton = new System.Windows.Forms.Button();
            this.otherOptions = new System.Windows.Forms.Button();
            this.keybindsOptions = new System.Windows.Forms.Button();
            this.versionOptions = new System.Windows.Forms.Button();
            this.version = new MarsClientLauncher.Settings_VersionControl();
            this.keybinds = new MarsClientLauncher.Settings_KeybindsControl();
            this.other = new MarsClientLauncher.Settings_OtherControl();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.exitButton.Location = new System.Drawing.Point(1210, 9);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(40, 40);
            this.exitButton.TabIndex = 0;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // otherOptions
            // 
            this.otherOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.otherOptions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.otherOptions.FlatAppearance.BorderSize = 0;
            this.otherOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.otherOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.otherOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.otherOptions.Font = new System.Drawing.Font("Nexa Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otherOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.otherOptions.Location = new System.Drawing.Point(104, 178);
            this.otherOptions.Name = "otherOptions";
            this.otherOptions.Size = new System.Drawing.Size(180, 71);
            this.otherOptions.TabIndex = 1;
            this.otherOptions.Text = "OTHER";
            this.otherOptions.UseVisualStyleBackColor = false;
            this.otherOptions.Click += new System.EventHandler(this.otherOptions_Click);
            // 
            // keybindsOptions
            // 
            this.keybindsOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.keybindsOptions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.keybindsOptions.FlatAppearance.BorderSize = 0;
            this.keybindsOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.keybindsOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.keybindsOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keybindsOptions.Font = new System.Drawing.Font("Nexa Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keybindsOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.keybindsOptions.Location = new System.Drawing.Point(104, 457);
            this.keybindsOptions.Name = "keybindsOptions";
            this.keybindsOptions.Size = new System.Drawing.Size(180, 71);
            this.keybindsOptions.TabIndex = 2;
            this.keybindsOptions.Text = "KEYBINDS";
            this.keybindsOptions.UseVisualStyleBackColor = false;
            this.keybindsOptions.Click += new System.EventHandler(this.keybindsOptions_Click);
            // 
            // versionOptions
            // 
            this.versionOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.versionOptions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.versionOptions.FlatAppearance.BorderSize = 0;
            this.versionOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.versionOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.versionOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.versionOptions.Font = new System.Drawing.Font("Nexa Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.versionOptions.Location = new System.Drawing.Point(104, 320);
            this.versionOptions.Name = "versionOptions";
            this.versionOptions.Size = new System.Drawing.Size(180, 71);
            this.versionOptions.TabIndex = 2;
            this.versionOptions.Text = "LAUNCHER";
            this.versionOptions.UseVisualStyleBackColor = false;
            this.versionOptions.Click += new System.EventHandler(this.versionOptions_Click);
            // 
            // version
            // 
            this.version.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.version.Location = new System.Drawing.Point(1262, 74);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(568, 609);
            this.version.TabIndex = 5;
            // 
            // keybinds
            // 
            this.keybinds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.keybinds.Location = new System.Drawing.Point(1266, 74);
            this.keybinds.Name = "keybinds";
            this.keybinds.Size = new System.Drawing.Size(568, 609);
            this.keybinds.TabIndex = 4;
            // 
            // other
            // 
            this.other.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.other.Location = new System.Drawing.Point(1266, 74);
            this.other.Margin = new System.Windows.Forms.Padding(0);
            this.other.Name = "other";
            this.other.Size = new System.Drawing.Size(568, 610);
            this.other.TabIndex = 3;
            // 
            // SettingsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MarsClientLauncher.Properties.Resources.marsSettingsSplash;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.version);
            this.Controls.Add(this.keybinds);
            this.Controls.Add(this.other);
            this.Controls.Add(this.versionOptions);
            this.Controls.Add(this.keybindsOptions);
            this.Controls.Add(this.otherOptions);
            this.Controls.Add(this.exitButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsMenu";
            this.Text = "SettingsMenu";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SettingsMenu_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button otherOptions;
        private System.Windows.Forms.Button keybindsOptions;
        private System.Windows.Forms.Button versionOptions;
        private Settings_OtherControl other;
        private Settings_KeybindsControl keybinds;
        private Settings_VersionControl version;
    }
}