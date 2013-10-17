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
      Log.As.Info("Cleaning project for archiving '{0}'", projectFolder.Name);
      projectFolder.IisLogFiles.Clean(OnFail.Ignore);
      projectFolder.Data.Viewstate.Clean(OnFail.Ignore);
      projectFolder.Data.Logs.Clean(OnFail.Ignore);
      projectFolder.Data.Audit.Clean(OnFail.Ignore);
      projectFolder.Data.Packages.Clean(OnFail.Ignore);
      projectFolder.Website.Temp.Clean(OnFail.Ignore);
      projectFolder.ProjectSettingsConfigFile.Path.Delete();
      projectFolder.Data.LicenseFile.Delete();
    }

    public void DeleteProject(DirectoryInfo projectFolder)
    {
      Log.As.Info("Deleting project '{0}'", projectFolder.Name);

      projectFolder.DeleteWithLog();

      if (projectFolder.Exists() == false)
        Log.As.Info("Project deleted");
    }

    public void CreateProject(DirectoryInfo projectFolder)
    {
      if (projectFolder == null) { throw new ArgumentNullException("projectFolder"); }
      projectFolder.CreateWithLog();
    }
  }
}
