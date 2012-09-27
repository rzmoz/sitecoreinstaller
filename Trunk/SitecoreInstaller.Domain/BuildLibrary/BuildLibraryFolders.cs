using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    using System.Diagnostics.Contracts;
    using System.IO;

    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.IO;

    public class BuildLibraryFolders
    {
        private const string _SitecoreFolderName = "Sitecore";
        private const string _LicenseFolderName = "Licenses";
        private const string _ModuleFolderName = "Modules";

        public BuildLibraryFolders(string rootPath)
            : this(new DirectoryInfo(rootPath))
        { }

        public BuildLibraryFolders(DirectoryInfo root)
        {
            Contract.Requires<ArgumentNullException>(root != null);
            Root = root;

            Modules = Root.CombineTo<DirectoryInfo>(_ModuleFolderName);
            Licenses = Root.CombineTo<DirectoryInfo>(_LicenseFolderName);
            Sitecore = Root.CombineTo<DirectoryInfo>(_SitecoreFolderName);
        }

        public void Create()
        {
            Root.CreateIfNotExists();
            Modules.CreateIfNotExists();
            Licenses.CreateIfNotExists();
            Sitecore.CreateIfNotExists();
            Log.As.Info("Build library folders created at: {0}", Root.FullName);
        }

        public DirectoryInfo Root { get; private set; }
        public DirectoryInfo Modules { get; private set; }
        public DirectoryInfo Licenses { get; private set; }
        public DirectoryInfo Sitecore { get; private set; }
    }
}
