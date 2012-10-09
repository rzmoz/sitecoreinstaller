using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Database
{
    public class ConnectionStringName
    {

        private const char _Delimiter = '_';

        public ConnectionStringName()
            : this(string.Empty, string.Empty)
        {
        }

        public ConnectionStringName(string databaseName)
        {
            if (databaseName == null)
                throw new ArgumentNullException("databaseName");
            var parts = databaseName.Split(_Delimiter);
            if (parts.Length != 2)
                throw new ArgumentException("database name should be in the format <projectPart>_<databasePart>");

            ProjectPart = parts[0];
            DatabasePart = parts[1];
        }

        public ConnectionStringName(string projectPart, string databasePart)
        {
            ProjectPart = projectPart;
            DatabasePart = databasePart;
        }

        public string ProjectPart { get; private set; }
        public string DatabasePart { get; private set; }

        public override string ToString()
        {
            return ProjectPart + _Delimiter + DatabasePart;
        }
    }
}
