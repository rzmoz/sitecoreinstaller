using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Database
{
  public class MongoConnectionString : BaseConnectionString
  {
    private const string _protocol = @"mongodb://";
    private const string _connectionStringFormat = "mongodb://{0}:{1}";
    private const string _connectionStringWithUsernameAndPasswordFormat = "mongodb://{0}:{1}@{2}:{3}";

    public MongoConnectionString()
    {
    }

    public MongoConnectionString(MongoSettings settings, ConnectionStringName name)
      : this(settings, name.ToString())
    {
    }

    public MongoConnectionString(MongoSettings settings, string dbName = "")
    {
      if (string.IsNullOrEmpty(settings.Username) || string.IsNullOrEmpty(settings.Password))
        Value = string.Format(_connectionStringFormat, settings.Endpoint, settings.Port);
      else
        Value = string.Format(_connectionStringWithUsernameAndPasswordFormat, settings.Username, settings.Password, settings.Endpoint, settings.Port);

      if (string.IsNullOrEmpty(dbName) == false)
        Value += "/" + dbName;
    }

    public void SetProjectName(string projectName)
    {
      var conStrWithoutProtocol = Value.Replace(_protocol, string.Empty);
      var dbNameIndex = conStrWithoutProtocol.LastIndexOf('/');
      if (dbNameIndex < 0)
        return;

      dbNameIndex++;

      var dbName = conStrWithoutProtocol.Substring(dbNameIndex);

      if (dbName.ToLowerInvariant().StartsWith(projectName.ToLowerInvariant()))
        return;

      var server = conStrWithoutProtocol.Substring(0, dbNameIndex);

      Value = _protocol + server + projectName + "_" + dbName;
    }

    public override bool IsValid()
    {
      if (string.IsNullOrEmpty(Value))
        return false;
      return Value.ToLowerInvariant().StartsWith(_protocol);
    }
  }
}
