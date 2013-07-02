using System;

namespace SitecoreInstaller.Framework.Archiving
{
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.IO;
  using SitecoreInstaller.Framework.System;

  using global::System.IO;

  public class SevenZipFile : CommandPrompt
  {
    private const string _FileName = @"7za.exe";
    private const string _ExtractSwitch = @" x ""{0}"" ""-o{1}"" -y -r -mmt";
    private const string _ArchiveSwitch = @" a -tzip ""{0}"" ""{1}\*"" -y -r -mmt";

    private const string _RunFormat = @" ";

    public FileInfo File { get; private set; }

    public SevenZipFile(FileInfo zipFile)
    {
      if (zipFile == null) { throw new ArgumentNullException("zipFile"); }

      File = zipFile;
      if (File.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase) == false)
        File = new FileInfo(File.FullName + ".zip");
    }

    public void ExtractAll(DirectoryInfo target)
    {
      if (target == null){throw new ArgumentNullException("target");}

      if (global::System.IO.File.Exists(File.FullName) == false)
      {
        Log.This.Error("File not found for extrating: {0}", File.FullName);
        return;
      }

      target.CreateIfNotExists();

      Run(_FileName + _ExtractSwitch + _RunFormat, File.FullName, target.FullName);
    }

    public void ZipContent(DirectoryInfo folder)
    {
      var fileName = File.Name;

      var target = folder.CombineTo<DirectoryInfo>(fileName);

      Run(_FileName + _ArchiveSwitch + _RunFormat, target.FullName, folder.FullName);
    }
  }
}
