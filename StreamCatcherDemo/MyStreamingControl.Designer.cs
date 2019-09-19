namespace StreamCatcherDemo
{
    partial class MyStreamingControl
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
            this.m_checkRtspGPU = new System.Windows.Forms.CheckBox();
            this.textBoxRtspURL1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRtspURL2 = new System.Windows.Forms.TextBox();
            this.textBoxRtspURL3 = new System.Windows.Forms.TextBox();
            this.textBoxRtspURL4 = new System.Windows.Forms.TextBox();
            this.m_btnStopStreaming = new System.Windows.Forms.Button();
            this.m_btnStartStreaming = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_checkRtspGPU
            // 
            this.m_checkRtspGPU.AutoSize = true;
            this.m_checkRtspGPU.Location = new System.Drawing.Point(12, 12);
            this.m_checkRtspGPU.Name = "m_checkRtspGPU";
            this.m_checkRtspGPU.Size = new System.Drawing.Size(134, 16);
            this.m_checkRtspGPU.TabIndex = 73;
            this.m_checkRtspGPU.Text = "INTEL GPU SUPPORT";
            this.m_checkRtspGPU.UseVisualStyleBackColor = true;
            this.m_checkRtspGPU.Click += new System.EventHandler(this.m_checkRtspGPU_Click);
            // 
            // textBoxRtspURL1
            // 
            this.textBoxRtspURL1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRtspURL1.Location = new System.Drawing.Point(98, 38);
            this.textBoxRtspURL1.Name = "textBoxRtspURL1";
            this.textBoxRtspURL1.ReadOnly = true;
            this.textBoxRtspURL1.Size = new System.Drawing.Size(230, 22);
            this.textBoxRtspURL1.TabIndex = 74;
            this.textBoxRtspURL1.Text = "rtsp://root:root@127.0.0.1/session0.mpg";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 75;
            this.label1.Text = "CH01 URL : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 12);
            this.label2.TabIndex = 76;
            this.label2.Text = "CH02 URL : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 77;
            this.label3.Text = "CH03 URL : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 78;
            this.label4.Text = "CH04 URL : ";
            // 
            // textBoxRtspURL2
            // 
            this.textBoxRtspURL2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRtspURL2.Location = new System.Drawing.Point(98, 69);
            this.textBoxRtspURL2.Name = "textBoxRtspURL2";
            this.textBoxRtspURL2.ReadOnly = true;
            this.textBoxRtspURL2.Size = new System.Drawing.Size(230, 22);
            this.textBoxRtspURL2.TabIndex = 79;
            this.textBoxRtspURL2.Text = "rtsp://root:root@127.0.0.1/session1.mpg";
            // 
            // textBoxRtspURL3
            // 
            this.textBoxRtspURL3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRtspURL3.Location = new System.Drawing.Point(98, 100);
            this.textBoxRtspURL3.Name = "textBoxRtspURL3";
            this.textBoxRtspURL3.ReadOnly = true;
            this.textBoxRtspURL3.Size = new System.Drawing.Size(230, 22);
            this.textBoxRtspURL3.TabIndex = 80;
            this.textBoxRtspURL3.Text = "rtsp://root:root@127.0.0.1/session2.mpg";
            // 
            // textBoxRtspURL4
            // 
            this.textBoxRtspURL4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRtspURL4.Location = new System.Drawing.Point(98, 131);
            this.textBoxRtspURL4.Name = "textBoxRtspURL4";
            this.textBoxRtspURL4.ReadOnly = true;
            this.textBoxRtspURL4.Size = new System.Drawing.Size(230, 22);
            this.textBoxRtspURL4.TabIndex = 81;
            this.textBoxRtspURL4.Text = "rtsp://root:root@127.0.0.1/session3.mpg";
            // 
            // m_btnStopStreaming
            // 
            this.m_btnStopStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnStopStreaming.Location = new System.Drawing.Point(174, 162);
            this.m_btnStopStreaming.Name = "m_btnStopStreaming";
            this.m_btnStopStreaming.Size = new System.Drawing.Size(154, 43);
            this.m_btnStopStreaming.TabIndex = 83;
            this.m_btnStopStreaming.Text = " STOP STREAMING";
            this.m_btnStopStreaming.UseVisualStyleBackColor = true;
            this.m_btnStopStreaming.Click += new System.EventHandler(this.m_btnStopStreaming_Click);
            // 
            // m_btnStartStreaming
            // 
            this.m_btnStartStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnStartStreaming.Location = new System.Drawing.Point(12, 162);
            this.m_btnStartStreaming.Name = "m_btnStartStreaming";
            this.m_btnStartStreaming.Size = new System.Drawing.Size(154, 43);
            this.m_btnStartStreaming.TabIndex = 82;
            this.m_btnStartStreaming.Text = " START STREAMING";
            this.m_btnStartStreaming.UseVisualStyleBackColor = true;
            this.m_btnStartStreaming.Click += new System.EventHandler(this.m_btnStartStreaming_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(253, 216);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 115;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // MyStreamingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 253);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.m_btnStopStreaming);
            this.Controls.Add(this.m_btnStartStreaming);
            this.Controls.Add(this.textBoxRtspURL4);
            this.Controls.Add(this.textBoxRtspURL3);
            this.Controls.Add(this.textBoxRtspURL2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRtspURL1);
            this.Controls.Add(this.m_checkRtspGPU);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyStreamingControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STREAMING SERVER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyStreamingControl_FormClosed);
            this.Load += new System.EventHandler(this.MyStreamingControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox m_checkRtspGPU;
        private System.Windows.Forms.TextBox textBoxRtspURL1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRtspURL2;
        private System.Windows.Forms.TextBox textBoxRtspURL3;
        private System.Windows.Forms.TextBox textBoxRtspURL4;
        private System.Windows.Forms.Button m_btnStopStreaming;
        private System.Windows.Forms.Button m_btnStartStreaming;
        internal System.Windows.Forms.Button buttonOK;
    }
}