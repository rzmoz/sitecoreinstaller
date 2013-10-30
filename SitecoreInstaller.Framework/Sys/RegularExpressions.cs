using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.Sys
{
  public static class RegularExpressions
  {

    private const string _notNumbersOnlyPattern = @"[^0-9]";
    private static readonly Regex _notNumbersOnlyRegex = new Regex(_notNumbersOnlyPattern, RegexOptions.Compiled);

    /// <summary>
    /// Get numbers in string. 
    /// </summary>
    /// <param name="str"></param>
    /// <returns>Returns -1 if no numbers are found</returns>
    public static Int64 GetNumbers(this string str)
    {
      if (string.IsNullOrEmpty(str))
        return -1;

      var numbersString = _notNumbersOnlyRegex.Replace(str, string.Empty);
      if (string.IsNullOrEmpty(numbersString))
        return -1;

      return Int64.Parse(numbersString);
    }
  }
}
