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
            this.立即刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.label_Percent.Location = new System.Drawing.Point(0, 90);
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
            this.立即刷新ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 立即刷新ToolStripMenuItem
            // 
            this.立即刷新ToolStripMenuItem.Name = "立即刷新ToolStripMenuItem";
            this.立即刷新ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.立即刷新ToolStripMenuItem.Text = "立即刷新";
            this.立即刷新ToolStripMenuItem.Click += new System.EventHandler(this.立即刷新ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(0, 60);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(212, 60);
            this.panel5.TabIndex = 8;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // daily_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 120);
            this.ControlBox = false;
            this.Controls.Add(this.label_Percent);
            this.Controls.Add(this.label_Text_Percent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "daily_Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "daily_Form";
            this.Load += new System.EventHandler(this.daily_Form_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem 立即刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
    }
}