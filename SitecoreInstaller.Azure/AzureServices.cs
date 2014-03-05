using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Azure.Packaging.Databases;

namespace SitecoreInstaller.Azure
{
    public static class AzureServices
    {
        static AzureServices()
        {
            Sql = new SqlServerService();
        }

        public static SqlServerService Sql { get; private set; }
    }
}
