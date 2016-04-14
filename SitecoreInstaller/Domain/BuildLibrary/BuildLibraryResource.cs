﻿using System;
using System.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public abstract class BuildLibraryResource<T> : IBuildLibraryResource where T : FileSystemInfo
    {
        protected BuildLibraryResource(T fsi, BuildLibraryType buildLibraryType)
        {
            if (fsi == null) throw new ArgumentNullException(nameof(fsi));
            FileSystemInfo = fsi;
            BuildLibraryType = buildLibraryType;

            var fi = fsi as FileInfo;
            if (fi != null)
            {
                Directory = fi.Directory;
                IOType = IoType.File;
            }
            var di = fsi as DirectoryInfo;
            if (di != null)
            {
                Directory = di;
                IOType = IoType.Dir;
            }
        }

        public string Name => FileSystemInfo.Name;
        public DirectoryInfo Directory { get; }
        public string FullName => FileSystemInfo.FullName;
        public BuildLibraryType BuildLibraryType { get; }
        public IoType IOType { get; }
        public FileSystemInfo FileSystemInfo { get; }
    }
}
