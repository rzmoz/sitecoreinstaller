using DotNet.Basics.IO;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Databases
{
    public class DatabaseName
    {
        public DatabaseName(string projectName, FilePath dataOrLogFile)
            : this(projectName, ToConnectionStringName(dataOrLogFile))
        {
        }

        public DatabaseName(string projectName, string connectionStringName)
        {
            ProjectName = projectName;
            ConnectionStringName = connectionStringName;
            FullName = $"{ProjectName}_{ConnectionStringName}";
        }

        public string ProjectName { get; }
        public string ConnectionStringName { get; }
        public string FullName { get; }

        public override string ToString()
        {
            return FullName;
        }

        private static string ToConnectionStringName(FilePath dataOrLogFile)
        {
            return dataOrLogFile.NameWithoutExtension.RemovePrefix("sitecore.");
        }
    }
}
