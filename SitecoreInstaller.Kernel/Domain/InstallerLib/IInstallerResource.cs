using System;
using System.Collections.Generic;
using System.Text;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.InstallerLib
{
    public interface IInstallerResource
    {
        string Name { get; }
        PathInfo Path { get; }
    }
}
