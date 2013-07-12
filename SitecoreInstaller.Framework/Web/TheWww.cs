using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.Web
{
  using System.Net;
  using System.Threading;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Sys;

  public class TheWww
  {
    public static void CallUrl(Uri url, int retryCount = 100)
    {
      for (var tryCount = 1; tryCount <= retryCount; tryCount++)
      {
        var response = CallUrlOnce(url);
        if (response != null && response.StatusCode == HttpStatusCode.OK)
        {
          Log.This.Debug("'{0}' responded: '{1}'", url.ToString(), response.StatusDescription);
          return;
        }
      }
      Log.This.Error("'{0}' never responded OK.", url.ToString());
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
        webRequest.Timeout = (1000 * 60 * 30); //30 minutes in miliseconds
        return (HttpWebResponse)webRequest.GetResponse();
      }
      catch (WebException we)
      {
        Log.This.Debug(we.ToString());
        return null;
      }
    }

    public static void OpenInBrowser(Uri url)
    {
      const string openBrowserFormat = @"""start"" {0}";
      var command = string.Format(openBrowserFormat, url);
      var cmd = new CommandPrompt();
      cmd.Run(command);
    }
  }
}
