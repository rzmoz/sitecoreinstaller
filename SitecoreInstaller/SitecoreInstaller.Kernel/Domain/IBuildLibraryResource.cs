﻿using CSharp.Basics.IO;

namespace SitecoreInstaller.Kernel.Domain
{
    public interface IBuildLibraryResource
    {
        IoDir SourceDir { get; }
    }
}
