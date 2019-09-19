using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using QCAP.NET;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using IMemory;
using MySql.Data.MySqlClient;

namespace StreamCatcherDemo
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern void OutputDebugString(string message);

        public Form1()
        {
            InitializeComponent();
        }
        unsafe public byte* pDstABGRBuffer;

        public static uint pathnum = 0;
        public static string constring = @"Data Source=VPGKN7VP7JTJ06Z;Initial Catalog=a2;User ID=sa;Pwd=123456";

        public bool[] b_bitmap = new bool[4];

        public object[] b_bitmapchose = new object[] { new Object(), new Object(), new Object(), new Object() };

        public uint i = 0;

        public bool m_bIsMaximizedForm = false;

        public bool[] m_bIsMaximizedChannelWindow = new bool[4];

        public bool[] m_bNoSignal = new bool[4];

        public string[] m_strFormatChangedOutput = new string[4];

        public bool[] m_bShareRecordCH = new bool[4];

        public bool m_bShowClone = false;

        public bool m_bIsShareRecord = false;

        public uint m_nVideoWidth = 1920;

        public uint m_nVideoHeight = 1080;

        public double m_dVideoFrameRate = 60.0;

        public bool m_bIsStreaming = false;

        public uint m_hRtspCapDev = 0;                                    // RTSP STREAM CAPTURE DEVICE

        // CRITICAL SECTION OBJECT
        // 
        volatile public uint[] m_nNetworkServerState_v = new uint[4];

        public Object m_hNetworkServerAccessCriticalSection_v0 = new Object();

        public Object m_hNetworkServerAccessCriticalSection_v1 = new Object();

        public Object m_hNetworkServerAccessCriticalSection_v2 = new Object();

        public Object m_hNetworkServerAccessCriticalSection_v3 = new Object();

        volatile public uint[] m_nNetworkServerState_a = new uint[4];


        public Object m_hNetworkServerAccessCriticalSection_a0 = new Object();

        public Object m_hNetworkServerAccessCriticalSection_a1 = new Object();

        public Object m_hNetworkServerAccessCriticalSection_a2 = new Object();

        public Object m_hNetworkServerAccessCriticalSection_a3 = new Object();

        // FOURCC MARCO
        //
        uint MAKEFOURCC(uint ch0, uint ch1, uint ch2, uint ch3)
        {
            return ((uint)(byte)(ch0) | ((uint)(byte)(ch1) << 8) | ((uint)(byte)(ch2) << 16) | ((uint)(byte)(ch3) << 24));
        }

        // CALLBACK FUNCTION
        //        
        public static EXPORTS.PF_FORMAT_CHANGED_CALLBACK m_pFormatChangedCB;

        public static EXPORTS.PF_NO_SIGNAL_DETECTED_CALLBACK m_pNoSignalDetectedCB;

        public static EXPORTS.PF_SIGNAL_REMOVED_CALLBACK m_pSignalRemovedCB;

        public static EXPORTS.PF_VIDEO_PREVIEW_CALLBACK m_pPreviewVideoCB;

        public static EXPORTS.PF_AUDIO_PREVIEW_CALLBACK m_pPreviewAudioCB;

        public MySetupControl m_cSetupControl = new MySetupControl();

        // UNCOMPRESSION BUFFER
        //
        public byte[] m_bytesFrameBuffer;        

        public GCHandle m_pinnedFrameArray;

        public IntPtr m_pointerFrameAry;

        // LIVE PREVIEW CHANNEL WINDOW
        //
        public MyChannelControl[] m_pChannelControl_LIVE = new MyChannelControl[4];

        string m_strChipName = "DC1150 USB";

        // DEVICE PROPERTY
        //
        public uint[] m_hCapDev = new uint[4];                         // STREAM CAPTURE DEVICE

        public uint[] m_hCloneCapDev = new uint[4];                // CLONE STREAM CAPTURE DEVICE

        //  FORMAT CHANGED CALLBACK FUNCTION
        //
        EXPORTS.ReturnOfCallbackEnum on_process_format_changed(uint pDevice, uint nVideoInput, uint nAudioInput, uint nVideoWidth, uint nVideoHeight, uint bVideoIsInterleaved, double dVideoFrameRate, uint nAudioChannels, uint nAudioBitsPerSample, uint nAudioSampleFrequency, uint pUserData)
        {
            uint nCH = pUserData;            
            
            // OUTPUT FORMAT CHANGED MESSAGE
            //
            string strOutput = "CH" + (nCH + 1).ToString() + " -> FORMAT CHANGED : pDevice : " + pDevice.ToString() + " , " + "nVideoInput : " + nVideoInput.ToString() + " , " +

                                        "nAudioInput : " + nAudioInput.ToString() + " , " + "nVideoWidth : " + nVideoWidth.ToString() + " , " +

                                        "nVideoHeight : " + nVideoHeight.ToString() + " , " + "bVideoIsInterleaved : " + bVideoIsInterleaved.ToString() + " , " +

                                        "dVideoFrameRate : " + dVideoFrameRate.ToString() + " , " + "nAudioChannels : " + nAudioChannels.ToString() + " , " +

                                        "nAudioBitsPerSample : " + nAudioBitsPerSample.ToString() + " , " + "nAudioSampleFrequency : " + nAudioSampleFrequency.ToString() + " , " +
                                        
                                        "pUserData : " + pUserData.ToString() + " \n";

            OutputDebugString(strOutput);

            m_nVideoWidth = nVideoWidth;

            m_nVideoHeight = nVideoHeight;

            m_dVideoFrameRate = dVideoFrameRate;
            
            uint nVH = 0;

            string strFrameType = " P ";

            string strVideoInput = "", strAudioInput = "";
             
            if (nVideoInput == 0) { strVideoInput = "COMPOSITE"; } if (nVideoInput == 1) { strVideoInput = "SVIDEO"; } if (nVideoInput == 2) { strVideoInput = "HDMI"; }

            if (nVideoInput == 3) { strVideoInput = "DVI_D"; } if (nVideoInput == 4) { strVideoInput = "COMPONENTS (YCBCR)"; } if (nVideoInput == 5) { strVideoInput = "DVI_A (RGB / VGA)"; }

            if (nVideoInput == 6) { strVideoInput = "SDI"; } if (nVideoInput == 7) { strVideoInput = "AUTO"; }

            if (nAudioInput == 0) { strAudioInput = "EMBEDDED_AUDIO";  } if (nAudioInput == 1) { strAudioInput = "LINE_IN"; }

            if (bVideoIsInterleaved == 1) { nVH = nVideoHeight / 2; } else { nVH = nVideoHeight; }

            if (bVideoIsInterleaved == 1) { strFrameType = " I "; } else { strFrameType = " P "; }

            m_strFormatChangedOutput[nCH] = @" INFO : " + nVideoWidth.ToString() + " x " + nVH.ToString() + strFrameType + " @" + dVideoFrameRate.ToString() +

                " FPS , " + nAudioChannels.ToString() + " CH x " + nAudioBitsPerSample.ToString() + " BITS x " + nAudioSampleFrequency.ToString() + " HZ , " + 
                
                " VIDEO INPUT : " + strVideoInput + " , " + " AUDIO INPUT : " + strAudioInput + " \n";

            // NO SIGNAL
            //       
            if (nVideoWidth == 0 && nVideoHeight == 0 && dVideoFrameRate == 0.0 && nAudioChannels == 0 && nAudioBitsPerSample == 0 && nAudioSampleFrequency == 0)
            {
                m_bNoSignal[nCH] = true;
            }
            else
            {
                m_bNoSignal[nCH] = false;
            }

            return EXPORTS.ReturnOfCallbackEnum.QCAP_RT_OK;
        }

        int g_nCount = 0;

        // PREVIEW VIDEO CALLBACK FUNCTION
        //
        EXPORTS.ReturnOfCallbackEnum on_process_preview_video_buffer(uint pDevice, double dSampleTime, uint pFrameBuffer, uint nFrameBufferLen, uint pUserData)
        {
            uint nCH = pUserData;

            //string strOutput = "CH" + (nCH + 1).ToString() +  " : on_process_preview_video_buffer => pDevice : " + pDevice.ToString() + " , dSampleTime : " + dSampleTime.ToString() + " , pFrameBuffer : " + pFrameBuffer.ToString() + " , nFrameBufferLen : " + nFrameBufferLen.ToString() + " , pUserData : " + pUserData.ToString() + " \n";

            //OutputDebugString(strOutput);

            if (b_bitmap[nCH] == true && pFrameBuffer != 0)
            {
                b_bitmap[nCH] = false;

                unsafe
                {
                    pDstABGRBuffer = (byte*)memory.Alloc((int)(m_nVideoWidth * m_nVideoHeight * 4));

                    EXPORTS.QCAP_COLORSPACE_YUY2_TO_ABGR32(pFrameBuffer, m_nVideoWidth, m_nVideoHeight, m_nVideoWidth * 2, (uint)pDstABGRBuffer, m_nVideoWidth, m_nVideoHeight, m_nVideoWidth * 4);

                    Bitmap bmp = new Bitmap((int)m_nVideoWidth, (int)m_nVideoHeight, PixelFormat.Format32bppRgb);

                    BitmapData bmpData = bmp.LockBits(new Rectangle(0,
                                                                    0,
                                                                    bmp.Width,
                                                                    bmp.Height),
                                                                    ImageLockMode.WriteOnly,
                                                                    bmp.PixelFormat);

                    byte[] managedArray = new byte[(m_nVideoWidth * m_nVideoHeight * 4)];

                    Marshal.Copy((IntPtr)pDstABGRBuffer, managedArray, 0, (int)(m_nVideoWidth * m_nVideoHeight * 4));

                    Marshal.Copy(managedArray, 0, bmpData.Scan0, (int)(m_nVideoWidth * m_nVideoHeight * 4));

                    bmp.UnlockBits(bmpData);

                    switch (nCH)
                    {
                        case 0:

                            {
                                PicTosql(bmp, nCH);
                                unsafe
                                {
                                    memory.free(pDstABGRBuffer);
                                }

                            }

                            break;
                        case 1:

                            {
                                PicTosql(bmp, nCH);
                               

                            }

                            break;
                        case 2:

                            {
                                PicTosql(bmp, nCH);

                            }

                            break;
                        case 3:

                            if (m_nNetworkServerState_v[nCH] > 0x00000000)
                            {
                                PicTosql(bmp, nCH);

                            }

                            break;
                        default:
                            break;
                    }

                }
            }
               

                return EXPORTS.ReturnOfCallbackEnum.QCAP_RT_OK;
        }
        public static byte[] BitmapByte(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Jpeg);
                byte[] data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
                return data;
            }
        }

        private static string GetPic(Bitmap bitmap,uint i)
        {
            String path = "F:/pictures/pictures"+(i+1).ToString() + "/photo"+ DateTime.Now.ToString("MMddHHmmss") + ".jpg";

            bitmap.Save(path);

            return path;

        }
        public void PicTosql(Bitmap bitmap, uint i)
        {

            String sqlpath = GetPic(bitmap,i);
            String connetStr = "server=127.0.0.1;port=3306;user=root;password=admin; database = picdetect;";
            // server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以不写
            MySqlConnection conn11 = new MySqlConnection(connetStr);
            conn11.Open();
            try
            { 
                MySqlCommand cmd1 = new MySqlCommand("insert into infodata"+(i+1).ToString()+"(time,path,iscaculated) values(@time,@path,@iscaculated)",conn11);
              //  String nowTime1 = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
               
                cmd1.Parameters.Add("time", MySqlDbType.DateTime).Value = DateTime.Now;
                cmd1.Parameters.Add("path", MySqlDbType.VarChar).Value = sqlpath;
                //该记录未被计算，设置为0；在C++中通过算法计算后，将其改为1
               cmd1.Parameters.Add("iscaculated", MySqlDbType.Int16).Value = 0;

                cmd1.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally {
                if (conn11.State == ConnectionState.Open)
                {
                    conn11.Close();
                   
                }
             }
                        
            //string constr = constring;
            //SqlConnection conn = new SqlConnection(constr);
            //conn.Open();

            //SqlCommand cmd = new SqlCommand("insert into Table_" + (i + 1).ToString() + "(time,photo) values(@time,@photo)", conn);
            //  string s = DateTime.Now.ToString("MMddHHmmss");
            //  int i = int.Parse(s);

            //String s = GetTimestamp(DateTime.Now);
            //int k = int.Parse(s);
            //String nowTime = DateTime.Now.ToString();
            //byte[] P = BitmapByte(bitmap);
            //cmd.Parameters.Add("time", SqlDbType.DateTime).Value = nowTime;
            //cmd.Parameters.Add("photo", SqlDbType.Image).Value = P;
            //cmd.ExecuteNonQuery();

        }
        public static string GetTimestamp(DateTime d)
        {
            TimeSpan ts = d - new DateTime(2019, 4, 25, 8, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds).ToString();     //精确到秒
        }

        public static void createSql(uint cameranum)
        {
            string constr = constring;
            SqlConnection conn = new SqlConnection(constr);
            conn.Open();

            for (int i = 1; i <= cameranum; i++)
            {
                //注意单引号与双引号
                string sqlstr = "if not exists (select * from sysobjects where id = OBJECT_ID(N'Table_" + i.ToString() + "')) CREATE TABLE Table_" + i.ToString() + "(time datetime not null,photo image)";

                SqlCommand cmd = new SqlCommand(sqlstr, conn);
                //  string s = DateTime.Now.ToString("MMddHHmmss");
                //  int i = int.Parse(s);

                cmd.ExecuteNonQuery();

            }
        }

        // PREVIEW AUDIO CALLBACK FUNCTION
        //
        EXPORTS.ReturnOfCallbackEnum on_process_preview_audio_buffer(uint pDevice, double dSampleTime, uint pFrameBuffer, uint nFrameBufferLen, uint pUserData)
        {
            uint nCH = pUserData;

            //string strOutput = "CH" + (nCH + 1).ToString() + " : on_process_preview_audio_buffer => pDevice : " + pDevice.ToString() + " , dSampleTime : " + dSampleTime.ToString() + " , pFrameBuffer : " + pFrameBuffer.ToString() + " , nFrameBufferLen : " + nFrameBufferLen.ToString() + " , pUserData : " + pUserData.ToString() + " \n";

            //OutputDebugString(strOutput);

            if (m_bIsShareRecord && m_bShareRecordCH[ nCH ] )
            {
                EXPORTS.QCAP_SET_AUDIO_SHARE_RECORD_UNCOMPRESSION_BUFFER(0, pFrameBuffer, nFrameBufferLen);
            }
     
            if (m_bIsStreaming && m_hRtspCapDev != 0)
            {
                switch (nCH)
                {
                    case 0:
                        lock (m_hNetworkServerAccessCriticalSection_a0)
                        {
                            if (m_nNetworkServerState_a[nCH] > 0x00000000)
                            {
                                EXPORTS.QCAP_SET_AUDIO_BROADCAST_SERVER_UNCOMPRESSION_BUFFER(m_hRtspCapDev, nCH, pFrameBuffer, nFrameBufferLen);
                            }
                        }
                        break;
                    case 1:
                        lock (m_hNetworkServerAccessCriticalSection_a1)
                        {
                            if (m_nNetworkServerState_a[nCH] > 0x00000000)
                            {
                                EXPORTS.QCAP_SET_AUDIO_BROADCAST_SERVER_UNCOMPRESSION_BUFFER(m_hRtspCapDev, nCH, pFrameBuffer, nFrameBufferLen);
                            }
                        }
                        break;
                    case 2:
                        lock (m_hNetworkServerAccessCriticalSection_a2)
                        {
                            if (m_nNetworkServerState_a[nCH] > 0x00000000)
                            {
                                EXPORTS.QCAP_SET_AUDIO_BROADCAST_SERVER_UNCOMPRESSION_BUFFER(m_hRtspCapDev, nCH, pFrameBuffer, nFrameBufferLen);
                            }
                        }
                        break;
                    case 3:
                        lock (m_hNetworkServerAccessCriticalSection_a3)
                        {
                            if (m_nNetworkServerState_a[nCH] > 0x00000000)
                            {
                                EXPORTS.QCAP_SET_AUDIO_BROADCAST_SERVER_UNCOMPRESSION_BUFFER(m_hRtspCapDev, nCH, pFrameBuffer, nFrameBufferLen);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return EXPORTS.ReturnOfCallbackEnum.QCAP_RT_OK;
        }

        // NO SIGNAL DETEACTED CALLBACK FUNCTION
        //
        EXPORTS.ReturnOfCallbackEnum on_process_no_signal_detected(uint pDevice, uint nVideoInput, uint nAudioInput, uint pUserData )
        {
            uint nCH = pUserData;

            OutputDebugString( "CH" + ( nCH + 1 ).ToString() + " No Signal Detected  \n");

            m_bNoSignal[nCH] = true;

            return EXPORTS.ReturnOfCallbackEnum.QCAP_RT_OK;
        }

        // SIGNAL REMOVED CALLBACK FUNCTION
        //
        EXPORTS.ReturnOfCallbackEnum on_process_signal_removed(uint pDevice, uint nVideoInput, uint nAudioInput, uint pUserData)
        {
            uint nCH = pUserData;

            OutputDebugString(  "CH" + ( nCH + 1 ).ToString() + " Signal Removed \n");

           m_bNoSignal[nCH] = true;

            return EXPORTS.ReturnOfCallbackEnum.QCAP_RT_OK;
        }

        private void Form1_Load(object sender, EventArgs e)
        {     
            // CREATE CHANNEL WINDOW
            //
            for (i = 0 ; i < 4 ; i++)
            {
                m_pChannelControl_LIVE[i] = new MyChannelControl();

                m_pChannelControl_LIVE[i].Parent = this;

                // LEFT POSITION
                //
                if (i == 0) { m_pChannelControl_LIVE[i].Left = 0; }

                if (i == 1) { m_pChannelControl_LIVE[i].Left = this.Width / 2; }

                if (i == 2) { m_pChannelControl_LIVE[i].Left = 0; }

                if (i == 3) { m_pChannelControl_LIVE[i].Left = this.Width / 2; }

                // TOP POSITION
                //
                if (i == 0) { m_pChannelControl_LIVE[i].Top = 0; }

                if (i == 1) { m_pChannelControl_LIVE[i].Top = 0; }

                if (i == 2) { m_pChannelControl_LIVE[i].Top = this.Height / 2; }

                if (i == 3) { m_pChannelControl_LIVE[i].Top = this.Height / 2; }

                // WIDTH & HEIGHT
                //
                m_pChannelControl_LIVE[i].Size = new System.Drawing.Size(this.Width / 2, this.Height / 2);

                m_pChannelControl_LIVE[i].Visible = true;

                m_pChannelControl_LIVE[i].m_nChannelNumber = i + 1;

                m_bIsMaximizedChannelWindow[i] = false;

                m_nNetworkServerState_v[i] = 0x00000000;

                m_nNetworkServerState_a[i] = 0x00000000;
            }            
                           
            CloneChannelPanel1.Left = 0; CloneChannelPanel1.Top = 0; CloneChannelPanel1.Width = 160; CloneChannelPanel1.Height = 120; CloneChannelPanel1.Visible = false;

            CloneChannelPanel2.Left = this.Width / 2; CloneChannelPanel2.Top = 0; CloneChannelPanel2.Width = 160; CloneChannelPanel2.Height = 120; CloneChannelPanel2.Visible = false;

            CloneChannelPanel3.Left = 0; CloneChannelPanel3.Top = this.Height / 2; CloneChannelPanel3.Width = 160; CloneChannelPanel3.Height = 120; CloneChannelPanel3.Visible = false;

            CloneChannelPanel4.Left = this.Width / 2; CloneChannelPanel4.Top = this.Height / 2; CloneChannelPanel4.Width = 160; CloneChannelPanel4.Height = 120; CloneChannelPanel4.Visible = false;

            HwInitialize();

            // USER INTERFACE PROGRAMMING (SETUP CONTROL)
            //
            m_cSetupControl = new MySetupControl();

            m_cSetupControl.m_pMainForm = this;

            m_cSetupControl.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetupControlClosed);

            m_cSetupControl.Left = this.Left;

            m_cSetupControl.Top = this.Bottom - 20;            

            m_cSetupControl.Visible = true;

            m_cSetupControl.Show();

            m_bShareRecordCH[0] = true; m_bShareRecordCH[1] = false; m_bShareRecordCH[2] = false; m_bShareRecordCH[3] = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerCheckSignal.Enabled = false;

            EXPORTS.QCAP_STOP_SHARE_RECORD(0);

            HwUnInitialize();

            //m_pinnedFrameArray.Free();
        }

        private void SetupControlClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        public void ShowCloneVideo(bool bShow)
        {
            if (bShow)
            {
                m_bShowClone = true;

                if (m_pChannelControl_LIVE[0].Visible == true) 
                { 
                    CloneChannelPanel1.Visible = true;

                    if (m_hCapDev[0] != 0)
                    {
                        EXPORTS.QCAP_CREATE_CLONE(m_hCapDev[0], (uint)CloneChannelPanel1.Handle.ToInt32(), ref m_hCloneCapDev[0], 1);

                        if (m_hCloneCapDev[0] != 0)
                        {
                            EXPORTS.QCAP_RUN(m_hCloneCapDev[0]);

                            EXPORTS.QCAP_SET_AUDIO_VOLUME(m_hCloneCapDev[0], 0);
                        }
                    }
                }

                if (m_pChannelControl_LIVE[1].Visible == true) 
                { 
                    CloneChannelPanel2.Visible = true;

                    if (m_hCapDev[1] != 0)
                    {
                        EXPORTS.QCAP_CREATE_CLONE(m_hCapDev[1], (uint)CloneChannelPanel2.Handle.ToInt32(), ref m_hCloneCapDev[1], 1);

                        if (m_hCloneCapDev[1] != 0)
                        {
                            EXPORTS.QCAP_RUN(m_hCloneCapDev[1]);

                            EXPORTS.QCAP_SET_AUDIO_VOLUME(m_hCloneCapDev[1], 0);
                        }
                    }
                }

                if (m_pChannelControl_LIVE[2].Visible == true) 
                { 
                    CloneChannelPanel3.Visible = true;

                    if (m_hCapDev[2] != 0)
                    {
                        EXPORTS.QCAP_CREATE_CLONE(m_hCapDev[2], (uint)CloneChannelPanel3.Handle.ToInt32(), ref m_hCloneCapDev[2], 1);

                        if (m_hCloneCapDev[2] != 0)
                        {
                            EXPORTS.QCAP_RUN(m_hCloneCapDev[2]);

                            EXPORTS.QCAP_SET_AUDIO_VOLUME(m_hCloneCapDev[2], 0);
                        }
                    }
                }

                if (m_pChannelControl_LIVE[3].Visible == true) 
                { 
                    CloneChannelPanel4.Visible = true;

                    if (m_hCapDev[3] != 0)
                    {
                        EXPORTS.QCAP_CREATE_CLONE(m_hCapDev[3], (uint)CloneChannelPanel4.Handle.ToInt32(), ref m_hCloneCapDev[3], 1);

                        if (m_hCloneCapDev[3] != 0)
                        {
                            EXPORTS.QCAP_RUN(m_hCloneCapDev[3]);

                            EXPORTS.QCAP_SET_AUDIO_VOLUME(m_hCloneCapDev[3], 0);
                        }
                    }
                }
            }
            else
            {
                m_bShowClone = false;

                if (m_pChannelControl_LIVE[0].Visible == true) 
                { 
                    CloneChannelPanel1.Visible = false;

                    if (m_hCloneCapDev[0] != 0) { EXPORTS.QCAP_STOP(m_hCloneCapDev[0]); EXPORTS.QCAP_DESTROY(m_hCloneCapDev[0]); m_hCloneCapDev[0] = 0; }
                }

                if (m_pChannelControl_LIVE[1].Visible == true) 
                { 
                    CloneChannelPanel2.Visible = false;

                    if (m_hCloneCapDev[1] != 0) { EXPORTS.QCAP_STOP(m_hCloneCapDev[1]); EXPORTS.QCAP_DESTROY(m_hCloneCapDev[1]); m_hCloneCapDev[1] = 0; }
                }

                if (m_pChannelControl_LIVE[2].Visible == true) 
                { 
                    CloneChannelPanel3.Visible = false;

                    if (m_hCloneCapDev[2] != 0) { EXPORTS.QCAP_STOP(m_hCloneCapDev[2]); EXPORTS.QCAP_DESTROY(m_hCloneCapDev[2]); m_hCloneCapDev[2] = 0; }
                }

                if (m_pChannelControl_LIVE[3].Visible == true) 
                { 
                    CloneChannelPanel4.Visible = false;

                    if (m_hCloneCapDev[3] != 0) { EXPORTS.QCAP_STOP(m_hCloneCapDev[3]); EXPORTS.QCAP_DESTROY(m_hCloneCapDev[3]); m_hCloneCapDev[3] = 0; }
                }
            }        
        }

        public void OnLButtonDown_ChannelControl(uint nChannelNumber)
        {
            if (m_bIsMaximizedChannelWindow[nChannelNumber - 1])
            {
                m_bIsMaximizedChannelWindow[nChannelNumber - 1] = false;

                for (i = 0; i < 4; i++)
                {
                    // LEFT POSITION
                    //
                    if (i == 0) { m_pChannelControl_LIVE[i].Left = 0; }

                    if (i == 1) { m_pChannelControl_LIVE[i].Left = this.Width / 2; }

                    if (i == 2) { m_pChannelControl_LIVE[i].Left = 0; }

                    if (i == 3) { m_pChannelControl_LIVE[i].Left = this.Width / 2; }

                    // TOP POSITION
                    //
                    if (i == 0) { m_pChannelControl_LIVE[i].Top = 0; }

                    if (i == 1) { m_pChannelControl_LIVE[i].Top = 0; }

                    if (i == 2) { m_pChannelControl_LIVE[i].Top = this.Height / 2; }

                    if (i == 3) { m_pChannelControl_LIVE[i].Top = this.Height / 2; }

                    m_pChannelControl_LIVE[i].Size = new System.Drawing.Size(this.Width / 2, this.Height / 2);

                    m_pChannelControl_LIVE[i].Visible = true;
                }

                CloneChannelPanel1.Left = 0; CloneChannelPanel1.Top = 0; CloneChannelPanel1.Width = 160; CloneChannelPanel1.Height = 120; CloneChannelPanel1.Visible = m_bShowClone;

                CloneChannelPanel2.Left = this.Width / 2; CloneChannelPanel2.Top = 0; CloneChannelPanel2.Width = 160; CloneChannelPanel2.Height = 120; CloneChannelPanel2.Visible = m_bShowClone;

                CloneChannelPanel3.Left = 0; CloneChannelPanel3.Top = this.Height / 2; CloneChannelPanel3.Width = 160; CloneChannelPanel3.Height = 120; CloneChannelPanel3.Visible = m_bShowClone;

                CloneChannelPanel4.Left = this.Width / 2; CloneChannelPanel4.Top = this.Height / 2; CloneChannelPanel4.Width = 160; CloneChannelPanel4.Height = 120; CloneChannelPanel4.Visible = m_bShowClone;                
            }
            else
            {
                m_bIsMaximizedChannelWindow[nChannelNumber - 1] = true;

                for (i = 0; i < 4; i++) { m_pChannelControl_LIVE[i].Visible = false; }

                CloneChannelPanel1.Visible = false; CloneChannelPanel2.Visible = false; CloneChannelPanel3.Visible = false; CloneChannelPanel4.Visible = false;

                m_pChannelControl_LIVE[nChannelNumber - 1].Left = 0;

                m_pChannelControl_LIVE[nChannelNumber - 1].Top = 0;

                m_pChannelControl_LIVE[nChannelNumber - 1].Size = new System.Drawing.Size(this.Width, this.Height);

                m_pChannelControl_LIVE[nChannelNumber - 1].Visible = true;

                if (nChannelNumber == 1) { CloneChannelPanel1.Left = 0; CloneChannelPanel1.Top = 0; CloneChannelPanel1.Width = 160; CloneChannelPanel1.Height = 120; CloneChannelPanel1.Visible = m_bShowClone; }

                if (nChannelNumber == 2) { CloneChannelPanel2.Left = this.Width / 2; CloneChannelPanel2.Top = 0; CloneChannelPanel2.Width = 160; CloneChannelPanel2.Height = 120; CloneChannelPanel2.Visible = m_bShowClone; }

                if (nChannelNumber == 3) { CloneChannelPanel3.Left = 0; CloneChannelPanel3.Top = this.Height / 2; CloneChannelPanel3.Width = 160; CloneChannelPanel3.Height = 120; CloneChannelPanel3.Visible = m_bShowClone; }

                if (nChannelNumber == 4) { CloneChannelPanel4.Left = this.Width / 2; CloneChannelPanel4.Top = this.Height / 2; CloneChannelPanel4.Width = 160; CloneChannelPanel4.Height = 120; CloneChannelPanel4.Visible = m_bShowClone; }
            }
        }

        public void OnRButtonDown_ChannelControl(uint nChannelNumber)
        {
            // CHANGE CHANNEL WINDOWS SIZE AND POSITION
            //
            if (!m_bIsMaximizedForm)
            {
                this.WindowState = FormWindowState.Maximized;

                m_bIsMaximizedForm = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;

                m_bIsMaximizedForm = false;
            }

            if (m_bIsMaximizedChannelWindow[nChannelNumber - 1])
            {
                m_pChannelControl_LIVE[nChannelNumber - 1].Left = 0;

                m_pChannelControl_LIVE[nChannelNumber - 1].Top = 0;

                m_pChannelControl_LIVE[nChannelNumber - 1].Size = new System.Drawing.Size(this.Width, this.Height);

                m_pChannelControl_LIVE[nChannelNumber - 1].Visible = true;

                if (nChannelNumber == 1) { CloneChannelPanel1.Left = this.Width - 320; CloneChannelPanel1.Top = this.Height - 240; CloneChannelPanel1.Width = 320; CloneChannelPanel1.Height = 240; CloneChannelPanel1.Visible = m_bShowClone; }

                if (nChannelNumber == 2) { CloneChannelPanel2.Left = this.Width - 320; CloneChannelPanel2.Top = this.Height - 240; CloneChannelPanel2.Width = 320; CloneChannelPanel2.Height = 240; CloneChannelPanel2.Visible = m_bShowClone; }

                if (nChannelNumber == 3) { CloneChannelPanel3.Left = this.Width - 320; CloneChannelPanel3.Top = this.Height - 240; CloneChannelPanel3.Width = 320; CloneChannelPanel3.Height = 240; CloneChannelPanel3.Visible = m_bShowClone; }

                if (nChannelNumber == 4) { CloneChannelPanel4.Left = this.Width - 320; CloneChannelPanel4.Top = this.Height - 240; CloneChannelPanel4.Width = 320; CloneChannelPanel4.Height = 240; CloneChannelPanel4.Visible = m_bShowClone; }                
            }
            else
            {
                for (i = 0; i < 4; i++)
                {
                    // LEFT POSITION
                    //
                    if (i == 0) { m_pChannelControl_LIVE[i].Left = 0; }

                    if (i == 1) { m_pChannelControl_LIVE[i].Left = this.Width / 2; }

                    if (i == 2) { m_pChannelControl_LIVE[i].Left = 0; }

                    if (i == 3) { m_pChannelControl_LIVE[i].Left = this.Width / 2; }

                    // TOP POSITION
                    //
                    if (i == 0) { m_pChannelControl_LIVE[i].Top = 0; }

                    if (i == 1) { m_pChannelControl_LIVE[i].Top = 0; }

                    if (i == 2) { m_pChannelControl_LIVE[i].Top = this.Height / 2; }

                    if (i == 3) { m_pChannelControl_LIVE[i].Top = this.Height / 2; }

                    m_pChannelControl_LIVE[i].Size = new System.Drawing.Size(this.Width / 2, this.Height / 2);

                    m_pChannelControl_LIVE[i].Visible = true;
                }

                CloneChannelPanel1.Left = 0; CloneChannelPanel1.Top = 0; CloneChannelPanel1.Width = 160; CloneChannelPanel1.Height = 120; CloneChannelPanel1.Visible = m_bShowClone;

                CloneChannelPanel2.Left = this.Width / 2; CloneChannelPanel2.Top = 0; CloneChannelPanel2.Width = 160; CloneChannelPanel2.Height = 120; CloneChannelPanel2.Visible = m_bShowClone;

                CloneChannelPanel3.Left = 0; CloneChannelPanel3.Top = this.Height / 2; CloneChannelPanel3.Width = 160; CloneChannelPanel3.Height = 120; CloneChannelPanel3.Visible = m_bShowClone;

                CloneChannelPanel4.Left = this.Width / 2; CloneChannelPanel4.Top = this.Height / 2; CloneChannelPanel4.Width = 160; CloneChannelPanel4.Height = 120; CloneChannelPanel4.Visible = m_bShowClone;
            }            
        }

        public bool HwInitialize()
        {
            for (i = 0; i < 4; i++) { m_hCapDev[i] = 0x00000000; }

            for (i = 0; i < 4; i++) { m_hCloneCapDev[i] = 0x00000000; }

            for (i = 0; i < 4; i++) { m_bNoSignal[i] = true; }

            for (i = 0; i < 4; i++) { m_strFormatChangedOutput[i] = ""; }            

            // CREATE CAPTURE DEVICE            
            //
            for (i = 0; i < 4; i++ )
            {
                string str_chip_name = m_strChipName;

                EXPORTS.QCAP_CREATE(ref str_chip_name, i, (uint)m_pChannelControl_LIVE[i].Handle.ToInt32(), ref m_hCapDev[i], 1);
            }
                       
            // REGISTER FORMAT CHANGED CALLBACK FUNCTION
            // 
            m_pFormatChangedCB = new EXPORTS.PF_FORMAT_CHANGED_CALLBACK(on_process_format_changed);

            EXPORTS.QCAP_REGISTER_FORMAT_CHANGED_CALLBACK(m_hCapDev[0], m_pFormatChangedCB, 0);

            EXPORTS.QCAP_REGISTER_FORMAT_CHANGED_CALLBACK(m_hCapDev[1], m_pFormatChangedCB, 1);

            EXPORTS.QCAP_REGISTER_FORMAT_CHANGED_CALLBACK(m_hCapDev[2], m_pFormatChangedCB, 2);

            EXPORTS.QCAP_REGISTER_FORMAT_CHANGED_CALLBACK(m_hCapDev[3], m_pFormatChangedCB, 3);
                        
            // REGISTER PREVIEW VIDEO CALLBACK FUNCTION
            // 
            m_pPreviewVideoCB = new EXPORTS.PF_VIDEO_PREVIEW_CALLBACK(on_process_preview_video_buffer);

            EXPORTS.QCAP_REGISTER_VIDEO_PREVIEW_CALLBACK(m_hCapDev[0], m_pPreviewVideoCB, 0);

            EXPORTS.QCAP_REGISTER_VIDEO_PREVIEW_CALLBACK(m_hCapDev[1], m_pPreviewVideoCB, 1);

            EXPORTS.QCAP_REGISTER_VIDEO_PREVIEW_CALLBACK(m_hCapDev[2], m_pPreviewVideoCB, 2);

            EXPORTS.QCAP_REGISTER_VIDEO_PREVIEW_CALLBACK(m_hCapDev[3], m_pPreviewVideoCB, 3);
            
            // REGISTER PREVIEW AUDIO CALLBACK FUNCTION
            //
            m_pPreviewAudioCB = new EXPORTS.PF_AUDIO_PREVIEW_CALLBACK(on_process_preview_audio_buffer);

            EXPORTS.QCAP_REGISTER_AUDIO_PREVIEW_CALLBACK(m_hCapDev[0], m_pPreviewAudioCB, 0);

            EXPORTS.QCAP_REGISTER_AUDIO_PREVIEW_CALLBACK(m_hCapDev[1], m_pPreviewAudioCB, 1);

            EXPORTS.QCAP_REGISTER_AUDIO_PREVIEW_CALLBACK(m_hCapDev[2], m_pPreviewAudioCB, 2);

            EXPORTS.QCAP_REGISTER_AUDIO_PREVIEW_CALLBACK(m_hCapDev[3], m_pPreviewAudioCB, 3);
            
            // REGISTER NO SIGNAL DETECTED CALLBACK FUNCTION
            //
            m_pNoSignalDetectedCB = new EXPORTS.PF_NO_SIGNAL_DETECTED_CALLBACK(on_process_no_signal_detected);

            EXPORTS.QCAP_REGISTER_NO_SIGNAL_DETECTED_CALLBACK(m_hCapDev[0], m_pNoSignalDetectedCB, 0);

            EXPORTS.QCAP_REGISTER_NO_SIGNAL_DETECTED_CALLBACK(m_hCapDev[1], m_pNoSignalDetectedCB, 1);

            EXPORTS.QCAP_REGISTER_NO_SIGNAL_DETECTED_CALLBACK(m_hCapDev[2], m_pNoSignalDetectedCB, 2);

            EXPORTS.QCAP_REGISTER_NO_SIGNAL_DETECTED_CALLBACK(m_hCapDev[3], m_pNoSignalDetectedCB, 3);

            // REGISTER SIGNAL REMOVED CALLBACK FUNCTION
            //
            m_pSignalRemovedCB = new EXPORTS.PF_SIGNAL_REMOVED_CALLBACK(on_process_signal_removed);

            EXPORTS.QCAP_REGISTER_SIGNAL_REMOVED_CALLBACK(m_hCapDev[0], m_pSignalRemovedCB, 0);

            EXPORTS.QCAP_REGISTER_SIGNAL_REMOVED_CALLBACK(m_hCapDev[1], m_pSignalRemovedCB, 1);

            EXPORTS.QCAP_REGISTER_SIGNAL_REMOVED_CALLBACK(m_hCapDev[2], m_pSignalRemovedCB, 2);

            EXPORTS.QCAP_REGISTER_SIGNAL_REMOVED_CALLBACK(m_hCapDev[3], m_pSignalRemovedCB, 3);
            
            // SET INPUT
            //
            uint nInput = (uint)EXPORTS.InputVideoSourceEnum.QCAP_INPUT_TYPE_SDI;

            EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[0], nInput);

            EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[1], nInput);

            EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[2], nInput);

            EXPORTS.QCAP_SET_VIDEO_INPUT(m_hCapDev[3], nInput);
         
            // RUN DEVICE
            //
            EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev[0], 0);

            EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev[1], 0);

            EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev[2], 0);

            EXPORTS.QCAP_SET_VIDEO_DEINTERLACE(m_hCapDev[3], 0);

            EXPORTS.QCAP_RUN(m_hCapDev[0]);

            EXPORTS.QCAP_RUN(m_hCapDev[1]);

            EXPORTS.QCAP_RUN(m_hCapDev[2]);

            EXPORTS.QCAP_RUN(m_hCapDev[3]);

            createSql(4);

            timerCheckSignal.Enabled = true;

            return true;
        }

        public bool HwUnInitialize()
        {
            m_bIsStreaming = false;
            for (i = 0; i < 4; i++)
            {
                b_bitmap[i] = false;
            }
            unsafe
            {
                memory.free(pDstABGRBuffer);
            }

            EXPORTS.QCAP_DESTROY_BROADCAST_SERVER(m_hRtspCapDev);

            if (m_hCloneCapDev[0] != 0) { EXPORTS.QCAP_STOP(m_hCloneCapDev[0]);  EXPORTS.QCAP_DESTROY(m_hCloneCapDev[0]);}

            if (m_hCloneCapDev[1] != 0) { EXPORTS.QCAP_STOP(m_hCloneCapDev[1]); EXPORTS.QCAP_DESTROY(m_hCloneCapDev[1]); }

            if (m_hCloneCapDev[2] != 0) { EXPORTS.QCAP_STOP(m_hCloneCapDev[2]); EXPORTS.QCAP_DESTROY(m_hCloneCapDev[2]); }

            if (m_hCloneCapDev[3] != 0) { EXPORTS.QCAP_STOP(m_hCloneCapDev[3]); EXPORTS.QCAP_DESTROY(m_hCloneCapDev[3]); }

            if (m_hCapDev[0] != 0) { EXPORTS.QCAP_STOP(m_hCapDev[0]); EXPORTS.QCAP_DESTROY(m_hCapDev[0]); }

            if (m_hCapDev[1] != 0) { EXPORTS.QCAP_STOP(m_hCapDev[1]); EXPORTS.QCAP_DESTROY(m_hCapDev[1]); }

            if (m_hCapDev[2] != 0) { EXPORTS.QCAP_STOP(m_hCapDev[2]); EXPORTS.QCAP_DESTROY(m_hCapDev[2]); }

            if (m_hCapDev[3] != 0) { EXPORTS.QCAP_STOP(m_hCapDev[3]); EXPORTS.QCAP_DESTROY(m_hCapDev[3]); }

            return true;
        }     

        private void timerCheckSignal_Tick(object sender, EventArgs e)
        {            
            // DISPLAY FORMAT CHANGED MESSAGE
            //
            if (m_bNoSignal[0]) { m_cSetupControl.m_strFormatChangedOutput1 = " INFO :  . . ."; } else { m_cSetupControl.m_strFormatChangedOutput1 = m_strFormatChangedOutput[0]; }

            if (m_bNoSignal[1]) { m_cSetupControl.m_strFormatChangedOutput2 = " INFO :  . . ."; } else { m_cSetupControl.m_strFormatChangedOutput2 = m_strFormatChangedOutput[1]; }

            if (m_bNoSignal[2]) { m_cSetupControl.m_strFormatChangedOutput3 = " INFO :  . . ."; } else { m_cSetupControl.m_strFormatChangedOutput3 = m_strFormatChangedOutput[2]; }

            if (m_bNoSignal[3]) { m_cSetupControl.m_strFormatChangedOutput4 = " INFO :  . . ."; } else { m_cSetupControl.m_strFormatChangedOutput4 = m_strFormatChangedOutput[3]; }

            m_cSetupControl.m_bNoSignal1 = m_bNoSignal[0];

            m_cSetupControl.m_bNoSignal2 = m_bNoSignal[1];

            m_cSetupControl.m_bNoSignal3 = m_bNoSignal[2];

            m_cSetupControl.m_bNoSignal4 = m_bNoSignal[3];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (i = 0; i < 4; i++)
            {

                if (m_bNoSignal[i] == false)
                {
                    lock (b_bitmapchose[i]) { b_bitmap[i] = true; }
                }

            }

            //if (m_bNoSignal[0] == false)
            //{
            //    lock (b_bitmapchose[0]) { b_bitmap[0] = true; }
            //}
            //if (m_bNoSignal[1] == false)
            //{
            //    lock (b_bitmapchose[1]) { b_bitmap[1] = true; }
            //}

        }
   

    private void Form1_Click(object sender, EventArgs e)
        {
            //OnLButtonDown_ChannelControl(0);
        }
    }
}
