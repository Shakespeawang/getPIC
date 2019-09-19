using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

using QCAP.NET;

namespace StreamCatcherDemo
{
    public partial class MySetupControl : Form
    {
        public Form1 m_pMainForm;

        public uint m_hCapDev1 = 0x00000000, m_hCapDev2 = 0x00000000, m_hCapDev3 = 0x00000000, m_hCapDev4 = 0x00000000;

        public string m_strFormatChangedOutput1 = " INFO :  . . .", m_strFormatChangedOutput2 = " INFO :  . . .", m_strFormatChangedOutput3 = " INFO :  . . .", m_strFormatChangedOutput4 = " INFO :  . . .";

        public string m_strCurrentDir = "";

        public bool m_bAutoDeinterlace = true;

        public bool m_bNoSignal1 = true, m_bNoSignal2 = true, m_bNoSignal3 = true, m_bNoSignal4 = true;

        public bool m_bIsRecord1_1 = false, m_bIsRecord1_2 = false, m_bIsRecord2_1 = false, m_bIsRecord2_2 = false;

        public bool m_bIsRecord3_1 = false, m_bIsRecord3_2 = false, m_bIsRecord4_1 = false, m_bIsRecord4_2 = false;

        public bool m_bSupportGPU1_1 = false, m_bSupportGPU1_2 = false, m_bSupportGPU2_1 = false, m_bSupportGPU2_2 = false;

        public bool m_bSupportGPU3_1 = false, m_bSupportGPU3_2 = false, m_bSupportGPU4_1 = false, m_bSupportGPU4_2 = false;

        public bool m_bCheckedAVI1_1 = true, m_bCheckedAVI1_2 = true, m_bCheckedAVI2_1 = true, m_bCheckedAVI2_2 = true;

        public bool m_bCheckedAVI3_1 = true, m_bCheckedAVI3_2 = true, m_bCheckedAVI4_1 = true, m_bCheckedAVI4_2 = true;

        public bool m_bCheckedMP41_1 = false, m_bCheckedMP41_2 = false, m_bCheckedMP42_1 = false, m_bCheckedMP42_2 = false;

        public bool m_bCheckedMP43_1 = false, m_bCheckedMP43_2 = false, m_bCheckedMP44_1 = false, m_bCheckedMP44_2 = false;     

        public string m_strAviName1_1, m_strAviName1_2, m_strAviName2_1, m_strAviName2_2;

        public string m_strAviName3_1, m_strAviName3_2, m_strAviName4_1, m_strAviName4_2;

        public MyVideoInputDlg m_cVideoInputDlg;

        public MyAudioInputDlg m_cAudioInputDlg;

        public MyVideoPropertyDlg m_cVideoPropertytDlg;

        public MySnapShotDlg m_cSnapShotDlg;

        public MyRecordingDlg m_cRecordingDlg;

        public MyShareRecordingDlg m_cShareRecordingDlg;

        public MyOSDPropertyDlg m_cOSDPropertytDlg;

        public MyStreamingControl m_cStreamingControlDlg;

        public MySetupControl()
        {
            InitializeComponent();
        }        

        private void MySetupControl_Load(object sender, EventArgs e)
        {          
            // GET CURRENT DIRECTORY
            //
            m_strCurrentDir = Directory.GetCurrentDirectory();

            m_cVideoInputDlg = new MyVideoInputDlg();

            m_cVideoInputDlg.m_pMainForm = this;

            m_cVideoInputDlg.Hide();

            m_cAudioInputDlg = new MyAudioInputDlg();

            m_cAudioInputDlg.m_pMainForm = this;

            m_cAudioInputDlg.Hide();

            m_cVideoPropertytDlg = new MyVideoPropertyDlg();

            m_cVideoPropertytDlg.m_pMainForm = this;

            m_cVideoPropertytDlg.Hide();

            m_cSnapShotDlg = new MySnapShotDlg();

            m_cSnapShotDlg.m_pMainForm = this;

            m_cSnapShotDlg.Hide();

            m_cRecordingDlg = new MyRecordingDlg();

            m_cRecordingDlg.m_pMainForm = this;

            m_cRecordingDlg.Hide();

            m_cShareRecordingDlg = new MyShareRecordingDlg();

            m_cShareRecordingDlg.m_pSetupForm = this;

            m_cShareRecordingDlg.Hide();

            m_cOSDPropertytDlg = new MyOSDPropertyDlg();

            m_cOSDPropertytDlg.m_pMainForm = this;

            m_cOSDPropertytDlg.Hide();

            m_cStreamingControlDlg = new MyStreamingControl();

            m_cStreamingControlDlg.m_pMainForm = this;

            m_cStreamingControlDlg.Hide();

            m_strAviName1_1 = m_strCurrentDir + "\\CH01_1.AVI";

            m_strAviName1_2 = m_strCurrentDir + "\\CH01_2.AVI";

            m_strAviName2_1 = m_strCurrentDir + "\\CH02_1.AVI";

            m_strAviName2_2 = m_strCurrentDir + "\\CH02_2.AVI";

            m_strAviName3_1 = m_strCurrentDir + "\\CH03_1.AVI";

            m_strAviName3_2 = m_strCurrentDir + "\\CH03_2.AVI";

            m_strAviName4_1 = m_strCurrentDir + "\\CH04_1.AVI";

            m_strAviName4_2 = m_strCurrentDir + "\\CH04_2.AVI";

            timerCheckSignal.Enabled = true;
        }

        private void MySetupControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerShowInfo.Enabled = false;

            timerCheckSignal.Enabled = false;
        }

        private void timerShowInfo_Tick(object sender, EventArgs e)
        {
            m_scDeviceFormatInformation1.Text = m_strFormatChangedOutput1;

            m_scDeviceFormatInformation2.Text = m_strFormatChangedOutput2;

            m_scDeviceFormatInformation3.Text = m_strFormatChangedOutput3;

            m_scDeviceFormatInformation4.Text = m_strFormatChangedOutput4;
        }

        private void m_btnVideoInput_Click(object sender, EventArgs e)
        {
            m_cVideoInputDlg.m_hCapDev[0] = m_pMainForm.m_hCapDev[0];

            m_cVideoInputDlg.m_hCapDev[1] = m_pMainForm.m_hCapDev[1];

            m_cVideoInputDlg.m_hCapDev[2] = m_pMainForm.m_hCapDev[2];

            m_cVideoInputDlg.m_hCapDev[3] = m_pMainForm.m_hCapDev[3];

            m_cVideoInputDlg.Show();
        }

        private void m_btnAudioInput_Click(object sender, EventArgs e)
        {        
            m_cAudioInputDlg.m_hCapDev[0] = m_pMainForm.m_hCapDev[0];

            m_cAudioInputDlg.m_hCapDev[1] = m_pMainForm.m_hCapDev[1];

            m_cAudioInputDlg.m_hCapDev[2] = m_pMainForm.m_hCapDev[2];

            m_cAudioInputDlg.m_hCapDev[3] = m_pMainForm.m_hCapDev[3];

            m_cAudioInputDlg.Show();
        }        

        private void m_btnVideoQuality_Click(object sender, EventArgs e)
        {            
            m_cVideoPropertytDlg.m_hCapDev[0] = m_pMainForm.m_hCapDev[0];

            m_cVideoPropertytDlg.m_hCapDev[1] = m_pMainForm.m_hCapDev[1];

            m_cVideoPropertytDlg.m_hCapDev[2] = m_pMainForm.m_hCapDev[2];

            m_cVideoPropertytDlg.m_hCapDev[3] = m_pMainForm.m_hCapDev[3];

            m_cVideoPropertytDlg.Show();
        }

        private void m_checkAutoDeinterlace_Click(object sender, EventArgs e)
        {            
            m_bAutoDeinterlace = m_checkAutoDeinterlace.Checked;

            m_hCapDev1 = m_pMainForm.m_hCapDev[0];

            m_hCapDev2 = m_pMainForm.m_hCapDev[1];

            m_hCapDev3 = m_pMainForm.m_hCapDev[2];

            m_hCapDev4 = m_pMainForm.m_hCapDev[3];

            if (m_hCapDev1 != 0)
            {
                if (m_bAutoDeinterlace)
                    EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev1, 1);
                else
                    EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev1, 0);
            }

            if (m_hCapDev2 != 0)
            {
                if (m_bAutoDeinterlace)
                    EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev2, 1);
                else
                    EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev2, 0);
            }

            if (m_hCapDev3 != 0)
            {
                if (m_bAutoDeinterlace)
                    EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev3, 1);
                else
                    EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev3, 0);
            }

            if (m_hCapDev4 != 0)
            {
                if (m_bAutoDeinterlace)
                    EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev4, 1);
                else
                    EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev4, 0);
            }
        }

        private void m_checkShowCloneVideo_Click(object sender, EventArgs e)
        {
            bool bShowCloneVideo = m_checkShowCloneVideo.Checked;

            if (bShowCloneVideo)
            {
                m_pMainForm.ShowCloneVideo( true );
            }
            else
            {
                m_pMainForm.ShowCloneVideo( false );
            }
        }

        private void timerCheckSignal_Tick(object sender, EventArgs e)
        {            
            m_hCapDev1 = m_pMainForm.m_hCapDev[0];

            m_hCapDev2 = m_pMainForm.m_hCapDev[1];

            m_hCapDev3 = m_pMainForm.m_hCapDev[2];

            m_hCapDev4 = m_pMainForm.m_hCapDev[3];

            m_cVideoInputDlg.m_hCapDev[0] = m_hCapDev1;

            m_cVideoInputDlg.m_hCapDev[1] = m_hCapDev2;

            m_cVideoInputDlg.m_hCapDev[2] = m_hCapDev3;

            m_cVideoInputDlg.m_hCapDev[3] = m_hCapDev4;

            m_cRecordingDlg.m_bNoSignal1 = m_bNoSignal1;

            m_cRecordingDlg.m_bNoSignal2 = m_bNoSignal2;

            m_cRecordingDlg.m_bNoSignal3 = m_bNoSignal3;

            m_cRecordingDlg.m_bNoSignal4 = m_bNoSignal4;
        }

        private void m_btnSnapShot_Click(object sender, EventArgs e)
        {
            m_cSnapShotDlg.m_hCapDev[0] = m_pMainForm.m_hCapDev[0];

            m_cSnapShotDlg.m_hCapDev[1] = m_pMainForm.m_hCapDev[1];

            m_cSnapShotDlg.m_hCapDev[2] = m_pMainForm.m_hCapDev[2];

            m_cSnapShotDlg.m_hCapDev[3] = m_pMainForm.m_hCapDev[3];

            m_cSnapShotDlg.Show();
        }

        private void m_btnFileRecording_Click(object sender, EventArgs e)
        {
            m_cRecordingDlg.m_hCapDev[0] = m_pMainForm.m_hCapDev[0];

            m_cRecordingDlg.m_hCapDev[1] = m_pMainForm.m_hCapDev[1];

            m_cRecordingDlg.m_hCapDev[2] = m_pMainForm.m_hCapDev[2];

            m_cRecordingDlg.m_hCapDev[3] = m_pMainForm.m_hCapDev[3];

            m_cRecordingDlg.Show();
        }

        private void m_btnShareRecording_Click(object sender, EventArgs e)
        {
            m_cShareRecordingDlg.m_hCapDev[0] = m_pMainForm.m_hCapDev[0];

            m_cShareRecordingDlg.m_hCapDev[1] = m_pMainForm.m_hCapDev[1];

            m_cShareRecordingDlg.m_hCapDev[2] = m_pMainForm.m_hCapDev[2];

            m_cShareRecordingDlg.m_hCapDev[3] = m_pMainForm.m_hCapDev[3];

            m_cShareRecordingDlg.Show();
        }

        private void m_btnOSDSettings_Click(object sender, EventArgs e)
        {
            m_cOSDPropertytDlg.m_hCapDev[0] = m_pMainForm.m_hCapDev[0];

            m_cOSDPropertytDlg.m_hCapDev[1] = m_pMainForm.m_hCapDev[1];

            m_cOSDPropertytDlg.m_hCapDev[2] = m_pMainForm.m_hCapDev[2];

            m_cOSDPropertytDlg.m_hCapDev[3] = m_pMainForm.m_hCapDev[3];

            m_cOSDPropertytDlg.Show();
        }

        private void m_btnStreaming_Click(object sender, EventArgs e)
        {
            m_cStreamingControlDlg.m_nVideoWidth = m_pMainForm.m_nVideoWidth;

            m_cStreamingControlDlg.m_nVideoHeight = m_pMainForm.m_nVideoHeight;

            m_cStreamingControlDlg.m_dVideoFrameRate = m_pMainForm.m_dVideoFrameRate;

            m_cStreamingControlDlg.m_hCapDev[0] = m_pMainForm.m_hCapDev[0];

            m_cStreamingControlDlg.m_hCapDev[1] = m_pMainForm.m_hCapDev[1];

            m_cStreamingControlDlg.m_hCapDev[2] = m_pMainForm.m_hCapDev[2];

            m_cStreamingControlDlg.m_hCapDev[3] = m_pMainForm.m_hCapDev[3];

            m_cStreamingControlDlg.Show();
        }
    }
}