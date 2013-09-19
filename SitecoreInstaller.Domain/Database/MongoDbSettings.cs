using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Database
{
    public class MongoDbSettings
    {
        public MongoDbSettings()
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
    }
}
