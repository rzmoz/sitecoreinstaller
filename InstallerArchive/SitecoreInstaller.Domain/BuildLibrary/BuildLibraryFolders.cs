using System;
using System.IO;
using CSharp.Basics.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class BuildLibraryFolders
    {
        private const string _sitecoreFolderName = "Sitecore";
        private const string _licenseFolderName = "Licenses";
        private const string _moduleFolderName = "Modules";

        public BuildLibraryFolders(string rootPath)
            : this(new DirectoryInfo(rootPath))
        { }

        public BuildLibraryFolders(DirectoryInfo root)
        {
            if (root == null) { throw new ArgumentNullException("root"); }
            Root = root;

            Modules = Root.CombineTo<DirectoryInfo>(_moduleFolderName);
            Licenses = Root.CombineTo<DirectoryInfo>(_licenseFolderName);
            Sitecore = Root.CombineTo<DirectoryInfo>(_sitecoreFolderName);
        }

        public void CreateIfNotExists()
        {
            Root.CreateIfNotExists();
            Modules.CreateIfNotExists();
            Licenses.CreateIfNotExists();
            Sitecore.CreateIfNotExists();
        }

        public DirectoryInfo Root { get; private set; }
        public DirectoryInfo Modules { get; private set; }
        public DirectoryInfo Licenses { get; private set; }
        public DirectoryInfo Sitecore { get; private set; }
    }
}
