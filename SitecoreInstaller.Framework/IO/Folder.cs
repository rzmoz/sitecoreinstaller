using System;

namespace SitecoreInstaller.Framework.IO
{
  using System.IO;

  public class Folder
  {
    public Folder(DirectoryInfo directory)
    {
      if (directory == null) { throw new ArgumentNullException("directory"); }

      Directory = directory;
    }

    public string FullName { get { return Directory.FullName; } }
    public string Name { get { return Directory.Name; } }
    public DirectoryInfo Directory { get; private set; }

    public override string ToString()
    {
      return Directory.ToString();
    }
  }
}
