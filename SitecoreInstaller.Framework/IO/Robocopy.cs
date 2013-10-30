using System;
using System.IO;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.IO
{
  public class Robocopy : CommandPrompt
  {
    private const string _fileName = @"Robocopy";
    private const string _sourceDestinationFormat = _fileName + @" ""{0}"" ""{1}"" /NP ";
    private const string _includeSubfoldersSwitch = " /e ";
    private const string _moveSwitch = " /move ";

    private void Run(DirectoryInfo source, DirectoryInfo target, string switches)
    {
      if (source == null) { throw new ArgumentNullException("source"); }
      if (target == null) { throw new ArgumentNullException("target"); }

      var command = string.Format(_sourceDestinationFormat, source.FullName, target.FullName);
      command += switches;
      Run(command);
    }

    public void Copy(DirectoryInfo source, DirectoryInfo target, DirCopyOptions dirCopyOptions)
    {
      var switches = string.Empty;
      if (dirCopyOptions == DirCopyOptions.IncludeSubDirectories)
        switches = _includeSubfoldersSwitch;
      Run(source, target, switches);
    }
    public void Move(DirectoryInfo source, DirectoryInfo target)
    {
      Run(source, target, _includeSubfoldersSwitch + _moveSwitch);
      source.Refresh();
      if (source.Exists)
        source.Delete(true);
    }
    public void Move(FileInfo file, DirectoryInfo target)
    {
      Run(file.Directory, target, file.Name + _moveSwitch);
    }
  }
}
