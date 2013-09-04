using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.Sys.Security
{
  using System.Net;
  using System.Security;
  using mshtml;

  public class SitecoreSDN
  {
    private System.Windows.Controls.WebBrowser webBrowser;

    private const string loginUrl = "http://sdn.sitecore.net/sdn5/misc/loginpage.aspx";

    public string GetAuthenticationCookie(string username, string password)
    {
      string cookies = null;
      this.webBrowser.LoadCompleted += (o1, args1) => cookies = GetCookies(username, password);
      this.webBrowser.Navigate(loginUrl);
      return cookies;
    }


    private string GetCookies(string login, string password)
    {
      var htmlDocument = this.webBrowser.Document;
      if (TryLogin((IHTMLDocument3)htmlDocument, login, password))
      {
        return null;
      }
      var authCookie = GetAuthCookie((IHTMLDocument2)htmlDocument);

      var session = GetSessionCookie(authCookie);

      return MakeValidCookie(authCookie, session);
    }

    private static string MakeValidCookie(string authCookie, string session)
    {
      return authCookie + "; " + session;
    }

    private static bool TryLogin(IHTMLDocument3 doc, string login, string password)
    {
      var email = doc.getElementById("ctl09_emailTextBox");
      if (email != null)
      {
        email.setAttribute("value", login);
        doc.getElementById("ctl09_passwordTextBox").setAttribute("value", password);
        doc.getElementById("ctl09_loginButton").click();
        return true;
      }

      return false;
    }

    private static string GetAuthCookie(IHTMLDocument2 doc)
    {
      string cookie = doc.cookie;

      if (string.IsNullOrEmpty(cookie))
      {
        throw new SecurityException("Authentication failed - the credentials seems to be invalid");
      }

      return cookie.Split(';').Single(s => s.Trim().Split('=')[0].Equals("sc_infrastructure_login"));
    }

    private static string GetSessionCookie(string authCookie)
    {
      var wc = WebRequest.Create(loginUrl) as HttpWebRequest;
      wc.AllowAutoRedirect = false;
      wc.Headers.Add(HttpRequestHeader.Cookie, authCookie);
      using (var response = wc.GetResponse())
      {
        var cookies = response.Headers[HttpResponseHeader.SetCookie];
        return cookies.GetCookie("ASP.NET_SessionId");
      }
    }
  }
}
