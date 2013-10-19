namespace SitecoreInstaller.Framework.IO
{
  using System.Collections.Generic;
  using System.IO;

  public class FileType
  {
    public FileType(string name, string extension)
    {
      Name = name ?? string.Empty;
      Extension = extension ?? string.Empty;
      GetAllSearchPattern = "*" + Extension;
    }

    public string Name { get; private set; }
    public string Extension { get; private set; }

    public bool IsType(FileInfo file)
    {
      if (file == null)
        return false;

      return IsType(file.Name);
    }

    public bool IsType(string filename)
    {
      if (string.IsNullOrEmpty(filename))
        return false;

      return filename.EndsWith(Extension, true, null);
    }

    public string GetAllSearchPattern { get; private set; }
    public IEnumerable<FileInfo> GetFiles(DirectoryInfo directory)
    {
      return directory.GetFiles(GetAllSearchPattern, SearchOption.TopDirectoryOnly);
    }
    public IEnumerable<FileInfo> GetFiles(DirectoryInfo directory, SearchOption searchOption)
    {
      return directory.GetFiles(GetAllSearchPattern, searchOption);
    }
  }
}
