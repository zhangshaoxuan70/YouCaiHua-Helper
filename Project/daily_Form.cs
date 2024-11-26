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
        public int input_Total_Num = 0;
        public int input_Total_Played = 0;
        public bool is_calculator = false;

        public daily_Form(Login_Info login_Info)
        {
            m_aeroEnabled = false;
            InitializeComponent();
            this.KeyPreview = true;
            int x = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Width / 20 * 19 - this.Width;
            int y = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size.Height / 20;
            this.SetDesktopLocation(x, y);
            CheckForIllegalCrossThreadCalls = false;

            if(!Global.is_formtest)
            {
                if (login_Info.ResponseStatus.ErrorCode != "0")
                    this.Close();
                else
                    Account_ToolStripMenuItem.Text = $"{login_Info.Data.RealName}({login_Info.Data.LoginName})";
                /*RECT fx = new RECT();
                IntPtr h = GetForegroundWindow();
                GetWindowRect(h, ref fx);
                int width = fx.Right - fx.Left;
                int height = fx.Bottom - fx.Top;
                Log.Info($"{width},{height}");*/
                timer = new System.Threading.Timer(Load_Current, null, 0, 300000);
            }
            
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
                else
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
                else
                {
                    is_error = true;
                    error_response.ErrorCode = feedback.ResponseStatus.ErrorCode;
                    error_response.Message = feedback.ResponseStatus.Message;
                }
            });
            Task.WaitAll(task_Get_Machine_Sale_Sum,task_Get_Total_Ticket_Sum);
            Log.Debug(is_error.ToString());
            is_using = false;
            if(is_error)
            {
                MessageBox.Show($"服务器错误，程序即将退出\n{error_response.Message}", $"{error_response.ErrorCode}错误！",MessageBoxButtons.OK,MessageBoxIcon.Error);
                timer.Dispose();
                this.Close();
            }
            if(Check_Played && Check_Ticket_Played)
            {
                Global.current_Num = TotalCount_Played;
                Global.current_Played = TotalCount_Ticket_Played;

                if (TotalCount_Played == 0)
                {
                    label_Percent.ForeColor = Color.Black;
                    label_Percent.Text = "0.00%";
                    return;
                }
                Global.current_Percent= (decimal)TotalCount_Ticket_Played / (decimal)TotalCount_Played;
                label_Num.Text = TotalCount_Played.ToString();
                label_Played.Text = TotalCount_Ticket_Played.ToString();
                decimal percent=(decimal)TotalCount_Ticket_Played / (decimal)TotalCount_Played;
                Log.Info(percent.ToString());
                calculator_percent();
                if (percent < 0.6m)
                    label_Percent.ForeColor = Color.Red;
                else
                    label_Percent.ForeColor = Color.Green;
                if (percent == 0m)
                    label_Percent.ForeColor = Color.Black;
                label_Percent.Text = percent.ToString("P");
            }
        }

        private void daily_Form_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Focus();
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
            try
            {
                timer.Dispose();
            }
            catch { }
            Close();
        }

        private void daily_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.timer.Dispose();
            }
            catch { }
        }

        private void daily_Form_Load(object sender, EventArgs e)
        {
            this.Text = "油菜花助手浮窗";
            Size = new Size(100, 100);
            this.TopMost = true;
            panel_Top.Height = panel_calculator_top.Height = panel_fully_top.Height / 2;
            panel_Bottom.Height = panel_fully_bottom.Height / 2;
            panel_input_Num.Width = panel_input_Played.Width = panel_input.Width / 2-2;
            label_Num.Width = label_Played.Width = panel_Num.Width / 2;
            label_Played.Width = label_Played.Width = panel_Num.Width / 2;
            
            panel_calculator_top.Visible=panel_calculator_percent.Visible = false;
            panel_fully_top.Height= panel_fully_bottom.Height = 45;
        }

        private void Num_Only_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread((ThreadStart)(() =>
            {
                Clipboard.SetText($"{Global.current_Num}\n{Global.current_Played}");
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        private void All_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread t = new Thread((ThreadStart)(() =>
            {
                Clipboard.SetText($"{Global.current_Num}\n{Global.current_Played}\n{Global.current_Percent.ToString("P")}");
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        private void Top_Most_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }

        private void Refresh_ToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)e.ClickedItem;
            if (!clickedItem.Checked)
            {
                foreach (ToolStripMenuItem toolStripItem in Refresh_ToolStripMenuItem.DropDownItems)
                {
                    toolStripItem.Checked = false;
                }
                clickedItem.Checked = true;
                switch (clickedItem.Name)
                {
                    case "Time5_ToolStripMenuItem":
                        timer.Change(0, 300000);
                        Log.Info("Change to 5 minutes.");
                        break;
                    case "Time10_ToolStripMenuItem":
                        timer.Change(0, 600000);
                        Log.Info("Change to 10 minutes.");
                        break;
                    case "Pause_ToolStripMenuItem":
                        timer.Change(Timeout.Infinite,Timeout.Infinite);
                        Log.Info("Change to pause.");
                        break;
                }
            }
        }

        private void Calculator_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Form Opened_Calculator = Application.OpenForms["Calculator_Form"];
            foreach(Form form in Application.OpenForms)
            {
                Log.Debug(form.Name);
            }    
            if(Opened_Calculator==null || Opened_Calculator.IsDisposed)
            {
                Log.Info("Opened Calculator.");
                new Calculator_Form().Show();
            }
            else
            {
                Log.Info("Activated Calculator.");
                Opened_Calculator.Activate();
                Opened_Calculator.WindowState = FormWindowState.Normal;
            }*/
            textBox_Num.Visible = !textBox_Num.Visible;
            textBox_Played.Visible = !textBox_Played.Visible;
            if(!is_calculator)
            {
                is_calculator = !is_calculator;
                Size = new Size(100, 200);
                panel_calculator_top.Visible= panel_calculator_percent.Visible = true;
                panel_calculator_top.Height += 5;
                panel_calculator_percent.Height += 5;
                panel_fully_top.Height=panel_fully_bottom.Height = 100;
                calculator_percent();
                this.Refresh();
                this.Refresh();
            }
            else
            {
                is_calculator = !is_calculator;
                Size = new Size(100, 100);
                panel_calculator_top.Visible = panel_calculator_percent.Visible = false;
                panel_calculator_top.Height -= 5;
                panel_calculator_percent.Height -= 5;
                panel_fully_top.Height = panel_fully_bottom.Height = 45;
                this.Refresh();
                this.Refresh();
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 1)
                e.Handled = true;
            if ((int)e.KeyChar == 13)
            {
                TextBox textBox = (TextBox)sender;

                switch (textBox.Name)
                {
                    case "textBox_Num":
                        textBox1.Focus();
                        break;
                    case "textBox_Played":
                        textBox1.Focus();
                        break;
                }
            }
        }


        private void calculator_percent()
        {
            int num_new = Global.current_Num + input_Total_Num;
            int played_new = Global.current_Played + input_Total_Played;
            label_count_Num.Text = num_new.ToString();
            label_count_Played.Text = played_new.ToString();
            if(num_new==0)
            {
                label_percent_difference.ForeColor = Color.Black;
                label_percent_difference.Text = "0.00%";
                return;
            }
            decimal percent_new = (decimal)played_new / (decimal)num_new;
            if (percent_new < 0.6m)
                label_percent_new.ForeColor = Color.Red;
            else
                label_percent_new.ForeColor = Color.Green;
            if (percent_new == 0m)
                label_percent_new.ForeColor = Color.Black;
            label_percent_new.Text = percent_new.ToString("P");
            decimal percent_difference = percent_new - Global.current_Percent;
            decimal percent_round = decimal.Round(percent_difference,4);
            if (percent_round > 0m)
            {
                label_percent_difference.ForeColor = Color.Green;
                label_percent_difference.Text = "+" + percent_difference.ToString("P");
            }
            else if (percent_round < 0m)
            {
                label_percent_difference.ForeColor = Color.Red;
                label_percent_difference.Text = percent_difference.ToString("P");
            }
            else
            {
                label_percent_difference.ForeColor = Color.Black;
                label_percent_difference.Text = percent_difference.ToString("P");
            }
            Application.DoEvents();
        }


        private void textBox_Played_Leave(object sender, EventArgs e)
        {
            string played = textBox_Played.Text;
            Log.Debug(played);
            if(played=="")
            {
                textBox_Played.Text = "+0";
                input_Total_Played = 0;
                calculator_percent();
                return;
            }
            if (played.StartsWith("+"))
                played=played.Substring(1);
            try
            {
                int played_num = int.Parse(played);
                if(played_num<0)
                {
                    MessageBox.Show("不能小于0！", "错误！");
                    input_Total_Played = 0;
                    textBox_Played.Text = "+0";
                    calculator_percent();
                }
                else
                {
                    input_Total_Played = played_num;
                    textBox_Played.Text = "+" + played_num.ToString();
                    calculator_percent();
                }
            }
            catch
            {
                MessageBox.Show("非法的数据", "错误！");
                textBox_Played.Text = "+0";
                input_Total_Played = 0;
                calculator_percent();
            }
        }

        private void textBox_Num_Leave(object sender, EventArgs e)
        {
            string num = textBox_Num.Text;
            Log.Debug(num);
            if (num == "")
            {
                textBox_Num.Text = "+0";
                input_Total_Num = 0;
                calculator_percent();
                return;
            }
            if (num.StartsWith("+"))
                num = num.Substring(1);
            try
            {
                int num_num = int.Parse(num);
                if (num_num < 0)
                {
                    MessageBox.Show("不能小于0！", "错误！");
                    textBox_Num.Text = "+0";
                    input_Total_Num = 0;
                    calculator_percent();
                }
                else
                {
                    input_Total_Num = num_num;
                    textBox_Num.Text = "+" + num_num.ToString();
                    calculator_percent();
                }
            }
            catch
            {
                MessageBox.Show("非法的数据", "错误！");
                textBox_Num.Text = "+0";
                input_Total_Num = 0;
                calculator_percent();
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {

            if((int)e.KeyCode==38)//↑
            {
                e.Handled = true;
                TextBox textBox = (TextBox)sender;

                switch (textBox.Name)
                {
                    case "textBox_Num":

                        if (input_Total_Num >= 0)
                        {
                            input_Total_Num++;
                            textBox_Num.Text = "+" + input_Total_Num.ToString();
                            calculator_percent();
                        }
                        break;
                    case "textBox_Played":
                        if (input_Total_Played >= 0)
                        {
                            input_Total_Played++;
                            textBox_Played.Text = "+" + input_Total_Played.ToString();
                            calculator_percent();
                        }
                        break;
                }
            }
            else if((int)e.KeyCode==40)//↓
            {
                e.Handled = true;
                TextBox textBox = (TextBox)sender;

                switch (textBox.Name)
                {
                    case "textBox_Num":
                        if(input_Total_Num>0)
                        {
                            input_Total_Num--;
                            textBox_Num.Text = "+" + input_Total_Num.ToString();
                            calculator_percent();
                        }
                        break;
                    case "textBox_Played":
                        if (input_Total_Played > 0)
                        {
                            input_Total_Played--;
                            textBox_Played.Text = "+" + input_Total_Played.ToString();
                            calculator_percent();
                        }
                        break;
                }
            }
        }

        private void textBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta>0)
            {
                TextBox textBox = (TextBox)sender;

                switch (textBox.Name)
                {
                    case "textBox_Num":
                        if (input_Total_Num >= 0)
                        {
                            input_Total_Num++;
                            textBox_Num.Text = "+" + input_Total_Num.ToString();
                            calculator_percent();
                        }
                        break;
                    case "textBox_Played":
                        if (input_Total_Played >= 0)
                        {
                            input_Total_Played++;
                            textBox_Played.Text = "+" + input_Total_Played.ToString();
                            calculator_percent();
                        }
                        break;
                }
            }
            else if(e.Delta<0)
            {
                TextBox textBox = (TextBox)sender;

                switch (textBox.Name)
                {
                    case "textBox_Num":
                        if (input_Total_Num > 0)
                        {
                            input_Total_Num--;
                            textBox_Num.Text = "+" + input_Total_Num.ToString();
                            calculator_percent();
                        }
                        break;
                    case "textBox_Played":
                        if (input_Total_Played > 0)
                        {
                            input_Total_Played--;
                            textBox_Played.Text = "+" + input_Total_Played.ToString();
                            calculator_percent();
                        }
                        break;
                }
            }
        }

        private void textBox_Played_Enter(object sender, EventArgs e)
        {
            textBox_Played.Text = textBox_Played.Text.Replace("+", "");
        }

        private void textBox_Num_Enter(object sender, EventArgs e)
        {
            textBox_Num.Text = textBox_Num.Text.Replace("+", "");
        }

    }
}
