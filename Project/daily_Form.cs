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
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x2;

        private System.Threading.Timer timer;
        private bool is_using = false;

        public daily_Form()
        {
            InitializeComponent();
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
                if (result_Machine_Sale.StatusCode == 200)
                {
                    Sale_Sum feedback = JsonConvert.DeserializeObject<Sale_Sum>(result_Machine_Sale.Result);
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
            });
            task_Get_Total_Ticket_Sum=Task.Run(() =>
            {
                Response result_Total_Ticket_Sum = Info.Get_Total_Ticket_Sum();
                if (result_Total_Ticket_Sum.StatusCode == 200)
                {
                    Sale_Sum feedback = JsonConvert.DeserializeObject<Sale_Sum>(result_Total_Ticket_Sum.Result);
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
            if (e.Button == MouseButtons.Left)
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

        private void daily_Form_Load(object sender, EventArgs e)
        {
            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width/20*19-this.Width;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height / 20;
            this.SetDesktopLocation(x, y);
        }

        private void 立即刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Load_Current(sender);
            });
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
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
