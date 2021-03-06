﻿using System.IO;
using System.Linq;
using CSharp.Basics.IO;
using Ionic.Zip;

namespace SitecoreInstaller.Framework.IOx
{
    public static class FileInfoExtensions
    {
        public static bool IsZipfile(this FileInfo file)
        {
            if (file == null)
                return false;
            if (!file.Exists())
                return false;
            return file.Extension.ToLowerInvariant().EndsWith("zip");
        }

        public static bool IsSitecorePackage(this FileInfo file)
        {
            if (!file.Exists())
                return false;
            if (file.IsZipfile() == false)
                return false;
            using (var zipFile = new ZipFile(file.FullName))
            {
                if (zipFile.Entries.Count != 1)
                    return false;
                return zipFile.Entries.First().FileName.Equals("package.zip");
            }
        }
    }
}
