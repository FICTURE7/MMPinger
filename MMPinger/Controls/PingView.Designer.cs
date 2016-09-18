﻿namespace MMPinger.Controls
{
    partial class PingView
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
            this.IPAddressLabel = new System.Windows.Forms.Label();
            this.PingMsLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IPAddressLabel
            // 
            this.IPAddressLabel.AutoSize = true;
            this.IPAddressLabel.BackColor = System.Drawing.Color.Transparent;
            this.IPAddressLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPAddressLabel.Location = new System.Drawing.Point(20, 30);
            this.IPAddressLabel.Name = "IPAddressLabel";
            this.IPAddressLabel.Size = new System.Drawing.Size(58, 21);
            this.IPAddressLabel.TabIndex = 0;
            this.IPAddressLabel.Text = "0.0.0.0";
            this.IPAddressLabel.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.IPAddressLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // PingMsLabel
            // 
            this.PingMsLabel.AutoSize = true;
            this.PingMsLabel.BackColor = System.Drawing.Color.Transparent;
            this.PingMsLabel.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PingMsLabel.Location = new System.Drawing.Point(21, 51);
            this.PingMsLabel.Name = "PingMsLabel";
            this.PingMsLabel.Size = new System.Drawing.Size(31, 17);
            this.PingMsLabel.TabIndex = 1;
            this.PingMsLabel.Text = "0ms";
            this.PingMsLabel.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.PingMsLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(20, 5);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(142, 21);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Unknown Region";
            this.TitleLabel.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.TitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            // 
            // PingView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.PingMsLabel);
            this.Controls.Add(this.IPAddressLabel);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(580, 75);
            this.MinimumSize = new System.Drawing.Size(580, 75);
            this.Name = "PingView";
            this.Size = new System.Drawing.Size(580, 75);
            this.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IPAddressLabel;
        private System.Windows.Forms.Label PingMsLabel;
        private System.Windows.Forms.Label TitleLabel;
    }
}
