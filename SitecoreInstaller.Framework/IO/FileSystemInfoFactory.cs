using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.IO
{
    using Sys;

    using System.IO;

    public class FileSystemInfoFactory
    {
        public T Create<T>(string path) where T : FileSystemInfo
        {
            var type = typeof(T);
            FileSystemInfo combined = null;
            if (type.Is<DirectoryInfo>())
                combined = new DirectoryInfo(path);
            else if (type.Is<FileInfo>())
                combined = new FileInfo(path);
            return (T)combined;
        }
    }
}
