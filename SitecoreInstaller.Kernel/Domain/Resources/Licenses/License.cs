using System.IO;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.Resources.Licenses
{
    public class License : InstallerResource<FilePath>
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
