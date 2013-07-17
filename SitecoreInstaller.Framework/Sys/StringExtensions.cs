using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Sys
{
  public static class StringExtensions
  {
    public static string ToSpaceDelimiteredString(this string str)
    {
      return str.TokenizeWhenCharIsUpper().ToDelimiteredString();
    }

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
  }
}
