using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.WebServer
{
    public interface IIisManagementService
    {
        /// <summary>
        /// Creates iis website and app pool
        /// </summary>
        void CreateApplication(IisSettings iisSettings, DirectoryInfo siteDirectory, DirectoryInfo iisLogFilesDirectory);
        /// <summary>
        /// Deletes iis website and app pool
        /// </summary>
        void DeleteApplication(string applicationName);

        void StartApplication(string applicationName);
        void StopApplication(string applicationName);

        bool BindingExists(string binding);
    }
}
