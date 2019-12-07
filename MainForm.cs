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
        readonly Dictionary<int, string> VoicedHira = new Dictionary<int, string>();
        readonly Dictionary<int, string> VoicedKata = new Dictionary<int, string>();
        readonly Dictionary<int, string> Ao = new Dictionary<int, string>();
        readonly Dictionary<int, string> AoHira = new Dictionary<int, string>();
        readonly Dictionary<int, string> AoKata = new Dictionary<int, string>();
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

            //清音-平假
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

            //清音-片假
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
            Voiced.Add(0, "ga"); Voiced.Add(1, "gi"); Voiced.Add(2, "gu"); Voiced.Add(3, "ge"); Voiced.Add(4, "go");
            Voiced.Add(5, "za"); Voiced.Add(6, "ji"); Voiced.Add(7, "zu"); Voiced.Add(8, "ze"); Voiced.Add(9, "zo");
            Voiced.Add(10, "da"); Voiced.Add(11, "ji"); Voiced.Add(12, "zu"); Voiced.Add(13, "de"); Voiced.Add(14, "do");
            Voiced.Add(15, "ba"); Voiced.Add(16, "bi"); Voiced.Add(17, "bu"); Voiced.Add(18, "be"); Voiced.Add(19, "bo");
            Voiced.Add(20, "pa"); Voiced.Add(21, "pi"); Voiced.Add(22, "pu"); Voiced.Add(23, "pe"); Voiced.Add(24, "po");

            //浊音-平假
            VoicedHira.Add(0, "が"); VoicedHira.Add(1, "ぎ"); VoicedHira.Add(2, "ぐ"); VoicedHira.Add(3, "げ"); VoicedHira.Add(4, "ご");
            VoicedHira.Add(5, "ざ"); VoicedHira.Add(6, "じ"); VoicedHira.Add(7, "ず"); VoicedHira.Add(8, "ぜ"); VoicedHira.Add(9, "ぞ");
            VoicedHira.Add(10, "だ"); VoicedHira.Add(11, "ぢ"); VoicedHira.Add(12, "づ"); VoicedHira.Add(13, "で"); VoicedHira.Add(14, "ど");
            VoicedHira.Add(15, "ば"); VoicedHira.Add(16, "び"); VoicedHira.Add(17, "ぶ"); VoicedHira.Add(18, "べ"); VoicedHira.Add(19, "ぼ");
            VoicedHira.Add(20, "ぱ"); VoicedHira.Add(21, "ぴ"); VoicedHira.Add(22, "ぷ"); VoicedHira.Add(23, "ぺ"); VoicedHira.Add(24, "ぽ");

            //浊音-片假
            VoicedKata.Add(0, "ガ"); VoicedKata.Add(1, "ギ"); VoicedKata.Add(2, "グ"); VoicedKata.Add(3, "ゲ"); VoicedKata.Add(4, "ゴ");
            VoicedKata.Add(5, "ザ"); VoicedKata.Add(6, "ジ"); VoicedKata.Add(7, "ズ"); VoicedKata.Add(8, "ゼ"); VoicedKata.Add(9, "ゾ");
            VoicedKata.Add(10, "ダ"); VoicedKata.Add(11, "ヂ"); VoicedKata.Add(12, "ヅ"); VoicedKata.Add(13, "デ"); VoicedKata.Add(14, "ド");
            VoicedKata.Add(15, "バ"); VoicedKata.Add(16, "ビ"); VoicedKata.Add(17, "ブ"); VoicedKata.Add(18, "ベ"); VoicedKata.Add(19, "ボ");
            VoicedKata.Add(20, "パ"); VoicedKata.Add(21, "ピ"); VoicedKata.Add(22, "プ"); VoicedKata.Add(23, "ペ"); VoicedKata.Add(24, "ポ");

            //拗音
            Ao.Add(0, "kya"); Ao.Add(1, "kyu"); Ao.Add(2, "kyo");
            Ao.Add(3, "gya"); Ao.Add(4, "gyu"); Ao.Add(5, "gyo");
            Ao.Add(6, "sha"); Ao.Add(7, "shu"); Ao.Add(8, "sho");
            Ao.Add(9, "cha"); Ao.Add(10, "chu"); Ao.Add(11, "cho");
            Ao.Add(12, "ja"); Ao.Add(13, "ju"); Ao.Add(14, "jo");
            Ao.Add(15, "nya"); Ao.Add(16, "nyu"); Ao.Add(17, "nyo");
            Ao.Add(18, "hya"); Ao.Add(19, "hyu"); Ao.Add(20, "hyo");
            Ao.Add(21, "bya"); Ao.Add(22, "byu"); Ao.Add(23, "byo");
            Ao.Add(24, "pya"); Ao.Add(25, "pyu"); Ao.Add(26, "pyo");
            Ao.Add(27, "mya"); Ao.Add(28, "myu"); Ao.Add(29, "myo");
            Ao.Add(30, "rya"); Ao.Add(31, "ryu"); Ao.Add(32, "ryo");

            //拗音-平假
            AoHira.Add(0, "きゃ"); AoHira.Add(1, "きゅ"); AoHira.Add(2, "きょ");
            AoHira.Add(3, "ぎゃ"); AoHira.Add(4, "ぎゅ"); AoHira.Add(5, "ぎょ");
            AoHira.Add(6, "しゃ"); AoHira.Add(7, "しゅ"); AoHira.Add(8, "しょ");
            AoHira.Add(9, "ちゃ"); AoHira.Add(10, "ちゅ"); AoHira.Add(11, "ちょ");
            AoHira.Add(12, "じゃ"); AoHira.Add(13, "じゅ"); AoHira.Add(14, "じょ");
            AoHira.Add(15, "にゃ"); AoHira.Add(16, "にゅ"); AoHira.Add(17, "にょ");
            AoHira.Add(18, "ひゃ"); AoHira.Add(19, "ひゅ"); AoHira.Add(20, "ひょ");
            AoHira.Add(21, "びゃ"); AoHira.Add(22, "びゅ"); AoHira.Add(23, "びょ");
            AoHira.Add(24, "ぴゃ"); AoHira.Add(25, "ぴゅ"); AoHira.Add(26, "ぴょ");
            AoHira.Add(27, "みゃ"); AoHira.Add(28, "みゅ"); AoHira.Add(29, "みょ");
            AoHira.Add(30, "りゃ"); AoHira.Add(31, "りゅ"); AoHira.Add(32, "りょ");

            //拗音-片假
            AoKata.Add(0, "キャ"); AoKata.Add(1, "キュ"); AoKata.Add(2, "キョ");
            AoKata.Add(3, "ギャ"); AoKata.Add(4, "ギュ"); AoKata.Add(5, "ギョ");
            AoKata.Add(6, "シャ"); AoKata.Add(7, "シュ"); AoKata.Add(8, "ショ");
            AoKata.Add(9, "チャ"); AoKata.Add(10, "チュ"); AoKata.Add(11, "チョ");
            AoKata.Add(12, "ジャ"); AoKata.Add(13, "ジュ"); AoKata.Add(14, "ジョ");
            AoKata.Add(15, "ニャ"); AoKata.Add(16, "ニュ"); AoKata.Add(17, "ニョ");
            AoKata.Add(18, "ヒャ"); AoKata.Add(19, "ヒュ"); AoKata.Add(20, "ヒョ");
            AoKata.Add(21, "ビャ"); AoKata.Add(22, "ビュ"); AoKata.Add(23, "ビョ");
            AoKata.Add(24, "ピャ"); AoKata.Add(25, "ピュ"); AoKata.Add(26, "ピョ");
            AoKata.Add(27, "ミャ"); AoKata.Add(28, "ミュ"); AoKata.Add(29, "ミョ");
            AoKata.Add(30, "リャ"); AoKata.Add(31, "リュ"); AoKata.Add(32, "リョ");
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
            string tempPath = Path.GetTempPath();
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
                    sum += VoicedHira.Count();
                    for (int j = 0; j < VoicedHira.Count(); j++)
                        L.Add(Tuple.Create(a[i], j));
                }
                else if (a[i] == 3)
                {
                    sum += VoicedKata.Count();
                    for (int j = 0; j < VoicedKata.Count(); j++)
                        L.Add(Tuple.Create(a[i], j));
                }
                else if (a[i] == 4)
                {
                    sum += AoHira.Count();
                    for (int j = 0; j < AoHira.Count(); j++)
                        L.Add(Tuple.Create(a[i], j));
                }
                else if (a[i] == 5)
                {
                    sum += AoKata.Count();
                    for (int j = 0; j < AoKata.Count(); j++)
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
            else if (R[0].Item1 == 2) ShowText.Text = VoicedHira[R[0].Item2];
            else if (R[0].Item1 == 3) ShowText.Text = VoicedKata[R[0].Item2];
            else if (R[0].Item1 == 4) ShowText.Text = AoHira[R[0].Item2];
            else if (R[0].Item1 == 5) ShowText.Text = AoKata[R[0].Item2];
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
            VoicedHiraToolStripMenuItem.Checked = false;
            VoicedKataToolStripMenuItem.Checked = false;
            AoHiraToolStripMenuItem.Checked = false;
            AoKataToolStripMenuItem.Checked = false;
            StartToolStripMenuItem.Enabled = true;
            RestartToolStripMenuItem.Enabled = false;
            ExitToolStripMenuItem.Enabled = false;
            QuitToolStripMenuItem.Enabled = true;
            HiraganaToolStripMenuItem.Enabled = true;
            KatakanaToolStripMenuItem.Enabled = true;
            VoicedHiraToolStripMenuItem.Enabled = true;
            VoicedKataToolStripMenuItem.Enabled = true;
            AoHiraToolStripMenuItem.Enabled = true;
            AoKataToolStripMenuItem.Enabled = true;
            MainForm_SizeChanged(sender, e);
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
            if (VoicedHiraToolStripMenuItem.Checked) Lvl[pos++] = 2;
            if (VoicedKataToolStripMenuItem.Checked) Lvl[pos++] = 3;
            if (AoHiraToolStripMenuItem.Checked) Lvl[pos++] = 4;
            if (AoKataToolStripMenuItem.Checked) Lvl[pos++] = 5;

            HiraganaToolStripMenuItem.Enabled = false;
            KatakanaToolStripMenuItem.Enabled = false;
            VoicedHiraToolStripMenuItem.Enabled = false;
            VoicedKataToolStripMenuItem.Enabled = false;
            AoHiraToolStripMenuItem.Enabled = false;
            AoKataToolStripMenuItem.Enabled = false;

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
                Delay(1000);
                if (Over)
                {
                    Submit.ReadOnly = true;
                    break;
                }
            }
            Schedule.Text = string.Format("正确率: {0:P}", 1.0 * CorrectCount / R.Count);
            ShowText.Text = "▶";
            ShowText.Enabled = true;
        }

        private void HiraganaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KatakanaToolStripMenuItem.Checked || VoicedHiraToolStripMenuItem.Checked ||
                VoicedKataToolStripMenuItem.Checked || AoHiraToolStripMenuItem.Checked ||
                AoHiraToolStripMenuItem.Checked || AoKataToolStripMenuItem.Checked)
                HiraganaToolStripMenuItem.Checked = !HiraganaToolStripMenuItem.Checked;
        }

        private void KatakanaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HiraganaToolStripMenuItem.Checked || VoicedHiraToolStripMenuItem.Checked ||
                VoicedKataToolStripMenuItem.Checked || AoHiraToolStripMenuItem.Checked ||
                AoHiraToolStripMenuItem.Checked || AoKataToolStripMenuItem.Checked)
                KatakanaToolStripMenuItem.Checked = !KatakanaToolStripMenuItem.Checked;
        }

        private void VoicedHiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KatakanaToolStripMenuItem.Checked || HiraganaToolStripMenuItem.Checked ||
                VoicedKataToolStripMenuItem.Checked || AoHiraToolStripMenuItem.Checked ||
                AoHiraToolStripMenuItem.Checked || AoKataToolStripMenuItem.Checked)
                VoicedHiraToolStripMenuItem.Checked = !VoicedHiraToolStripMenuItem.Checked;
        }

        private void VoicedKataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KatakanaToolStripMenuItem.Checked || VoicedHiraToolStripMenuItem.Checked ||
                HiraganaToolStripMenuItem.Checked || AoHiraToolStripMenuItem.Checked ||
                AoHiraToolStripMenuItem.Checked || AoKataToolStripMenuItem.Checked)
                VoicedKataToolStripMenuItem.Checked = !VoicedKataToolStripMenuItem.Checked;
        }

        private void AoHiraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KatakanaToolStripMenuItem.Checked || VoicedHiraToolStripMenuItem.Checked ||
                VoicedKataToolStripMenuItem.Checked || HiraganaToolStripMenuItem.Checked ||
                AoHiraToolStripMenuItem.Checked || AoKataToolStripMenuItem.Checked)
                AoHiraToolStripMenuItem.Checked = !AoHiraToolStripMenuItem.Checked;
        }

        private void AoKataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (KatakanaToolStripMenuItem.Checked || VoicedHiraToolStripMenuItem.Checked ||
                VoicedKataToolStripMenuItem.Checked || AoHiraToolStripMenuItem.Checked ||
                AoHiraToolStripMenuItem.Checked || HiraganaToolStripMenuItem.Checked)
                AoKataToolStripMenuItem.Checked = !AoKataToolStripMenuItem.Checked;
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
                BackUpdate.RunWorkerAsync();
            }
            catch
            {
                
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
            StartToolStripMenuItem_Click(sender, e);
        }

        private void BackUpdate_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
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
                                DelayRun(oldName, 2);
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
                }
                else if (R[Count].Item1 <= 3)
                {
                    if (Submit.Text == Voiced[R[Count].Item2]) CorrectCount++;
                    else
                    {
                        WrongCount++;
                        if (R[Count].Item1 == 2)
                            Log.Text += VoicedHira[R[Count].Item2];
                        else if (R[Count].Item1 == 3)
                            Log.Text += VoicedKata[R[Count].Item2];
                        Log.Text += ":  " + Voiced[R[Count].Item2] + Environment.NewLine;
                    }
                }
                else
                {
                    if (Submit.Text == Ao[R[Count].Item2]) CorrectCount++;
                    else
                    {
                        WrongCount++;
                        if (R[Count].Item1 == 4)
                            Log.Text += AoHira[R[Count].Item2];
                        else if (R[Count].Item1 == 5)
                            Log.Text += AoKata[R[Count].Item2];
                        Log.Text += ":  " + Ao[R[Count].Item2] + Environment.NewLine;
                    }
                }
                if (Count + 1 < R.Count)
                {
                    if (R[Count + 1].Item1 == 0) ShowText.Text = Hiragana[R[++Count].Item2];
                    else if (R[Count + 1].Item1 == 1) ShowText.Text = Katakana[R[++Count].Item2];
                    else if (R[Count + 1].Item1 == 2) ShowText.Text = VoicedHira[R[++Count].Item2];
                    else if (R[Count + 1].Item1 == 3) ShowText.Text = VoicedKata[R[++Count].Item2];
                    else if (R[Count + 1].Item1 == 4) ShowText.Text = AoHira[R[++Count].Item2];
                    else if (R[Count + 1].Item1 == 5) ShowText.Text = AoKata[R[++Count].Item2];
                }
                else if (Count + 1 == R.Count)
                {
                    Count++;
                    Submit.ReadOnly = true;
                }
                Submit.Text = "";
                Correct.Text = string.Format("正确: {0:D}", CorrectCount);
                Wrong.Text = string.Format("错误: {0:D}", WrongCount);
                Schedule.Text = string.Format("{0:D} / {1:D}", Count, R.Count);
                if (Count == R.Count)
                {
                    Over = true;
                    return;
                }
            }
        }
    }
}
