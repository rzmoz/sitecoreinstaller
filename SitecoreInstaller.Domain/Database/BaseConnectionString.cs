using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Database
{
    public abstract class BaseConnectionString : IConnectionString
    {
        public string Value { get; set; }
        public virtual bool IsValid()
        {
            if (string.IsNullOrEmpty(Value))
                return false;

            //we assume it's always good
            return true;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
