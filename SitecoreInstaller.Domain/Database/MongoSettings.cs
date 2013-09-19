using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.Database
{
    public class MongoSettings
    {
        public MongoSettings()
        {
            Username = string.Empty;
            Password = string.Empty;
            Endpoint = "localhost";
            Port = 27017;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Endpoint { get; set; }
        public int Port { get; set; }

        public bool TestConnection()
        {
          try
          {
            var conStr = new MongoConnectionString(this).Value;
            var client = new MongoClient(conStr);
            var server = client.GetServer();
            server.Ping();
            return true;
          }
          catch (Exception e)
          {
            Log.This.Debug(e.ToString());
            Log.This.Error(e.Message);
            return false;
          }
        }
    }
}
