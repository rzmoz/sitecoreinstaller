﻿namespace SitecoreInstaller.App
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Runtime.Serialization;

  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Domain.Database;
  using SitecoreInstaller.Domain.WebServer;
  using SitecoreInstaller.Domain.Website;
  using SitecoreInstaller.Framework.IO;
  using SitecoreInstaller.Domain;
  using SitecoreInstaller.Framework.Sys;

  /// <summary>
  /// Not thread safe!
  /// </summary>
  [DataContract]
  public class ProjectSettings
  {
    private readonly Observable<string> _projectName;
    private UserPreferencesConfig _userPreferences;

    public event EventHandler<GenericEventArgs<string>> Updated;

    public ProjectSettings()
    {
      _projectName = new Observable<string>();
      _projectName.Updated += this.ProjectNameUpdated;
      Reset();
    }

    public void Init(UserPreferencesConfig userPreferences)
    {
      _userPreferences = userPreferences;
      this.SetSystemPaths();
      Sql.InstanceName = userPreferences.SqlInstanceName;
      Sql.Login = userPreferences.SqlLogin;
      Sql.Password = userPreferences.SqlPassword;
    }

    void ProjectNameUpdated(object sender, GenericEventArgs<string> e)
    {
      ResolveDependentPaths();
      if (this.Updated != null)
        this.Updated(sender, e);
    }

    public bool ProjectNameIsSet { get { return !string.IsNullOrEmpty(ProjectName); } }

    public string ProjectName
    {
      get { return _projectName.Value; }
      set { _projectName.Value = value; }
    }

    public InstallType InstallType { get; set; }

    public BuildLibrarySelections BuildLibrarySelections { get; set; }
    public SqlSettings Sql { get; set; }
    public IisSettings Iis { get; set; }
    public ProjectFolder ProjectFolder { get; set; }

    public IEnumerable<ConnectionStringName> DatabaseNames { get; set; }

    private void Reset()
    {
      _projectName.Reset();
      DatabaseNames = Enumerable.Empty<ConnectionStringName>();
      InstallType = InstallType.Full;
      Iis = new IisSettings();
      ProjectFolder = new ProjectFolder(new DirectoryInfo(@"K:\"));
      BuildLibrarySelections = new BuildLibrarySelections();
      Sql = new SqlSettings();
    }

    private void ResolveDependentPaths()
    {
      SetSystemPaths();
      Iis.Name = ProjectName;
    }

    private void SetSystemPaths()
    {
      if (_userPreferences == null)
        throw new NotSupportedException("User preferences has not been set. Call Init(UserPreferencesConfig) first");

      var projectfolder = new DirectoryInfo(_userPreferences.ProjectsFolder);
      if (ProjectNameIsSet)
        projectfolder = projectfolder.CombineTo<DirectoryInfo>(ProjectName);
      ProjectFolder = new ProjectFolder(projectfolder);
      Iis.Url = ProjectName + _userPreferences.IisSitePostfix;
    }
  }
}