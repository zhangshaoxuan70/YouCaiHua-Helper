namespace youcaihua
{
    partial class login_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Mini = new System.Windows.Forms.Button();
            this.label_Account = new System.Windows.Forms.Label();
            this.label_Mall_Info = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Account = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_login = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label_Error = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.SystemColors.Window;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("宋体", 10F);
            this.btn_Close.Location = new System.Drawing.Point(319, 0);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Close.Size = new System.Drawing.Size(41, 30);
            this.btn_Close.TabIndex = 0;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "×";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            this.btn_Close.MouseEnter += new System.EventHandler(this.btn_Close_MouseEnter);
            this.btn_Close.MouseLeave += new System.EventHandler(this.btn_Close_MouseLeave);
            // 
            // btn_Mini
            // 
            this.btn_Mini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Mini.BackColor = System.Drawing.SystemColors.Window;
            this.btn_Mini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Mini.FlatAppearance.BorderSize = 0;
            this.btn_Mini.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btn_Mini.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btn_Mini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Mini.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_Mini.Location = new System.Drawing.Point(278, 0);
            this.btn_Mini.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Mini.Name = "btn_Mini";
            this.btn_Mini.Size = new System.Drawing.Size(41, 30);
            this.btn_Mini.TabIndex = 0;
            this.btn_Mini.TabStop = false;
            this.btn_Mini.Text = "-";
            this.btn_Mini.UseMnemonic = false;
            this.btn_Mini.UseVisualStyleBackColor = false;
            this.btn_Mini.Click += new System.EventHandler(this.btn_Mini_Click);
            // 
            // label_Account
            // 
            this.label_Account.AutoSize = true;
            this.label_Account.BackColor = System.Drawing.Color.Transparent;
            this.label_Account.Font = new System.Drawing.Font("宋体", 18F);
            this.label_Account.Location = new System.Drawing.Point(3, 3);
            this.label_Account.Name = "label_Account";
            this.label_Account.Size = new System.Drawing.Size(82, 24);
            this.label_Account.TabIndex = 0;
            this.label_Account.Text = "账号：";
            this.label_Account.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_Form_MouseDown);
            // 
            // label_Mall_Info
            // 
            this.label_Mall_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Mall_Info.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Mall_Info.Location = new System.Drawing.Point(30, 55);
            this.label_Mall_Info.Name = "label_Mall_Info";
            this.label_Mall_Info.Size = new System.Drawing.Size(300, 74);
            this.label_Mall_Info.TabIndex = 0;
            this.label_Mall_Info.Text = "请稍等...";
            this.label_Mall_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Mall_Info.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_Form_MouseDown);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_Password.ForeColor = System.Drawing.Color.Black;
            this.textBox_Password.Location = new System.Drawing.Point(71, 0);
            this.textBox_Password.MaxLength = 255;
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '▪';
            this.textBox_Password.Size = new System.Drawing.Size(229, 30);
            this.textBox_Password.TabIndex = 1;
            this.textBox_Password.WordWrap = false;
            this.textBox_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Password_KeyPress);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.BackColor = System.Drawing.Color.Transparent;
            this.label_Password.Font = new System.Drawing.Font("宋体", 18F);
            this.label_Password.Location = new System.Drawing.Point(3, 3);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(82, 24);
            this.label_Password.TabIndex = 0;
            this.label_Password.Text = "密码：";
            this.label_Password.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_Form_MouseDown);
            // 
            // textBox_Account
            // 
            this.textBox_Account.Font = new System.Drawing.Font("宋体", 15F);
            this.textBox_Account.ForeColor = System.Drawing.Color.Black;
            this.textBox_Account.Location = new System.Drawing.Point(71, 0);
            this.textBox_Account.MaxLength = 255;
            this.textBox_Account.Name = "textBox_Account";
            this.textBox_Account.Size = new System.Drawing.Size(229, 30);
            this.textBox_Account.TabIndex = 0;
            this.textBox_Account.WordWrap = false;
            this.textBox_Account.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Account_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_Account);
            this.panel1.Controls.Add(this.label_Account);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 30);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_Form_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_Password);
            this.panel2.Controls.Add(this.label_Password);
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 30);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_Form_MouseDown);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(30, 186);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 66);
            this.panel3.TabIndex = 0;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_Form_MouseDown);
            // 
            // btn_login
            // 
            this.btn_login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_login.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_login.Location = new System.Drawing.Point(40, 0);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(120, 45);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.btn_login);
            this.panel4.Controls.Add(this.label_Error);
            this.panel4.Location = new System.Drawing.Point(80, 350);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 2;
            // 
            // label_Error
            // 
            this.label_Error.ForeColor = System.Drawing.Color.Red;
            this.label_Error.Location = new System.Drawing.Point(0, 48);
            this.label_Error.Name = "label_Error";
            this.label_Error.Size = new System.Drawing.Size(200, 43);
            this.label_Error.TabIndex = 0;
            this.label_Error.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(360, 450);
            this.Controls.Add(this.btn_Mini);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.label_Mall_Info);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_Form_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Mini;
        private System.Windows.Forms.Label label_Account;
        private System.Windows.Forms.Label label_Mall_Info;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Account;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label_Error;
    }
}