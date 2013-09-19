using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Database
{
    public class MsSqlConnectionString : IConnectionString
    {
        public string Value { get; set; }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Value))
                return false;

            //we assume it's always good
            return true;
        }
    }
}
