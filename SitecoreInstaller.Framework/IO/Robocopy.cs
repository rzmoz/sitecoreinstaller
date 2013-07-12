using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.IO
{
  using SitecoreInstaller.Framework.Sys;
  using global::System.IO;

  public class Robocopy : CommandPrompt
  {
    private const string _FileName = @"Robocopy";
    private const string _SourceDestinationFormat = _FileName + @" ""{0}"" ""{1}"" /NP ";
    private const string _IncludeSubfoldersSwitch = " /e ";
    private const string _MoveSwitch = " /move ";

    private void Run(DirectoryInfo source, DirectoryInfo target, string switches)
    {
      if (source == null) { throw new ArgumentNullException("source"); }
      if (target == null) { throw new ArgumentNullException("target"); }

      var command = string.Format(_SourceDestinationFormat, source.FullName, target.FullName);
      command += switches;
      Run(command);
    }

    public void Copy(DirectoryInfo source, DirectoryInfo target, DirCopyOptions dirCopyOptions)
    {
      var switches = string.Empty;
      if (dirCopyOptions == DirCopyOptions.IncludeSubDirectories)
        switches = _IncludeSubfoldersSwitch;
      Run(source, target, switches);
    }
    public void Move(DirectoryInfo source, DirectoryInfo target)
    {
      Run(source, target, _IncludeSubfoldersSwitch + _MoveSwitch);
      source.Refresh();
      if (source.Exists)
        source.Delete(true);
    }
    public void Move(FileInfo file, DirectoryInfo target)
    {
      Run(file.Directory, target, file.Name + _MoveSwitch);
    }
  }
}
