using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using QCAP.NET;

namespace StreamCatcherDemo
{
    public partial class MyAudioInputDlg : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        public MySetupControl m_pMainForm;

        public uint[] m_hCapDev = new uint[4];

        public MyAudioInputDlg()
        {
            InitializeComponent();
        }

        private void MyAudioInputDlg_Load(object sender, EventArgs e)
        {            
        }

        private void MyAudioInputDlg_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MyAudioInputDlg_Shown(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                uint nInput = (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_EMBEDDED_AUDIO;

                EXPORTS.QCAP_GET_AUDIO_INPUT(m_hCapDev[0], ref nInput);

                if (nInput == (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_EMBEDDED_AUDIO)
                {
                    RadioButtonInputEMBEDDEDAUDIO.Checked = true;
                }

                if (nInput == (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_LINE_IN)
                {
                    RadioButtonInputEMBEDDEDLINEIN.Checked = true;
                }
            }
        }
          
        private void RadioButtonInputEMBEDDEDAUDIO_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_AUDIO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_EMBEDDED_AUDIO);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_AUDIO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_EMBEDDED_AUDIO);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_AUDIO_INPUT(m_hCapDev[2], (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_EMBEDDED_AUDIO);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_AUDIO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_EMBEDDED_AUDIO);
            }
        }

        private void RadioButtonInputEMBEDDEDLINEIN_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_AUDIO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_LINE_IN);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_AUDIO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_LINE_IN);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_AUDIO_INPUT(m_hCapDev[2], (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_LINE_IN);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_AUDIO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputAudioSourceEnum.QCAP_INPUT_TYPE_LINE_IN);
            }
        }        

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}