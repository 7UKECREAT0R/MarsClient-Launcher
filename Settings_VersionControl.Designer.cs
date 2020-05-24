namespace TitanixClient___Forms
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
            this.SuspendLayout();
            // 
            // versionSelector
            // 
            this.versionSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.versionSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionSelector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.versionSelector.Font = new System.Drawing.Font("Nexa Light", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionSelector.ForeColor = System.Drawing.Color.White;
            this.versionSelector.FormattingEnabled = true;
            this.versionSelector.Location = new System.Drawing.Point(23, 23);
            this.versionSelector.Name = "versionSelector";
            this.versionSelector.Size = new System.Drawing.Size(522, 34);
            this.versionSelector.Sorted = true;
            this.versionSelector.TabIndex = 5;
            // 
            // Settings_VersionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.Controls.Add(this.versionSelector);
            this.Name = "Settings_VersionControl";
            this.Size = new System.Drawing.Size(568, 609);
            this.Load += new System.EventHandler(this.Settings_VersionControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox versionSelector;
    }
}
