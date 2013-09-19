using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Database
{
    public class MongoDbConnectionString : BaseConnectionString
    {
        private const string _protocol = @"mongodb://";
        
        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Value))
                return false;
            return Value.ToLowerInvariant().StartsWith(_protocol);
        }
    }
}
