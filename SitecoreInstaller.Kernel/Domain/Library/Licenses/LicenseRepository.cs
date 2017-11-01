using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library.Licenses
{
    public class LicenseRepository : DirPath, IInitializable
    {
        public LicenseRepository(DirPath parent)
            : base(parent.Add("Licenses").RawPath)
        {
        }
        
        public void Init()
        {
            throw new NotImplementedException();
            //CreateIfNotExists();
        }
    }
}
