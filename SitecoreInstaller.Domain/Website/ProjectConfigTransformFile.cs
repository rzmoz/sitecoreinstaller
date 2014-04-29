using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.Domain.Website
{
    public class ProjectDeltaFile
    {
        public ProjectDeltaFile(string moduleName, FileInfo file)
        {
            if (moduleName == null) throw new ArgumentNullException("moduleName");
            if (file == null) throw new ArgumentNullException("file");
            ModuleName = moduleName;
            File = file;
        }

        public string ModuleName { get; private set; }
        public FileInfo File { get; private set; }

        public string GetRelativePath()
        {
            var relativePath = File.FullNameWithoutExtension();

            var moduleIndex = relativePath.IndexOf(ModuleName, StringComparison.InvariantCultureIgnoreCase);
            if (moduleIndex < 0)
                return relativePath;

            return relativePath.Substring(moduleIndex + ModuleName.Length).TrimStart('\\');
        }
    }
}
