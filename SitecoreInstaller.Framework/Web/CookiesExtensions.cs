namespace SitecoreInstaller.Framework.Web
{
  using System.Linq;

  public static class CookiesExtensions
  {
    public static string GetCookie(this string cookies, string cookieName)
    {
      return cookies.Split(';').Single(s => s.Split('=')[0].Trim().Equals(cookieName)).Trim();
    }

    public static string GetCookieValue(this string cookies, string cookieName)
    {
      string cookie = GetCookie(cookies, cookieName);
      if (string.IsNullOrEmpty(cookie))
      {
        return null;
      }

      return cookie.Split('=')[1].Trim();
    }
  }
}
