namespace StreamCatcherDemo
{
    partial class MySetupControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MySetupControl));
            this.m_scDeviceFormatInformation1 = new System.Windows.Forms.TextBox();
            this.timerShowInfo = new System.Windows.Forms.Timer(this.components);
            this.m_btnVideoInput = new System.Windows.Forms.Button();
            this.m_btnAudioInput = new System.Windows.Forms.Button();
            this.m_btnVideoQuality = new System.Windows.Forms.Button();
            this.m_checkAutoDeinterlace = new System.Windows.Forms.CheckBox();
            this.timerCheckSignal = new System.Windows.Forms.Timer(this.components);
            this.m_checkShowCloneVideo = new System.Windows.Forms.CheckBox();
            this.m_scDeviceFormatInformation2 = new System.Windows.Forms.TextBox();
            this.m_scDeviceFormatInformation3 = new System.Windows.Forms.TextBox();
            this.m_scDeviceFormatInformation4 = new System.Windows.Forms.TextBox();
            this.m_btnSnapShot = new System.Windows.Forms.Button();
            this.m_btnFileRecording = new System.Windows.Forms.Button();
            this.m_btnShareRecording = new System.Windows.Forms.Button();
            this.m_btnOSDSettings = new System.Windows.Forms.Button();
            this.m_btnStreaming = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_scDeviceFormatInformation1
            // 
            this.m_scDeviceFormatInformation1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_scDeviceFormatInformation1.Location = new System.Drawing.Point(7, 7);
            this.m_scDeviceFormatInformation1.Name = "m_scDeviceFormatInformation1";
            this.m_scDeviceFormatInformation1.ReadOnly = true;
            this.m_scDeviceFormatInformation1.Size = new System.Drawing.Size(891, 22);
            this.m_scDeviceFormatInformation1.TabIndex = 0;
            // 
            // timerShowInfo
            // 
            this.timerShowInfo.Enabled = true;
            this.timerShowInfo.Interval = 500;
            this.timerShowInfo.Tick += new System.EventHandler(this.timerShowInfo_Tick);
            // 
            // m_btnVideoInput
            // 
            this.m_btnVideoInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnVideoInput.Location = new System.Drawing.Point(7, 119);
            this.m_btnVideoInput.Name = "m_btnVideoInput";
            this.m_btnVideoInput.Size = new System.Drawing.Size(154, 43);
            this.m_btnVideoInput.TabIndex = 1;
            this.m_btnVideoInput.Text = " VIDEO INPUT +";
            this.m_btnVideoInput.UseVisualStyleBackColor = true;
            this.m_btnVideoInput.Click += new System.EventHandler(this.m_btnVideoInput_Click);
            // 
            // m_btnAudioInput
            // 
            this.m_btnAudioInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAudioInput.Location = new System.Drawing.Point(7, 168);
            this.m_btnAudioInput.Name = "m_btnAudioInput";
            this.m_btnAudioInput.Size = new System.Drawing.Size(154, 43);
            this.m_btnAudioInput.TabIndex = 2;
            this.m_btnAudioInput.Text = " AUDIO INPUT +";
            this.m_btnAudioInput.UseVisualStyleBackColor = true;
            this.m_btnAudioInput.Click += new System.EventHandler(this.m_btnAudioInput_Click);
            // 
            // m_btnVideoQuality
            // 
            this.m_btnVideoQuality.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnVideoQuality.Location = new System.Drawing.Point(167, 119);
            this.m_btnVideoQuality.Name = "m_btnVideoQuality";
            this.m_btnVideoQuality.Size = new System.Drawing.Size(154, 43);
            this.m_btnVideoQuality.TabIndex = 5;
            this.m_btnVideoQuality.Text = " VIDEO QUALITY +";
            this.m_btnVideoQuality.UseVisualStyleBackColor = true;
            this.m_btnVideoQuality.Click += new System.EventHandler(this.m_btnVideoQuality_Click);
            // 
            // m_checkAutoDeinterlace
            // 
            this.m_checkAutoDeinterlace.AutoSize = true;
            this.m_checkAutoDeinterlace.Location = new System.Drawing.Point(741, 181);
            this.m_checkAutoDeinterlace.Name = "m_checkAutoDeinterlace";
            this.m_checkAutoDeinterlace.Size = new System.Drawing.Size(155, 20);
            this.m_checkAutoDeinterlace.TabIndex = 16;
            this.m_checkAutoDeinterlace.Text = "AUTO DEINTERLACE";
            this.m_checkAutoDeinterlace.UseVisualStyleBackColor = true;
            this.m_checkAutoDeinterlace.Click += new System.EventHandler(this.m_checkAutoDeinterlace_Click);
            // 
            // timerCheckSignal
            // 
            this.timerCheckSignal.Interval = 1000;
            this.timerCheckSignal.Tick += new System.EventHandler(this.timerCheckSignal_Tick);
            // 
            // m_checkShowCloneVideo
            // 
            this.m_checkShowCloneVideo.AutoSize = true;
            this.m_checkShowCloneVideo.Location = new System.Drawing.Point(741, 155);
            this.m_checkShowCloneVideo.Name = "m_checkShowCloneVideo";
            this.m_checkShowCloneVideo.Size = new System.Drawing.Size(155, 20);
            this.m_checkShowCloneVideo.TabIndex = 25;
            this.m_checkShowCloneVideo.Text = "SHOW CLONE VIDEO";
            this.m_checkShowCloneVideo.UseVisualStyleBackColor = true;
            this.m_checkShowCloneVideo.Click += new System.EventHandler(this.m_checkShowCloneVideo_Click);
            // 
            // m_scDeviceFormatInformation2
            // 
            this.m_scDeviceFormatInformation2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_scDeviceFormatInformation2.Location = new System.Drawing.Point(7, 35);
            this.m_scDeviceFormatInformation2.Name = "m_scDeviceFormatInformation2";
            this.m_scDeviceFormatInformation2.ReadOnly = true;
            this.m_scDeviceFormatInformation2.Size = new System.Drawing.Size(891, 22);
            this.m_scDeviceFormatInformation2.TabIndex = 26;
            // 
            // m_scDeviceFormatInformation3
            // 
            this.m_scDeviceFormatInformation3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_scDeviceFormatInformation3.Location = new System.Drawing.Point(7, 63);
            this.m_scDeviceFormatInformation3.Name = "m_scDeviceFormatInformation3";
            this.m_scDeviceFormatInformation3.ReadOnly = true;
            this.m_scDeviceFormatInformation3.Size = new System.Drawing.Size(891, 22);
            this.m_scDeviceFormatInformation3.TabIndex = 27;
            // 
            // m_scDeviceFormatInformation4
            // 
            this.m_scDeviceFormatInformation4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_scDeviceFormatInformation4.Location = new System.Drawing.Point(7, 91);
            this.m_scDeviceFormatInformation4.Name = "m_scDeviceFormatInformation4";
            this.m_scDeviceFormatInformation4.ReadOnly = true;
            this.m_scDeviceFormatInformation4.Size = new System.Drawing.Size(891, 22);
            this.m_scDeviceFormatInformation4.TabIndex = 28;
            // 
            // m_btnSnapShot
            // 
            this.m_btnSnapShot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnSnapShot.Location = new System.Drawing.Point(167, 168);
            this.m_btnSnapShot.Name = "m_btnSnapShot";
            this.m_btnSnapShot.Size = new System.Drawing.Size(154, 43);
            this.m_btnSnapShot.TabIndex = 65;
            this.m_btnSnapShot.Text = "SNAPSHOT";
            this.m_btnSnapShot.UseVisualStyleBackColor = true;
            this.m_btnSnapShot.Click += new System.EventHandler(this.m_btnSnapShot_Click);
            // 
            // m_btnFileRecording
            // 
            this.m_btnFileRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnFileRecording.Location = new System.Drawing.Point(327, 119);
            this.m_btnFileRecording.Name = "m_btnFileRecording";
            this.m_btnFileRecording.Size = new System.Drawing.Size(154, 43);
            this.m_btnFileRecording.TabIndex = 66;
            this.m_btnFileRecording.Text = "FILE RECORDING";
            this.m_btnFileRecording.UseVisualStyleBackColor = true;
            this.m_btnFileRecording.Click += new System.EventHandler(this.m_btnFileRecording_Click);
            // 
            // m_btnShareRecording
            // 
            this.m_btnShareRecording.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnShareRecording.Location = new System.Drawing.Point(327, 168);
            this.m_btnShareRecording.Name = "m_btnShareRecording";
            this.m_btnShareRecording.Size = new System.Drawing.Size(154, 43);
            this.m_btnShareRecording.TabIndex = 67;
            this.m_btnShareRecording.Text = "SHARE RECORDING";
            this.m_btnShareRecording.UseVisualStyleBackColor = true;
            this.m_btnShareRecording.Click += new System.EventHandler(this.m_btnShareRecording_Click);
            // 
            // m_btnOSDSettings
            // 
            this.m_btnOSDSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOSDSettings.Location = new System.Drawing.Point(487, 119);
            this.m_btnOSDSettings.Name = "m_btnOSDSettings";
            this.m_btnOSDSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_btnOSDSettings.Size = new System.Drawing.Size(154, 43);
            this.m_btnOSDSettings.TabIndex = 68;
            this.m_btnOSDSettings.Text = "OSD SETTINGS +";
            this.m_btnOSDSettings.UseVisualStyleBackColor = true;
            this.m_btnOSDSettings.Click += new System.EventHandler(this.m_btnOSDSettings_Click);
            // 
            // m_btnStreaming
            // 
            this.m_btnStreaming.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnStreaming.Location = new System.Drawing.Point(487, 168);
            this.m_btnStreaming.Name = "m_btnStreaming";
            this.m_btnStreaming.Size = new System.Drawing.Size(154, 43);
            this.m_btnStreaming.TabIndex = 69;
            this.m_btnStreaming.Text = "STREAMING +";
            this.m_btnStreaming.UseVisualStyleBackColor = true;
            this.m_btnStreaming.Click += new System.EventHandler(this.m_btnStreaming_Click);
            // 
            // MySetupControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 226);
            this.Controls.Add(this.m_btnStreaming);
            this.Controls.Add(this.m_btnOSDSettings);
            this.Controls.Add(this.m_btnShareRecording);
            this.Controls.Add(this.m_btnFileRecording);
            this.Controls.Add(this.m_btnSnapShot);
            this.Controls.Add(this.m_scDeviceFormatInformation4);
            this.Controls.Add(this.m_scDeviceFormatInformation3);
            this.Controls.Add(this.m_scDeviceFormatInformation2);
            this.Controls.Add(this.m_checkShowCloneVideo);
            this.Controls.Add(this.m_checkAutoDeinterlace);
            this.Controls.Add(this.m_btnVideoQuality);
            this.Controls.Add(this.m_btnAudioInput);
            this.Controls.Add(this.m_btnVideoInput);
            this.Controls.Add(this.m_scDeviceFormatInformation1);
            this.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MySetupControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Yuan\'s Capture Card Demo Software";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MySetupControl_FormClosed);
            this.Load += new System.EventHandler(this.MySetupControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_scDeviceFormatInformation1;
        private System.Windows.Forms.Timer timerShowInfo;
        private System.Windows.Forms.Button m_btnVideoInput;
        private System.Windows.Forms.Button m_btnAudioInput;
        private System.Windows.Forms.Button m_btnVideoQuality;
        private System.Windows.Forms.CheckBox m_checkAutoDeinterlace;
        private System.Windows.Forms.Timer timerCheckSignal;
        private System.Windows.Forms.CheckBox m_checkShowCloneVideo;
        private System.Windows.Forms.TextBox m_scDeviceFormatInformation2;
        private System.Windows.Forms.TextBox m_scDeviceFormatInformation3;
        private System.Windows.Forms.TextBox m_scDeviceFormatInformation4;
        private System.Windows.Forms.Button m_btnSnapShot;
        private System.Windows.Forms.Button m_btnFileRecording;
        private System.Windows.Forms.Button m_btnShareRecording;
        private System.Windows.Forms.Button m_btnOSDSettings;
        private System.Windows.Forms.Button m_btnStreaming;
    }
}