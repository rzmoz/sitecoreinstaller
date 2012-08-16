using System;
using System.Threading;

using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System.IO;
    using System.Net;
    using System.Web;

    using SitecoreInstaller.Framework.Diagnostics;

    public class NothingPipeline : IPipeline
    {
        public void Init()
        {
        }
        [Step(1, Run = Run.OnlyInUi)]
        public void DoNothing(object sender, EventArgs e)
        {
            Log.It.Info("Starting doing nothing...");
        }
        [Step(2)]
        public void DoNothingForAWhile(object sender, EventArgs e)
        {
            /*
            var loginUrl = "http://sdn.sitecore.net/sdn5/misc/loginpage.aspx";
        
            // have a cookie container ready to receive the forms auth cookie
            var cookies = new CookieContainer();

            // first, request the login form to get the viewstate value
            var webRequest = WebRequest.Create(loginUrl) as HttpWebRequest;
            webRequest.CookieContainer = cookies;
            var responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
            string responseData = responseReader.ReadToEnd();
            responseReader.Close();

            // extract the viewstate value and build out POST data
            string viewState = ExtractViewState(responseData);
            string postData =
                  string.Format(
                     "__VIEWSTATE={0}&ctl09$emailTextBox={1}&ctl09$passwordTextBox={2}&ctl09_loginButton=Login",
                     viewState, "rar@sitecore.net", "rarrar"
                  );

            // now post to the login form
            webRequest = WebRequest.Create(loginUrl) as HttpWebRequest;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookies;

            // write the form values into the request message
            StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
            requestWriter.Write(postData);
            requestWriter.Close();

            // we don't need the contents of the response, just the cookie it issues
            webRequest.GetResponse().Close();

            // now we can send out cookie along with a request for the protected page
            webRequest = WebRequest.Create("http://sdn.sitecore.net/downloads/Sitecore650rev120427.download") as HttpWebRequest;
            webRequest.CookieContainer = cookies;
            var fileStream = webRequest.GetResponse().GetResponseStream();
            using (Stream file = File.OpenWrite(@"c:\projects\sc.zip"))
            {
                CopyStream(fileStream, file);
            }
            fileStream.Close();
            */

            for(var i=0;i<10;i++)
                Log.It.Info("Logging...");
            Log.It.Info("Pinging the world!...");
            Thread.Sleep(200);
            Log.It.Debug("Debugging the world!...");
            Thread.Sleep(200);
            Log.It.Warning("Warning the world!...");
            Thread.Sleep(200);
            Log.It.Error("Erroring the world!");
             
            
        }

        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        private string ExtractViewState(string s)
        {
            string viewStateNameDelimiter = "__VIEWSTATE";
            string valueDelimiter = "value=\"";

            int viewStateNamePosition = s.IndexOf(viewStateNameDelimiter);
            int viewStateValuePosition = s.IndexOf(valueDelimiter, viewStateNamePosition);

            int viewStateStartPosition = viewStateValuePosition + valueDelimiter.Length;
            int viewStateEndPosition = s.IndexOf("\"", viewStateStartPosition);

            return HttpUtility.UrlEncodeUnicode(s.Substring(viewStateStartPosition, viewStateEndPosition - viewStateStartPosition));
        }
    }
}
