﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain
{
  using System.IO;
  using SitecoreInstaller.Domain.Projects;
  using SitecoreInstaller.Domain.Website;
  using SitecoreInstaller.Framework.Configuration;
  using SitecoreInstaller.Framework.IO;

  public class ProjectFolder : Folder
  {
    private const string _ProjectSettingsConfigFileName = "ProjectSettings.config";

    private const string _DataFolderName = "Data";

    private const string _DatabasesFolderName = "Databases";
    private const string _WebsiteFolderName = "Website";
    private const string _IisLogFilesFolderName = "IisLogFiles";

    public ProjectFolder(DirectoryInfo directory)
      : base(directory)
    {
      Website = new WebsiteFolder(Directory.CombineTo<DirectoryInfo>(_WebsiteFolderName));
      Databases = Directory.CombineTo<DirectoryInfo>(_DatabasesFolderName);
      IisLogFiles = Directory.CombineTo<DirectoryInfo>(_IisLogFilesFolderName);
      ProjectSettingsConfigFile = new ConfigFile<ProjectSettingsConfig>(Directory.CombineTo<FileInfo>(_ProjectSettingsConfigFileName));
      Data = new DataFolder(Directory.CombineTo<DirectoryInfo>(_DataFolderName));
    }

    public DataFolder Data { get; private set; }
    public DirectoryInfo Databases { get; private set; }
    public WebsiteFolder Website { get; private set; }
    public DirectoryInfo IisLogFiles { get; private set; }
    public ConfigFile<ProjectSettingsConfig> ProjectSettingsConfigFile { get; private set; }
  }
}