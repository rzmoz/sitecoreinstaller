using System;
using System.Collections.Generic;
using System.Text;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.InstallerLib
{
    public interface IInstallerResource
    {
        string Name { get; }
        PathInfo Path { get; }
    }
}
