using System;
using System.IO;

namespace SitecoreInstaller.App
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
            LibraryRootDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".si");
        }

        public string LibraryRootDir { get; set; }
    }
}
