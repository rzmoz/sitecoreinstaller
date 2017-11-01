using System;
using System.Collections.Generic;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library.Sitecores
{
    public class Sitecore9Repository : DirPath, IInitializable
    {
        public Sitecore9Repository(DirPath parent)
            : base(parent.Add("Sitecore9s").RawPath)
        {
        }

        
        public void Init()
        {
            throw new NotImplementedException();
        }
    }
}
