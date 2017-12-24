using MMPinger.UI;

namespace MMPinger.Views
{
    public partial class MainForm : dForm
    {
        private bool _disposed = false;
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
            if (_disposed)
                return;

            if (disposing && (components != null))
            {
                components.Dispose();
            }

            _disposed = true;
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.outerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.innerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dScroll1 = new MMPinger.Views.UI.dVScrollBar();
            this.outerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI Black", 8.5F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.titleLabel.Location = new System.Drawing.Point(8, 2);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(155, 15);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "MATCHMAKING PINGER";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkRed;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(591, 0);
            this.exitButton.Margin = new System.Windows.Forms.Padding(0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(19, 19);
            this.exitButton.TabIndex = 7;
            this.exitButton.Text = "x";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButtonClick);
            // 
            // outerPanel
            // 
            this.outerPanel.Controls.Add(this.innerPanel);
            this.outerPanel.Location = new System.Drawing.Point(6, 24);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Size = new System.Drawing.Size(587, 345);
            this.outerPanel.TabIndex = 10;
            // 
            // innerPanel
            // 
            this.innerPanel.AutoScroll = true;
            this.innerPanel.Location = new System.Drawing.Point(3, 3);
            this.innerPanel.Name = "innerPanel";
            this.innerPanel.Size = new System.Drawing.Size(605, 333);
            this.innerPanel.TabIndex = 10;
            // 
            // dScroll1
            // 
            this.dScroll1.Location = new System.Drawing.Point(599, 24);
            this.dScroll1.Name = "dScroll1";
            this.dScroll1.Size = new System.Drawing.Size(8, 333);
            this.dScroll1.TabIndex = 11;
            this.dScroll1.WrapControl = this.innerPanel;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(610, 375);
            this.Controls.Add(this.dScroll1);
            this.Controls.Add(this.outerPanel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.titleLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Opacity = 1D;
            this.Text = "Matchmaking Pinger";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.outerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.FlowLayoutPanel outerPanel;
        private System.Windows.Forms.FlowLayoutPanel innerPanel;
        private UI.dVScrollBar dScroll1;
    }
}

