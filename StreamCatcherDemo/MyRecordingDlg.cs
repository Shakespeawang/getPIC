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
    public partial class MyRecordingDlg : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        public string m_strCurrentDir = "";

        public MySetupControl m_pMainForm;

        public uint[] m_hCapDev = new uint[4];

        public bool m_bNoSignal1 = true, m_bNoSignal2 = true, m_bNoSignal3 = true, m_bNoSignal4 = true;

        public bool m_bIsRecord1_1 = false, m_bIsRecord1_2 = false, m_bIsRecord2_1 = false, m_bIsRecord2_2 = false;

        public bool m_bIsRecord3_1 = false, m_bIsRecord3_2 = false, m_bIsRecord4_1 = false, m_bIsRecord4_2 = false;

        public bool m_bSupportGPU1_1 = false, m_bSupportGPU1_2 = false, m_bSupportGPU2_1 = false, m_bSupportGPU2_2 = false;

        public bool m_bSupportGPU3_1 = false, m_bSupportGPU3_2 = false, m_bSupportGPU4_1 = false, m_bSupportGPU4_2 = false;

        public bool m_bCheckedAVI1_1 = false, m_bCheckedAVI1_2 = false, m_bCheckedAVI2_1 = false, m_bCheckedAVI2_2 = false;

        public bool m_bCheckedAVI3_1 = false, m_bCheckedAVI3_2 = false, m_bCheckedAVI4_1 = false, m_bCheckedAVI4_2 = false;

        public bool m_bCheckedMP41_1 = true, m_bCheckedMP41_2 = true, m_bCheckedMP42_1 = true, m_bCheckedMP42_2 = true;

        public bool m_bCheckedMP43_1 = true, m_bCheckedMP43_2 = true, m_bCheckedMP44_1 = true, m_bCheckedMP44_2 = true;

        public bool m_bCheckedFLV1_1 = false, m_bCheckedFLV1_2 = false, m_bCheckedFLV2_1 = false, m_bCheckedFLV2_2 = false;

        public bool m_bCheckedFLV3_1 = false, m_bCheckedFLV3_2 = false, m_bCheckedFLV4_1 = false, m_bCheckedFLV4_2 = false;

        public string m_strAviName1_1, m_strAviName1_2, m_strAviName2_1, m_strAviName2_2;

        public string m_strAviName3_1, m_strAviName3_2, m_strAviName4_1, m_strAviName4_2;

        public MyRecordingDlg()
        {
            InitializeComponent();
        }

        private void MyRecordingDlg_Load(object sender, EventArgs e)
        {
            // GET CURRENT DIRECTORY
            //
            m_strCurrentDir = Directory.GetCurrentDirectory();

            m_strAviName1_1 = m_strCurrentDir + "\\CH01_1.MP4";

            m_strAviName1_2 = m_strCurrentDir + "\\CH01_2.MP4";

            m_strAviName2_1 = m_strCurrentDir + "\\CH02_1.MP4";

            m_strAviName2_2 = m_strCurrentDir + "\\CH02_2.MP4";

            m_strAviName3_1 = m_strCurrentDir + "\\CH03_1.MP4";

            m_strAviName3_2 = m_strCurrentDir + "\\CH03_2.MP4";

            m_strAviName4_1 = m_strCurrentDir + "\\CH04_1.MP4";

            m_strAviName4_2 = m_strCurrentDir + "\\CH04_2.MP4";

            textBoxRecordAVI1_1.Text = m_strAviName1_1; textBoxRecordAVI1_2.Text = m_strAviName1_2;

            textBoxRecordAVI2_1.Text = m_strAviName2_1; textBoxRecordAVI2_2.Text = m_strAviName2_2;

            textBoxRecordAVI3_1.Text = m_strAviName3_1; textBoxRecordAVI3_2.Text = m_strAviName3_2;

            textBoxRecordAVI4_1.Text = m_strAviName4_1; textBoxRecordAVI4_2.Text = m_strAviName4_2;

            m_btnRecordStart1_1.Enabled = true; m_btnRecordStop1_1.Enabled = false;

            m_btnRecordStart1_2.Enabled = true; m_btnRecordStop1_2.Enabled = false;

            m_btnRecordStart2_1.Enabled = true; m_btnRecordStop2_1.Enabled = false;

            m_btnRecordStart2_2.Enabled = true; m_btnRecordStop2_2.Enabled = false;

            m_btnRecordStart3_1.Enabled = true; m_btnRecordStop3_1.Enabled = false;

            m_btnRecordStart3_2.Enabled = true; m_btnRecordStop3_2.Enabled = false;

            m_btnRecordStart4_1.Enabled = true; m_btnRecordStop4_1.Enabled = false;

            m_btnRecordStart4_2.Enabled = true; m_btnRecordStop4_2.Enabled = false;
        }

        private void MyRecordingDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_hCapDev[0] != 0) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[0], 0); m_bIsRecord1_1 = false; }

            if (m_hCapDev[0] != 0) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[0], 1); m_bIsRecord1_2 = false; }

            if (m_hCapDev[1] != 0) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[1], 0); m_bIsRecord2_1 = false; }

            if (m_hCapDev[1] != 0) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[1], 1); m_bIsRecord2_2 = false; }

            if (m_hCapDev[2] != 0) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[2], 0); m_bIsRecord3_1 = false; }

            if (m_hCapDev[2] != 0) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[2], 1); m_bIsRecord3_2 = false; }

            if (m_hCapDev[3] != 0) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[3], 0); m_bIsRecord4_1 = false; }

            if (m_hCapDev[3] != 0) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[3], 1); m_bIsRecord4_2 = false; }
        }

        private void MyRecordingDlg_Shown(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void m_btnRecordStart1_1_Click(object sender, EventArgs e)
        {
            m_hCapDev[0] = m_pMainForm.m_hCapDev1;

            m_btnRecordStart1_1.Enabled = false;

            m_btnRecordStop1_1.Enabled = true;

            m_bSupportGPU1_1 = m_checkGPU1_1.Checked;

            if (m_hCapDev[0] != 0)
            {
                if (m_bCheckedAVI1_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[0], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_PCM);
                }

                if (m_bCheckedMP41_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[0], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bCheckedFLV1_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[0], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bSupportGPU1_1)
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[0], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_INTEL_MEDIA_SDK, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_OFF);

                    string str_avi_name1_1 = m_strAviName1_1;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[0], 0, ref str_avi_name1_1, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }
                else
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[0], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_OFF);

                    string str_avi_name1_1 = m_strAviName1_1;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[0], 0, ref str_avi_name1_1, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }

                m_bIsRecord1_1 = true;
            }
        }

        private void m_btnRecordStop1_1_Click(object sender, EventArgs e)
        {
            m_hCapDev[0] = m_pMainForm.m_hCapDev1;

            m_btnRecordStart1_1.Enabled = true;

            m_btnRecordStop1_1.Enabled = false;

            if (m_hCapDev[0] != 0)
            {
                EXPORTS.QCAP_STOP_RECORD(m_hCapDev[0], 0);

                m_bIsRecord1_1 = false;
            }
        }

        private void m_btnRecordStart1_2_Click(object sender, EventArgs e)
        {
            m_hCapDev[0] = m_pMainForm.m_hCapDev1;

            m_btnRecordStart1_2.Enabled = false;

            m_btnRecordStop1_2.Enabled = true;

            m_bSupportGPU1_2 = m_checkGPU1_2.Checked;

            if (m_hCapDev[0] != 0)
            {
                if (m_bCheckedAVI1_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[0], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_PCM);
                }

                if (m_bCheckedMP41_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[0], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bCheckedFLV1_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[0], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bSupportGPU1_2)
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[0], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_INTEL_MEDIA_SDK, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_1_4);

                    string str_avi_name1_2 = m_strAviName1_2;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[0], 1, ref str_avi_name1_2, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }
                else
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[0], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_1_4);

                    string str_avi_name1_2 = m_strAviName1_2;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[0], 1, ref str_avi_name1_2, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }

                m_bIsRecord1_2 = true;
            }
        }

        private void m_btnRecordStop1_2_Click(object sender, EventArgs e)
        {
            m_hCapDev[0] = m_pMainForm.m_hCapDev1;

            m_btnRecordStart1_2.Enabled = true;

            m_btnRecordStop1_2.Enabled = false;

            if (m_hCapDev[0] != 0)
            {
                EXPORTS.QCAP_STOP_RECORD(m_hCapDev[0], 1);

                m_bIsRecord1_2 = false;
            }
        }

        private void m_btnRecordStart2_1_Click(object sender, EventArgs e)
        {
            m_hCapDev[1] = m_pMainForm.m_hCapDev2;

            m_btnRecordStart2_1.Enabled = false;

            m_btnRecordStop2_1.Enabled = true;

            m_bSupportGPU2_1 = m_checkGPU2_1.Checked;

            if (m_hCapDev[1] != 0)
            {
                if (m_bCheckedAVI2_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[1], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_PCM);
                }

                if (m_bCheckedMP42_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[1], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bCheckedFLV2_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[1], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bSupportGPU2_1)
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[1], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_INTEL_MEDIA_SDK, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_OFF);

                    string str_avi_name2_1 = m_strAviName2_1;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[1], 0, ref str_avi_name2_1, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }
                else
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[1], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_OFF);

                    string str_avi_name2_1 = m_strAviName2_1;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[1], 0, ref str_avi_name2_1, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }

                m_bIsRecord2_1 = true;
            }
        }

        private void m_btnRecordStop2_1_Click(object sender, EventArgs e)
        {
            m_hCapDev[1] = m_pMainForm.m_hCapDev2;

            m_btnRecordStart2_1.Enabled = true;

            m_btnRecordStop2_1.Enabled = false;

            if (m_hCapDev[1] != 0)
            {
                EXPORTS.QCAP_STOP_RECORD(m_hCapDev[1], 0);

                m_bIsRecord2_1 = false;
            }
        }

        private void m_btnRecordStart2_2_Click(object sender, EventArgs e)
        {
            m_hCapDev[1] = m_pMainForm.m_hCapDev2;

            m_btnRecordStart2_2.Enabled = false;

            m_btnRecordStop2_2.Enabled = true;

            m_bSupportGPU2_2 = m_checkGPU2_2.Checked;

            if (m_hCapDev[1] != 0)
            {
                if (m_bCheckedAVI2_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[1], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_PCM);
                }

                if (m_bCheckedMP42_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[1], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bCheckedFLV2_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[1], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bSupportGPU2_2)
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[1], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_INTEL_MEDIA_SDK, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_1_4);

                    string str_avi_name2_2 = m_strAviName2_2;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[1], 1, ref str_avi_name2_2, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }
                else
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[1], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_1_4);

                    string str_avi_name2_2 = m_strAviName2_2;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[1], 1, ref str_avi_name2_2, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }

                m_bIsRecord2_2 = true;
            }
        }

        private void m_btnRecordStop2_2_Click(object sender, EventArgs e)
        {
            m_hCapDev[1] = m_pMainForm.m_hCapDev2;

            m_btnRecordStart2_2.Enabled = true;

            m_btnRecordStop2_2.Enabled = false;

            if (m_hCapDev[1] != 0)
            {
                EXPORTS.QCAP_STOP_RECORD(m_hCapDev[1], 1);

                m_bIsRecord2_2 = false;
            }
        }

        private void m_btnRecordStart3_1_Click(object sender, EventArgs e)
        {
            m_hCapDev[2] = m_pMainForm.m_hCapDev3;

            m_btnRecordStart3_1.Enabled = false;

            m_btnRecordStop3_1.Enabled = true;

            m_bSupportGPU3_1 = m_checkGPU3_1.Checked;

            if (m_hCapDev[2] != 0)
            {
                if (m_bCheckedAVI3_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[2], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_PCM);
                }

                if (m_bCheckedMP43_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[2], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bCheckedFLV3_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[2], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bSupportGPU3_1)
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[2], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_INTEL_MEDIA_SDK, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_OFF);

                    string str_avi_name3_1 = m_strAviName3_1;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[2], 0, ref str_avi_name3_1, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }
                else
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[2], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_OFF);

                    string str_avi_name3_1 = m_strAviName3_1;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[2], 0, ref str_avi_name3_1, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }

                m_bIsRecord3_1 = true;
            }
        }

        private void m_btnRecordStop3_1_Click(object sender, EventArgs e)
        {
            m_hCapDev[2] = m_pMainForm.m_hCapDev3;

            m_btnRecordStart3_1.Enabled = true;

            m_btnRecordStop3_1.Enabled = false;

            if (m_hCapDev[2] != 0)
            {
                EXPORTS.QCAP_STOP_RECORD(m_hCapDev[2], 0);

                m_bIsRecord3_1 = false;
            }
        }

        private void m_btnRecordStart3_2_Click(object sender, EventArgs e)
        {
            m_hCapDev[2] = m_pMainForm.m_hCapDev3;

            m_btnRecordStart3_2.Enabled = false;

            m_btnRecordStop3_2.Enabled = true;

            m_bSupportGPU3_2 = m_checkGPU3_2.Checked;

            if (m_hCapDev[2] != 0)
            {
                if (m_bCheckedAVI3_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[2], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_PCM);
                }

                if (m_bCheckedMP43_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[2], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bCheckedFLV3_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[2], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bSupportGPU3_2)
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[2], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_INTEL_MEDIA_SDK, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_1_4);

                    string str_avi_name3_2 = m_strAviName3_2;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[2], 1, ref str_avi_name3_2, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }
                else
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[2], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_1_4);

                    string str_avi_name3_2 = m_strAviName3_2;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[2], 1, ref str_avi_name3_2, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }

                m_bIsRecord3_2 = true;
            }
        }

        private void m_btnRecordStop3_2_Click(object sender, EventArgs e)
        {
            m_hCapDev[2] = m_pMainForm.m_hCapDev3;

            m_btnRecordStart3_2.Enabled = true;

            m_btnRecordStop3_2.Enabled = false;

            if (m_hCapDev[2] != 0)
            {
                EXPORTS.QCAP_STOP_RECORD(m_hCapDev[2], 1);

                m_bIsRecord3_2 = false;
            }
        }

        private void m_btnRecordStart4_1_Click(object sender, EventArgs e)
        {
            m_hCapDev[3] = m_pMainForm.m_hCapDev4;

            m_btnRecordStart4_1.Enabled = false;

            m_btnRecordStop4_1.Enabled = true;

            m_bSupportGPU4_1 = m_checkGPU4_1.Checked;

            if (m_hCapDev[3] != 0)
            {
                if (m_bCheckedAVI4_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[3], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_PCM);
                }

                if (m_bCheckedMP44_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[3], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bCheckedFLV4_1 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[3], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bSupportGPU4_1)
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[3], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_INTEL_MEDIA_SDK, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_OFF);

                    string str_avi_name4_1 = m_strAviName4_1;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[3], 0, ref str_avi_name4_1, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }
                else
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[3], 0, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_OFF);

                    string str_avi_name4_1 = m_strAviName4_1;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[3], 0, ref str_avi_name4_1, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }

                m_bIsRecord4_1 = true;
            }
        }

        private void m_btnRecordStop4_1_Click(object sender, EventArgs e)
        {
            m_hCapDev[3] = m_pMainForm.m_hCapDev4;

            m_btnRecordStart4_1.Enabled = true;

            m_btnRecordStop4_1.Enabled = false;

            if (m_hCapDev[3] != 0)
            {
                EXPORTS.QCAP_STOP_RECORD(m_hCapDev[3], 0);

                m_bIsRecord4_1 = false;
            }
        }

        private void m_btnRecordStart4_2_Click(object sender, EventArgs e)
        {
            m_hCapDev[3] = m_pMainForm.m_hCapDev4;

            m_btnRecordStart4_2.Enabled = false;

            m_btnRecordStop4_2.Enabled = true;

            m_bSupportGPU4_2 = m_checkGPU4_2.Checked;

            if (m_hCapDev[3] != 0)
            {
                if (m_bCheckedAVI4_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[3], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_PCM);
                }

                if (m_bCheckedMP44_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[3], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bCheckedFLV4_2 == true)
                {
                    EXPORTS.QCAP_SET_AUDIO_RECORD_PROPERTY(m_hCapDev[3], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.AudioEncoderFormatEnum.QCAP_ENCODER_FORMAT_AAC);
                }

                if (m_bSupportGPU4_2)
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[3], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_INTEL_MEDIA_SDK, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_1_4);

                    string str_avi_name4_2 = m_strAviName4_2;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[3], 1, ref str_avi_name4_2, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }
                else
                {
                    EXPORTS.QCAP_SET_VIDEO_RECORD_PROPERTY(m_hCapDev[3], 1, (uint)EXPORTS.EncoderTypeEnum.QCAP_ENCODER_TYPE_SOFTWARE, (uint)EXPORTS.VideoEncoderFormatEnum.QCAP_ENCODER_FORMAT_H264, (uint)EXPORTS.RecordModeEnum.QCAP_RECORD_MODE_CBR, 8000, 12582912, 30, 0, 0, (uint)EXPORTS.DownScaleModeEnum.QCAP_DOWNSCALE_MODE_1_4);

                    string str_avi_name4_2 = m_strAviName4_2;

                    string pszNULL = null;

                    EXPORTS.QCAP_START_RECORD(m_hCapDev[3], 1, ref str_avi_name4_2, (uint)EXPORTS.RecordFlagEnum.QCAP_RECORD_FLAG_FULL, 0.0, 0.0, 0.0, 0, ref pszNULL);
                }

                m_bIsRecord4_2 = true;
            }
        }

        private void m_btnRecordStop4_2_Click(object sender, EventArgs e)
        {
            m_hCapDev[3] = m_pMainForm.m_hCapDev4;

            m_btnRecordStart4_2.Enabled = true;

            m_btnRecordStop4_2.Enabled = false;

            if (m_hCapDev[3] != 0)
            {
                EXPORTS.QCAP_STOP_RECORD(m_hCapDev[3], 1);

                m_bIsRecord4_2 = false;
            }
        }

        private void m_checkGPU1_1_Click(object sender, EventArgs e)
        {
            m_btnRecordStop1_1_Click(sender, e);
        }

        private void m_checkGPU1_2_Click(object sender, EventArgs e)
        {
            m_btnRecordStop1_2_Click(sender, e);
        }

        private void m_checkGPU2_1_Click(object sender, EventArgs e)
        {
            m_btnRecordStop2_1_Click(sender, e);
        }

        private void m_checkGPU2_2_Click(object sender, EventArgs e)
        {
            m_btnRecordStop2_2_Click(sender, e);
        }

        private void m_checkGPU3_1_Click(object sender, EventArgs e)
        {
            m_btnRecordStop3_1_Click(sender, e);
        }

        private void m_checkGPU3_2_Click(object sender, EventArgs e)
        {
            m_btnRecordStop3_2_Click(sender, e);
        }

        private void m_checkGPU4_1_Click(object sender, EventArgs e)
        {
            m_btnRecordStop4_1_Click(sender, e);
        }

        private void m_checkGPU4_2_Click(object sender, EventArgs e)
        {
            m_btnRecordStop4_2_Click(sender, e);
        }        

        private void timerCheckSignal_Tick(object sender, EventArgs e)
        {
            m_hCapDev[0] = m_pMainForm.m_hCapDev1;

            m_hCapDev[1] = m_pMainForm.m_hCapDev2;

            m_hCapDev[2] = m_pMainForm.m_hCapDev3;

            m_hCapDev[3] = m_pMainForm.m_hCapDev4;

            if (m_hCapDev[0] != 0)
            {
                if (m_bIsRecord1_1 && m_bNoSignal1) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[0], 0); m_bIsRecord1_1 = false; }

                if (m_bIsRecord1_2 && m_bNoSignal1) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[0], 1); m_bIsRecord1_2 = false; }
            }

            if (m_hCapDev[1] != 0)
            {
                if (m_bIsRecord2_1 && m_bNoSignal2) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[1], 0); m_bIsRecord2_1 = false; }

                if (m_bIsRecord2_2 && m_bNoSignal2) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[1], 1); m_bIsRecord2_2 = false; }
            }

            if (m_hCapDev[2] != 0)
            {
                if (m_bIsRecord3_1 && m_bNoSignal3) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[2], 0); m_bIsRecord3_1 = false; }

                if (m_bIsRecord3_2 && m_bNoSignal3) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[2], 1); m_bIsRecord3_2 = false; }
            }

            if (m_hCapDev[3] != 0)
            {
                if (m_bIsRecord4_1 && m_bNoSignal4) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[3], 0); m_bIsRecord4_1 = false; }

                if (m_bIsRecord4_2 && m_bNoSignal4) { EXPORTS.QCAP_STOP_RECORD(m_hCapDev[3], 1); m_bIsRecord4_2 = false; }
            }
        }

        private void m_checkAVI1_1_Click(object sender, EventArgs e)
        {
            m_checkAVI1_1.Checked = true;

            m_checkMP41_1.Checked = false;

            m_checkFLV1_1.Checked = false;

            m_bCheckedAVI1_1 = true;

            m_bCheckedMP41_1 = false;

            m_bCheckedFLV1_1 = false;

            m_strAviName1_1 = m_strAviName1_1.Replace(".MP4", ".AVI");

            m_strAviName1_1 = m_strAviName1_1.Replace(".FLV", ".AVI");

            textBoxRecordAVI1_1.Text = m_strAviName1_1;
        }

        private void m_checkAVI1_2_Click(object sender, EventArgs e)
        {
            m_checkAVI1_2.Checked = true;

            m_checkMP41_2.Checked = false;

            m_checkFLV1_2.Checked = false;

            m_bCheckedAVI1_2 = true;

            m_bCheckedMP41_2 = false;

            m_bCheckedFLV1_2 = false;

            m_strAviName1_2 = m_strAviName1_2.Replace(".MP4", ".AVI");

            m_strAviName1_2 = m_strAviName1_2.Replace(".FLV", ".AVI");

            textBoxRecordAVI1_2.Text = m_strAviName1_2;
        }

        private void m_checkAVI2_1_Click(object sender, EventArgs e)
        {
            m_checkAVI2_1.Checked = true;

            m_checkMP42_1.Checked = false;

            m_checkFLV2_1.Checked = false;

            m_bCheckedAVI2_1 = true;

            m_bCheckedMP42_1 = false;

            m_bCheckedFLV2_1 = false;

            m_strAviName2_1 = m_strAviName1_1.Replace(".MP4", ".AVI");

            m_strAviName2_1 = m_strAviName1_1.Replace(".FLV", ".AVI");

            textBoxRecordAVI2_1.Text = m_strAviName2_1;
        }

        private void m_checkAVI2_2_Click(object sender, EventArgs e)
        {
            m_checkAVI2_2.Checked = true;

            m_checkMP42_2.Checked = false;

            m_checkFLV2_2.Checked = false;

            m_bCheckedAVI2_2 = true;

            m_bCheckedMP42_2 = false;

            m_bCheckedFLV2_2 = false;

            m_strAviName2_2 = m_strAviName2_2.Replace(".MP4", ".AVI");

            m_strAviName2_2 = m_strAviName2_2.Replace(".FLV", ".AVI");

            textBoxRecordAVI2_2.Text = m_strAviName2_2;
        }

        private void m_checkAVI3_1_Click(object sender, EventArgs e)
        {
            m_checkAVI3_1.Checked = true;

            m_checkMP43_1.Checked = false;

            m_checkFLV3_1.Checked = false;

            m_bCheckedAVI3_1 = true;

            m_bCheckedMP43_1 = false;

            m_bCheckedFLV3_1 = false;

            m_strAviName3_1 = m_strAviName3_1.Replace(".MP4", ".AVI");

            m_strAviName3_1 = m_strAviName3_1.Replace(".FLV", ".AVI");

            textBoxRecordAVI3_1.Text = m_strAviName3_1;
        }

        private void m_checkAVI3_2_Click(object sender, EventArgs e)
        {
            m_checkAVI3_2.Checked = true;

            m_checkMP43_2.Checked = false;

            m_checkFLV3_2.Checked = false;

            m_bCheckedAVI3_2 = true;

            m_bCheckedMP43_2 = false;

            m_bCheckedFLV3_2 = false;

            m_strAviName3_2 = m_strAviName3_2.Replace(".MP4", ".AVI");

            m_strAviName3_2 = m_strAviName3_2.Replace(".FLV", ".AVI");

            textBoxRecordAVI3_2.Text = m_strAviName3_2;
        }

        private void m_checkAVI4_1_Click(object sender, EventArgs e)
        {
            m_checkAVI4_1.Checked = true;

            m_checkMP44_1.Checked = false;

            m_checkFLV4_1.Checked = false;

            m_bCheckedAVI4_1 = true;

            m_bCheckedMP44_1 = false;

            m_bCheckedFLV4_1 = false;

            m_strAviName4_1 = m_strAviName4_1.Replace(".MP4", ".AVI");

            m_strAviName4_1 = m_strAviName4_1.Replace(".FLV", ".AVI");

            textBoxRecordAVI4_1.Text = m_strAviName4_1;
        }

        private void m_checkAVI4_2_Click(object sender, EventArgs e)
        {
            m_checkAVI4_2.Checked = true;

            m_checkMP44_2.Checked = false;

            m_checkFLV4_2.Checked = false;

            m_bCheckedAVI4_2 = true;

            m_bCheckedMP44_2 = false;

            m_bCheckedFLV4_2 = false;

            m_strAviName4_2 = m_strAviName4_2.Replace(".MP4", ".AVI");

            m_strAviName4_2 = m_strAviName4_2.Replace(".FLV", ".AVI");

            textBoxRecordAVI4_2.Text = m_strAviName4_2;
        }

        private void m_checkMP41_1_Click(object sender, EventArgs e)
        {
            m_checkAVI1_1.Checked = false;

            m_checkMP41_1.Checked = true;

            m_checkFLV1_1.Checked = false;

            m_bCheckedAVI1_1 = false;

            m_bCheckedMP41_1 = true;

            m_bCheckedFLV1_1 = false;

            m_strAviName1_1 = m_strAviName1_1.Replace(".AVI", ".MP4");

            m_strAviName1_1 = m_strAviName1_1.Replace(".FLV", ".MP4");

            textBoxRecordAVI1_1.Text = m_strAviName1_1;
        }

        private void m_checkMP41_2_Click(object sender, EventArgs e)
        {
            m_checkAVI1_2.Checked = false;

            m_checkMP41_2.Checked = true;

            m_checkFLV1_2.Checked = false;

            m_bCheckedAVI1_2 = false;

            m_bCheckedMP41_2 = true;

            m_bCheckedFLV1_2 = false;

            m_strAviName1_2 = m_strAviName1_2.Replace(".AVI", ".MP4");

            m_strAviName1_2 = m_strAviName1_2.Replace(".FLV", ".MP4");

            textBoxRecordAVI1_2.Text = m_strAviName1_2;
        }

        private void m_checkMP42_1_Click(object sender, EventArgs e)
        {
            m_checkAVI2_1.Checked = false;

            m_checkMP42_1.Checked = true;

            m_checkFLV2_1.Checked = false;

            m_bCheckedAVI2_1 = false;

            m_bCheckedMP42_1 = true;

            m_bCheckedFLV2_1 = false;

            m_strAviName2_1 = m_strAviName2_1.Replace(".AVI", ".MP4");

            m_strAviName2_1 = m_strAviName2_1.Replace(".FLV", ".MP4");

            textBoxRecordAVI2_1.Text = m_strAviName2_1;
        }

        private void m_checkMP42_2_Click(object sender, EventArgs e)
        {
            m_checkAVI2_2.Checked = false;

            m_checkMP42_2.Checked = true;

            m_checkFLV2_2.Checked = false;

            m_bCheckedAVI2_2 = false;

            m_bCheckedMP42_2 = true;

            m_bCheckedFLV2_2 = false;

            m_strAviName2_2 = m_strAviName2_2.Replace(".AVI", ".MP4");

            m_strAviName2_2 = m_strAviName2_2.Replace(".FLV", ".MP4");

            textBoxRecordAVI2_2.Text = m_strAviName2_2;
        }

        private void m_checkMP43_1_Click(object sender, EventArgs e)
        {
            m_checkAVI3_1.Checked = false;

            m_checkMP43_1.Checked = true;

            m_checkFLV3_1.Checked = false;

            m_bCheckedAVI3_1 = false;

            m_bCheckedMP43_1 = true;

            m_bCheckedFLV3_1 = false;

            m_strAviName3_1 = m_strAviName3_1.Replace(".AVI", ".MP4");

            m_strAviName3_1 = m_strAviName3_1.Replace(".FLV", ".MP4");

            textBoxRecordAVI3_1.Text = m_strAviName3_1;
        }

        private void m_checkMP43_2_Click(object sender, EventArgs e)
        {
            m_checkAVI3_2.Checked = false;

            m_checkMP43_2.Checked = true;

            m_checkFLV3_2.Checked = false;

            m_bCheckedAVI3_2 = false;

            m_bCheckedMP43_2 = true;

            m_bCheckedFLV3_2 = false;

            m_strAviName3_2 = m_strAviName3_2.Replace(".AVI", ".MP4");

            m_strAviName3_2 = m_strAviName3_2.Replace(".FLV", ".MP4");

            textBoxRecordAVI3_2.Text = m_strAviName3_2;
        }

        private void m_checkMP44_1_Click(object sender, EventArgs e)
        {
            m_checkAVI4_1.Checked = false;

            m_checkMP44_1.Checked = true;

            m_checkFLV4_1.Checked = false;

            m_bCheckedAVI4_1 = false;

            m_bCheckedMP44_1 = true;

            m_bCheckedFLV4_1 = false;

            m_strAviName4_1 = m_strAviName4_1.Replace(".AVI", ".MP4");

            m_strAviName4_1 = m_strAviName4_1.Replace(".FLV", ".MP4");

            textBoxRecordAVI4_1.Text = m_strAviName4_1;
        }

        private void m_checkMP44_2_Click(object sender, EventArgs e)
        {
            m_checkAVI4_2.Checked = false;

            m_checkMP44_2.Checked = true;

            m_checkFLV4_2.Checked = false;

            m_bCheckedAVI4_2 = false;

            m_bCheckedMP44_2 = true;

            m_bCheckedFLV4_2 = false;

            m_strAviName4_2 = m_strAviName4_2.Replace(".AVI", ".MP4");

            m_strAviName4_2 = m_strAviName4_2.Replace(".FLV", ".MP4");

            textBoxRecordAVI4_2.Text = m_strAviName4_2;
        }

        private void m_checkFLV1_1_Click(object sender, EventArgs e)
        {
            m_checkAVI1_1.Checked = false;

            m_checkMP41_1.Checked = false;

            m_checkFLV1_1.Checked = true;

            m_bCheckedAVI1_1 = false;

            m_bCheckedMP41_1 = false;

            m_bCheckedFLV1_1 = true;

            m_strAviName1_1 = m_strAviName1_1.Replace(".AVI", ".FLV");

            m_strAviName1_1 = m_strAviName1_1.Replace(".MP4", ".FLV");

            textBoxRecordAVI1_1.Text = m_strAviName1_1;
        }

        private void m_checkFLV1_2_Click(object sender, EventArgs e)
        {
            m_checkAVI1_2.Checked = false;

            m_checkMP41_2.Checked = false;

            m_checkFLV1_2.Checked = true;

            m_bCheckedAVI1_2 = false;

            m_bCheckedMP41_2 = false;

            m_bCheckedFLV1_2 = true;

            m_strAviName1_2 = m_strAviName1_2.Replace(".AVI", ".FLV");

            m_strAviName1_2 = m_strAviName1_2.Replace(".MP4", ".FLV");

            textBoxRecordAVI1_2.Text = m_strAviName1_2;
        }

        private void m_checkFLV2_1_Click(object sender, EventArgs e)
        {
            m_checkAVI2_1.Checked = false;

            m_checkMP42_1.Checked = false;

            m_checkFLV2_1.Checked = true;

            m_bCheckedAVI2_1 = false;

            m_bCheckedMP42_1 = false;

            m_bCheckedFLV2_1 = true;

            m_strAviName2_1 = m_strAviName2_1.Replace(".AVI", ".FLV");

            m_strAviName2_1 = m_strAviName2_1.Replace(".MP4", ".FLV");

            textBoxRecordAVI2_1.Text = m_strAviName2_1;
        }

        private void m_checkFLV2_2_Click(object sender, EventArgs e)
        {
            m_checkAVI2_2.Checked = false;

            m_checkMP42_2.Checked = false;

            m_checkFLV2_2.Checked = true;

            m_bCheckedAVI2_2 = false;

            m_bCheckedMP42_2 = false;

            m_bCheckedFLV2_2 = true;

            m_strAviName2_2 = m_strAviName2_2.Replace(".AVI", ".FLV");

            m_strAviName2_2 = m_strAviName2_2.Replace(".MP4", ".FLV");

            textBoxRecordAVI2_2.Text = m_strAviName2_2;
        }

        private void m_checkFLV3_1_Click(object sender, EventArgs e)
        {
            m_checkAVI3_1.Checked = false;

            m_checkMP43_1.Checked = false;

            m_checkFLV3_1.Checked = true;

            m_bCheckedAVI3_1 = false;

            m_bCheckedMP43_1 = false;

            m_bCheckedFLV3_1 = true;

            m_strAviName3_1 = m_strAviName3_1.Replace(".AVI", ".FLV");

            m_strAviName3_1 = m_strAviName3_1.Replace(".MP4", ".FLV");

            textBoxRecordAVI3_1.Text = m_strAviName3_1;
        }

        private void m_checkFLV3_2_Click(object sender, EventArgs e)
        {
            m_checkAVI3_2.Checked = false;

            m_checkMP43_2.Checked = false;

            m_checkFLV3_2.Checked = true;

            m_bCheckedAVI3_2 = false;

            m_bCheckedMP43_2 = false;

            m_bCheckedFLV3_2 = true;

            m_strAviName3_2 = m_strAviName3_2.Replace(".AVI", ".FLV");

            m_strAviName3_2 = m_strAviName3_2.Replace(".MP4", ".FLV");

            textBoxRecordAVI3_2.Text = m_strAviName3_2;
        }

        private void m_checkFLV4_1_Click(object sender, EventArgs e)
        {
            m_checkAVI4_1.Checked = false;

            m_checkMP44_1.Checked = false;

            m_checkFLV4_1.Checked = true;

            m_bCheckedAVI4_1 = false;

            m_bCheckedMP44_1 = false;

            m_bCheckedFLV4_1 = true;

            m_strAviName4_1 = m_strAviName4_1.Replace(".AVI", ".FLV");

            m_strAviName4_1 = m_strAviName4_1.Replace(".MP4", ".FLV");

            textBoxRecordAVI4_1.Text = m_strAviName4_1;
        }

        private void m_checkFLV4_2_Click(object sender, EventArgs e)
        {
            m_checkAVI4_2.Checked = false;

            m_checkMP44_2.Checked = false;

            m_checkFLV4_2.Checked = true;

            m_bCheckedAVI4_2 = false;

            m_bCheckedMP44_2 = false;

            m_bCheckedFLV4_2 = true;

            m_strAviName4_2 = m_strAviName4_2.Replace(".AVI", ".FLV");

            m_strAviName4_2 = m_strAviName4_2.Replace(".MP4", ".FLV");

            textBoxRecordAVI4_2.Text = m_strAviName4_2;
        }
    }
}
