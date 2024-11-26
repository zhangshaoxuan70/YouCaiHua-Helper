namespace youcaihua
{
    partial class PreLoad
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
            this.components = new System.ComponentModel.Container();
            this.btn_Close = new System.Windows.Forms.Button();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.HintPictureBox = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CheckButton = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.btnToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HintPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.BackColor = System.Drawing.Color.White;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe MDL2 Assets", 10F);
            this.btn_Close.Location = new System.Drawing.Point(342, 1);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Close.Size = new System.Drawing.Size(41, 30);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLabel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(7, 10, 0, 0);
            this.TitleLabel.Size = new System.Drawing.Size(384, 30);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "设定（建议将该软件放到文件夹中以免配置丢失）";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            this.TitleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseUp);
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.Transparent;
            this.InfoLabel.Location = new System.Drawing.Point(1, 33);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(383, 28);
            this.InfoLabel.TabIndex = 3;
            this.InfoLabel.Text = "请输入您店铺的代码\r\n当您登录网页后台时，您网址的前面以y为前缀的为店铺代码";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.InfoLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PreLoad_MouseDown);
            // 
            // HintPictureBox
            // 
            this.HintPictureBox.Image = global::youcaihua.Properties.Resources.hint;
            this.HintPictureBox.Location = new System.Drawing.Point(1, 61);
            this.HintPictureBox.Name = "HintPictureBox";
            this.HintPictureBox.Size = new System.Drawing.Size(383, 27);
            this.HintPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.HintPictureBox.TabIndex = 4;
            this.HintPictureBox.TabStop = false;
            this.HintPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PreLoad_MouseDown);
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textBox1.Location = new System.Drawing.Point(119, 91);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(150, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(154, 135);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(75, 23);
            this.CheckButton.TabIndex = 6;
            this.CheckButton.Text = "检查";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(1, 115);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(383, 17);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NameLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PreLoad_MouseDown);
            // 
            // PreLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.CheckButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.HintPictureBox);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "PreLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PreLoad";
            this.Load += new System.EventHandler(this.PreLoad_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PreLoad_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PreLoad_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.HintPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.PictureBox HintPictureBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.ToolTip btnToolTip;
    }
}