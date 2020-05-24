namespace TitanixClient___Forms
{
    partial class SmoothCheckBox
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
            this.title = new System.Windows.Forms.Label();
            this.subtitle = new System.Windows.Forms.Label();
            this.frontPanel = new System.Windows.Forms.PictureBox();
            this.backPanel = new System.Windows.Forms.PictureBox();
            this.animator = new System.Windows.Forms.Timer(this.components);
            this.rainbowTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.frontPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Font = new System.Drawing.Font("Nexa Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.title.Location = new System.Drawing.Point(75, 3);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(181, 37);
            this.title.TabIndex = 0;
            this.title.Text = "Title Text";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // subtitle
            // 
            this.subtitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitle.Font = new System.Drawing.Font("Nexa Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitle.ForeColor = System.Drawing.Color.Silver;
            this.subtitle.Location = new System.Drawing.Point(3, 43);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(253, 24);
            this.subtitle.TabIndex = 1;
            this.subtitle.Text = "Subtitle text goes here.";
            this.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frontPanel
            // 
            this.frontPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.frontPanel.Location = new System.Drawing.Point(33, 4);
            this.frontPanel.Name = "frontPanel";
            this.frontPanel.Size = new System.Drawing.Size(10, 36);
            this.frontPanel.TabIndex = 3;
            this.frontPanel.TabStop = false;
            this.frontPanel.Click += new System.EventHandler(this.frontPanel_Click);
            // 
            // backPanel
            // 
            this.backPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.backPanel.Location = new System.Drawing.Point(33, 4);
            this.backPanel.Name = "backPanel";
            this.backPanel.Size = new System.Drawing.Size(36, 36);
            this.backPanel.TabIndex = 2;
            this.backPanel.TabStop = false;
            this.backPanel.Click += new System.EventHandler(this.backPanel_Click);
            // 
            // animator
            // 
            this.animator.Enabled = true;
            this.animator.Interval = 16;
            this.animator.Tick += new System.EventHandler(this.animator_Tick);
            // 
            // rainbowTimer
            // 
            this.rainbowTimer.Enabled = true;
            this.rainbowTimer.Tick += new System.EventHandler(this.doTheRainbow);
            // 
            // SmoothCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.frontPanel);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.subtitle);
            this.Controls.Add(this.title);
            this.Name = "SmoothCheckBox";
            this.Size = new System.Drawing.Size(259, 71);
            ((System.ComponentModel.ISupportInitialize)(this.frontPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label title;
        public System.Windows.Forms.Label subtitle;
        private System.Windows.Forms.PictureBox backPanel;
        private System.Windows.Forms.PictureBox frontPanel;
        private System.Windows.Forms.Timer animator;
        private System.Windows.Forms.Timer rainbowTimer;
    }
}
