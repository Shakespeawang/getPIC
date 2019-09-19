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
    public partial class MyShareRecordingDlg : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        public string m_strCurrentDir = "";

        public MySetupControl m_pSetupForm;

        public uint[] m_hCapDev = new uint[4];

        public bool m_bSupportGPU = false;

        public bool m_bIsShareRecord = false;

        public bool m_bCheckedAVI = false;

        public bool m_bCheckedMP4 = true;

        public bool m_bCheckedFLV = false;

        public bool[] m_bShareRecordCH = new bool[4];

        public string m_strAviName;

        // FOURCC MARCO
        //
        uint MAKEFOURCC(uint ch0, uint ch1, uint ch2, uint ch3)
        {
            return ((uint)(byte)(ch0) | ((uint)(byte)(ch1) << 8) | ((uint)(byte)(ch2) << 16) | ((uint)(byte)(ch3) << 24));
        }

        public MyShareRecordingDlg()
        {
            InitializeComponent();
        }

        private void MyShareRecordingDlg_Load(object sender, EventArgs e)
        {
            // GET CURRENT DIRECTORY
            //
            m_strCurrentDir = Directory.GetCurrentDirectory();

            m_strAviName = m_strCurrentDir + "\\SHARE_RECORD.MP4";

            textBoxRecordAVI1_1.Text = m_strAviName;

            m_btnShareRecordStart1.Enabled = true; m_btnShareRecordStop1.Enabled = false;

            m_btnShareSwitchCH01.Checked = true; m_btnShareSwitchCH02.Checked = false; m_btnShareSwitchCH03.Checked = false; m_btnShareSwitchCH04.Checked = false;

            m_bShareRecordCH[0] = true; m_bShareRecordCH[1] = false; m_bShareRecordCH[2] = false; m_bShareRecordCH[3] = false;
        }

        private void MyShareRecordingDlg_FormClosed(object sender, FormClosedEventArgs e)
        {            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            //m_btnShareRecordStop1_Click(sender, e);

            Hide();
        }

        private void timerCheckSignal_Tick(object sender, EventArgs e)
        {
            m_hCapDev[0] = m_pSetupForm.m_hCapDev1;

            m_hCapDev[1] = m_pSetupForm.m_hCapDev2;

            m_hCapDev[2] = m_pSetupForm.m_hCapDev3;

            m_hCapDev[3] = m_pSetupForm.m_hCapDev4;
        }

        private void m_btnShareRecordStart1_Click(object sender, EventArgs e)
        {
            m_btnShareRecordStart1.Enabled = false;

            m_btnShareRecordStop1.Enabled = true;

            m_bSupportGPU = m_checkGPU1_1.Checked;

            uint nVideoWidth = m_pSetupForm.m_pMainForm.m_nVideoWidth;

            uint nVideoHeight = m_pSetupForm.m_pMainForm.m_nVideoHeight;

            double dVideoFrameRate = m_pSetupForm.m_pMainForm.m_dVideoFrameRate;

            if (m_bCheckedAVI)
            {
                EXPORTS.QCAP_SET_AUDIO_SHARE_RECORD_PROPERTY(0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_PCM, 2, 16, 48000);
            }

            if (m_bCheckedMP4)
            {
                EXPORTS.QCAP_SET_AUDIO_SHARE_RECORD_PROPERTY(0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC, 2, 16, 48000);
            }

            if (m_bCheckedFLV)
            {
                EXPORTS.QCAP_SET_AUDIO_SHARE_RECORD_PROPERTY(0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC, 2, 16, 48000);
            }

            if (m_bSupportGPU)
            {
                EXPORTS.QCAP_SET_VIDEO_SHARE_RECORD_PROPERTY(0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_INTEL_MEDIA_SDK, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, MAKEFOURCC('Y', 'U', 'Y', '2'), nVideoWidth, nVideoHeight, dVideoFrameRate, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 4194304, 30, 0, 0, (uint)ShareWindow.Handle.ToInt32(), 1);
            }
            else
            {
                EXPORTS.QCAP_SET_VIDEO_SHARE_RECORD_PROPERTY(0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, MAKEFOURCC('Y', 'U', 'Y', '2'), nVideoWidth, nVideoHeight, dVideoFrameRate, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 4194304, 30, 0, 0, (uint)ShareWindow.Handle.ToInt32(), 1);
            }

            string str_avi_name = m_strAviName;

            string pszNULL = null;

            EXPORTS.QCAP_START_SHARE_RECORD(0, ref str_avi_name, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);

            m_bIsShareRecord = true;

            m_pSetupForm.m_pMainForm.m_bIsShareRecord = true;
        }

        private void m_btnShareRecordStop1_Click(object sender, EventArgs e)
        {
            m_btnShareRecordStart1.Enabled = true;

            m_btnShareRecordStop1.Enabled = false;

            EXPORTS.QCAP_STOP_SHARE_RECORD(0);

            m_bIsShareRecord = false;

            m_pSetupForm.m_pMainForm.m_bIsShareRecord = false;            
        }

        private void m_checkGPU1_1_Click(object sender, EventArgs e)
        {
            m_btnShareRecordStop1_Click(sender, e);
        }        

        private void m_btnShareSwitchCH01_Click(object sender, EventArgs e)
        {
            m_btnShareSwitchCH01.Checked = true;

            m_btnShareSwitchCH02.Checked = false;

            m_btnShareSwitchCH03.Checked = false;

            m_btnShareSwitchCH04.Checked = false;

            m_bShareRecordCH[0] = true; m_bShareRecordCH[1] = false; m_bShareRecordCH[2] = false; m_bShareRecordCH[3] = false;

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[0] = m_bShareRecordCH[0];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[1] = m_bShareRecordCH[1];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[2] = m_bShareRecordCH[2];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[3] = m_bShareRecordCH[3];
        }

        private void m_btnShareSwitchCH02_Click(object sender, EventArgs e)
        {
            m_btnShareSwitchCH01.Checked = false;

            m_btnShareSwitchCH02.Checked = true;

            m_btnShareSwitchCH03.Checked = false;

            m_btnShareSwitchCH04.Checked = false;

            m_bShareRecordCH[0] = false; m_bShareRecordCH[1] = true; m_bShareRecordCH[2] = false; m_bShareRecordCH[3] = false;

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[0] = m_bShareRecordCH[0];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[1] = m_bShareRecordCH[1];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[2] = m_bShareRecordCH[2];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[3] = m_bShareRecordCH[3];
        }

        private void m_btnShareSwitchCH03_Click(object sender, EventArgs e)
        {
            m_btnShareSwitchCH01.Checked = false;

            m_btnShareSwitchCH02.Checked = false;

            m_btnShareSwitchCH03.Checked = true;

            m_btnShareSwitchCH04.Checked = false;

            m_bShareRecordCH[0] = false; m_bShareRecordCH[1] = false; m_bShareRecordCH[2] = true; m_bShareRecordCH[3] = false;

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[0] = m_bShareRecordCH[0];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[1] = m_bShareRecordCH[1];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[2] = m_bShareRecordCH[2];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[3] = m_bShareRecordCH[3];
        }

        private void m_btnShareSwitchCH04_Click(object sender, EventArgs e)
        {
            m_btnShareSwitchCH01.Checked = false;

            m_btnShareSwitchCH02.Checked = false;

            m_btnShareSwitchCH03.Checked = false;

            m_btnShareSwitchCH04.Checked = true;

            m_bShareRecordCH[0] = false; m_bShareRecordCH[1] = false; m_bShareRecordCH[2] = false; m_bShareRecordCH[3] = true;

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[0] = m_bShareRecordCH[0];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[1] = m_bShareRecordCH[1];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[2] = m_bShareRecordCH[2];

            m_pSetupForm.m_pMainForm.m_bShareRecordCH[3] = m_bShareRecordCH[3];
        }

        private void m_checkAVI1_1_Click(object sender, EventArgs e)
        {
            m_checkAVI1_1.Checked = true;

            m_checkMP41_1.Checked = false;

            m_checkFLV1_1.Checked = false;

            m_bCheckedAVI = true;

            m_bCheckedMP4 = false;

            m_bCheckedFLV = false;

            m_strAviName = m_strAviName.Replace(".MP4", ".AVI");

            m_strAviName = m_strAviName.Replace(".FLV", ".AVI");

            textBoxRecordAVI1_1.Text = m_strAviName;
        }

        private void m_checkMP41_1_Click(object sender, EventArgs e)
        {
            m_checkAVI1_1.Checked = false;

            m_checkMP41_1.Checked = true;

            m_checkFLV1_1.Checked = false;

            m_bCheckedAVI = false;

            m_bCheckedMP4 = true;

            m_bCheckedFLV = false;

            m_strAviName = m_strAviName.Replace(".AVI", ".MP4");

            m_strAviName = m_strAviName.Replace(".FLV", ".MP4");

            textBoxRecordAVI1_1.Text = m_strAviName;
        }

        private void m_checkFLV1_1_Click(object sender, EventArgs e)
        {
            m_checkAVI1_1.Checked = false;

            m_checkMP41_1.Checked = false;

            m_checkFLV1_1.Checked = true;

            m_bCheckedAVI = false;

            m_bCheckedMP4 = false;

            m_bCheckedFLV = true;

            m_strAviName = m_strAviName.Replace(".AVI", ".FLV");

            m_strAviName = m_strAviName.Replace(".MP4", ".FLV");

            textBoxRecordAVI1_1.Text = m_strAviName;
        }
    }
}
