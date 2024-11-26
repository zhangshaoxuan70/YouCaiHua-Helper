using BorderlessForm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youcaihua
{
    public partial class PreLoad : FormBase
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

        private const int WS_MINIMIZEBOX = 0x00020000;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_RESTORE = 0xF120;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;
                //cp.Style |= WS_MINIMIZEBOX;
                //cp.ExStyle |= 0x02000000;
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
                case WM_SYSCOMMAND:
                    int command = m.WParam.ToInt32();
                    if (command == SC_RESTORE)
                    {
                        this.FormBorderStyle = FormBorderStyle.Sizable;
                        this.ControlBox = true;
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
        public const int SC_MOVE = 0xF010;

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private bool Changing = false;

        public PreLoad(bool Is_Changing = false)
        {
            Changing = Is_Changing;
            m_aeroEnabled = false;
            InitializeComponent();
            //Log.Debug(SetWindowLong32(this.Handle, -16, 0x40000000 & 0x80000000 & 0x00800000 & 0x00040000));//GetWindowLong(this.Handle, -16) & 0x40000000));
            //this.WindowState= FormWindowState.Minimized;
            CheckButton.Enabled = false;
            btnToolTip.SetToolTip(btn_Close, "关闭");
            if (Is_Changing)
            {
                TitleLabel.Text = "设定";
                btn_Close.Text = "\uE72B";
                btn_Close.FlatAppearance.MouseDownBackColor = Color.Silver;
                btn_Close.FlatAppearance.MouseOverBackColor = Color.Gainsboro;
                btnToolTip.SetToolTip(btn_Close, "返回登录");
            }
            timer = new System.Threading.Timer(Check_Correct, null, -1, -1);
            this.Text = "油菜花助手-设定";
        }

        private void PreLoad_Load(object sender, EventArgs e)
        {
            this.Size = new Size(400, 170);
            this.TransparencyKey = Color.White;
        }

        private void PreLoad_Paint(object sender, PaintEventArgs e)
        {
            this.TransparencyKey = Color.Empty;

            this.DoubleBuffered = true;

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);


            this.Update();
        }

        private void PreLoad_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            if (Changing)
            {
                this.Close();
                Thread t = new Thread(delegate ()
                {
                    //Thread.Sleep(1000);
                    new login_Form().ShowDialog();
                });
                t.Start();
            }
            else
                Close();
        }

        private System.Threading.Timer timer;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            CheckButton.Enabled = false;
            timer.Change(500, -1);
            NameLabel.Text = "";

        }

        private string precode;
        private bool correct = false;
        private string content;

        private void Check_Correct(object sender)
        {
            Task.Run(() =>
            {

                string code = textBox1.Text;
                if (code == "")
                {
                    NameLabel.Text = "";
                    return;
                }
                if (code == precode)
                {
                    CheckButton.Enabled = correct;
                    NameLabel.Text = content;
                    return;
                }
                Response result = Info.Check_mall(code);
                if (result.StatusCode == 200)
                {
                    SysInfo result_des = JsonConvert.DeserializeObject<SysInfo>(result.Result);
                    if (result_des.ResponseStatus.ErrorCode == "0")
                    {
                        NameLabel.Text = result_des.MallName;
                        precode = code;
                        correct = true;
                        content = result_des.MallName;
                        CheckButton.Enabled = true;
                    }
                    else
                    {
                        precode = code;
                        correct = false;
                        content = "店铺信息异常，请检查店铺情况";
                        NameLabel.Text = "店铺信息异常，请检查店铺情况";
                    }
                }
                else
                {
                    precode = code;
                    correct = false;
                    content = "未获取到店铺信息！";
                    NameLabel.Text = "未获取到店铺信息！";
                }

            });
        }

        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && e.Clicks == 1 && e.X <= 30)
            {
                ShowSystemMenu(MouseButtons.Left);
                return;
            }
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }

        private void TitleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Y <= 30)
                ShowSystemMenu(MouseButtons.Right);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.ImeMode = ImeMode.Disable;
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 1)
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter && CheckButton.Enabled)
                CheckButton_Click(sender, e);
        }


        private void CheckButton_Click(object sender, EventArgs e)
        {
            Log.Debug("Clicked!");
            if (Config_Controller.Load_File() == new Config())
            {
                Config_Controller.Create_Config(new Config() { Code = textBox1.Text });
            }
            else
            {
                Config_Controller.Change_Config(Code: textBox1.Text);
            }
            Global.mall_code = textBox1.Text;
            Global.get_mall_code = true;
            this.Close();
            Thread t = new Thread(delegate ()
            {
                //Thread.Sleep(1000);
                new login_Form().ShowDialog();
            });
            t.Start();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.ImeMode = ImeMode.Disable;
        }



    }
}
