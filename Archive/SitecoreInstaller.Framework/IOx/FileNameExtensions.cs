﻿using System.Text.RegularExpressions;

namespace SitecoreInstaller.Framework.IOx
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
