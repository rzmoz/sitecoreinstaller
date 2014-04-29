using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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

        public static FileInfo WithNewExtension(this FileInfo file, string newExtension)
        {
            if (file == null) { throw new ArgumentNullException("file"); }
            if (newExtension == null) { throw new ArgumentNullException("newExtension"); }

            return new FileInfo(file.FullNameWithoutExtension() + "." + newExtension);
        }

        public static void CopyTo(this FileInfo source, Folder target, bool overwrite)
        {
            source.CopyTo(target.Directory, overwrite);
        }

        public static void CopyTo(this IEnumerable<FileInfo> files, Folder target, bool overwrite)
        {
            foreach (var file in files)
            {
                file.CopyTo(target, overwrite);
            }
        }
    }
}
