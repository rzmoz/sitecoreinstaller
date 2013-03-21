using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SitecoreInstaller.Framework.System
{
  public static class StringExtensions
  {
    private const string _Slash = "/";
    private const string _MultipleSlashRegexFormat = "[/]{2,}";
    private static readonly Regex _multipleSlashRegex = new Regex(_MultipleSlashRegexFormat, RegexOptions.Compiled);

    internal static IEnumerable<string> TokenizeWhenCharIsUpper(this string str)
    {
      if (string.IsNullOrEmpty(str))
        return Enumerable.Empty<string>();

      var resolvedName = new StringBuilder();

      foreach (var @char in str.ToArray())
      {
        if (Char.IsUpper(@char))
          resolvedName.Append(' ');
        resolvedName.Append(@char);
      }
      return resolvedName.ToString().Trim().Split(' ');
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
