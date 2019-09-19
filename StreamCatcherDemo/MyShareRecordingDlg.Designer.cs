namespace StreamCatcherDemo
{
    partial class MyShareRecordingDlg
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
            this.m_btnShareSwitchCH03 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btnShareSwitchCH04 = new System.Windows.Forms.RadioButton();
            this.m_btnShareSwitchCH02 = new System.Windows.Forms.RadioButton();
            this.m_btnShareSwitchCH01 = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.timerCheckSignal = new System.Windows.Forms.Timer(this.components);
            this.m_checkAVI1_1 = new System.Windows.Forms.RadioButton();
            this.m_checkMP41_1 = new System.Windows.Forms.RadioButton();
            this.m_checkGPU1_1 = new System.Windows.Forms.CheckBox();
            this.textBoxRecordAVI1_1 = new System.Windows.Forms.TextBox();
            this.m_btnShareRecordStop1 = new System.Windows.Forms.Button();
            this.m_btnShareRecordStart1 = new System.Windows.Forms.Button();
            this.ShareWindow = new System.Windows.Forms.Panel();
            this.m_checkFLV1_1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnShareSwitchCH03
            // 
            this.m_btnShareSwitchCH03.AutoCheck = false;
            this.m_btnShareSwitchCH03.AutoSize = true;
            this.m_btnShareSwitchCH03.Location = new System.Drawing.Point(151, 21);
            this.m_btnShareSwitchCH03.Name = "m_btnShareSwitchCH03";
            this.m_btnShareSwitchCH03.Size = new System.Drawing.Size(51, 16);
            this.m_btnShareSwitchCH03.TabIndex = 2;
            this.m_btnShareSwitchCH03.TabStop = true;
            this.m_btnShareSwitchCH03.Text = "CH03";
            this.m_btnShareSwitchCH03.UseVisualStyleBackColor = true;
            this.m_btnShareSwitchCH03.Click += new System.EventHandler(this.m_btnShareSwitchCH03_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_btnShareSwitchCH04);
            this.groupBox1.Controls.Add(this.m_btnShareSwitchCH03);
            this.groupBox1.Controls.Add(this.m_btnShareSwitchCH02);
            this.groupBox1.Controls.Add(this.m_btnShareSwitchCH01);
            this.groupBox1.Location = new System.Drawing.Point(173, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(285, 48);
            this.groupBox1.TabIndex = 172;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SWITCH CHANNEL ( MANUAL SELECTED )";
            // 
            // m_btnShareSwitchCH04
            // 
            this.m_btnShareSwitchCH04.AutoCheck = false;
            this.m_btnShareSwitchCH04.AutoSize = true;
            this.m_btnShareSwitchCH04.Location = new System.Drawing.Point(218, 21);
            this.m_btnShareSwitchCH04.Name = "m_btnShareSwitchCH04";
            this.m_btnShareSwitchCH04.Size = new System.Drawing.Size(51, 16);
            this.m_btnShareSwitchCH04.TabIndex = 3;
            this.m_btnShareSwitchCH04.TabStop = true;
            this.m_btnShareSwitchCH04.Text = "CH04";
            this.m_btnShareSwitchCH04.UseVisualStyleBackColor = true;
            this.m_btnShareSwitchCH04.Click += new System.EventHandler(this.m_btnShareSwitchCH04_Click);
            // 
            // m_btnShareSwitchCH02
            // 
            this.m_btnShareSwitchCH02.AutoCheck = false;
            this.m_btnShareSwitchCH02.AutoSize = true;
            this.m_btnShareSwitchCH02.Location = new System.Drawing.Point(86, 20);
            this.m_btnShareSwitchCH02.Name = "m_btnShareSwitchCH02";
            this.m_btnShareSwitchCH02.Size = new System.Drawing.Size(51, 16);
            this.m_btnShareSwitchCH02.TabIndex = 1;
            this.m_btnShareSwitchCH02.TabStop = true;
            this.m_btnShareSwitchCH02.Text = "CH02";
            this.m_btnShareSwitchCH02.UseVisualStyleBackColor = true;
            this.m_btnShareSwitchCH02.Click += new System.EventHandler(this.m_btnShareSwitchCH02_Click);
            // 
            // m_btnShareSwitchCH01
            // 
            this.m_btnShareSwitchCH01.AutoCheck = false;
            this.m_btnShareSwitchCH01.AutoSize = true;
            this.m_btnShareSwitchCH01.Location = new System.Drawing.Point(11, 20);
            this.m_btnShareSwitchCH01.Name = "m_btnShareSwitchCH01";
            this.m_btnShareSwitchCH01.Size = new System.Drawing.Size(51, 16);
            this.m_btnShareSwitchCH01.TabIndex = 0;
            this.m_btnShareSwitchCH01.TabStop = true;
            this.m_btnShareSwitchCH01.Text = "CH01";
            this.m_btnShareSwitchCH01.UseVisualStyleBackColor = true;
            this.m_btnShareSwitchCH01.Click += new System.EventHandler(this.m_btnShareSwitchCH01_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(383, 198);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 171;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // timerCheckSignal
            // 
            this.timerCheckSignal.Interval = 1000;
            this.timerCheckSignal.Tick += new System.EventHandler(this.timerCheckSignal_Tick);
            // 
            // m_checkAVI1_1
            // 
            this.m_checkAVI1_1.AutoCheck = false;
            this.m_checkAVI1_1.AutoSize = true;
            this.m_checkAVI1_1.Location = new System.Drawing.Point(318, 14);
            this.m_checkAVI1_1.Name = "m_checkAVI1_1";
            this.m_checkAVI1_1.Size = new System.Drawing.Size(119, 16);
            this.m_checkAVI1_1.TabIndex = 169;
            this.m_checkAVI1_1.TabStop = true;
            this.m_checkAVI1_1.Text = "AVI (H.264 + PCM)";
            this.m_checkAVI1_1.UseVisualStyleBackColor = true;
            this.m_checkAVI1_1.Click += new System.EventHandler(this.m_checkAVI1_1_Click);
            // 
            // m_checkMP41_1
            // 
            this.m_checkMP41_1.AutoCheck = false;
            this.m_checkMP41_1.AutoSize = true;
            this.m_checkMP41_1.Checked = true;
            this.m_checkMP41_1.Location = new System.Drawing.Point(439, 14);
            this.m_checkMP41_1.Name = "m_checkMP41_1";
            this.m_checkMP41_1.Size = new System.Drawing.Size(121, 16);
            this.m_checkMP41_1.TabIndex = 170;
            this.m_checkMP41_1.TabStop = true;
            this.m_checkMP41_1.Text = "MP4 (H.264 + AAC)";
            this.m_checkMP41_1.UseVisualStyleBackColor = true;
            this.m_checkMP41_1.Click += new System.EventHandler(this.m_checkMP41_1_Click);
            // 
            // m_checkGPU1_1
            // 
            this.m_checkGPU1_1.AutoSize = true;
            this.m_checkGPU1_1.Location = new System.Drawing.Point(174, 14);
            this.m_checkGPU1_1.Name = "m_checkGPU1_1";
            this.m_checkGPU1_1.Size = new System.Drawing.Size(134, 16);
            this.m_checkGPU1_1.TabIndex = 168;
            this.m_checkGPU1_1.Text = "INTEL GPU SUPPORT";
            this.m_checkGPU1_1.UseVisualStyleBackColor = true;
            this.m_checkGPU1_1.Click += new System.EventHandler(this.m_checkGPU1_1_Click);
            // 
            // textBoxRecordAVI1_1
            // 
            this.textBoxRecordAVI1_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxRecordAVI1_1.Location = new System.Drawing.Point(12, 128);
            this.textBoxRecordAVI1_1.Name = "textBoxRecordAVI1_1";
            this.textBoxRecordAVI1_1.ReadOnly = true;
            this.textBoxRecordAVI1_1.Size = new System.Drawing.Size(444, 22);
            this.textBoxRecordAVI1_1.TabIndex = 167;
            // 
            // m_btnShareRecordStop1
            // 
            this.m_btnShareRecordStop1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnShareRecordStop1.Location = new System.Drawing.Point(12, 64);
            this.m_btnShareRecordStop1.Name = "m_btnShareRecordStop1";
            this.m_btnShareRecordStop1.Size = new System.Drawing.Size(154, 43);
            this.m_btnShareRecordStop1.TabIndex = 166;
            this.m_btnShareRecordStop1.Text = " STOP SHARE RECORD";
            this.m_btnShareRecordStop1.UseVisualStyleBackColor = true;
            this.m_btnShareRecordStop1.Click += new System.EventHandler(this.m_btnShareRecordStop1_Click);
            // 
            // m_btnShareRecordStart1
            // 
            this.m_btnShareRecordStart1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnShareRecordStart1.Location = new System.Drawing.Point(12, 11);
            this.m_btnShareRecordStart1.Name = "m_btnShareRecordStart1";
            this.m_btnShareRecordStart1.Size = new System.Drawing.Size(154, 43);
            this.m_btnShareRecordStart1.TabIndex = 165;
            this.m_btnShareRecordStart1.Text = " START SHARE RECORD";
            this.m_btnShareRecordStart1.UseVisualStyleBackColor = true;
            this.m_btnShareRecordStart1.Click += new System.EventHandler(this.m_btnShareRecordStart1_Click);
            // 
            // ShareWindow
            // 
            this.ShareWindow.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ShareWindow.Location = new System.Drawing.Point(463, 33);
            this.ShareWindow.Name = "ShareWindow";
            this.ShareWindow.Size = new System.Drawing.Size(267, 188);
            this.ShareWindow.TabIndex = 173;
            // 
            // m_checkFLV1_1
            // 
            this.m_checkFLV1_1.AutoCheck = false;
            this.m_checkFLV1_1.AutoSize = true;
            this.m_checkFLV1_1.Location = new System.Drawing.Point(563, 14);
            this.m_checkFLV1_1.Name = "m_checkFLV1_1";
            this.m_checkFLV1_1.Size = new System.Drawing.Size(120, 16);
            this.m_checkFLV1_1.TabIndex = 175;
            this.m_checkFLV1_1.TabStop = true;
            this.m_checkFLV1_1.Text = "FLV (H.264 + AAC)";
            this.m_checkFLV1_1.UseVisualStyleBackColor = true;
            this.m_checkFLV1_1.Click += new System.EventHandler(this.m_checkFLV1_1_Click);
            // 
            // MyShareRecordingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 233);
            this.ControlBox = false;
            this.Controls.Add(this.m_checkFLV1_1);
            this.Controls.Add(this.ShareWindow);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.m_checkAVI1_1);
            this.Controls.Add(this.m_checkMP41_1);
            this.Controls.Add(this.m_checkGPU1_1);
            this.Controls.Add(this.textBoxRecordAVI1_1);
            this.Controls.Add(this.m_btnShareRecordStop1);
            this.Controls.Add(this.m_btnShareRecordStart1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyShareRecordingDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Share Recording";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyShareRecordingDlg_FormClosed);
            this.Load += new System.EventHandler(this.MyShareRecordingDlg_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton m_btnShareSwitchCH03;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton m_btnShareSwitchCH04;
        private System.Windows.Forms.RadioButton m_btnShareSwitchCH02;
        private System.Windows.Forms.RadioButton m_btnShareSwitchCH01;
        internal System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Timer timerCheckSignal;
        private System.Windows.Forms.RadioButton m_checkAVI1_1;
        private System.Windows.Forms.RadioButton m_checkMP41_1;
        private System.Windows.Forms.CheckBox m_checkGPU1_1;
        private System.Windows.Forms.TextBox textBoxRecordAVI1_1;
        private System.Windows.Forms.Button m_btnShareRecordStop1;
        private System.Windows.Forms.Button m_btnShareRecordStart1;
        private System.Windows.Forms.Panel ShareWindow;
        private System.Windows.Forms.RadioButton m_checkFLV1_1;
    }
}