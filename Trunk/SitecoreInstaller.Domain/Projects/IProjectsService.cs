using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Projects
{
    public interface IProjectsService
    {
        IEnumerable<DirectoryInfo> GetExistingProjects();

        void CleanProjectForArchiving(ProjectFolder projectFolder);

        void DeleteProject(DirectoryInfo projectFolder);
        void CreateProject(DirectoryInfo projectFolder);
    }
}
