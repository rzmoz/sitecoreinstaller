using System;
using System.IO;
using System.Linq;
using DotNet.Basics.IO;
using System.IO.Compression;

namespace SitecoreInstaller.Domain
{
    public static class FileExtensions
    {
        public static bool IsZipfile(this FileInfo file)
        {
            if (file == null)
                return false;
            if (!file.Exists())
                return false;
            return file.Extension.EndsWith("zip", StringComparison.OrdinalIgnoreCase);
        }

        public static bool IsSitecorePackage(this FileInfo file)
        {
            if (!file.Exists())
                return false;
            if (file.IsZipfile() == false)
                return false;

            throw new NotImplementedException();/*
            using (var zipFile = new ZipFile(file.FullName))
            {
                if (zipFile.Entries.Count != 1)
                    return false;
                return zipFile.Entries.First().FileName.Equals("package.zip");
            }*/
        }
    }
}
