using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharp.Basics.IO;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.Domain.Website
{
    public class WwwRootServices
    {
        public void Copy64BitAssemblies(DirectoryInfo websiteDir)
        {
            var bin32BitFolder = websiteDir.Combine(new DirectoryInfo("bin"));
            var bin64BitFolder = websiteDir.Combine(new DirectoryInfo("bin_x64"));

            bin64BitFolder.CopyTo(bin32BitFolder, DirCopyOptions.ExcludeSubDirectories);
        }

        public void SetDataFolder(DataFolder dataFolder, FileInfo dataFolderConfigFile)
        {
            var configFile = string.Format(WebsiteResource.DataFolderFormat, dataFolder.Directory);
            configFile.WriteToDisk(dataFolderConfigFile);
            Log.ToApp.Info("Data folder set to '{0}'", dataFolder.FullName);
        }

        public void CopySitecoreToProjectfolder(ProjectFolder projectFolder, BuildLibraryDirectory sitecore, DbInstallType sqlInstallType)
        {
            Log.ToApp.Info("Copying '{0}'...", sitecore.Directory.Name);

            //Copy web site folder
            var sitecoreWebsiteFolder = sitecore.Directory.CombineTo<DirectoryInfo>(projectFolder.Website.Name);
            sitecoreWebsiteFolder.CopyTo(projectFolder.Website, DirCopyOptions.IncludeSubDirectories);

            //Copy database folder
            if (sqlInstallType == DbInstallType.Auto)
            {
                //TODO: Move database folder name to central location
                CopyDatabaseFolder("Database", sitecore.Directory, projectFolder);
                CopyDatabaseFolder(projectFolder.Databases.Name, sitecore.Directory, projectFolder);
            }

            //Copy data folder
            //TODO: Move data folder name to central location
            var sitecoreDataFolder = sitecore.Directory.CombineTo<DirectoryInfo>("data");
            sitecoreDataFolder.CopyTo(projectFolder.Data, DirCopyOptions.IncludeSubDirectories);

            //Copy rest of files as is
            sitecore.Directory.GetFiles().CopyTo(projectFolder, true);

            Log.ToApp.Info("Sitecore copied");
        }

        public void CopyModule(ProjectFolder projectFolder, BuildLibraryDirectory module, DbInstallType sqlInstallType)
        {
            Log.ToApp.Info("Copying module to website...");

            if (sqlInstallType == DbInstallType.Auto)
            {
                try
                {
                    //copy database files to database folder
                    var dbFiles = new[] { FileTypes.SqlMdf.GetAllSearchPattern, FileTypes.SqlLdf.GetAllSearchPattern }
                        .SelectMany(fileExtensions => module.Directory.GetFiles(fileExtensions));

                    dbFiles.CopyTo(projectFolder.Databases, true);
                }
                catch (IOException e)
                {
                    Log.ToApp.Warning(e.ToString());
                }
            }

            //copy powershell scripts to project root folder
            module.Directory.GetFiles(FileTypes.PowerShellScript).CopyTo(projectFolder, true);

            //copy config delta files to project root folder
            //we don't copy delta files to project since we read them directly from the source modules to avoid naming conflicts

            //copy config files to App_Config/Include folder
            module.Directory.GetFiles(FileTypes.SitecoreConfig).CopyTo(projectFolder.Website.AppConfig.Include, true);

            //copy disabled config files to App_Config/Include folder
            module.Directory.GetFiles(FileTypes.DisabledSitecoreConfig).CopyTo(projectFolder.Website.AppConfig.Include, true);

            //copy Sitecore packages to package folder (zip files)
            module.Directory.GetFiles(FileTypes.SitecorePackage).CopyTo(projectFolder.Data.Packages, true);

            //copy Sitecore update packages to package folder (update files)
            module.Directory.GetFiles(FileTypes.SitecoreUpdate).CopyTo(projectFolder.Data.Packages, true);

            //Copy rest of files
            Array.FindAll(module.Directory.GetFiles(), FileTypes.IsNotRegisteredFileType).CopyTo(projectFolder, true);

            //Copy directories to project folder
            module.Directory.GetDirectories().CopyTo(projectFolder);

            Log.ToApp.Info("Module copied to website");
        }

        public void CopyStandAloneScPackage(ProjectFolder projectFolder, BuildLibraryFile file, DbInstallType sqlInstallType)
        {
            Log.ToApp.Info("Copying stand alone sitecore package to website...");

            if (file.File.IsSitecorePackage())
            {
                file.File.CopyTo(projectFolder.Data.Packages, true);
            }


            Log.ToApp.Info("Stand alone sitecore package copied to website");
        }

        private void CopyDatabaseFolder(string sourceDbName, DirectoryInfo sitecore, ProjectFolder projectfolder)
        {
            var sitecoreDatabaseFolder = sitecore.CombineTo<DirectoryInfo>(sourceDbName);
            if (Directory.Exists(sitecoreDatabaseFolder.FullName) == false)
                return;

            sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, FileTypes.SqlLdf.GetAllSearchPattern);
            sitecoreDatabaseFolder.CopyFlattenedTo(projectfolder.Databases, FileTypes.SqlMdf.GetAllSearchPattern);
        }

        public void SetSitecoreSettings(IEnumerable<SitecoreSetting> settings, FileInfo settingsFile)
        {
            var settingsArg = string.Empty;
            foreach (var sitecoreSetting in settings)
            {
                settingsArg += sitecoreSetting.ToString();
            }

            var settingsString = string.Format(WebsiteResource.SitecoreSettingsFormat, settingsArg);
            settingsString.WriteToDisk(settingsFile);
        }

        public void TransformConfigFiles(ProjectFolder projectFolder, IEnumerable<ProjectDeltaFile> deltas)
        {
            var projectConfigTransforms = new ProjectConfigTransforms(projectFolder, deltas);
            projectConfigTransforms.Transform();
        }
    }
}
