using System;
using System.IO;
using System.Linq;

namespace SitecoreInstaller.Framework.IO
{
  using Ionic.Zip;

  using global::System.Diagnostics.Contracts;

  public static class FileInfoExtensions
  {
    public static bool Exists(this FileInfo file)
    {
      if (file == null)
        return false;
      return File.Exists(file.FullName);
    }

    public static bool IsZipfile(this FileInfo file)
    {
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
      Contract.Requires<ArgumentNullException>(file != null);
      Contract.Requires<ArgumentNullException>(newExtension != null);

      return new FileInfo(file.FullNameWithoutExtension() + "." + newExtension);
    }

    public static void MoveTo(this FileInfo source, DirectoryInfo target, bool overwrite)
    {
      if (!source.Exists())
        return;
      var targetFile = target.CombineTo<FileInfo>(source.Name);
      if (overwrite && File.Exists(targetFile.FullName))
        targetFile.Delete();
      source.MoveTo(targetFile.FullName);
    }

    public static void CopyTo(this FileInfo source, Folder target, bool overwrite)
    {
      if (!source.Exists())
        return;
      source.CopyTo(target.Directory, overwrite);
    }

    public static void CopyTo(this FileInfo source, DirectoryInfo target, bool overwrite)
    {
      if (!source.Exists())
        return;

      var targetFile = target.Combine(source);
      target.CreateIfNotExists();
      source.CopyTo(targetFile.FullName, overwrite);
    }
  }
}
