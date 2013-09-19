using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
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
