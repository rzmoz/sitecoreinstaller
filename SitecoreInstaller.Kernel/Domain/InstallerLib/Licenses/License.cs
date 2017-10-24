using System.IO;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.InstallerLib.Licenses
{
    public class License : InstallerResource
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
