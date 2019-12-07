using LicenseExamination;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CS_GUI_DEMO
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
			LoadResoureDll.RegistDLL();
			if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
	public class Author
	{
		public string login { get; set; }
		public string id { get; set; }
		public string node_id { get; set; }
		public string avatar_url { get; set; }
		public string gravatar_id { get; set; }
		public string url { get; set; }
		public string html_url { get; set; }
		public string followers_url { get; set; }
		public string following_url { get; set; }
		public string gists_url { get; set; }
		public string starred_url { get; set; }
		public string subscriptions_url { get; set; }
		public string organizations_url { get; set; }
		public string repos_url { get; set; }
		public string events_url { get; set; }
		public string received_events_url { get; set; }
		public string type { get; set; }
		public string site_admin { get; set; }
	}

	public class Uploader
	{
		public string login { get; set; }
		public string id { get; set; }
		public string node_id { get; set; }
		public string avatar_url { get; set; }
		public string gravatar_id { get; set; }
		public string url { get; set; }
		public string html_url { get; set; }
		public string followers_url { get; set; }
		public string following_url { get; set; }
		public string gists_url { get; set; }
		public string starred_url { get; set; }
		public string subscriptions_url { get; set; }
		public string organizations_url { get; set; }
		public string repos_url { get; set; }
		public string events_url { get; set; }
		public string received_events_url { get; set; }
		public string type { get; set; }
		public string site_admin { get; set; }
	}

	public class Assets
	{
		public string url { get; set; }
		public string id { get; set; }
		public string node_id { get; set; }
		public string name { get; set; }
		public string label { get; set; }
		public Uploader uploader { get; set; }
		public string content_type { get; set; }
		public string state { get; set; }
		public string size { get; set; }
		public string download_count { get; set; }
		public string created_at { get; set; }
		public string updated_at { get; set; }
		public string browser_download_url { get; set; }
	}

	public class RootObject
	{
		public string url { get; set; }
		public string assets_url { get; set; }
		public string upload_url { get; set; }
		public string html_url { get; set; }
		public string id { get; set; }
		public string node_id { get; set; }
		public string tag_name { get; set; }
		public string target_commitish { get; set; }
		public string name { get; set; }
		public string draft { get; set; }
		public Author author { get; set; }
		public string prerelease { get; set; }
		public string created_at { get; set; }
		public string published_at { get; set; }
		public List<Assets> assets { get; set; }
		public string tarball_url { get; set; }
		public string zipball_url { get; set; }
		public string body { get; set; }
	}
}
