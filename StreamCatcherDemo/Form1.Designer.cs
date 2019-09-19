namespace StreamCatcherDemo
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerCheckSignal = new System.Windows.Forms.Timer(this.components);
            this.CloneChannelPanel1 = new System.Windows.Forms.Panel();
            this.CloneChannelPanel2 = new System.Windows.Forms.Panel();
            this.CloneChannelPanel3 = new System.Windows.Forms.Panel();
            this.CloneChannelPanel4 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerCheckSignal
            // 
            this.timerCheckSignal.Interval = 500;
            this.timerCheckSignal.Tick += new System.EventHandler(this.timerCheckSignal_Tick);
            // 
            // CloneChannelPanel1
            // 
            this.CloneChannelPanel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CloneChannelPanel1.Location = new System.Drawing.Point(2, 326);
            this.CloneChannelPanel1.Name = "CloneChannelPanel1";
            this.CloneChannelPanel1.Size = new System.Drawing.Size(240, 178);
            this.CloneChannelPanel1.TabIndex = 1;
            this.CloneChannelPanel1.Visible = false;
            // 
            // CloneChannelPanel2
            // 
            this.CloneChannelPanel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CloneChannelPanel2.Location = new System.Drawing.Point(248, 326);
            this.CloneChannelPanel2.Name = "CloneChannelPanel2";
            this.CloneChannelPanel2.Size = new System.Drawing.Size(240, 178);
            this.CloneChannelPanel2.TabIndex = 2;
            this.CloneChannelPanel2.Visible = false;
            // 
            // CloneChannelPanel3
            // 
            this.CloneChannelPanel3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CloneChannelPanel3.Location = new System.Drawing.Point(494, 326);
            this.CloneChannelPanel3.Name = "CloneChannelPanel3";
            this.CloneChannelPanel3.Size = new System.Drawing.Size(240, 178);
            this.CloneChannelPanel3.TabIndex = 3;
            this.CloneChannelPanel3.Visible = false;
            // 
            // CloneChannelPanel4
            // 
            this.CloneChannelPanel4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.CloneChannelPanel4.Location = new System.Drawing.Point(740, 326);
            this.CloneChannelPanel4.Name = "CloneChannelPanel4";
            this.CloneChannelPanel4.Size = new System.Drawing.Size(240, 178);
            this.CloneChannelPanel4.TabIndex = 4;
            this.CloneChannelPanel4.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(952, 506);
            this.Controls.Add(this.CloneChannelPanel4);
            this.Controls.Add(this.CloneChannelPanel3);
            this.Controls.Add(this.CloneChannelPanel2);
            this.Controls.Add(this.CloneChannelPanel1);
            this.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yuan\'s Capture Card Demo Software";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerCheckSignal;
        private System.Windows.Forms.Panel CloneChannelPanel1;
        private System.Windows.Forms.Panel CloneChannelPanel2;
        private System.Windows.Forms.Panel CloneChannelPanel3;
        private System.Windows.Forms.Panel CloneChannelPanel4;
        private System.Windows.Forms.Timer timer1;
    }
}

