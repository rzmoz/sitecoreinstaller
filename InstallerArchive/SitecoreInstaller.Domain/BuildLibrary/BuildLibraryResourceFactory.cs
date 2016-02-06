using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace SitecoreInstaller.Domain.BuildLibrary
{
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
