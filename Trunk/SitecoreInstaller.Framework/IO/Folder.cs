using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.IO
{
    using global::System.Diagnostics.Contracts;
    using global::System.IO;

    public class Folder
    {
        public Folder()
        {
        }

        public Folder(DirectoryInfo directory)
        {
            Contract.Requires<ArgumentNullException>(directory != null);
            Directory = directory;
        }
        public string FullName { get { return Directory.FullName; } }
        public string Name { get { return Directory.Name; } }
        public DirectoryInfo Directory { get; protected set; }
    }
}
