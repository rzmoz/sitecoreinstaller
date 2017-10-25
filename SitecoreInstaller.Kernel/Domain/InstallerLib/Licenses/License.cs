using System;
using System.IO;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.InstallerLib.Licenses
{
    public class License : InstallerResource
    {
        public License(FilePath path)
        {
            Path = path;
        }

        public LicenseInfo GetInfo()
        {
            throw new NotImplementedException();
            /*
            if (Path.Exists() == false)
                throw new IOException();

            return LicenseInfo.Load(Path.ToFile());
            */
        }
    }
}
