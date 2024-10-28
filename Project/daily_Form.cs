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

        private System.Threading.Timer timer;
        private bool is_using = false;

        public daily_Form()
        {
            m_aeroEnabled = false;
            InitializeComponent();
            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width / 20 * 19 - this.Width;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height / 20;
            this.SetDesktopLocation(x, y);
            CheckForIllegalCrossThreadCalls = false;
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
                        MessageBox.Show(feedback.ResponseStatus.Message, $"{feedback.ResponseStatus.ErrorCode}错误！");
                        timer.Dispose();
                        Close();
                    }
                }
                else if(result_Machine_Sale.StatusCode==405)
                {
                    MessageBox.Show(feedback.ResponseStatus.Message, $"{feedback.ResponseStatus.ErrorCode}错误！");
                    timer.Dispose();
                    Close();
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
                        MessageBox.Show(feedback.ResponseStatus.Message, $"{feedback.ResponseStatus.ErrorCode}错误！");
                        timer.Dispose();
                        Close();
                    }
                }
                else if(result_Total_Ticket_Sum.StatusCode==405)
                {
                    MessageBox.Show(feedback.ResponseStatus.Message, $"{feedback.ResponseStatus.ErrorCode}错误！");
                    timer.Dispose();
                    Close();
                }
            });
            Task.WaitAll(task_Get_Machine_Sale_Sum,task_Get_Total_Ticket_Sum);
            is_using = false;
            if(Check_Played && Check_Ticket_Played)
            {
                label_Num.Text = TotalCount_Played.ToString();
                label_Played.Text = TotalCount_Ticket_Played.ToString();
                label_Percent.Text = ((decimal)TotalCount_Ticket_Played / (decimal)TotalCount_Played).ToString("P");
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
    }
}
