using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    using System.IO;
    using System.Xml;

    public class BuildLibraryResourceFactory
    {
        public BuildLibraryFile CreateFile(string path)
        {
            if (File.Exists(path) == false)
                throw new ArgumentException("Path doesn't exist. Was " + path);

            BuildLibraryFile file;
            try
            {
                file = new LicenseFile(new FileInfo(path), DateTime.Now);
            }
            catch (XmlException)
            {
                file = new BuildLibraryFile(new FileInfo(path));
            }
            return file;
        }

    }
}
