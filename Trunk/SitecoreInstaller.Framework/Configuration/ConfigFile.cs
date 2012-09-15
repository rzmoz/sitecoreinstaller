using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Configuration
{
    using global::System.Dynamic;
    using global::System.IO;
    using global::System.Xml.Linq;

    public class ConfigFile : DynamicObject
    {
        private XDocument _document;
        private XElement _rootElement;


        public ConfigFile(string path):this(new FileInfo(path))
        {
        }

        public ConfigFile(FileInfo path)
        {
            Path = path;
        }

        public FileInfo Path { get; private set; }

        // If you try to get a value of a property  
        // not defined in the class, this method is called. 
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            if (_document == null)
                Load(Path.FullName);

            var element = _rootElement.Element(binder.Name);
            if (element == null)
                result = null;
            else
                result = element.Value;
            return true;
        }

        // If you try to set a value of a property that is 
        // not defined in the class, this method is called. 
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            throw new NotImplementedException();

            // You can always add a value to a dictionary, 
            // so this method always returns true. 
            return true;
        }
        public void Load(string path)
        {
            if (File.Exists(path) == false)
                throw new IOException("path doesnt exist:" + path);

            _document = XDocument.Load(path);
            _rootElement = _document.Elements().FirstOrDefault();
        }

    }
}
