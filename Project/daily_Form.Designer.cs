namespace youcaihua
{
    partial class daily_Form
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
            this.label_Text_Num = new System.Windows.Forms.Label();
            this.label_Text_Played = new System.Windows.Forms.Label();
            this.label_Num = new System.Windows.Forms.Label();
            this.label_Played = new System.Windows.Forms.Label();
            this.label_Text_Percent = new System.Windows.Forms.Label();
            this.label_Percent = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Refresh_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Time1_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Time2_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Pause_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Instant_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Text_Num
            // 
            this.label_Text_Num.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Text_Num.Location = new System.Drawing.Point(0, 0);
            this.label_Text_Num.Margin = new System.Windows.Forms.Padding(0);
            this.label_Text_Num.Name = "label_Text_Num";
            this.label_Text_Num.Size = new System.Drawing.Size(106, 30);
            this.label_Text_Num.TabIndex = 0;
            this.label_Text_Num.Text = "游玩总人数";
            this.label_Text_Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Text_Num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Text_Played
            // 
            this.label_Text_Played.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Text_Played.Location = new System.Drawing.Point(0, 0);
            this.label_Text_Played.Margin = new System.Windows.Forms.Padding(0);
            this.label_Text_Played.Name = "label_Text_Played";
            this.label_Text_Played.Size = new System.Drawing.Size(106, 30);
            this.label_Text_Played.TabIndex = 1;
            this.label_Text_Played.Text = "红彩票游玩人数";
            this.label_Text_Played.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Text_Played.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Num
            // 
            this.label_Num.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Num.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Num.Location = new System.Drawing.Point(0, 0);
            this.label_Num.Margin = new System.Windows.Forms.Padding(0);
            this.label_Num.Name = "label_Num";
            this.label_Num.Size = new System.Drawing.Size(106, 30);
            this.label_Num.TabIndex = 2;
            this.label_Num.Text = "0";
            this.label_Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Played
            // 
            this.label_Played.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Played.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Played.Location = new System.Drawing.Point(106, 0);
            this.label_Played.Margin = new System.Windows.Forms.Padding(0);
            this.label_Played.Name = "label_Played";
            this.label_Played.Size = new System.Drawing.Size(106, 30);
            this.label_Played.TabIndex = 3;
            this.label_Played.Text = "0";
            this.label_Played.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Played.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Text_Percent
            // 
            this.label_Text_Percent.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Text_Percent.Location = new System.Drawing.Point(0, 60);
            this.label_Text_Percent.Margin = new System.Windows.Forms.Padding(0);
            this.label_Text_Percent.Name = "label_Text_Percent";
            this.label_Text_Percent.Size = new System.Drawing.Size(212, 30);
            this.label_Text_Percent.TabIndex = 4;
            this.label_Text_Percent.Text = "红彩票机游玩占比";
            this.label_Text_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Text_Percent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Percent
            // 
            this.label_Percent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Percent.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Percent.Location = new System.Drawing.Point(0, 30);
            this.label_Percent.Margin = new System.Windows.Forms.Padding(0);
            this.label_Percent.Name = "label_Percent";
            this.label_Percent.Size = new System.Drawing.Size(212, 30);
            this.label_Percent.TabIndex = 5;
            this.label_Percent.Text = "0.00%";
            this.label_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Percent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 60);
            this.panel1.TabIndex = 6;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label_Played);
            this.panel4.Controls.Add(this.label_Num);
            this.panel4.Location = new System.Drawing.Point(0, 30);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 30);
            this.panel4.TabIndex = 6;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_Text_Num);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(106, 30);
            this.panel2.TabIndex = 4;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label_Text_Played);
            this.panel3.Location = new System.Drawing.Point(106, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(106, 30);
            this.panel3.TabIndex = 5;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Refresh_ToolStripMenuItem,
            this.Instant_ToolStripMenuItem,
            this.Exit_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            this.contextMenuStrip1.TabStop = true;
            // 
            // Refresh_ToolStripMenuItem
            // 
            this.Refresh_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Time1_ToolStripMenuItem,
            this.Time2_ToolStripMenuItem,
            this.Pause_ToolStripMenuItem});
            this.Refresh_ToolStripMenuItem.Name = "Refresh_ToolStripMenuItem";
            this.Refresh_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.Refresh_ToolStripMenuItem.Text = "刷新时间";
            this.Refresh_ToolStripMenuItem.Visible = false;
            // 
            // Time1_ToolStripMenuItem
            // 
            this.Time1_ToolStripMenuItem.Checked = true;
            this.Time1_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Time1_ToolStripMenuItem.Name = "Time1_ToolStripMenuItem";
            this.Time1_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.Time1_ToolStripMenuItem.Text = "5分钟";
            // 
            // Time2_ToolStripMenuItem
            // 
            this.Time2_ToolStripMenuItem.Name = "Time2_ToolStripMenuItem";
            this.Time2_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.Time2_ToolStripMenuItem.Text = "10分钟";
            // 
            // Pause_ToolStripMenuItem
            // 
            this.Pause_ToolStripMenuItem.Name = "Pause_ToolStripMenuItem";
            this.Pause_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.Pause_ToolStripMenuItem.Text = "暂停";
            // 
            // Instant_ToolStripMenuItem
            // 
            this.Instant_ToolStripMenuItem.Name = "Instant_ToolStripMenuItem";
            this.Instant_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.Instant_ToolStripMenuItem.Text = "立即刷新";
            this.Instant_ToolStripMenuItem.Click += new System.EventHandler(this.Instant_ToolStripMenuItem_Click);
            // 
            // Exit_ToolStripMenuItem
            // 
            this.Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            this.Exit_ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.Exit_ToolStripMenuItem.Text = "退出";
            this.Exit_ToolStripMenuItem.Click += new System.EventHandler(this.Exit_ToolStripMenuItem_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label_Percent);
            this.panel5.Location = new System.Drawing.Point(0, 60);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(212, 60);
            this.panel5.TabIndex = 8;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // daily_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(212, 120);
            this.Controls.Add(this.label_Text_Percent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "daily_Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "daily_Form";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.daily_Form_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Text_Num;
        private System.Windows.Forms.Label label_Text_Played;
        private System.Windows.Forms.Label label_Num;
        private System.Windows.Forms.Label label_Played;
        private System.Windows.Forms.Label label_Text_Percent;
        private System.Windows.Forms.Label label_Percent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem Instant_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_ToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ToolStripMenuItem Refresh_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Time1_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Time2_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Pause_ToolStripMenuItem;
    }
}