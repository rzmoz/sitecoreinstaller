using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SitecoreInstaller.Framework.Configuration;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain.Projects
{
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
    }
}
