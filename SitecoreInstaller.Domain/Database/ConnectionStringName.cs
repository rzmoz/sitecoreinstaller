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

            var delimiterIndex = databaseName.LastIndexOf(_Delimiter);
            if (delimiterIndex < 0)
                throw new ArgumentException(string.Format("database name should have {0} as delimiter", _Delimiter));

            ProjectPart = databaseName.Substring(0, delimiterIndex);
            DatabasePart = databaseName.Substring(delimiterIndex + 1);
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
