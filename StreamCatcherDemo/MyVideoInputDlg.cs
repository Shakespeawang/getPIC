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
    public partial class MyVideoInputDlg : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        public MySetupControl m_pMainForm;

        public uint[] m_hCapDev = new uint[4];

        public MyVideoInputDlg()
        {
            InitializeComponent();
        }

        private void MyVideoInputDlg_Load(object sender, EventArgs e)
        {            
        }

        private void MyVideoInputDlg_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MyVideoInputDlg_Shown(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                uint nInput = (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SDI;

                EXPORTS.QCAP_GET_VIDEO_INPUT(m_hCapDev[0], ref nInput);

                if (nInput == (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPOSITE)
                {
                    RadioButtonCOMPOSITE.Checked = true;
                }

                if (nInput == (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SVIDEO)
                {
                    RadioButtonSVIDEO.Checked = true;
                }

                if (nInput == (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_HDMI)
                {
                    RadioButtonInputHDMI.Checked = true;
                }

                if (nInput == (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_D)
                {
                    RadioButtonInputDVI.Checked = true;
                }

                if (nInput == (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPONENTS)
                {
                    RadioButtonYCBCR.Checked = true;
                }

                if (nInput == (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_A)
                {
                    RadioButtonRGB.Checked = true;
                }

                if (nInput == (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SDI)
                {
                    RadioButtonSDI.Checked = true;
                }

                if (nInput == (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_AUTO)
                {
                    RadioButtonAUTO.Checked = true;
                }               
            }
        }      

        private void RadioButtonInputHDMI_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_HDMI);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_HDMI);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[2], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_HDMI);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_HDMI);
            }
        }

        private void RadioButtonInputDVI_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_D);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_D);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[2], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_D);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_D);
            }
        }

        private void RadioButtonYCBCR_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPONENTS);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPONENTS);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[2], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPONENTS);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPONENTS);
            }
        }

        private void RadioButtonRGB_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_A);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_A);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[2], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_A);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_DVI_A);
            }
        }

        private void RadioButtonSDI_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SDI);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SDI);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[2], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SDI);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SDI);
            }
        }

        private void RadioButtonCOMPOSITE_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPOSITE);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPOSITE);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[2], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPOSITE);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_COMPOSITE);
            }
        }

        private void RadioButtonSVIDEO_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SVIDEO);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SVIDEO);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SVIDEO);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SVIDEO);
            }
        }

        private void RadioButtonAUTO_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[0], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_AUTO);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_AUTO);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[2], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_AUTO);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[3], (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_AUTO);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}