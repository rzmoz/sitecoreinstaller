using System.Linq;
using DotNet.Basics.IO;
using Ionic.Zip;

namespace SitecoreInstaller.Kernel.Domain
{
    public static class FileExtensions
    {
        public static bool IsZipfile(this IoFile file)
        {
            if (file == null)
                return false;
            if (!file.Exists())
                return false;
            return file.Extension.ToLowerInvariant().EndsWith("zip");
        }

        public static bool IsSitecorePackage(this IoFile file)
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
