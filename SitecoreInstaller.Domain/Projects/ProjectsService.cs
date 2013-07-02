using System;
using System.Collections.Generic;
using System.IO;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain.Projects
{
  using SitecoreInstaller.Framework.Diagnostics;

  public class ProjectsService
  {
    private readonly DirectoryInfo _projectsFolder;

    public ProjectsService(string projectsFolder)
    {
      _projectsFolder = new DirectoryInfo(projectsFolder);
    }
    public IEnumerable<DirectoryInfo> GetExistingProjects()
    {
      return _projectsFolder.GetSubFolders("Existing project");
    }

    public void CleanProjectForArchiving(ProjectFolder projectFolder)
    {
      Log.This.Info("Cleaning project for archiving '{0}'", projectFolder.Name);
      projectFolder.IisLogFiles.DeleteWithLog();
      projectFolder.Data.Viewstate.Clean();
      projectFolder.Data.Logs.Clean();
      projectFolder.Data.Audit.Clean();
      projectFolder.Data.Packages.Clean();
      projectFolder.Website.Temp.Clean();
      projectFolder.ProjectSettingsConfigFile.Path.Delete();
      projectFolder.Data.LicenseFile.Delete();
    }

    public void DeleteProject(DirectoryInfo projectFolder)
    {
      Log.This.Info("Deleting project '{0}'", projectFolder.Name);

      projectFolder.DeleteWithLog();

      if (projectFolder.Exists() == false)
        Log.This.Info("Project deleted");
    }

    public void CreateProject(DirectoryInfo projectFolder)
    {
      if (projectFolder == null) { throw new ArgumentNullException("projectFolder"); }
      projectFolder.CreateWithLog();
    }
  }
}
