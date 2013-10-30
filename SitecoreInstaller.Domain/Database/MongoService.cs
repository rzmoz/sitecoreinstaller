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
      Log.This.Debug(connectionStringDelta);
      return connectionStringDelta;
    }

    public MongoServer GetServer(MongoUrl monguUrl)
    {
      var client = new MongoClient(monguUrl);
      return client.GetServer();
    }

    public void EnsureDatabases(ConnectionStringsFile connectionStrings)
    {
      foreach (var mongoEntry in connectionStrings.Where(entry => entry.ConnectionString is MongoConnectionString))
      {
        var mongoUrl = new MongoUrl(mongoEntry.ConnectionString.Value);
        var server = GetServer(mongoUrl);

        var dbSettings = new MongoDatabaseSettings();
        var db = new MongoDatabase(server, mongoUrl.DatabaseName, dbSettings);
        const string tempCollectionName = "SitecoreInstallerTempCollection";
        db.CreateCollection(tempCollectionName);
        db.DropCollection(tempCollectionName);
      }
    }
    public void DropDatabases(ConnectionStringsFile connectionStrings)
    {
      foreach (var mongoEntry in connectionStrings.Where(entry => entry.ConnectionString is MongoConnectionString))
      {
        var mongoUrlBuilder = new MongoUrlBuilder(mongoEntry.ConnectionString.Value)
        {
          ConnectTimeout = TimeSpan.FromSeconds(3)
        };
        var mongoUrl = new MongoUrl(mongoUrlBuilder.ToString());
        try
        {
          var server = GetServer(mongoUrl);
          var dbSettings = new MongoDatabaseSettings();
          new MongoDatabase(server, mongoUrl.DatabaseName, dbSettings).Drop();
        }
        catch (MongoConnectionException)
        {
          Log.This.Error("Couldn't drop mongo db: '{0}'", mongoUrl.DatabaseName);
        }
      }
    }
  }
}
