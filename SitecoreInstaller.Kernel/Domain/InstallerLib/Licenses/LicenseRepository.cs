using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.InstallerLib.Licenses
{
    public class LicenseRepository : DirPath, IInitializable
    {
        public LicenseRepository(DirPath parent)
            : base(parent.Add("Licenses").RawPath)
        {
        }

        public IEnumerable<License> GetAll()
        {
            throw new NotImplementedException();
            //return EnumerateFiles().Select(d => new License(d.ToFile()));
        }

        public License Get(string name)
        {
            throw new NotImplementedException();
            var license = new License(this.ToFile(name));
            //return license.Path.Exists() ? license : null;
        }

        public void Init()
        {
            throw new NotImplementedException();
            //CreateIfNotExists();
        }
    }
}
