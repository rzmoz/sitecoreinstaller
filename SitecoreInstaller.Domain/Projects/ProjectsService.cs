using System;
using CSharp.Basics.IO;
using System.Collections.Generic;
using System.IO;
using SitecoreInstaller.Framework.IOx;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.Projects
{
    public class ProjectsService
    {
        private readonly DirectoryInfo _projectsFolder;

        public ProjectsService(string projectsFolder)
        {
            _projectsFolder = projectsFolder.ToDirectoryInfo();
        }
        public IEnumerable<DirectoryInfo> GetExistingProjects()
        {
            return _projectsFolder.GetSubFolders("Existing project");
        }

        public void CleanProjectForArchiving(ProjectFolder projectFolder)
        {
            Log.As.Info("Cleaning project for archiving '{0}'", projectFolder.Name);
            projectFolder.IisLogFiles.Clean();
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
