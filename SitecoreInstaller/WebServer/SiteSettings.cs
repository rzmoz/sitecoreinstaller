using System;
using DotNet.Basics.IO;

namespace SitecoreInstaller.WebServer
{
    public class SiteSettings
    {
        private const string _bindingInformationFormat = "*:80:{0}";

        public SiteSettings(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            Name = name;
            Url = string.Empty;
            SiteRoot = @"c:\inetpub\sciroot".ToDir(name);
            IisLogFilesDir = SiteRoot.Add("IisLogFiles");
        }

        public string Name { get; set; }
        public string Url { get; set; }
        public string BindingInformation => string.Format(_bindingInformationFormat, Url);
        public DirPath SiteRoot { get; set; }
        public DirPath IisLogFilesDir { get; set; }
    }
}
