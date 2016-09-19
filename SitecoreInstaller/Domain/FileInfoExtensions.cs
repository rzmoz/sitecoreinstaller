using System;
using System.IO;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain
{
    public static class FileInfoExtensions
    {
        public static bool IsZipfile(this FilePath file)
        {
            if (file == null)
                return false;
            if (!file.Exists())
                return false;
            return file.IsFileType(RegisteredFileTypes.ZipArchive);
        }

        public static bool IsSitecorePackage(this FilePath file)
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
