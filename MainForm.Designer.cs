namespace CS_GUI_DEMO
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LvlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HiraganaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KatakanaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VoicedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Submit = new System.Windows.Forms.TextBox();
            this.ShowText = new System.Windows.Forms.Label();
            this.Correct = new System.Windows.Forms.Label();
            this.Wrong = new System.Windows.Forms.Label();
            this.Schedule = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.TextBox();
            this.LogTitle = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Menu;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.LvlToolStripMenuItem,
            this.UpdateToolStripMenuItem,
            this.AboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(782, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartToolStripMenuItem,
            this.RestartToolStripMenuItem,
            this.ExitToolStripMenuItem,
            this.QuitToolStripMenuItem});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.ToolStripMenuItem.Text = "设置";
            // 
            // StartToolStripMenuItem
            // 
            this.StartToolStripMenuItem.Name = "StartToolStripMenuItem";
            this.StartToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.StartToolStripMenuItem.Text = "开始";
            this.StartToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // RestartToolStripMenuItem
            // 
            this.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem";
            this.RestartToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.RestartToolStripMenuItem.Text = "重新开始";
            this.RestartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.ExitToolStripMenuItem.Text = "结束";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // QuitToolStripMenuItem
            // 
            this.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem";
            this.QuitToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.QuitToolStripMenuItem.Text = "退出";
            this.QuitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // LvlToolStripMenuItem
            // 
            this.LvlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HiraganaToolStripMenuItem,
            this.KatakanaToolStripMenuItem,
            this.VoicedToolStripMenuItem,
            this.AoToolStripMenuItem,
            this.LongToolStripMenuItem,
            this.AccentToolStripMenuItem});
            this.LvlToolStripMenuItem.Name = "LvlToolStripMenuItem";
            this.LvlToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.LvlToolStripMenuItem.Text = "级别";
            // 
            // HiraganaToolStripMenuItem
            // 
            this.HiraganaToolStripMenuItem.Checked = true;
            this.HiraganaToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HiraganaToolStripMenuItem.Name = "HiraganaToolStripMenuItem";
            this.HiraganaToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.HiraganaToolStripMenuItem.Text = "平假名";
            this.HiraganaToolStripMenuItem.Click += new System.EventHandler(this.HiraganaToolStripMenuItem_Click);
            // 
            // KatakanaToolStripMenuItem
            // 
            this.KatakanaToolStripMenuItem.Name = "KatakanaToolStripMenuItem";
            this.KatakanaToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.KatakanaToolStripMenuItem.Text = "片假名";
            this.KatakanaToolStripMenuItem.Click += new System.EventHandler(this.KatakanaToolStripMenuItem_Click);
            // 
            // VoicedToolStripMenuItem
            // 
            this.VoicedToolStripMenuItem.Name = "VoicedToolStripMenuItem";
            this.VoicedToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.VoicedToolStripMenuItem.Text = "浊音";
            // 
            // AoToolStripMenuItem
            // 
            this.AoToolStripMenuItem.Name = "AoToolStripMenuItem";
            this.AoToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.AoToolStripMenuItem.Text = "拗音";
            // 
            // LongToolStripMenuItem
            // 
            this.LongToolStripMenuItem.Name = "LongToolStripMenuItem";
            this.LongToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.LongToolStripMenuItem.Text = "长音";
            // 
            // AccentToolStripMenuItem
            // 
            this.AccentToolStripMenuItem.Name = "AccentToolStripMenuItem";
            this.AccentToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.AccentToolStripMenuItem.Text = "促音";
            // 
            // UpdateToolStripMenuItem
            // 
            this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
            this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.UpdateToolStripMenuItem.Text = "更新";
            this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.AboutToolStripMenuItem.Text = "关于";
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // Submit
            // 
            this.Submit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Submit.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Submit.Location = new System.Drawing.Point(340, 300);
            this.Submit.MaxLength = 8;
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(120, 50);
            this.Submit.TabIndex = 1;
            this.Submit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Submit_KeyDown);
            // 
            // ShowText
            // 
            this.ShowText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ShowText.AutoSize = true;
            this.ShowText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ShowText.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ShowText.Location = new System.Drawing.Point(300, 100);
            this.ShowText.Margin = new System.Windows.Forms.Padding(0);
            this.ShowText.MinimumSize = new System.Drawing.Size(200, 150);
            this.ShowText.Name = "ShowText";
            this.ShowText.Size = new System.Drawing.Size(200, 150);
            this.ShowText.TabIndex = 2;
            this.ShowText.Text = "▶";
            this.ShowText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Correct
            // 
            this.Correct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Correct.AutoSize = true;
            this.Correct.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Correct.Location = new System.Drawing.Point(30, 125);
            this.Correct.Name = "Correct";
            this.Correct.Size = new System.Drawing.Size(100, 25);
            this.Correct.TabIndex = 3;
            this.Correct.Text = "正确：0";
            // 
            // Wrong
            // 
            this.Wrong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Wrong.AutoSize = true;
            this.Wrong.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Wrong.Location = new System.Drawing.Point(30, 166);
            this.Wrong.Name = "Wrong";
            this.Wrong.Size = new System.Drawing.Size(100, 25);
            this.Wrong.TabIndex = 4;
            this.Wrong.Text = "错误：0";
            // 
            // Schedule
            // 
            this.Schedule.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Schedule.AutoSize = true;
            this.Schedule.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Schedule.Location = new System.Drawing.Point(355, 59);
            this.Schedule.Name = "Schedule";
            this.Schedule.Size = new System.Drawing.Size(90, 25);
            this.Schedule.TabIndex = 5;
            this.Schedule.Text = "1 / 51";
            this.Schedule.SizeChanged += new System.EventHandler(this.Schedule_SizeChanged);
            // 
            // Timer
            // 
            this.Timer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Timer.AutoSize = true;
            this.Timer.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Timer.Location = new System.Drawing.Point(651, 32);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(77, 25);
            this.Timer.TabIndex = 6;
            this.Timer.Text = "00:00";
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.SystemColors.Window;
            this.Log.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Log.Location = new System.Drawing.Point(600, 100);
            this.Log.Margin = new System.Windows.Forms.Padding(0);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(120, 150);
            this.Log.TabIndex = 7;
            this.Log.TextChanged += new System.EventHandler(this.Log_TextChanged);
            // 
            // LogTitle
            // 
            this.LogTitle.AutoSize = true;
            this.LogTitle.Location = new System.Drawing.Point(600, 80);
            this.LogTitle.Margin = new System.Windows.Forms.Padding(0);
            this.LogTitle.Name = "LogTitle";
            this.LogTitle.Size = new System.Drawing.Size(39, 15);
            this.LogTitle.TabIndex = 8;
            this.LogTitle.Text = "Log:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.LogTitle);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.Schedule);
            this.Controls.Add(this.Wrong);
            this.Controls.Add(this.Correct);
            this.Controls.Add(this.ShowText);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "五十音图";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TextBox Submit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.Label ShowText;
        private System.Windows.Forms.ToolStripMenuItem StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RestartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LvlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QuitToolStripMenuItem;
        private System.Windows.Forms.Label Correct;
        private System.Windows.Forms.Label Wrong;
        private System.Windows.Forms.Label Schedule;
        private System.Windows.Forms.ToolStripMenuItem HiraganaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KatakanaToolStripMenuItem;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.ToolStripMenuItem VoicedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AccentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label LogTitle;
    }
}

