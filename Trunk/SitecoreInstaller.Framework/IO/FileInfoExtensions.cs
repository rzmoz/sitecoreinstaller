using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.Web.Publishing.Tasks;

namespace SitecoreInstaller.Framework.IO
{
    using Ionic.Zip;

    using global::System.Diagnostics.Contracts;

    public static class FileInfoExtensions
    {
        public static bool IsZipfile(this FileInfo file)
        {
            if (file == null)
                return false;
            return file.Extension.ToLowerInvariant().EndsWith("zip");
        }
        public static bool IsSitecorePackage(this FileInfo file)
        {
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
            Contract.Requires<ArgumentNullException>(file != null);
            Contract.Requires<ArgumentNullException>(newExtension != null);

            return new FileInfo(file.FullNameWithoutExtension() + "." + newExtension);
        }

        public static void MoveTo(this FileInfo source, DirectoryInfo target, bool overwrite)
        {
            var targetFile = target.CombineTo<FileInfo>(source.Name);
            if (overwrite && File.Exists(targetFile.FullName))
                targetFile.Delete();
            source.MoveTo(targetFile.FullName);
        }

        public static void CopyTo(this FileInfo source, DirectoryInfo target, bool overwrite)
        {
            if (File.Exists(source.FullName) == false)
                return;

            var targetFile = target.Combine(source);
            target.CreateIfNotExists();
            source.CopyTo(targetFile.FullName, overwrite);
        }
    }
}
