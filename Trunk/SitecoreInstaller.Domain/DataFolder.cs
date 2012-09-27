using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain
{
    using System.Diagnostics.Contracts;
    using System.IO;

    using SitecoreInstaller.Domain.Website;
    using SitecoreInstaller.Framework.IO;

    public class DataFolder : Folder
    {
        private const string _AppDataFolderName = "App_Data";
        private const string _DataFolderName = "Data";

        private const string _PackagesFolderName = "Packages";
        private const string _AuditFolderName = "Audit";
        private const string _ViewstateFolderName = "Viewstate";
        private const string _LogsFolderName = "Logs";

        public DataFolder(DataFolderMode dataFolderMode, DirectoryInfo parent)
        {
            Contract.Requires<ArgumentNullException>(parent != null);

            DataFolderMode = dataFolderMode;
            switch (DataFolderMode)
            {
                case DataFolderMode.AppDataInside:
                    Directory = parent.CombineTo<DirectoryInfo>(_AppDataFolderName);
                    break;
                case DataFolderMode.DataOutside:
                default:
                    Directory = parent.CombineTo<DirectoryInfo>(_DataFolderName);
                    break;
            }
            Packages = Directory.CombineTo<DirectoryInfo>(_PackagesFolderName);
            Audit = Directory.CombineTo<DirectoryInfo>(_AuditFolderName);
            Logs = Directory.CombineTo<DirectoryInfo>(_LogsFolderName);
            Viewstate = Directory.CombineTo<DirectoryInfo>(_ViewstateFolderName);
        }

        public DataFolderMode DataFolderMode { get; private set; }

        
        public DirectoryInfo Packages { get; private set; }
        public DirectoryInfo Audit { get; private set; }
        public DirectoryInfo Logs { get; private set; }
        public DirectoryInfo Viewstate { get; private set; }
    }
}
