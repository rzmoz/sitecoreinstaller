using System;
using System.IO;

namespace SitecoreInstaller.App
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
            LibraryRootDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ".si");
        }

        public string LibraryRootDir { get; set; }
    }
}
