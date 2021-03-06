﻿using DotNet.Basics.IO;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public abstract class EgressAsset : LibraryAsset
    {
        protected EgressAsset(string name, string container, PathType pathType) : base(name, container, pathType)
        {
        }

        public virtual bool Load(DirPath containerDir)
        {
            return containerDir.Add(Name).Exists();
        }
    }
}
