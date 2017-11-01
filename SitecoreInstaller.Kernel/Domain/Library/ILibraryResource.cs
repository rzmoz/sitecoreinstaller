using System;
using System.Collections.Generic;
using System.Text;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public interface ILibraryResource
    {
        string Name { get; }
        PathInfo Path { get; }
    }
}
