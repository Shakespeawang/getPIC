using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;

using QCAP.NET;

namespace StreamCatcherDemo
{
    public unsafe partial class MyOSDPropertyDlg : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        // CONVERT COLOR TO UINT
        //
        private uint ColorToUInt(Color color)
        {
            return (uint)((color.A << 24) | (color.R << 16) | (color.G << 8) | (color.B << 0));
        }

        // CONVERT UINT TO COLORs
        //
        private Color UIntToColor(uint color)
        {
            byte a = (byte)(color >> 24);
            byte r = (byte)(color >> 16);
            byte g = (byte)(color >> 8);
            byte b = (byte)(color >> 0);

            return Color.FromArgb(a, r, g, b);
        }        

        public MySetupControl m_pMainForm;        

        public uint[] m_hCapDev = new uint[4];        

        public string m_pszString = "YUAN";

        public string m_pszFontFamilyName = "Arial";

        public Color m_clrForeground;

        public Color m_clrBackground;

        public uint m_nOsdNum1 = 0, m_nOsdNum2 = 1, m_nOsdNum3 = 2;

        public uint m_dwFontColor = 0;

        public uint m_nFontSize = 24;

        public uint m_nFontStyle = (uint)EXPORTS.FontStyleEnum.QCAP_FONT_STYLE_REGULAR;

        public uint m_dwBackgroundColor = 0;

        public int m_xoffset1 = 0, m_xoffset2 = 0, m_xoffset3 = 0;

        public int m_yoffset1 = 0, m_yoffset2 = 0, m_yoffset3 = 0;

        public int m_width1 = 320, m_width2 = 320, m_width3 = 320;

        public int m_height1 = 240, m_height2 = 240, m_height3 = 240;

        public uint m_nTransparent1 = 255, m_nTransparent2 = 255, m_nTransparent3 = 255;

        public string m_strPicturePath = "";

        public string m_strBinaryFilePath = "";

        public byte[] m_bytesOSDBuffer;

        public Bitmap m_PicImage = null;

        public GCHandle m_pinnedOSDArray;

        public IntPtr m_pointerOSDAry;

        public MyOSDPropertyDlg()
        {
            InitializeComponent();
        }        

        private void MyOSDPropertyDlg_Load(object sender, EventArgs e)
        {
            m_clrBackground = labelOSDBackgroundColor.BackColor;

            comboxOSDLayer1.SelectedIndex = 0;

            comboxOSDLayer2.SelectedIndex = 1;

            comboxOSDLayer3.SelectedIndex = 2;

            comboxFontSize1.SelectedIndex = 9;

            comboOSDBufferColorSpace.SelectedIndex = 0;

            txtBoxTypeString.Text = m_pszString;           
        }

        private void MyOSDPropertyDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_PicImage != null)
            {
                m_PicImage.Dispose();
            }

            m_pinnedOSDArray.Free();
        }

        private void btnApplyOSDText_Click(object sender, EventArgs e)
        {
            m_nOsdNum1 = (uint)comboxOSDLayer1.SelectedIndex;

            m_xoffset1 = Convert.ToInt32(txtBox_Xoffset1.Text);

            m_yoffset1 = Convert.ToInt32(txtBox_Yoffset1.Text);

            m_width1 = Convert.ToInt32(txtBox_width1.Text);

            m_height1 = Convert.ToInt32(txtBox_height1.Text);

            m_dwFontColor = ColorToUInt(txtBoxTypeString.ForeColor);

            m_dwBackgroundColor = ColorToUInt(m_clrBackground);

            m_pszFontFamilyName = txtBoxTypeString.Font.FontFamily.Name;

            m_nFontStyle = (uint)txtBoxTypeString.Font.Style;

            Font txtFont = txtBoxTypeString.Font;

            bool bBold = txtFont.Bold;

            if (bBold) { m_nFontStyle |= (uint)EXPORTS.FontStyleEnum.QCAP_FONT_STYLE_BOLD; }

            bool bItalic = txtFont.Italic;

            if (bItalic) { m_nFontStyle |= (uint)EXPORTS.FontStyleEnum.QCAP_FONT_STYLE_ITALIC; }

            bool bStrikeout = txtFont.Strikeout;

            if (bStrikeout) { m_nFontStyle |= (uint)EXPORTS.FontStyleEnum.QCAP_FONT_STYLE_STRIKEOUT; }

            bool bUnderline = txtFont.Underline;

            if (bUnderline) { m_nFontStyle |= (uint)EXPORTS.FontStyleEnum.QCAP_FONT_STYLE_UNDERLINE; }

            m_nFontSize = Convert.ToUInt32(comboxFontSize1.Text);

            m_nTransparent1 = Convert.ToUInt32(txtBox_Transparent1.Text);

            m_pszString = txtBoxTypeString.Text;

            if (m_hCapDev[0] != 0)
            {
                string str_string = m_pszString;

                string str_font_family_name = m_pszFontFamilyName;

                EXPORTS.QCAP_SET_OSD_TEXT(m_hCapDev[0], m_nOsdNum1, m_xoffset1, m_yoffset1, m_width1, m_height1, ref str_string, ref str_font_family_name, m_nFontStyle, m_nFontSize, m_dwFontColor, m_dwBackgroundColor, m_nTransparent1);
            }

            if (m_hCapDev[1] != 0)
            {
                string str_string = m_pszString;

                string str_font_family_name = m_pszFontFamilyName;

                EXPORTS.QCAP_SET_OSD_TEXT(m_hCapDev[1], m_nOsdNum1, m_xoffset1, m_yoffset1, m_width1, m_height1, ref str_string, ref str_font_family_name, m_nFontStyle, m_nFontSize, m_dwFontColor, m_dwBackgroundColor, m_nTransparent1);
            }

            if (m_hCapDev[2] != 0)
            {
                string str_string = m_pszString;

                string str_font_family_name = m_pszFontFamilyName;

                EXPORTS.QCAP_SET_OSD_TEXT(m_hCapDev[2], m_nOsdNum1, m_xoffset1, m_yoffset1, m_width1, m_height1, ref str_string, ref str_font_family_name, m_nFontStyle, m_nFontSize, m_dwFontColor, m_dwBackgroundColor, m_nTransparent1);
            }

            if (m_hCapDev[3] != 0)
            {
                string str_string = m_pszString;

                string str_font_family_name = m_pszFontFamilyName;

                EXPORTS.QCAP_SET_OSD_TEXT(m_hCapDev[3], m_nOsdNum1, m_xoffset1, m_yoffset1, m_width1, m_height1, ref str_string, ref str_font_family_name, m_nFontStyle, m_nFontSize, m_dwFontColor, m_dwBackgroundColor, m_nTransparent1);
            }
        }

        private void btnChangeFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Color = txtBoxTypeString.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtBoxTypeString.Font = new Font(fontDialog1.Font.FontFamily, 12, fontDialog1.Font.Style);

                txtBoxTypeString.ForeColor = fontDialog1.Color;

                labelOSDFontColor.BackColor = txtBoxTypeString.ForeColor;
            }
        }

        private void btnBrowsePicPath_Click(object sender, EventArgs e)
        {
            Stream fileStream;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "D:\\";

            openFileDialog1.Filter = "Image Files (*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg|All Files (*.*)|*.*||";

            openFileDialog1.FilterIndex = 0;

            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((fileStream = openFileDialog1.OpenFile()) != null)
                {
                    txtBoxPicPath.Text = openFileDialog1.FileName;

                    m_strPicturePath = txtBoxPicPath.Text;

                    if (m_PicImage != null)
                    {
                        m_PicImage.Dispose();
                    }

                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    m_PicImage = new Bitmap(m_strPicturePath);

                    picBox.Image = (Image)m_PicImage;

                    string strRes = m_PicImage.Width.ToString() + " x " + m_PicImage.Height.ToString();

                    txtboxImageRes.Text = strRes;

                    fileStream.Close();
                }
            }
        }

        private void btnApplyOSDPic_Click(object sender, EventArgs e)
        {
            m_nOsdNum2 = (uint)comboxOSDLayer2.SelectedIndex;

            m_xoffset2 = Convert.ToInt32(txtBox_Xoffset2.Text);

            m_yoffset2 = Convert.ToInt32(txtBox_Yoffset2.Text);

            m_width2 = Convert.ToInt32(txtBox_width2.Text);

            m_height2 = Convert.ToInt32(txtBox_height2.Text);

            m_nTransparent2 = Convert.ToUInt32(txtBox_Transparent2.Text);

            if (m_hCapDev[0] != 0)
            {
                string str_picture_path = m_strPicturePath;

                EXPORTS.QCAP_SET_OSD_PICTURE(m_hCapDev[0], m_nOsdNum2, m_xoffset2, m_yoffset2, m_width2, m_height2, ref str_picture_path, m_nTransparent2);
            }

            if (m_hCapDev[1] != 0)
            {
                string str_picture_path = m_strPicturePath;

                EXPORTS.QCAP_SET_OSD_PICTURE(m_hCapDev[1], m_nOsdNum2, m_xoffset2, m_yoffset2, m_width2, m_height2, ref str_picture_path, m_nTransparent2);
            }

            if (m_hCapDev[2] != 0)
            {
                string str_picture_path = m_strPicturePath;

                EXPORTS.QCAP_SET_OSD_PICTURE(m_hCapDev[2], m_nOsdNum2, m_xoffset2, m_yoffset2, m_width2, m_height2, ref str_picture_path, m_nTransparent2);
            }

            if (m_hCapDev[3] != 0)
            {
                string str_picture_path = m_strPicturePath;

                EXPORTS.QCAP_SET_OSD_PICTURE(m_hCapDev[3], m_nOsdNum2, m_xoffset2, m_yoffset2, m_width2, m_height2, ref str_picture_path, m_nTransparent2);
            }  

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }                        

        private void comboxFontSize1_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_nFontSize = Convert.ToUInt32(comboxFontSize1.Text);
        }

        private void txtBox_Xoffset1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_Yoffset1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_width1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_height1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_Transparent1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_Xoffset2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_Yoffset2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_width2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_height2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_Transparent2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_Xoffset3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_Yoffset3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_width3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_height3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }

        private void txtBox_Transparent3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // USE REGEX FOR NUMBER ONLY TXTBOX
            //
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
            else
                e.Handled = false;
        }        

        private void btnBrowseBinFilePath_Click(object sender, EventArgs e)
        {
            Stream fileStream;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "D:\\";

            openFileDialog1.Filter = "Binary Files (*.yuy2;*.yv12;*.rgb24,*.bgr24;*.argb32;*.abgr32)|*.yuy2;*.yv12;*.rgb24,*.bgr24;*.argb32;*.abgr32|All Files (*.*)|*.*||";

            openFileDialog1.FilterIndex = 0;

            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((fileStream = openFileDialog1.OpenFile()) != null)
                {
                    txtBoxBinFilePath.Text = openFileDialog1.FileName;

                    m_strBinaryFilePath = txtBoxBinFilePath.Text;

                    fileStream.Close();
                }
            }
        }        

        private void btnApplyOSDBuffer_Click(object sender, EventArgs e)
        {
            // SPECIFY A FILE TO READ FROM
            //
            FileStream fsSource = new FileStream(m_strBinaryFilePath, FileMode.Open, FileAccess.Read);

            m_bytesOSDBuffer = new byte[fsSource.Length];

            int numBytesToRead = (int)fsSource.Length;

            int numBytesRead = 0;

            int nRead = fsSource.Read(m_bytesOSDBuffer, numBytesRead, numBytesToRead);

            fsSource.Close();

            if (nRead == 0) { return; }

            m_pinnedOSDArray = GCHandle.Alloc(m_bytesOSDBuffer, GCHandleType.Pinned);

            m_pointerOSDAry = m_pinnedOSDArray.AddrOfPinnedObject();

            m_nOsdNum3 = (uint)comboxOSDLayer3.SelectedIndex;

            m_xoffset3 = Convert.ToInt32(txtBox_Xoffset3.Text);

            m_yoffset3 = Convert.ToInt32(txtBox_Yoffset3.Text);

            m_width3 = Convert.ToInt32(txtBox_width3.Text);

            m_height3 = Convert.ToInt32(txtBox_height3.Text);

            m_nTransparent3 = Convert.ToUInt32(txtBox_Transparent3.Text);

            uint nOSDColorSpace = (uint)EXPORTS.ColorSpaceTypeEnum.QCAP_COLORSPACE_TYEP_RGB24;

            if (comboOSDBufferColorSpace.SelectedIndex == 0) 
            { 
                nOSDColorSpace = (uint)EXPORTS.ColorSpaceTypeEnum.QCAP_COLORSPACE_TYEP_YUY2; 
            }

            if (comboOSDBufferColorSpace.SelectedIndex == 1) 
            { 
                nOSDColorSpace = (uint)EXPORTS.ColorSpaceTypeEnum.QCAP_COLORSPACE_TYEP_YV12; 
            }

            if (comboOSDBufferColorSpace.SelectedIndex == 2) 
            { 
                nOSDColorSpace = (uint)EXPORTS.ColorSpaceTypeEnum.QCAP_COLORSPACE_TYEP_RGB24; 
            }

            if (comboOSDBufferColorSpace.SelectedIndex == 3) 
            { 
                nOSDColorSpace = (uint)EXPORTS.ColorSpaceTypeEnum.QCAP_COLORSPACE_TYEP_BGR24; 
            }

            if (comboOSDBufferColorSpace.SelectedIndex == 4) 
            { 
                nOSDColorSpace = (uint)EXPORTS.ColorSpaceTypeEnum.QCAP_COLORSPACE_TYEP_ARGB32; 
            }

            if (comboOSDBufferColorSpace.SelectedIndex == 5) 
            { 
                nOSDColorSpace = (uint)EXPORTS.ColorSpaceTypeEnum.QCAP_COLORSPACE_TYEP_ABGR32; 
            }

            uint nOSDBufferWidth = Convert.ToUInt32(textBoxOSDBufferWidth.Text);

            uint nOSDBufferHeight = Convert.ToUInt32(textBoxOSDBufferHeight.Text);
            
            if (m_hCapDev[0] != 0)
            {
                EXPORTS.QCAP_SET_OSD_BUFFER(m_hCapDev[0],  m_nOsdNum3,  m_xoffset3, m_yoffset3,  m_width3, m_height3, 
                    
                    nOSDColorSpace, (uint)m_pointerOSDAry, nOSDBufferWidth, nOSDBufferHeight, 0, m_nTransparent3);
            }
            
            if (m_hCapDev[1] != 0)
            {
                EXPORTS.QCAP_SET_OSD_BUFFER(m_hCapDev[1], m_nOsdNum3, m_xoffset3, m_yoffset3, m_width3, m_height3, 
                    
                    nOSDColorSpace, (uint)m_pointerOSDAry, nOSDBufferWidth, nOSDBufferHeight, 0, m_nTransparent3);
            }

            if (m_hCapDev[2] != 0)
            {
                EXPORTS.QCAP_SET_OSD_BUFFER(m_hCapDev[2], m_nOsdNum3, m_xoffset3, m_yoffset3, m_width3, m_height3, 
                    
                    nOSDColorSpace, (uint)m_pointerOSDAry, nOSDBufferWidth, nOSDBufferHeight, 0, m_nTransparent3);
            }

            if (m_hCapDev[3] != 0)
            {
                EXPORTS.QCAP_SET_OSD_BUFFER(m_hCapDev[3], m_nOsdNum3, m_xoffset3, m_yoffset3, m_width3, m_height3, 
                    
                    nOSDColorSpace, (uint)m_pointerOSDAry, nOSDBufferWidth, nOSDBufferHeight, 0, m_nTransparent3);
            }
            
        }

        private void labelOSDFontColor_Click_1(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();

            ColorDlg.AllowFullOpen = true;

            // SET INITIAL COLOR TO THE CURRENT OSD BACKGROUND COLOR
            //
            ColorDlg.Color = labelOSDFontColor.BackColor;

            // UPDATE THE TEXTBOX COLOR IF USER CLICK OK
            //
            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                labelOSDFontColor.BackColor = ColorDlg.Color;

                m_clrForeground = ColorDlg.Color;

                txtBoxTypeString.ForeColor = m_clrForeground;
            }
        }

        private void labelOSDBackgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDlg = new ColorDialog();

            ColorDlg.AllowFullOpen = true;

            // SET INITIAL COLOR TO THE CURRENT OSD BACKGROUND COLOR
            //
            ColorDlg.Color = labelOSDBackgroundColor.BackColor;

            // UPDATE THE TEXTBOX COLOR IF USER CLICK OK
            //
            if (ColorDlg.ShowDialog() == DialogResult.OK)
            {
                labelOSDBackgroundColor.BackColor = ColorDlg.Color;

                m_clrBackground = ColorDlg.Color;

                txtBoxTypeString.BackColor = m_clrBackground;
            }
        }        

    }
}
