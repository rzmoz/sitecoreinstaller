﻿using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Infrastructure.Library;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRepository : DirPath, IInitializable
    {
        public SitecoreInstallerRepository(LibraryConfig libraryConfig)
            : base(libraryConfig.DataDirRoot.Add("SitecoreInstaller").RawPath)
        {
        }
        
        public void Init()
        {
            
            
        }
    }
}