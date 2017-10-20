using System.IO;
using DotNet.Basics.IO;

namespace SitecoreInstaller.BuildLibrary
{
    public class License : BuildLibraryResource
    {
        public License(FilePath path) : base(path)
        {
        }

        public LicenseInfo GetInfo()
        {
            if (Path.Exists() == false)
                throw new IOException();

            return LicenseInfo.Load(Path.ToFile());
        }
    }
}
