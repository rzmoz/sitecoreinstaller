using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Network
{
  using SitecoreInstaller.Framework.Sys;

  using global::System.IO;

  public class Curl : CommandPrompt
  {
    private const string _FileName = @"curl.exe";
    private const string _Format = _FileName + @" ";

    public Curl(DirectoryInfo targetFolder)
    {
      TargetFolder = targetFolder;
    }

    public void Download(string url)
    {
      if (url == null) { throw new ArgumentNullException("url"); }
    }

    public DirectoryInfo TargetFolder { get; private set; }

  }
}
