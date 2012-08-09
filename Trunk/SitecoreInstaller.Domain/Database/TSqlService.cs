using System;
using System.Collections.Generic;

namespace SitecoreInstaller.Domain.Database
{
    public class TSqlService
    {
        private readonly char[] _physicalDatabaseNameDelimiter = new[] { '.', '_' };

        public string GetAttachScript(string projectName, IEnumerable<string> databaseNames, string databaseFolderPath)
        {
            var combinedScript = string.Empty;

            foreach (var databaseName in databaseNames)
            {
                combinedScript += string.Format(_SqlAttachFormat, projectName, databaseFolderPath, databaseName, GetLogicalDatabaseName(databaseName));
            }

            return combinedScript.TrimEnd();
        }

        public string GetDetachScript(string projectName, IEnumerable<string> databaseNames)
        {
            var combinedScript = string.Empty;

            foreach (var databaseName in databaseNames)
            {
                combinedScript += string.Format(_SqlDetachFormat, projectName, GetLogicalDatabaseName(databaseName));
            }

            return combinedScript.TrimEnd();
        }

        public string GetMapLoginScript(string projectName, string sqlLogin, IEnumerable<string> databaseNames)
        {
            var combinedScript = string.Empty;

            foreach (var databaseName in databaseNames)
            {
                combinedScript += string.Format(_SqlMapLoginFormat, projectName, GetLogicalDatabaseName(databaseName), sqlLogin);
            }

            return combinedScript.TrimEnd();
        }

        public string GetLogicalDatabaseName(string physicalDatabaseName)
        {
            int dbPrefixIndex = -1;
            foreach (var dbNameDelimiter in _physicalDatabaseNameDelimiter)
            {
                dbPrefixIndex = physicalDatabaseName.LastIndexOf(dbNameDelimiter);
                if (dbPrefixIndex > -1)
                    break;
            }
            if (dbPrefixIndex > -1)
                return physicalDatabaseName.Remove(0, dbPrefixIndex + 1);
            return physicalDatabaseName;
        }

        private const string _SqlAttachFormat =
            @"USE [master]
GO
CREATE DATABASE [{0}_{3}] ON
( FILENAME = N'{1}\{2}.Mdf' ),
( FILENAME = N'{1}\{2}.Ldf' )
FOR ATTACH
GO

";


        private const string _SqlDetachFormat =
            @"USE [master]
GO
ALTER DATABASE [{0}_{1}] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO
USE [master]
GO
EXEC master.dbo.sp_detach_db @dbname = N'{0}_{1}'
GO

";

        private const string _SqlMapLoginFormat =
            @"USE [{0}_{1}];
CREATE USER [{2}] FROM LOGIN [{2}];
USE [{0}_{1}];
EXEC sp_addrolemember 'db_owner', '{2}';

";
    }
}
