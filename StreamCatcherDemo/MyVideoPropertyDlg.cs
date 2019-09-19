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
    public partial class MyVideoPropertyDlg : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        public MySetupControl m_pMainForm;

        public uint[] m_hCapDev = new uint[4];

        public MyVideoPropertyDlg()
        {
            InitializeComponent();
        }

        private void MyVideoPropertyDlg_Load(object sender, EventArgs e)
        {
            m_hCapDev[0] = 0x00000000;

            m_hCapDev[1] = 0x00000000;

            m_hCapDev[2] = 0x00000000;

            m_hCapDev[3] = 0x00000000;
        }

        private void MyVideoPropertyDlg_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MyVideoPropertyDlg_Shown(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0x00000000)
            {
                uint nBrightness = 0;

                EXPORTS.QCAP_GET_VIDEO_BRIGHTNESS(m_hCapDev[0], ref nBrightness);

                m_sliderBrightness.Value = (int)nBrightness;

                m_staticBrightness.Text = nBrightness.ToString();

                uint nContrast = 0;

                EXPORTS.QCAP_GET_VIDEO_CONTRAST(m_hCapDev[0], ref nContrast);

                m_sliderContrast.Value = (int)nContrast;

                m_staticContrast.Text = nContrast.ToString();

                uint nHue = 0;

                EXPORTS.QCAP_GET_VIDEO_HUE(m_hCapDev[0], ref nHue);

                m_sliderHue.Value = (int)nHue;

                m_staticHue.Text = nHue.ToString();

                uint nSaturation = 0;

                EXPORTS.QCAP_GET_VIDEO_SATURATION(m_hCapDev[0], ref nSaturation);

                m_sliderSaturation.Value = (int)nSaturation;

                m_staticSaturation.Text = nSaturation.ToString();

                uint nSharpness = 0;

                EXPORTS.QCAP_GET_VIDEO_SHARPNESS(m_hCapDev[0], ref nSharpness);

                m_sliderSharpness.Value = (int)nSharpness;

                m_staticSharpness.Text = nSharpness.ToString();
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            EXPORTS.QCAP_SET_VIDEO_BRIGHTNESS(m_hCapDev[0], 128);

            EXPORTS.QCAP_SET_VIDEO_BRIGHTNESS(m_hCapDev[1], 128);

            EXPORTS.QCAP_SET_VIDEO_BRIGHTNESS(m_hCapDev[2], 128);

            EXPORTS.QCAP_SET_VIDEO_BRIGHTNESS(m_hCapDev[3], 128);

            m_sliderBrightness.Value = 128;

            m_staticBrightness.Text = "128";

            EXPORTS.QCAP_SET_VIDEO_CONTRAST(m_hCapDev[0], 128);

            EXPORTS.QCAP_SET_VIDEO_CONTRAST(m_hCapDev[1], 128);

            EXPORTS.QCAP_SET_VIDEO_CONTRAST(m_hCapDev[2], 128);

            EXPORTS.QCAP_SET_VIDEO_CONTRAST(m_hCapDev[3], 128);

            m_sliderContrast.Value = 128;

            m_staticContrast.Text = "128";

            EXPORTS.QCAP_SET_VIDEO_HUE(m_hCapDev[0], 128);

            EXPORTS.QCAP_SET_VIDEO_HUE(m_hCapDev[1], 128);

            EXPORTS.QCAP_SET_VIDEO_HUE(m_hCapDev[2], 128);

            EXPORTS.QCAP_SET_VIDEO_HUE(m_hCapDev[3], 128);

            m_sliderHue.Value = 128;

            m_staticHue.Text = "128";

            EXPORTS.QCAP_SET_VIDEO_SATURATION(m_hCapDev[0], 128);

            EXPORTS.QCAP_SET_VIDEO_SATURATION(m_hCapDev[1], 128);

            EXPORTS.QCAP_SET_VIDEO_SATURATION(m_hCapDev[2], 128);

            EXPORTS.QCAP_SET_VIDEO_SATURATION(m_hCapDev[3], 128);

            m_sliderSaturation.Value = 128;

            m_staticSaturation.Text = "128";

            EXPORTS.QCAP_SET_VIDEO_SHARPNESS(m_hCapDev[0], 128);

            EXPORTS.QCAP_SET_VIDEO_SHARPNESS(m_hCapDev[1], 128);

            EXPORTS.QCAP_SET_VIDEO_SHARPNESS(m_hCapDev[2], 128);

            EXPORTS.QCAP_SET_VIDEO_SHARPNESS(m_hCapDev[3], 128);

            m_sliderSharpness.Value = 128;

            m_staticSharpness.Text = "128";
        }

        private void m_sliderBrightness_Scroll(object sender, EventArgs e)
        {
            int n_property_value = m_sliderBrightness.Value;

            m_staticBrightness.Text = n_property_value.ToString();

            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_BRIGHTNESS(m_hCapDev[0], (uint)n_property_value);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_BRIGHTNESS(m_hCapDev[1], (uint)n_property_value);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_BRIGHTNESS(m_hCapDev[2], (uint)n_property_value);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_BRIGHTNESS(m_hCapDev[3], (uint)n_property_value);
            }
        }

        private void m_sliderContrast_Scroll(object sender, EventArgs e)
        {
            int n_property_value = m_sliderContrast.Value;

            m_staticContrast.Text = n_property_value.ToString();

            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_CONTRAST(m_hCapDev[0], (uint)n_property_value);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_CONTRAST(m_hCapDev[1], (uint)n_property_value);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_CONTRAST(m_hCapDev[2], (uint)n_property_value);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_CONTRAST(m_hCapDev[3], (uint)n_property_value);
            }
        }

        private void m_sliderHue_Scroll(object sender, EventArgs e)
        {
            int n_property_value = m_sliderHue.Value;

            m_staticHue.Text = n_property_value.ToString();

            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_HUE(m_hCapDev[0], (uint)n_property_value);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_HUE(m_hCapDev[1], (uint)n_property_value);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_HUE(m_hCapDev[2], (uint)n_property_value);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_HUE(m_hCapDev[3], (uint)n_property_value);
            }
        }

        private void m_sliderSaturation_Scroll(object sender, EventArgs e)
        {
            int n_property_value = m_sliderSaturation.Value;

            m_staticSaturation.Text = n_property_value.ToString();

            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_SATURATION(m_hCapDev[0], (uint)n_property_value);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_SATURATION(m_hCapDev[1], (uint)n_property_value);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_SATURATION(m_hCapDev[2], (uint)n_property_value);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_SATURATION(m_hCapDev[3], (uint)n_property_value);
            }
        }

        private void m_sliderSharpness_Scroll(object sender, EventArgs e)
        {
            int n_property_value = m_sliderSharpness.Value;

            m_staticSharpness.Text = n_property_value.ToString();

            if (m_hCapDev[0] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_SHARPNESS(m_hCapDev[0], (uint)n_property_value);
            }

            if (m_hCapDev[1] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_SHARPNESS(m_hCapDev[1], (uint)n_property_value);
            }

            if (m_hCapDev[2] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_SHARPNESS(m_hCapDev[2], (uint)n_property_value);
            }

            if (m_hCapDev[3] != 0x00000000)
            {
                EXPORTS.QCAP_SET_VIDEO_SHARPNESS(m_hCapDev[3], (uint)n_property_value);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}