using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_GUI_DEMO
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            Sign.Text = string.Format(Application.ProductName + " v" + Application.ProductVersion);
            License.Text = "本软件是免费的！";
            BuildTime.Text = string.Format("构建于{0:G}", DateTime.Now);
        }

        private void Url_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://blog.todest.cn");
        }
    }
}
