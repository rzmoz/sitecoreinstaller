﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
namespace SitecoreInstaller.Framework.Configuration
{
    using global::System.IO;

    public class ConfigFileConfigurationRepository : IConfigurationRepository
    {
        private XDocument _document;
        private XElement _rootElement;

        public void Load(string path)
        {
            if (File.Exists(path) == false)
                throw new IOException("path doesnt exist:" + path);

            _document = XDocument.Load(path);
            _rootElement = _document.Elements().FirstOrDefault();
        }

        public IEnumerable<XElement> GetElements(string elementName)
        {
            var elements = _rootElement.Elements(elementName);
            return elements;
        }

        public string this[string key]
        {
            get
            {
                var element = _rootElement.Element(key);
                if (element == null)
                    return null;
                return element.Value;
            }
        }
    }

}
