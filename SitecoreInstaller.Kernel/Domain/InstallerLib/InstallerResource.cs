﻿using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.InstallerLib
{
    public abstract class InstallerResource : IInstallerResource
    {
        public string Name => Path.Name;
        public PathInfo Path { get; set; }
    }
}
