using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace youcaihua
{
    public partial class login_Form : Form
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

        private Response result;
        private bool is_checked = false;

        public login_Form()
        {
            m_aeroEnabled = false;
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            btn_login.Enabled = false;
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.Padding = new Padding(border_size);
            if (Global.mall_code_set == false)
                Log.Warn("Couldn't get mall code, use default.");
            Task.Run(() =>
            {
                SysInfo result_des = new SysInfo();
                result = Info.Check_mall(Global.mall_code);
                switch (result.StatusCode)
                {
                    case 200:
                        result_des = JsonConvert.DeserializeObject<SysInfo>(result.Result);
                        if(result_des.ResponseStatus.ErrorCode=="0")
                        {
                            this.label_Mall_Info.Text = $"登录门店：\n{result_des.MallName}({result_des.MallCode})";
                            btn_login.Enabled = true;
                            is_checked = true;
                            break;
                        }
                        else
                        {
                            this.label_Mall_Info.Text = $"服务器返回错误：\n{result_des.ResponseStatus.Message}({result_des.ResponseStatus.ErrorCode})";
                            break;
                        }
                    case 404:
                        this.label_Mall_Info.Text = $"{result_des.MallCode}此店铺代码有错误\n请检查店铺代码。";
                        break;
                    case 502:
                        this.label_Mall_Info.Text = "连接超时，请重启软件。";
                        break;
                }
            });

        }

        private void login_Form_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                Log.Debug("login form mouse down.");
                ReleaseCapture();
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }

        private void btn_Close_MouseEnter(object sender, EventArgs e)
        {
            btn_Close.ForeColor = Color.White;
        }

        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            btn_Close.ForeColor = SystemColors.ControlText;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Log.Warn("Login Form clicked close.");
            Application.Exit();
        }

        private void btn_Mini_Click(object sender, EventArgs e)
        {
            Log.Warn("Login Form clicked minimize.");
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            int missing = 0;
            bool pass = true;
            label_Error.Text = "";
            btn_login.Enabled = false;
            textBox_Account.Enabled = false;
            textBox_Password.Enabled = false;
            string account = textBox_Account.Text;
            string password = textBox_Password.Text;
            if (account == "" && password == "")
            {
                label_Error.Text = "请输入账户和密码！";
                missing = 1;
                pass = false;
            }
            else if (account == "")
            {
                label_Error.Text = "请输入账户！";
                missing = 1;
                pass = false;
            }
            else if (password == "")
            {
                label_Error.Text = "请输入密码！";
                
                missing = 2;
                pass = false;
            }
            if(pass==false)
            {
                btn_login.Enabled = true;
                textBox_Account.Enabled = true;
                textBox_Password.Enabled = true;
                if(missing==1)
                    textBox_Account.Focus();
                else if(missing==2)
                    textBox_Password.Focus();
                return;
            }

            result=Info.Get_Account(account, password);
            if(result.StatusCode==200)
            {
                Only_Status result_des = JsonConvert.DeserializeObject<Only_Status>(result.Result);
                if(result_des.ResponseStatus.ErrorCode=="0")
                {
                    Global.is_login = true;

                    Response responese=Info.Get_Login_Info();
                    if(responese.StatusCode==200)
                    {
                        Login_Info login_Info= JsonConvert.DeserializeObject<Login_Info>(responese.Result);
                        if(login_Info.ResponseStatus.ErrorCode=="0")
                        {
                            label_Error.ForeColor = Color.Green;
                            label_Error.Text = $"登录成功！\n{login_Info.Data.RealName}\n5秒钟后该窗口将自动退出。";
                            Thread close_t = new Thread(delegate()
                            {
                                Thread.Sleep(1000);
                                label_Error.Text = $"登录成功！\n{login_Info.Data.RealName}\n4秒钟后该窗口将自动退出。";
                                Thread.Sleep(1000);
                                label_Error.Text = $"登录成功！\n{login_Info.Data.RealName}\n3秒钟后该窗口将自动退出。";
                                Thread.Sleep(1000);
                                label_Error.Text = $"登录成功！\n{login_Info.Data.RealName}\n2秒钟后该窗口将自动退出。";
                                Thread.Sleep(1000);
                                label_Error.Text = $"登录成功！\n{login_Info.Data.RealName}\n1秒钟后该窗口将自动退出。";
                                Thread.Sleep(1000);
                                Close();
                            });
                            close_t.Start();
                            Thread t = new Thread(delegate ()
                            {
                                new daily_Form().ShowDialog();
                            });
                            t.Start();

                        }
                    }
                    
                }
                else
                    label_Error.Text = $"登录失败：\n{result_des.ResponseStatus.Message}({result_des.ResponseStatus.ErrorCode})";
            }
            else
                label_Error.Text = "登录失败！\n请尝试重新登录！";
            if(!Global.is_login)
            {
                btn_login.Enabled = true;
                textBox_Account.Enabled = true;
                textBox_Password.Enabled = true;
                textBox_Account.Focus();
            }
        }

        private void textBox_Account_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                textBox_Password.Focus();
        }

        private void textBox_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && is_checked==true)
                btn_login_Click(sender,e);
        }
    }
}
