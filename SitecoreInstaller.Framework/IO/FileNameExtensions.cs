using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SitecoreInstaller.Framework.IO
{
    public static class FileNameExtensions
    {
        private const string _illegalFileNameCharactersFormat = @"[\\/:*?""<>|]";
        private static readonly Regex _illegalFileNameCharactersRegex = new Regex(_illegalFileNameCharactersFormat, RegexOptions.Compiled);

        public static string CleanIllegalFileNameChars(this string fileNameWithPossibleIllegalCharacters, string replacer = "")
        {
            return _illegalFileNameCharactersRegex.Replace(fileNameWithPossibleIllegalCharacters, replacer);
        }
    }
}
