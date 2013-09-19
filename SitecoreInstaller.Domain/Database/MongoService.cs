using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.Database
{
    public class MongoService
    {
        public string GenerateConnectionStringsDelta(MongoSettings settings, IEnumerable<ConnectionStringEntry> existingStringEntries, string projectName)
        {
            var connectionStringEntries = string.Empty;

            foreach (var mongoEntry in existingStringEntries.Where(entry => entry.ConnectionString is MongoConnectionString))
            {
                ((MongoConnectionString)mongoEntry.ConnectionString).SetProjectName(projectName);
                connectionStringEntries += mongoEntry.ToReplaceString();
            }

            var connectionStringDelta = string.Format(ConnectionStringFormats.ConnectionStringDotConfigDelta, connectionStringEntries);
            Log.This.Debug(connectionStringDelta);
            return connectionStringDelta;
        }
    }
}
