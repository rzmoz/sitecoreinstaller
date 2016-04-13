using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Database
{
    public class ConnectionStringName
    {
        private const char _delimiter = '_';

        public ConnectionStringName()
            : this(string.Empty, string.Empty)
        {
        }

        public ConnectionStringName(string databaseName)
        {
            if (databaseName == null)
                throw new ArgumentNullException("databaseName");

            var delimiterIndex = databaseName.LastIndexOf(_delimiter);
            if (delimiterIndex < 0)
            {
                ProjectPart = string.Empty;
                DatabasePart = databaseName;
            }
            else
            {
                ProjectPart = databaseName.Substring(0, delimiterIndex);
                DatabasePart = databaseName.Substring(delimiterIndex + 1);
            }
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
            if (string.IsNullOrEmpty(ProjectPart))
                return DatabasePart;
            return ProjectPart + _delimiter + DatabasePart;
        }
    }
}
