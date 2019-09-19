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
    public partial class MySnapShotDlg : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        public string m_strCurrentDir = "";

        public MySetupControl m_pMainForm;

        public uint[] m_hCapDev = new uint[4];

        public string m_strBmpName1, m_strBmpName2, m_strBmpName3, m_strBmpName4;

        public string m_strJpgName1, m_strJpgName2, m_strJpgName3, m_strJpgName4;

        public MySnapShotDlg()
        {
            InitializeComponent();
        }

        private void MySnapShotDlg_Load(object sender, EventArgs e)
        {
            // GET CURRENT DIRECTORY
            //
            m_strCurrentDir = Directory.GetCurrentDirectory();

            m_strBmpName1 = m_strCurrentDir + "\\CH01.BMP";

            m_strJpgName1 = m_strCurrentDir + "\\CH01.JPG";

            m_strBmpName2 = m_strCurrentDir + "\\CH02.BMP";

            m_strJpgName2 = m_strCurrentDir + "\\CH02.JPG";

            m_strBmpName3 = m_strCurrentDir + "\\CH03.BMP";

            m_strJpgName3 = m_strCurrentDir + "\\CH03.JPG";

            m_strBmpName4 = m_strCurrentDir + "\\CH04.BMP";

            m_strJpgName4 = m_strCurrentDir + "\\CH04.JPG";

            textBoxSnapshotBMP1.Text = m_strBmpName1;

            textBoxSnapshotJPG1.Text = m_strJpgName1;

            textBoxSnapshotBMP2.Text = m_strBmpName2;

            textBoxSnapshotJPG2.Text = m_strJpgName2;

            textBoxSnapshotBMP3.Text = m_strBmpName3;

            textBoxSnapshotJPG3.Text = m_strJpgName3;

            textBoxSnapshotBMP4.Text = m_strBmpName4;

            textBoxSnapshotJPG4.Text = m_strJpgName4;            
        }

        private void MySnapShotDlg_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MySnapShotDlg_Shown(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void m_btnSnapshotBMP1_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0)
            {
                string strBmpName = m_strCurrentDir + "\\CH01.BMP";

                EXPORTS.QCAP_SNAPSHOT_BMP(m_hCapDev[0], ref strBmpName);
            }
        }

        private void m_btnSnapshotJPG1_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[0] != 0)
            {
                string strJpgName = m_strCurrentDir + "\\CH01.JPG";

                EXPORTS.QCAP_SNAPSHOT_JPG(m_hCapDev[0], ref strJpgName, 80);
            }
        }

        private void m_btnSnapshotBMP2_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[1] != 0)
            {
                string strBmpName = m_strCurrentDir + "\\CH02.BMP";

                EXPORTS.QCAP_SNAPSHOT_BMP(m_hCapDev[1], ref strBmpName);
            }
        }

        private void m_btnSnapshotJPG2_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[1] != 0)
            {
                string strJpgName = m_strCurrentDir + "\\CH02.JPG";

                EXPORTS.QCAP_SNAPSHOT_JPG(m_hCapDev[1], ref strJpgName, 80);
            }
        }

        private void m_btnSnapshotBMP3_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[2] != 0)
            {
                string strBmpName = m_strCurrentDir + "\\CH03.BMP";

                EXPORTS.QCAP_SNAPSHOT_BMP(m_hCapDev[2], ref strBmpName);
            }
        }

        private void m_btnSnapshotJPG3_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[2] != 0)
            {
                string strJpgName = m_strCurrentDir + "\\CH03.JPG";

                EXPORTS.QCAP_SNAPSHOT_JPG(m_hCapDev[2], ref strJpgName, 80);
            }
        }

        private void m_btnSnapshotBMP4_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[3] != 0)
            {
                string strBmpName = m_strCurrentDir + "\\CH04.BMP";

                EXPORTS.QCAP_SNAPSHOT_BMP(m_hCapDev[3], ref strBmpName);
            }
        }

        private void m_btnSnapshotJPG4_Click(object sender, EventArgs e)
        {
            if (m_hCapDev[3] != 0)
            {
                string strJpgName = m_strCurrentDir + "\\CH04.JPG";

                EXPORTS.QCAP_SNAPSHOT_JPG(m_hCapDev[3], ref strJpgName, 80);
            }
        }
    }
}
