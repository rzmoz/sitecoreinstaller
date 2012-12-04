﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SitecoreInstaller.Framework.Configuration;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain.Projects
{
    using System.Diagnostics.Contracts;

    using SitecoreInstaller.Framework.Diagnostics;

    public class ProjectsService : IProjectsService
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
            Log.As.Info("Deleting project '{0}'", projectFolder.Name);

            projectFolder.DeleteWithLog();

            if (projectFolder.Exists() == false)
                Log.As.Info("Project deleted");
        }

        public void CreateProject(DirectoryInfo projectFolder)
        {
            Contract.Requires<ArgumentNullException>(projectFolder != null);
            projectFolder.CreateWithLog();
        }
    }
}
