using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlTypes;

namespace youcaihua
{
    public partial class daily_Form : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect, // x-coordinate of upper-left corner
        int nTopRect, // y-coordinate of upper-left corner
        int nRightRect, // x-coordinate of lower-right corner
        int nBottomRect, // y-coordinate of lower-right corner
        int nWidthEllipse, // height of ellipse
        int nHeightEllipse // width of ellipse
        );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
                m.Result = (IntPtr)HTCAPTION;

        }



        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return:MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top; 
            public int Right;
            public int Bottom;
        }

        private System.Threading.Timer timer;
        private bool is_using = false;

        public daily_Form(Login_Info login_Info)
        {
            m_aeroEnabled = false;
            InitializeComponent();
            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width / 20 * 19 - this.Width;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height / 20;
            this.SetDesktopLocation(x, y);
            CheckForIllegalCrossThreadCalls = false;

            if (login_Info.ResponseStatus.ErrorCode!="0")
                this.Close();
            else
                Account_ToolStripMenuItem.Text = $"{login_Info.Data.RealName}({login_Info.Data.LoginName})";
            /*RECT fx = new RECT();
            IntPtr h = GetForegroundWindow();
            GetWindowRect(h, ref fx);
            int width = fx.Right - fx.Left;
            int height = fx.Bottom - fx.Top;
            Log.Info($"{width},{height}");*/
            timer = new System.Threading.Timer(Load_Current,null,0,300000);
        }

        private void Load_Current(object sender)
        {
            if(is_using==true)
            {
                Log.Warn("HttpWebRequest is using!");
                return;
            }
            Log.Info("Start a new request...");
            Task task_Get_Machine_Sale_Sum;
            Task task_Get_Total_Ticket_Sum;
            int TotalCount_Played = 0;
            int TotalCount_Ticket_Played = 0;
            bool Check_Played = false;
            bool Check_Ticket_Played = false;
            is_using = true;
            bool is_error = false;
            ResponseStatus error_response = new ResponseStatus();
            task_Get_Machine_Sale_Sum=Task.Run(() =>
            {
                Response result_Machine_Sale = Info.Get_Machine_Sale_Sum();

                Sale_Sum feedback = JsonConvert.DeserializeObject<Sale_Sum>(result_Machine_Sale.Result);
                if (result_Machine_Sale.StatusCode == 200)
                {
                    if (feedback.ResponseStatus.ErrorCode == "0")
                    {
                        TotalCount_Played = feedback.PageInfo.TotalCount;
                        Check_Played = true;
                    }
                    else
                    {
                        is_error = true;
                        error_response.ErrorCode = feedback.ResponseStatus.ErrorCode;
                        error_response.Message = feedback.ResponseStatus.Message;
                    }
                }
                else if(result_Machine_Sale.StatusCode==405)
                {
                    is_error = true;
                    error_response.ErrorCode = feedback.ResponseStatus.ErrorCode;
                    error_response.Message = feedback.ResponseStatus.Message;
                }
            });
            task_Get_Total_Ticket_Sum=Task.Run(() =>
            {
                Response result_Total_Ticket_Sum = Info.Get_Total_Ticket_Sum();

                Sale_Sum feedback = JsonConvert.DeserializeObject<Sale_Sum>(result_Total_Ticket_Sum.Result);
                if (result_Total_Ticket_Sum.StatusCode == 200)
                {
                    if (feedback.ResponseStatus.ErrorCode == "0")
                    {
                        TotalCount_Ticket_Played = feedback.PageInfo.TotalCount;
                        Check_Ticket_Played = true;
                    }
                    else
                    {
                        is_error = true;
                        error_response.ErrorCode = feedback.ResponseStatus.ErrorCode;
                        error_response.Message = feedback.ResponseStatus.Message;
                    }
                }
                else if(result_Total_Ticket_Sum.StatusCode==405)
                {
                    is_error = true;
                    error_response.ErrorCode = feedback.ResponseStatus.ErrorCode;
                    error_response.Message = feedback.ResponseStatus.Message;
                }
            });
            Task.WaitAll(task_Get_Machine_Sale_Sum,task_Get_Total_Ticket_Sum);
            is_using = false;
            if(is_error)
            {
                MessageBox.Show($"服务器错误，程序即将退出\n{error_response.Message}", $"{error_response.ErrorCode}错误！");
                timer.Dispose();
                this.Close();
            }
            if(Check_Played && Check_Ticket_Played)
            {
                label_Num.Text = TotalCount_Played.ToString();
                label_Played.Text = TotalCount_Ticket_Played.ToString();
                decimal percent=(decimal)TotalCount_Ticket_Played / (decimal)TotalCount_Played;
                Log.Info(percent.ToString());
                if(percent<0.6m)
                    label_Percent.ForeColor = Color.Red;
                else
                    label_Percent.ForeColor = Color.Green;
                label_Percent.Text = percent.ToString("P");
            }
        }

        private void daily_Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks==1)
            {
                Log.Debug("daily form mouse down.");
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
            else if(e.Button==MouseButtons.Right)
            {
                Log.Debug("Show right context menu.");
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void Instant_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                Load_Current(sender);
            });
        }

        private void Exit_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Info("Daily Form clicked close.");
            timer.Dispose();
            Close();
        }

        private void daily_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer.Dispose();
        }

        private void daily_Form_Load(object sender, EventArgs e)
        {

            Size = new Size(100, 100);
            panel_Top.Height= panel_Bottom.Height = (Height - (Padding.All * 2)) / 2;
            panel_Text.Height = panel_Num.Height = panel_Top.Height / 2;
            label_Text_Percent.Height = label_Percent.Height = panel_Bottom.Height / 2;
            label_Text_Num.Width = label_Text_Played.Width = panel_Text.Width / 2;
            label_Num.Width = label_Played.Width = panel_Num.Width / 2;
        }
    }
}
