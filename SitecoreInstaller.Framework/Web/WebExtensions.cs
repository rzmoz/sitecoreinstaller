using System;

namespace SitecoreInstaller.Framework.Web
{
  using System.Text.RegularExpressions;
  using SitecoreInstaller.Framework.Diagnostics;

  public static class WebExtensions
  {
    private const string _Slash = "/";
    private const string _MultipleSlashRegexFormat = "[/]{2,}";
    private static readonly Regex _multipleSlashRegex = new Regex(_MultipleSlashRegexFormat, RegexOptions.Compiled);
    
    public static Uri ToUri(this string baseUrl, params string[] subPaths)
    {
      if (baseUrl == null) { throw new ArgumentNullException("baseUrl"); }
      if (subPaths == null) { throw new ArgumentNullException("subPaths"); }

      try
      {
        var url = new Url(baseUrl, subPaths);
        return url.Uri;
      }
      catch (UriFormatException e)
      {
        Log.ToApp.Error(e.ToString());
        throw;
      }
    }

    public static string UrlCombine(this string str, params string[] paths)
    {
      foreach (var path in paths)
      {
        str += "/" + path;
      }
      str = str.Replace(@"\", _Slash);
      return _multipleSlashRegex.Replace(str, _Slash);
    }
  }
}
