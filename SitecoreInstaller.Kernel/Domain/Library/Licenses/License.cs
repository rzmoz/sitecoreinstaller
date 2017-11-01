using System;
using System.IO;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library.Licenses
{
    public class License : LibraryResource
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
