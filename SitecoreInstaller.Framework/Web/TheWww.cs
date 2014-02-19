using System;
using System.IO;
using System.Net;
using System.Threading;
using CSharp.Basics.Sys.Tasks;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.Web
{

    public class TheWww
    {
        /// <summary>
        /// Far small to medium files => use Curl.Download for larger files (1MB+)
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="targetFile"></param>
        /// <param name="timeoutInMs"></param>
        public static void DownloadFile(Uri uri, FileInfo targetFile, int timeoutInMs = 5000)
        {
            var wc = new WebClient();
            wc.DownloadFile(uri, targetFile.FullName);
        }

        public static void CallUrl(Uri url, int retryCount = 100)
        {
            const int maxRetries = 50;

            HttpWebResponse response = null;
            var succeeded = Do.This(() =>
            {
                response = null;
                response = CallUrlOnce(url);
            }).WithPing(() =>
            {
                if (response == null)
                    return;
                Log.ToApp.Info(response.StatusDescription);
            })
            .Until(() => (response != null && response.StatusCode == HttpStatusCode.OK), maxRetries);

            if (!succeeded)
                Log.ToApp.Error("'{0}' never responded OK.", url.ToString());
        }

        public static void CallUrlOnceNoWait(Uri uri)
        {
            ThreadPool.QueueUserWorkItem(t => CallUrlOnce(uri));
        }

        public static HttpWebResponse CallUrlOnce(Uri url)
        {
            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(url.ToString());
                webRequest.AllowAutoRedirect = false;
                webRequest.Timeout = (int)TimeSpan.FromMinutes(30).TotalMilliseconds;
                return (HttpWebResponse)webRequest.GetResponse();
            }
            catch (WebException we)
            {
                Log.ToApp.Debug(we.ToString());
                return null;
            }
        }

        public static void OpenInBrowser(Uri url)
        {
            const string openBrowserFormat = @"""start"" {0}";
            var command = string.Format(openBrowserFormat, url);
            CommandPrompt.Run(command);
        }
    }
}
