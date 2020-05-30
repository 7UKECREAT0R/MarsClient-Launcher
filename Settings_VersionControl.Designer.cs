namespace MarsClientLauncher
{
    partial class Settings_VersionControl
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
            this.versionSelector = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.serverField = new MarsClientLauncher.TextBoxCueExtension();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // versionSelector
            // 
            this.versionSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.versionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.versionSelector.Font = new System.Drawing.Font("Nexa Light", 18F);
            this.versionSelector.ForeColor = System.Drawing.Color.White;
            this.versionSelector.FormattingEnabled = true;
            this.versionSelector.Location = new System.Drawing.Point(23, 23);
            this.versionSelector.Name = "versionSelector";
            this.versionSelector.Size = new System.Drawing.Size(522, 38);
            this.versionSelector.TabIndex = 0;
            this.versionSelector.SelectedIndexChanged += new System.EventHandler(this.versionSelector_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.serverField);
            this.panel1.Location = new System.Drawing.Point(23, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 49);
            this.panel1.TabIndex = 2;
            // 
            // serverField
            // 
            this.serverField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.serverField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.serverField.CueColor = System.Drawing.Color.DimGray;
            this.serverField.CueText = "(Optional) Server IP";
            this.serverField.Font = new System.Drawing.Font("Nexa Light", 18F);
            this.serverField.ForeColor = System.Drawing.Color.White;
            this.serverField.Location = new System.Drawing.Point(11, 9);
            this.serverField.Name = "serverField";
            this.serverField.Size = new System.Drawing.Size(499, 30);
            this.serverField.TabIndex = 1;
            this.serverField.TextChanged += new System.EventHandler(this.serverField_TextChanged);
            this.serverField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCueExtension1_KeyDown);
            // 
            // Settings_VersionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.versionSelector);
            this.Name = "Settings_VersionControl";
            this.Size = new System.Drawing.Size(568, 609);
            this.Load += new System.EventHandler(this.Settings_VersionControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox versionSelector;
        private TextBoxCueExtension serverField;
        private System.Windows.Forms.Panel panel1;
    }
}
