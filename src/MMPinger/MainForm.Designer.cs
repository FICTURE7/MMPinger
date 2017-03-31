using System.Net;

namespace MMPinger
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.elValveView1 = new MMPinger.UI.dPingView();
            this.elValveView2 = new MMPinger.UI.dPingView();
            this.elValveView3 = new MMPinger.UI.dPingView();
            this.elValveView4 = new MMPinger.UI.dPingView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "MATCHMAKING PINGER";
            // 
            // elValveView1
            // 
            this.elValveView1.HostName = "197.80.4.37";
            this.elValveView1.Location = new System.Drawing.Point(8, 65);
            this.elValveView1.MaximumSize = new System.Drawing.Size(580, 75);
            this.elValveView1.MinimumSize = new System.Drawing.Size(580, 75);
            this.elValveView1.Name = "elValveView1";
            this.elValveView1.Size = new System.Drawing.Size(580, 75);
            this.elValveView1.TabIndex = 2;
            this.elValveView1.Title = "South Africa";
            // 
            // elValveView2
            // 
            this.elValveView2.HostName = "103.28.54.1";
            this.elValveView2.Location = new System.Drawing.Point(8, 146);
            this.elValveView2.MaximumSize = new System.Drawing.Size(580, 75);
            this.elValveView2.MinimumSize = new System.Drawing.Size(580, 75);
            this.elValveView2.Name = "elValveView2";
            this.elValveView2.Size = new System.Drawing.Size(580, 75);
            this.elValveView2.TabIndex = 3;
            this.elValveView2.Title = "Singapore";
            // 
            // elValveView3
            // 
            this.elValveView3.HostName = "45.121.186.1";
            this.elValveView3.Location = new System.Drawing.Point(8, 227);
            this.elValveView3.MaximumSize = new System.Drawing.Size(580, 75);
            this.elValveView3.MinimumSize = new System.Drawing.Size(580, 75);
            this.elValveView3.Name = "elValveView3";
            this.elValveView3.Size = new System.Drawing.Size(580, 75);
            this.elValveView3.TabIndex = 4;
            this.elValveView3.Title = "Japan";
            // 
            // elValveView4
            // 
            this.elValveView4.HostName = "155.133.244.1";
            this.elValveView4.Location = new System.Drawing.Point(8, 308);
            this.elValveView4.MaximumSize = new System.Drawing.Size(580, 75);
            this.elValveView4.MinimumSize = new System.Drawing.Size(580, 75);
            this.elValveView4.Name = "elValveView4";
            this.elValveView4.Size = new System.Drawing.Size(580, 75);
            this.elValveView4.TabIndex = 5;
            this.elValveView4.Title = "Hong Kong";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.elValveView4);
            this.Controls.Add(this.elValveView3);
            this.Controls.Add(this.elValveView2);
            this.Controls.Add(this.elValveView1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "Matchmaking Pinger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UI.dPingView elValveView1;
        private UI.dPingView elValveView2;
        private UI.dPingView elValveView3;
        private UI.dPingView elValveView4;
    }
}

