namespace CS_GUI_DEMO
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.Container = new System.Windows.Forms.TextBox();
            this.BuildTime = new System.Windows.Forms.Label();
            this.Sign = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.License = new System.Windows.Forms.TextBox();
            this.Url = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Container
            // 
            this.Container.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Container.CausesValidation = false;
            this.Container.Cursor = System.Windows.Forms.Cursors.Default;
            this.Container.Enabled = false;
            this.Container.Location = new System.Drawing.Point(40, 78);
            this.Container.Margin = new System.Windows.Forms.Padding(0);
            this.Container.Multiline = true;
            this.Container.Name = "Container";
            this.Container.ReadOnly = true;
            this.Container.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Container.ShortcutsEnabled = false;
            this.Container.Size = new System.Drawing.Size(300, 165);
            this.Container.TabIndex = 0;
            this.Container.TabStop = false;
            // 
            // BuildTime
            // 
            this.BuildTime.AutoSize = true;
            this.BuildTime.Font = new System.Drawing.Font("宋体", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BuildTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BuildTime.Location = new System.Drawing.Point(215, 9);
            this.BuildTime.Name = "BuildTime";
            this.BuildTime.Size = new System.Drawing.Size(155, 12);
            this.BuildTime.TabIndex = 1;
            this.BuildTime.Text = "构建于2019/12/03 21:14:40";
            // 
            // Sign
            // 
            this.Sign.AutoSize = true;
            this.Sign.Location = new System.Drawing.Point(37, 21);
            this.Sign.Name = "Sign";
            this.Sign.Size = new System.Drawing.Size(139, 15);
            this.Sign.TabIndex = 2;
            this.Sign.Text = "五十音图 v1.0.0.0";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(130, 70);
            this.Title.Margin = new System.Windows.Forms.Padding(0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(119, 15);
            this.Title.TabIndex = 3;
            this.Title.Text = "Public License";
            // 
            // License
            // 
            this.License.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.License.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.License.Location = new System.Drawing.Point(55, 90);
            this.License.Margin = new System.Windows.Forms.Padding(0);
            this.License.Multiline = true;
            this.License.Name = "License";
            this.License.ReadOnly = true;
            this.License.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.License.ShortcutsEnabled = false;
            this.License.Size = new System.Drawing.Size(270, 152);
            this.License.TabIndex = 4;
            // 
            // Url
            // 
            this.Url.AutoSize = true;
            this.Url.Location = new System.Drawing.Point(118, 279);
            this.Url.Name = "Url";
            this.Url.Size = new System.Drawing.Size(183, 15);
            this.Url.TabIndex = 5;
            this.Url.TabStop = true;
            this.Url.Text = "https://blog.todest.cn";
            this.Url.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Url_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 279);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "作者主页:";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(382, 303);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Url);
            this.Controls.Add(this.License);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Sign);
            this.Controls.Add(this.BuildTime);
            this.Controls.Add(this.Container);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于";
            this.Load += new System.EventHandler(this.About_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Container;
        private System.Windows.Forms.Label BuildTime;
        private System.Windows.Forms.Label Sign;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox License;
        private System.Windows.Forms.LinkLabel Url;
        private System.Windows.Forms.Label label1;
    }
}