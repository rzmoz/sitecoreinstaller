using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Internal;
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
            Log.As.Debug(connectionStringDelta);
            return connectionStringDelta;
        }

      public IEnumerable<MongoDatabase> GetDatabases(ConnectionStringsFile connectionStrings)
      {
        foreach (var mongoEntry in connectionStrings.Where(entry => entry.ConnectionString is MongoConnectionString))
        {
          var conStr = new MongoUrl(mongoEntry.ConnectionString.Value);
          var client = new MongoClient(conStr);
          var server = client.GetServer();
          var dbSettings = new MongoDatabaseSettings();
          yield return new MongoDatabase(server, conStr.DatabaseName , dbSettings);
        }
      }
    }
}
