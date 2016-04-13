using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Tests.Domain.Database
{
    public static class MockConnectionStrings
    {
        public static class MsSql
        {
            public const string StandardSecurtiy = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
            public const string TrustedConnection = "Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;";
            public const string ConnectionToASQLServerInstance = @"Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        }
        public static class Mongo
        {
            public const string Default = "mongodb://localhost/myfb";
            public const string WithUsernameAndPassword = "mongodb://<dbuser>:<dbpassword>@ds045948.mongolab.com:27017/mydb";
        }
    }
}
