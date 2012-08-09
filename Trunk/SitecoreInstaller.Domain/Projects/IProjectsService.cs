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
    }
}
