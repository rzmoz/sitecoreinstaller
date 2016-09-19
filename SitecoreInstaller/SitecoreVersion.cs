using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SitecoreInstaller
{
    public class SitecoreVersion
    {
        public SitecoreVersion(string version)
        {
            if (version == null)
                throw new FormatException(nameof(version));

            Regex regex = new Regex(@"(?<Name>[^.]+)\s(?<Major>\d+)?(\.(?<Minor>\d+))?(\srev\.\s?(?<Revision>[^.]+))?", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            version = version.Trim();
            //add 1 space char if it's only name (this is to make regex pattern simpler)
            //this cannot distinguish between sitecore 17 (name) and sitecore 17 (name & major)
            //so digits and spaces are mutually exclusive for names
            if (version.IndexOf(' ') < 0 || (version.IndexOf(' ') > -1 && version.Count(c => char.IsDigit(c)) == 0))
                version += " ";
            var match = regex.Match(version);
            if (!match.Success)
                throw new FormatException(nameof(version));
            if (match.Groups[nameof(Name)].Success)
                Name = match.Groups[nameof(Name)].Value;
            if (match.Groups[nameof(Major)].Success)
                Major = int.Parse(match.Groups[nameof(Major)].Value);
            if (match.Groups[nameof(Minor)].Success)
                Minor = int.Parse(match.Groups[nameof(Minor)].Value);
            if (match.Groups[nameof(Revision)].Success)
                Revision = match.Groups[nameof(Revision)].Value;
            else
                Revision = null;
        }

        public SitecoreVersion(string name = null, int? major = null, int? minor = null, string revision = null)
        {
            Name = name;
            Major = major;
            Minor = minor;
            Revision = revision;
        }

        public string Name { get; set; }
        public int? Major { get; set; }
        public int? Minor { get; set; }
        public string Revision { get; set; }

        public override string ToString()
        {
            var version = string.Empty;
            if (Name != null)
                version += $"{Name}";
            if (Major != null)
                version += $" {Major}";
            if (Minor != null)
            {
                if (Major == null)
                    version += " ";
                version += $".{Minor}";
            }

            if (Revision != null)
                version += $" rev. {Revision}";

            version = version.Trim(' ');

            return version;
        }
    }
}
