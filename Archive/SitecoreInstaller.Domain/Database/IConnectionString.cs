using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Database
{
    public interface IConnectionString
    {
        string Value { get; set; }
        bool IsValid();
    }
}
