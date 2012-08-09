using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.IO
{
    using global::System.Text.RegularExpressions;

    public static class FileNameExtensions
    {
        private const string _IllegalFileNameCharactersFormat = @"[\\/:*?""<>|]";
        private static readonly Regex _illegalFileNameCharactersRegex = new Regex(_IllegalFileNameCharactersFormat, RegexOptions.Compiled);
        
        public static string CleanIllegalFileNameChars(this string fileNameWithPossibleIllegalCharacters, string replacer = "")
        {
            return _illegalFileNameCharactersRegex.Replace(fileNameWithPossibleIllegalCharacters, replacer);
        }
    }
}
