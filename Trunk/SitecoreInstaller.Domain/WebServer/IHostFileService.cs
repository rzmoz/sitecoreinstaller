using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.WebServer
{
    public interface IHostFileService
    {
        bool HasWritePermissions();
        void AddHostName(string hostName);
        void RemoveHostName(string hostName);
    }
}
