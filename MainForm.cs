using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;

namespace CS_GUI_DEMO
{
    public partial class MainForm : Form
    {
        readonly Dictionary<int, string> Unvoiced = new Dictionary<int, string>();
        readonly Dictionary<int, string> Hiragana = new Dictionary<int, string>();
        readonly Dictionary<int, string> Katakana = new Dictionary<int, string>();
        readonly Dictionary<int, string> Voiced = new Dictionary<int, string>();
        readonly Dictionary<int, string> Ao = new Dictionary<int, string>();
        readonly Dictionary<int, string> Long = new Dictionary<int, string>();
        readonly Dictionary<int, string> Accent = new Dictionary<int, string>();
        readonly List<Tuple<int, int>> R = new List<Tuple<int, int>>();
        int Count = 0, CorrectCount, WrongCount;
        bool Over;

        public System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }

        public void Init()
        {
            //清音
            Unvoiced.Add(0, "a"); Unvoiced.Add(1, "i"); Unvoiced.Add(2, "u"); Unvoiced.Add(3, "e"); Unvoiced.Add(4, "o");
            Unvoiced.Add(5, "ka"); Unvoiced.Add(6, "ki"); Unvoiced.Add(7, "ku"); Unvoiced.Add(8, "ke"); Unvoiced.Add(9, "ko");
            Unvoiced.Add(10, "sa"); Unvoiced.Add(11, "shi"); Unvoiced.Add(12, "su"); Unvoiced.Add(13, "se"); Unvoiced.Add(14, "so");
            Unvoiced.Add(15, "ta"); Unvoiced.Add(16, "chi"); Unvoiced.Add(17, "tsu"); Unvoiced.Add(18, "te"); Unvoiced.Add(19, "to");
            Unvoiced.Add(20, "na"); Unvoiced.Add(21, "ni"); Unvoiced.Add(22, "nu"); Unvoiced.Add(23, "ne"); Unvoiced.Add(24, "no");
            Unvoiced.Add(25, "ha"); Unvoiced.Add(26, "hi"); Unvoiced.Add(27, "fu"); Unvoiced.Add(28, "he"); Unvoiced.Add(29, "ho");
            Unvoiced.Add(30, "ma"); Unvoiced.Add(31, "mi"); Unvoiced.Add(32, "mu"); Unvoiced.Add(33, "me"); Unvoiced.Add(34, "mo");
            Unvoiced.Add(35, "ya"); Unvoiced.Add(36, "yu"); Unvoiced.Add(37, "yo");
            Unvoiced.Add(38, "ra"); Unvoiced.Add(39, "ri"); Unvoiced.Add(40, "ru"); Unvoiced.Add(41, "re"); Unvoiced.Add(42, "ro");
            Unvoiced.Add(43, "wa"); Unvoiced.Add(44, "wo");
            Unvoiced.Add(45, "n");

            //平假名
            Hiragana.Add(0, "あ"); Hiragana.Add(1, "い"); Hiragana.Add(2, "う"); Hiragana.Add(3, "え"); Hiragana.Add(4, "お");
            Hiragana.Add(5, "か"); Hiragana.Add(6, "き"); Hiragana.Add(7, "く"); Hiragana.Add(8, "け"); Hiragana.Add(9, "こ");
            Hiragana.Add(10, "さ"); Hiragana.Add(11, "し"); Hiragana.Add(12, "す"); Hiragana.Add(13, "せ"); Hiragana.Add(14, "そ");
            Hiragana.Add(15, "た"); Hiragana.Add(16, "ち"); Hiragana.Add(17, "つ"); Hiragana.Add(18, "て"); Hiragana.Add(19, "と");
            Hiragana.Add(20, "な"); Hiragana.Add(21, "に"); Hiragana.Add(22, "ぬ"); Hiragana.Add(23, "ね"); Hiragana.Add(24, "の");
            Hiragana.Add(25, "は"); Hiragana.Add(26, "ひ"); Hiragana.Add(27, "ふ"); Hiragana.Add(28, "へ"); Hiragana.Add(29, "ほ");
            Hiragana.Add(30, "ま"); Hiragana.Add(31, "み"); Hiragana.Add(32, "む"); Hiragana.Add(33, "め"); Hiragana.Add(34, "も");
            Hiragana.Add(35, "や"); Hiragana.Add(36, "ゆ"); Hiragana.Add(37, "よ");
            Hiragana.Add(38, "ら"); Hiragana.Add(39, "り"); Hiragana.Add(40, "る"); Hiragana.Add(41, "れ"); Hiragana.Add(42, "ろ");
            Hiragana.Add(43, "わ"); Hiragana.Add(44, "を");
            Hiragana.Add(45, "ん");


            //片假名
            Katakana.Add(0, "ア"); Katakana.Add(1, "イ"); Katakana.Add(2, "ウ"); Katakana.Add(3, "エ"); Katakana.Add(4, "オ");
            Katakana.Add(5, "カ"); Katakana.Add(6, "キ"); Katakana.Add(7, "ク"); Katakana.Add(8, "ケ"); Katakana.Add(9, "コ");
            Katakana.Add(10, "サ"); Katakana.Add(11, "シ"); Katakana.Add(12, "ス"); Katakana.Add(13, "セ"); Katakana.Add(14, "ソ");
            Katakana.Add(15, "タ"); Katakana.Add(16, "チ"); Katakana.Add(17, "ツ"); Katakana.Add(18, "テ"); Katakana.Add(19, "ト");
            Katakana.Add(20, "ナ"); Katakana.Add(21, "ニ"); Katakana.Add(22, "ヌ"); Katakana.Add(23, "ネ"); Katakana.Add(24, "ノ");
            Katakana.Add(25, "ハ"); Katakana.Add(26, "ヒ"); Katakana.Add(27, "フ"); Katakana.Add(28, "ヘ"); Katakana.Add(29, "ホ");
            Katakana.Add(30, "マ"); Katakana.Add(31, "ミ"); Katakana.Add(32, "ム"); Katakana.Add(33, "メ"); Katakana.Add(34, "モ");
            Katakana.Add(35, "ヤ"); Katakana.Add(36, "ユ"); Katakana.Add(37, "ヨ");
            Katakana.Add(38, "ラ"); Katakana.Add(39, "リ"); Katakana.Add(40, "ル"); Katakana.Add(41, "レ"); Katakana.Add(42, "ロ");
            Katakana.Add(43, "ワ"); Katakana.Add(44, "ヲ");
            Katakana.Add(45, "ン");

            //浊音

            //拗音

            //长音

            //促音
        }

        public static void Delay(int mm)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

        public static bool CompareVersion(string new_version, string old_version)
        {
            try
            {
                if (string.IsNullOrEmpty(new_version) || string.IsNullOrEmpty(old_version))
                    return false;

                Version v_new = new Version(new_version);
                Version v_old = new Version(old_version);
                if (v_new > v_old)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string Get(string url)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.UserAgent = "[Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36]";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            try
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            finally
            {
                stream.Close();
            }
            return result;
        }

        public static void DelayRun(string path, int time)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe", "/C ping 127.0.0.1 -n " + time + " -w 1000 > Nul && del /F update.old && \"" + path + "\"")
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            Process.Start(psi);
            Application.Exit();
        }

        public bool DownloadFile(string URL, string filename)
        {
            string tempPath = Path.GetDirectoryName(filename) + @"\temp";
            Directory.CreateDirectory(tempPath);
            string tempFile = tempPath + @"\" + Path.GetFileName(filename) + ".temp";
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
            try
            {
                FileStream fs = new FileStream(tempFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                HttpWebRequest request = WebRequest.Create(URL) as HttpWebRequest;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream responseStream = response.GetResponseStream();
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                fs.Close();
                responseStream.Close();
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                File.Move(tempFile, filename);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public void LoadTest(int[] a, int n)
        {
            int sum = 0, t;
            List<Tuple<int,int>> L = new List<Tuple<int,int>>();
            R.Clear();
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                if (a[i] == 0)
                {
                    sum += Hiragana.Count();
                    for (int j = 0; j < Hiragana.Count(); j++)
                        L.Add(Tuple.Create(a[i], j));
                }
                else if (a[i] == 1)
                {
                    sum += Katakana.Count();
                    for (int j = 0; j < Katakana.Count(); j++)
                        L.Add(Tuple.Create(a[i], j));
                }
                else if (a[i] == 2)
                {
                    sum += Voiced.Count();
                    for (int j = 0; j < Voiced.Count(); j++)
                        L.Add(Tuple.Create(a[i], j));
                }
                else if (a[i] == 3)
                {
                    sum += Ao.Count();
                    for (int j = 0; j < Ao.Count(); j++)
                        L.Add(Tuple.Create(a[i], j));
                }
                else if (a[i] == 4)
                {
                    sum += Long.Count();
                    for (int j = 0; j < Long.Count(); j++)
                        L.Add(Tuple.Create(a[i], j));
                }
                else if (a[i] == 5)
                {
                    sum += Accent.Count();
                    for (int j = 0; j < Accent.Count(); j++)
                        L.Add(Tuple.Create(a[i], j));
                }
            }
            for(int i=0;i<sum;i++)
            {
                t = rand.Next(0, L.Count);
                R.Add(L[t]);
                L.Remove(L[t]);
            }
            Schedule.Text = string.Format("{0:D} / {1:D}", 1, sum);
            if (R[0].Item1 == 0) ShowText.Text = Hiragana[R[0].Item2];
            else if (R[0].Item1 == 1) ShowText.Text = Katakana[R[0].Item2];
            else if (R[0].Item1 == 2) ShowText.Text = Voiced[R[0].Item2];
            else if (R[0].Item1 == 3) ShowText.Text = Ao[R[0].Item2];
            else if (R[0].Item1 == 4) ShowText.Text = Long[R[0].Item2];
            else if (R[0].Item1 == 5) ShowText.Text = Accent[R[0].Item2];
        }

        public MainForm()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();
            Init();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*默认设置*/
            Submit.Text = "";
            ShowText.Text = "▶";
            Correct.Visible = false;
            Wrong.Visible = false;
            Schedule.Visible = false;
            Timer.Visible = false;
            Submit.Visible = false;
            Log.Visible = false;
            LogTitle.Visible = false;
            Submit.ReadOnly = true;
            HiraganaToolStripMenuItem.Checked = true;
            KatakanaToolStripMenuItem.Checked = false;
            VoicedToolStripMenuItem.Checked = false;
            AoToolStripMenuItem.Checked = false;
            LongToolStripMenuItem.Checked = false;
            AccentToolStripMenuItem.Checked = false;
            StartToolStripMenuItem.Enabled = true;
            RestartToolStripMenuItem.Enabled = false;
            ExitToolStripMenuItem.Enabled = false;
            QuitToolStripMenuItem.Enabled = true;
            MainForm_SizeChanged(sender, e);

            /*待开发*/
            HiraganaToolStripMenuItem.Enabled = true;
            KatakanaToolStripMenuItem.Enabled = true;
            VoicedToolStripMenuItem.Enabled = false;
            AoToolStripMenuItem.Enabled = false;
            LongToolStripMenuItem.Enabled = false;
            AccentToolStripMenuItem.Enabled = false;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);
        }

        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log.Text = "";
            Submit.Visible = true;
            Submit.Focus();
            StartToolStripMenuItem.Enabled = false;
            RestartToolStripMenuItem.Enabled = true;
            ExitToolStripMenuItem.Enabled = true;

            for (int i = 3; i >= 1; i--)
            {
                ShowText.Text = i.ToString();
                Delay(1000);
            }
            int[] Lvl = new int[10];
            int pos = 0;
            Count = 0;
            Over = false;
            Submit.Text = "";
            Submit.ReadOnly = false;
            CorrectCount = WrongCount = 0;
            Correct.Text = string.Format("正确: {0:D}", CorrectCount);
            Wrong.Text = string.Format("错误: {0:D}", WrongCount);
            if (HiraganaToolStripMenuItem.Checked) Lvl[pos++] = 0;
            if (KatakanaToolStripMenuItem.Checked) Lvl[pos++] = 1;
            if (VoicedToolStripMenuItem.Checked) Lvl[pos++] = 2;
            if (AoToolStripMenuItem.Checked) Lvl[pos++] = 3;
            if (LongToolStripMenuItem.Checked) Lvl[pos++] = 4;
            if (AccentToolStripMenuItem.Checked) Lvl[pos++] = 5;

            HiraganaToolStripMenuItem.Enabled = false;
            KatakanaToolStripMenuItem.Enabled = false;
            VoicedToolStripMenuItem.Enabled = false;
            AoToolStripMenuItem.Enabled = false;
            LongToolStripMenuItem.Enabled = false;
            AccentToolStripMenuItem.Enabled = false;

            LoadTest(Lvl, pos);
            Log.Visible = true;
            LogTitle.Visible = true;
            Timer.Visible = true;
            Schedule.Visible = true;
            Correct.Visible = true;
            Wrong.Visible = true;
            DateTime Current = DateTime.Now;
            while(true)
            {
                int seconds = Convert.ToInt32(DateTime.Now.Subtract(Current).TotalSeconds);
                int minutes=seconds/60;
                Timer.Text = string.Format("{0:D2}:{1:D2}", minutes, seconds % 60);
                if (Over)
                {
                    Submit.ReadOnly = true;
                    break;
                }
                Delay(1000);
            }
            Schedule.Text = string.Format("正确率: {0:P}", 1.0 * CorrectCount / R.Count);
            ShowText.Text = "▶";
            ShowText.Enabled = true;
        }

        private void HiraganaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KatakanaToolStripMenuItem.Checked || VoicedToolStripMenuItem.Checked ||
                AoToolStripMenuItem.Checked || LongToolStripMenuItem.Checked ||
                LongToolStripMenuItem.Checked || AccentToolStripMenuItem.Checked)
                HiraganaToolStripMenuItem.Checked = !HiraganaToolStripMenuItem.Checked;
        }

        private void KatakanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HiraganaToolStripMenuItem.Checked || VoicedToolStripMenuItem.Checked ||
                AoToolStripMenuItem.Checked || LongToolStripMenuItem.Checked ||
                LongToolStripMenuItem.Checked || AccentToolStripMenuItem.Checked)
                KatakanaToolStripMenuItem.Checked = !KatakanaToolStripMenuItem.Checked;
        }

        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);
            StartToolStripMenuItem_Click(sender, e);
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            Schedule.Location = new Point((this.Width - Schedule.Width) / 2, this.Height / 8);
            ShowText.Location = new Point((this.Width - ShowText.Width) / 2, (this.Height - ShowText.Height) / 5 * 2);
            Submit.Location = new Point((this.Width - Submit.Width) / 2, (this.Height - Submit.Height) / 4 * 3);
            Correct.Location = new Point(this.Width / 10, this.Height / 5);
            Wrong.Location = new Point(this.Width / 10, this.Height / 3);
            Timer.Location = new Point((this.Width - Timer.Width) / 10 * 9, this.Height / 8);
            Log.Location = new Point((this.Width - Log.Width) / 10 * 9, (this.Height - Log.Height) / 5 * 2);
            LogTitle.Location = new Point(Log.Location.X, Log.Location.Y - LogTitle.Height);
        }

        private void Schedule_SizeChanged(object sender, EventArgs e)
        {
            Schedule.Location = new Point((this.Width - Schedule.Width) / 2, this.Height / 8);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void UpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonText = Get("https://api.github.com/repos/todest/FiftySounds/releases/latest");
                RootObject rb = JsonConvert.DeserializeObject<RootObject>(jsonText);
                if (CompareVersion(rb.tag_name.Substring(1), Application.ProductVersion))
                {
                    if (MessageBox.Show("检测到新版本!  是否更新?", "检查更新", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (DownloadFile(rb.assets[0].browser_download_url, "update.exe"))
                        {
                            string oldName = Process.GetCurrentProcess().MainModule.FileName;
                            FileInfo fi = new FileInfo(oldName);
                            FileInfo fo = new FileInfo("./update.exe");
                            if (File.Exists("./update.old"))
                            {
                                File.Delete("./update.old");
                            }
                            fi.MoveTo("./update.old");
                            fo.MoveTo(oldName);
                            if (MessageBox.Show("重启以完成更新!", "更新", MessageBoxButtons.OK) == DialogResult.OK)
                            {
                                DelayRun(oldName, 1);
                                Application.Exit();
                            }
                        }
                        else
                        {
                            MessageBox.Show("由于未知原因,下载更新失败!", "提示", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("已是最新版本!", "检查更新");
                }
            }
            catch
            {
                MessageBox.Show("网络连接失败!", "提示");
            }
        }

        private void Log_TextChanged(object sender, EventArgs e)
        {
            Log.SelectionStart = Log.Text.Length;
            Log.ScrollToCaret();
        }

        private void ShowText_Click(object sender, EventArgs e)
        {
            if (ShowText.Text == "▶")
            RestartToolStripMenuItem_Click(sender, e);
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Submit_KeyDown(object sender, KeyEventArgs e)
        {
            if (Submit.Text != "" && e.KeyCode == Keys.Enter)
            {
                if (R[Count].Item1 <= 1)
                {
                    if (Submit.Text == Unvoiced[R[Count].Item2]) CorrectCount++;
                    else
                    {
                        WrongCount++;
                        if (R[Count].Item1 == 0)
                            Log.Text += Hiragana[R[Count].Item2];
                        else if (R[Count].Item1 == 1)
                            Log.Text += Katakana[R[Count].Item2];
                        Log.Text += ":  " + Unvoiced[R[Count].Item2] + Environment.NewLine;
                    }
                    if (Count + 1 < R.Count)
                    {
                        if (R[Count].Item1 == 0) ShowText.Text = Hiragana[R[++Count].Item2];
                        else if (R[Count].Item1 == 1) ShowText.Text = Katakana[R[++Count].Item2];
                        else if (R[Count].Item1 == 2) ShowText.Text = Voiced[R[++Count].Item2];
                        else if (R[Count].Item1 == 3) ShowText.Text = Ao[R[++Count].Item2];
                        else if (R[Count].Item1 == 4) ShowText.Text = Long[R[++Count].Item2];
                        else if (R[Count].Item1 == 5) ShowText.Text = Accent[R[++Count].Item2];
                    }
                    else
                    {
                        Submit.ReadOnly = true;
                    }
                }
                Submit.Text = "";
                Correct.Text = string.Format("正确: {0:D}", CorrectCount);
                Wrong.Text = string.Format("错误: {0:D}", WrongCount);
                if (Count + 1 == R.Count)
                {
                    Over = true;
                    return;
                }
                Schedule.Text = string.Format("{0:D} / {1:D}", Count, R.Count);
            }
        }
    }
}
