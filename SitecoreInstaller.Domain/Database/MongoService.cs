using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
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
      Log.ToApp.Debug(connectionStringDelta);
      return connectionStringDelta;
    }


    public void EnsureDatabases(ConnectionStringsFile connectionStrings)
    {
      foreach (var mongoEntry in connectionStrings.Where(entry => entry.ConnectionString is MongoConnectionString))
      {
        var mongoUrl = new MongoUrl(mongoEntry.ConnectionString.Value);
        var db = mongoUrl.ToMongoDatabase();
        const string tempCollectionName = "SitecoreInstallerTempCollection";
        db.CreateCollection(tempCollectionName);
        db.DropCollection(tempCollectionName);
      }
    }
    public void DropDatabases(ConnectionStringsFile connectionStrings)
    {
      foreach (var mongoEntry in connectionStrings.Where(entry => entry.ConnectionString is MongoConnectionString))
      {
        var mongoUrl = mongoEntry.ConnectionString.Value.ToMongoUrl(3);
        try
        {
          var db = mongoUrl.ToMongoDatabase();
          db.Drop();
        }
        catch (MongoConnectionException)
        {
          Log.ToApp.Error("Couldn't drop mongo db: '{0}'", mongoUrl.DatabaseName);
        }
      }
    }
  }
}
