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
            this.label_Text_Percent = new System.Windows.Forms.Label();
            this.label_Percent = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Account_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator_Top = new System.Windows.Forms.ToolStripSeparator();
            this.Instant_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Calculator_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Top_Most_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Refresh_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Time5_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Time10_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Pause_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Num_Only_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.All_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.label_Text_Played = new System.Windows.Forms.Label();
            this.label_Text_Num = new System.Windows.Forms.Label();
            this.panel_Num = new System.Windows.Forms.Panel();
            this.label_Played = new System.Windows.Forms.Label();
            this.label_Num = new System.Windows.Forms.Label();
            this.textBox_Played = new System.Windows.Forms.TextBox();
            this.textBox_Num = new System.Windows.Forms.TextBox();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.panel_Text = new System.Windows.Forms.Panel();
            this.panel_calculator_top = new System.Windows.Forms.Panel();
            this.panel_calculator_Bottom = new System.Windows.Forms.Panel();
            this.panel_count_Played = new System.Windows.Forms.Panel();
            this.label_count_Played = new System.Windows.Forms.Label();
            this.panel_count_Num = new System.Windows.Forms.Panel();
            this.label_count_Num = new System.Windows.Forms.Label();
            this.panel_input = new System.Windows.Forms.Panel();
            this.panel_input_Played = new System.Windows.Forms.Panel();
            this.panel_input_Num = new System.Windows.Forms.Panel();
            this.panel_fully_top = new System.Windows.Forms.Panel();
            this.panel_fully_bottom = new System.Windows.Forms.Panel();
            this.panel_calculator_percent = new System.Windows.Forms.Panel();
            this.panel_calculator_percent_bottom = new System.Windows.Forms.Panel();
            this.label_percent_new = new System.Windows.Forms.Label();
            this.panel_calculator_percent_top = new System.Windows.Forms.Panel();
            this.label_percent_difference = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.panel_Bottom.SuspendLayout();
            this.panel_Num.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.panel_Text.SuspendLayout();
            this.panel_calculator_top.SuspendLayout();
            this.panel_calculator_Bottom.SuspendLayout();
            this.panel_count_Played.SuspendLayout();
            this.panel_count_Num.SuspendLayout();
            this.panel_input.SuspendLayout();
            this.panel_input_Played.SuspendLayout();
            this.panel_input_Num.SuspendLayout();
            this.panel_fully_top.SuspendLayout();
            this.panel_fully_bottom.SuspendLayout();
            this.panel_calculator_percent.SuspendLayout();
            this.panel_calculator_percent_bottom.SuspendLayout();
            this.panel_calculator_percent_top.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Text_Percent
            // 
            this.label_Text_Percent.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Text_Percent.Location = new System.Drawing.Point(0, 0);
            this.label_Text_Percent.Margin = new System.Windows.Forms.Padding(0);
            this.label_Text_Percent.Name = "label_Text_Percent";
            this.label_Text_Percent.Size = new System.Drawing.Size(92, 22);
            this.label_Text_Percent.TabIndex = 4;
            this.label_Text_Percent.Text = "红彩票游玩占比";
            this.label_Text_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Text_Percent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Percent
            // 
            this.label_Percent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Percent.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Percent.Location = new System.Drawing.Point(0, 20);
            this.label_Percent.Margin = new System.Windows.Forms.Padding(0);
            this.label_Percent.Name = "label_Percent";
            this.label_Percent.Size = new System.Drawing.Size(92, 25);
            this.label_Percent.TabIndex = 5;
            this.label_Percent.Text = "0.00%";
            this.label_Percent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Percent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Account_ToolStripMenuItem,
            this.toolStripSeparator_Top,
            this.Instant_ToolStripMenuItem,
            this.Calculator_ToolStripMenuItem,
            this.Top_Most_ToolStripMenuItem,
            this.Refresh_ToolStripMenuItem,
            this.Copy_ToolStripMenuItem,
            this.Exit_ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 164);
            this.contextMenuStrip1.TabStop = true;
            // 
            // Account_ToolStripMenuItem
            // 
            this.Account_ToolStripMenuItem.Name = "Account_ToolStripMenuItem";
            this.Account_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.Account_ToolStripMenuItem.Text = "Unauthorized";
            // 
            // toolStripSeparator_Top
            // 
            this.toolStripSeparator_Top.Name = "toolStripSeparator_Top";
            this.toolStripSeparator_Top.Size = new System.Drawing.Size(151, 6);
            // 
            // Instant_ToolStripMenuItem
            // 
            this.Instant_ToolStripMenuItem.Name = "Instant_ToolStripMenuItem";
            this.Instant_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.Instant_ToolStripMenuItem.Text = "立即刷新";
            this.Instant_ToolStripMenuItem.Click += new System.EventHandler(this.Instant_ToolStripMenuItem_Click);
            // 
            // Calculator_ToolStripMenuItem
            // 
            this.Calculator_ToolStripMenuItem.Name = "Calculator_ToolStripMenuItem";
            this.Calculator_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.Calculator_ToolStripMenuItem.Text = "计算器";
            this.Calculator_ToolStripMenuItem.Click += new System.EventHandler(this.Calculator_ToolStripMenuItem_Click);
            // 
            // Top_Most_ToolStripMenuItem
            // 
            this.Top_Most_ToolStripMenuItem.Checked = true;
            this.Top_Most_ToolStripMenuItem.CheckOnClick = true;
            this.Top_Most_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Top_Most_ToolStripMenuItem.Name = "Top_Most_ToolStripMenuItem";
            this.Top_Most_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.Top_Most_ToolStripMenuItem.Text = "置顶";
            this.Top_Most_ToolStripMenuItem.Click += new System.EventHandler(this.Top_Most_ToolStripMenuItem_Click);
            // 
            // Refresh_ToolStripMenuItem
            // 
            this.Refresh_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Time5_ToolStripMenuItem,
            this.Time10_ToolStripMenuItem,
            this.Pause_ToolStripMenuItem});
            this.Refresh_ToolStripMenuItem.Name = "Refresh_ToolStripMenuItem";
            this.Refresh_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.Refresh_ToolStripMenuItem.Text = "刷新时间";
            this.Refresh_ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Refresh_ToolStripMenuItem_DropDownItemClicked);
            // 
            // Time5_ToolStripMenuItem
            // 
            this.Time5_ToolStripMenuItem.Checked = true;
            this.Time5_ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Time5_ToolStripMenuItem.Name = "Time5_ToolStripMenuItem";
            this.Time5_ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.Time5_ToolStripMenuItem.Text = "5分钟";
            // 
            // Time10_ToolStripMenuItem
            // 
            this.Time10_ToolStripMenuItem.Name = "Time10_ToolStripMenuItem";
            this.Time10_ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.Time10_ToolStripMenuItem.Text = "10分钟";
            // 
            // Pause_ToolStripMenuItem
            // 
            this.Pause_ToolStripMenuItem.Name = "Pause_ToolStripMenuItem";
            this.Pause_ToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.Pause_ToolStripMenuItem.Text = "暂停";
            // 
            // Copy_ToolStripMenuItem
            // 
            this.Copy_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Num_Only_ToolStripMenuItem,
            this.All_ToolStripMenuItem});
            this.Copy_ToolStripMenuItem.Name = "Copy_ToolStripMenuItem";
            this.Copy_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.Copy_ToolStripMenuItem.Text = "复制";
            // 
            // Num_Only_ToolStripMenuItem
            // 
            this.Num_Only_ToolStripMenuItem.Name = "Num_Only_ToolStripMenuItem";
            this.Num_Only_ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.Num_Only_ToolStripMenuItem.Text = "仅游玩与红票";
            this.Num_Only_ToolStripMenuItem.Click += new System.EventHandler(this.Num_Only_ToolStripMenuItem_Click);
            // 
            // All_ToolStripMenuItem
            // 
            this.All_ToolStripMenuItem.Name = "All_ToolStripMenuItem";
            this.All_ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.All_ToolStripMenuItem.Text = "全部";
            this.All_ToolStripMenuItem.Click += new System.EventHandler(this.All_ToolStripMenuItem_Click);
            // 
            // Exit_ToolStripMenuItem
            // 
            this.Exit_ToolStripMenuItem.Name = "Exit_ToolStripMenuItem";
            this.Exit_ToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.Exit_ToolStripMenuItem.Text = "退出";
            this.Exit_ToolStripMenuItem.Click += new System.EventHandler(this.Exit_ToolStripMenuItem_Click);
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.label_Percent);
            this.panel_Bottom.Controls.Add(this.label_Text_Percent);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 0);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(92, 45);
            this.panel_Bottom.TabIndex = 8;
            this.panel_Bottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Text_Played
            // 
            this.label_Text_Played.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Text_Played.Font = new System.Drawing.Font("宋体", 7.5F);
            this.label_Text_Played.Location = new System.Drawing.Point(46, 0);
            this.label_Text_Played.Margin = new System.Windows.Forms.Padding(3);
            this.label_Text_Played.Name = "label_Text_Played";
            this.label_Text_Played.Size = new System.Drawing.Size(46, 22);
            this.label_Text_Played.TabIndex = 1;
            this.label_Text_Played.Text = "红票总数";
            this.label_Text_Played.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Text_Played.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Text_Num
            // 
            this.label_Text_Num.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Text_Num.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Text_Num.Location = new System.Drawing.Point(0, 0);
            this.label_Text_Num.Margin = new System.Windows.Forms.Padding(3);
            this.label_Text_Num.Name = "label_Text_Num";
            this.label_Text_Num.Size = new System.Drawing.Size(46, 22);
            this.label_Text_Num.TabIndex = 0;
            this.label_Text_Num.Text = "游玩总数";
            this.label_Text_Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Text_Num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_Num
            // 
            this.panel_Num.Controls.Add(this.label_Played);
            this.panel_Num.Controls.Add(this.label_Num);
            this.panel_Num.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Num.Location = new System.Drawing.Point(0, 22);
            this.panel_Num.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Num.Name = "panel_Num";
            this.panel_Num.Size = new System.Drawing.Size(92, 23);
            this.panel_Num.TabIndex = 6;
            this.panel_Num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Played
            // 
            this.label_Played.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Played.Font = new System.Drawing.Font("宋体", 12F);
            this.label_Played.Location = new System.Drawing.Point(48, 0);
            this.label_Played.Margin = new System.Windows.Forms.Padding(3);
            this.label_Played.Name = "label_Played";
            this.label_Played.Size = new System.Drawing.Size(44, 23);
            this.label_Played.TabIndex = 3;
            this.label_Played.Text = "0";
            this.label_Played.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Played.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_Num
            // 
            this.label_Num.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Num.Font = new System.Drawing.Font("宋体", 12F);
            this.label_Num.Location = new System.Drawing.Point(0, 0);
            this.label_Num.Margin = new System.Windows.Forms.Padding(3);
            this.label_Num.Name = "label_Num";
            this.label_Num.Size = new System.Drawing.Size(44, 23);
            this.label_Num.TabIndex = 2;
            this.label_Num.Text = "0";
            this.label_Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // textBox_Played
            // 
            this.textBox_Played.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Played.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Played.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_Played.Location = new System.Drawing.Point(0, 0);
            this.textBox_Played.Name = "textBox_Played";
            this.textBox_Played.Size = new System.Drawing.Size(44, 19);
            this.textBox_Played.TabIndex = 2;
            this.textBox_Played.Text = "+0";
            this.textBox_Played.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Played.Visible = false;
            this.textBox_Played.Enter += new System.EventHandler(this.textBox_Played_Enter);
            this.textBox_Played.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox_Played.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox_Played.Leave += new System.EventHandler(this.textBox_Played_Leave);
            this.textBox_Played.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseWheel);
            // 
            // textBox_Num
            // 
            this.textBox_Num.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Num.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Num.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox_Num.Location = new System.Drawing.Point(0, 0);
            this.textBox_Num.Name = "textBox_Num";
            this.textBox_Num.Size = new System.Drawing.Size(44, 19);
            this.textBox_Num.TabIndex = 1;
            this.textBox_Num.Text = "+0";
            this.textBox_Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Num.Visible = false;
            this.textBox_Num.Enter += new System.EventHandler(this.textBox_Num_Enter);
            this.textBox_Num.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox_Num.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox_Num.Leave += new System.EventHandler(this.textBox_Num_Leave);
            this.textBox_Num.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseWheel);
            // 
            // panel_Top
            // 
            this.panel_Top.Controls.Add(this.panel_Text);
            this.panel_Top.Controls.Add(this.panel_Num);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(92, 45);
            this.panel_Top.TabIndex = 6;
            this.panel_Top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_Text
            // 
            this.panel_Text.Controls.Add(this.label_Text_Num);
            this.panel_Text.Controls.Add(this.label_Text_Played);
            this.panel_Text.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Text.Location = new System.Drawing.Point(0, 0);
            this.panel_Text.Name = "panel_Text";
            this.panel_Text.Size = new System.Drawing.Size(92, 22);
            this.panel_Text.TabIndex = 2;
            this.panel_Text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_calculator_top
            // 
            this.panel_calculator_top.Controls.Add(this.panel_calculator_Bottom);
            this.panel_calculator_top.Controls.Add(this.panel_input);
            this.panel_calculator_top.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_calculator_top.Location = new System.Drawing.Point(0, 49);
            this.panel_calculator_top.Name = "panel_calculator_top";
            this.panel_calculator_top.Size = new System.Drawing.Size(92, 45);
            this.panel_calculator_top.TabIndex = 9;
            this.panel_calculator_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_calculator_Bottom
            // 
            this.panel_calculator_Bottom.Controls.Add(this.panel_count_Played);
            this.panel_calculator_Bottom.Controls.Add(this.panel_count_Num);
            this.panel_calculator_Bottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_calculator_Bottom.Location = new System.Drawing.Point(0, 23);
            this.panel_calculator_Bottom.Name = "panel_calculator_Bottom";
            this.panel_calculator_Bottom.Size = new System.Drawing.Size(92, 17);
            this.panel_calculator_Bottom.TabIndex = 4;
            this.panel_calculator_Bottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_count_Played
            // 
            this.panel_count_Played.Controls.Add(this.label_count_Played);
            this.panel_count_Played.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_count_Played.Location = new System.Drawing.Point(48, 0);
            this.panel_count_Played.Name = "panel_count_Played";
            this.panel_count_Played.Size = new System.Drawing.Size(44, 17);
            this.panel_count_Played.TabIndex = 1;
            this.panel_count_Played.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_count_Played
            // 
            this.label_count_Played.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_count_Played.Font = new System.Drawing.Font("宋体", 12F);
            this.label_count_Played.Location = new System.Drawing.Point(0, 0);
            this.label_count_Played.Name = "label_count_Played";
            this.label_count_Played.Size = new System.Drawing.Size(44, 17);
            this.label_count_Played.TabIndex = 0;
            this.label_count_Played.Text = "0";
            this.label_count_Played.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_count_Played.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_count_Num
            // 
            this.panel_count_Num.Controls.Add(this.label_count_Num);
            this.panel_count_Num.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_count_Num.Location = new System.Drawing.Point(0, 0);
            this.panel_count_Num.Name = "panel_count_Num";
            this.panel_count_Num.Size = new System.Drawing.Size(44, 17);
            this.panel_count_Num.TabIndex = 0;
            this.panel_count_Num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_count_Num
            // 
            this.label_count_Num.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_count_Num.Font = new System.Drawing.Font("宋体", 12F);
            this.label_count_Num.Location = new System.Drawing.Point(0, 0);
            this.label_count_Num.Name = "label_count_Num";
            this.label_count_Num.Size = new System.Drawing.Size(44, 17);
            this.label_count_Num.TabIndex = 0;
            this.label_count_Num.Text = "0";
            this.label_count_Num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_count_Num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_input
            // 
            this.panel_input.Controls.Add(this.panel_input_Played);
            this.panel_input.Controls.Add(this.panel_input_Num);
            this.panel_input.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_input.Location = new System.Drawing.Point(0, 0);
            this.panel_input.Name = "panel_input";
            this.panel_input.Size = new System.Drawing.Size(92, 23);
            this.panel_input.TabIndex = 3;
            this.panel_input.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_input_Played
            // 
            this.panel_input_Played.Controls.Add(this.textBox_Played);
            this.panel_input_Played.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_input_Played.Location = new System.Drawing.Point(48, 0);
            this.panel_input_Played.Name = "panel_input_Played";
            this.panel_input_Played.Size = new System.Drawing.Size(44, 23);
            this.panel_input_Played.TabIndex = 0;
            this.panel_input_Played.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_input_Num
            // 
            this.panel_input_Num.Controls.Add(this.textBox_Num);
            this.panel_input_Num.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_input_Num.Location = new System.Drawing.Point(0, 0);
            this.panel_input_Num.Name = "panel_input_Num";
            this.panel_input_Num.Size = new System.Drawing.Size(44, 23);
            this.panel_input_Num.TabIndex = 4;
            this.panel_input_Num.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_fully_top
            // 
            this.panel_fully_top.Controls.Add(this.panel_calculator_top);
            this.panel_fully_top.Controls.Add(this.panel_Top);
            this.panel_fully_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_fully_top.Location = new System.Drawing.Point(4, 4);
            this.panel_fully_top.Margin = new System.Windows.Forms.Padding(4);
            this.panel_fully_top.Name = "panel_fully_top";
            this.panel_fully_top.Size = new System.Drawing.Size(92, 94);
            this.panel_fully_top.TabIndex = 10;
            this.panel_fully_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_fully_bottom
            // 
            this.panel_fully_bottom.Controls.Add(this.panel_calculator_percent);
            this.panel_fully_bottom.Controls.Add(this.panel_Bottom);
            this.panel_fully_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_fully_bottom.Location = new System.Drawing.Point(4, 102);
            this.panel_fully_bottom.Margin = new System.Windows.Forms.Padding(4);
            this.panel_fully_bottom.Name = "panel_fully_bottom";
            this.panel_fully_bottom.Size = new System.Drawing.Size(92, 94);
            this.panel_fully_bottom.TabIndex = 6;
            this.panel_fully_bottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_calculator_percent
            // 
            this.panel_calculator_percent.Controls.Add(this.panel_calculator_percent_bottom);
            this.panel_calculator_percent.Controls.Add(this.panel_calculator_percent_top);
            this.panel_calculator_percent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_calculator_percent.Location = new System.Drawing.Point(0, 49);
            this.panel_calculator_percent.Name = "panel_calculator_percent";
            this.panel_calculator_percent.Size = new System.Drawing.Size(92, 45);
            this.panel_calculator_percent.TabIndex = 9;
            this.panel_calculator_percent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_calculator_percent_bottom
            // 
            this.panel_calculator_percent_bottom.Controls.Add(this.label_percent_new);
            this.panel_calculator_percent_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_calculator_percent_bottom.Location = new System.Drawing.Point(0, 22);
            this.panel_calculator_percent_bottom.Name = "panel_calculator_percent_bottom";
            this.panel_calculator_percent_bottom.Size = new System.Drawing.Size(92, 23);
            this.panel_calculator_percent_bottom.TabIndex = 1;
            this.panel_calculator_percent_bottom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_percent_new
            // 
            this.label_percent_new.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_percent_new.Font = new System.Drawing.Font("宋体", 15F);
            this.label_percent_new.Location = new System.Drawing.Point(0, 0);
            this.label_percent_new.Name = "label_percent_new";
            this.label_percent_new.Size = new System.Drawing.Size(92, 23);
            this.label_percent_new.TabIndex = 0;
            this.label_percent_new.Text = "0.00%";
            this.label_percent_new.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_percent_new.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // panel_calculator_percent_top
            // 
            this.panel_calculator_percent_top.Controls.Add(this.label_percent_difference);
            this.panel_calculator_percent_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_calculator_percent_top.Location = new System.Drawing.Point(0, 0);
            this.panel_calculator_percent_top.Name = "panel_calculator_percent_top";
            this.panel_calculator_percent_top.Size = new System.Drawing.Size(92, 22);
            this.panel_calculator_percent_top.TabIndex = 0;
            this.panel_calculator_percent_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // label_percent_difference
            // 
            this.label_percent_difference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_percent_difference.Font = new System.Drawing.Font("宋体", 12F);
            this.label_percent_difference.Location = new System.Drawing.Point(0, 0);
            this.label_percent_difference.Name = "label_percent_difference";
            this.label_percent_difference.Size = new System.Drawing.Size(92, 22);
            this.label_percent_difference.TabIndex = 0;
            this.label_percent_difference.Text = "+0.00%";
            this.label_percent_difference.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_percent_difference.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            // 
            // textBox1
            // 
            this.textBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.textBox1.Location = new System.Drawing.Point(0, -10);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(0, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "wtf";
            // 
            // daily_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(100, 200);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel_fully_bottom);
            this.Controls.Add(this.panel_fully_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "daily_Form";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "daily_Form";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.daily_Form_FormClosing);
            this.Load += new System.EventHandler(this.daily_Form_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.daily_Form_MouseDown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Num.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_Text.ResumeLayout(false);
            this.panel_calculator_top.ResumeLayout(false);
            this.panel_calculator_Bottom.ResumeLayout(false);
            this.panel_count_Played.ResumeLayout(false);
            this.panel_count_Num.ResumeLayout(false);
            this.panel_input.ResumeLayout(false);
            this.panel_input_Played.ResumeLayout(false);
            this.panel_input_Played.PerformLayout();
            this.panel_input_Num.ResumeLayout(false);
            this.panel_input_Num.PerformLayout();
            this.panel_fully_top.ResumeLayout(false);
            this.panel_fully_bottom.ResumeLayout(false);
            this.panel_calculator_percent.ResumeLayout(false);
            this.panel_calculator_percent_bottom.ResumeLayout(false);
            this.panel_calculator_percent_top.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label_Text_Percent;
        private System.Windows.Forms.Label label_Percent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Instant_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_ToolStripMenuItem;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.ToolStripMenuItem Refresh_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Time5_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Time10_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Pause_ToolStripMenuItem;
        private System.Windows.Forms.Label label_Text_Played;
        private System.Windows.Forms.Label label_Text_Num;
        private System.Windows.Forms.Panel panel_Num;
        private System.Windows.Forms.Label label_Played;
        private System.Windows.Forms.Label label_Num;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Text;
        private System.Windows.Forms.ToolStripMenuItem Account_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator_Top;
        private System.Windows.Forms.ToolStripMenuItem Copy_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Num_Only_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem All_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Top_Most_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Calculator_ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_Num;
        private System.Windows.Forms.TextBox textBox_Played;
        private System.Windows.Forms.Panel panel_calculator_top;
        private System.Windows.Forms.Panel panel_fully_top;
        private System.Windows.Forms.Panel panel_fully_bottom;
        private System.Windows.Forms.Panel panel_input;
        private System.Windows.Forms.Panel panel_input_Num;
        private System.Windows.Forms.Panel panel_input_Played;
        private System.Windows.Forms.Panel panel_calculator_Bottom;
        private System.Windows.Forms.Panel panel_count_Num;
        private System.Windows.Forms.Label label_count_Num;
        private System.Windows.Forms.Panel panel_count_Played;
        private System.Windows.Forms.Label label_count_Played;
        private System.Windows.Forms.Panel panel_calculator_percent;
        private System.Windows.Forms.Panel panel_calculator_percent_bottom;
        private System.Windows.Forms.Panel panel_calculator_percent_top;
        private System.Windows.Forms.Label label_percent_new;
        private System.Windows.Forms.Label label_percent_difference;
        private System.Windows.Forms.TextBox textBox1;
    }
}