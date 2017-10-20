using System;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Databases
{
    public class SqlDatabaseFilePair
    {
        public SqlDatabaseFilePair(string projectName, FilePath dataOrLogFile)
        {
            if (dataOrLogFile == null) throw new ArgumentNullException(nameof(dataOrLogFile));
            Name = new DatabaseName(projectName, dataOrLogFile);
            DataFile = dataOrLogFile.Directory.ToFile(dataOrLogFile.NameWithoutExtension + FileTypes.SqlMdf.Extension);
            LogFile = dataOrLogFile.Directory.ToFile(dataOrLogFile.NameWithoutExtension + FileTypes.SqlLdf.Extension);
        }

        public DatabaseName Name { get; }
        public FilePath DataFile { get; }
        public FilePath LogFile { get; }
    }
}
