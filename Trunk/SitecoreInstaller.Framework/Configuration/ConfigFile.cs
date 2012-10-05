using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Configuration
{
    using SitecoreInstaller.Framework.System;

    using global::System.Dynamic;
    using global::System.IO;
    using global::System.Reflection;
    using global::System.Xml.Linq;

    public class ConfigFile : DynamicObject
    {
        private XDocument _document;
        private XElement _rootElement;

        public ConfigFile(string path)
            : this(new FileInfo(path))
        {
        }

        public ConfigFile(FileInfo path)
        {
            Path = path;
        }

        public FileInfo Path { get; private set; }

        public bool Exists { get { return File.Exists(Path.FullName); } }

        public IEnumerable<T> GetElements<T>(string sourceName = "") where T : new()
        {
            Init();
            var elements = new List<T>();

            var type = typeof(T);
            if (string.IsNullOrEmpty(sourceName))
                sourceName = type.Name;
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            var xElements = _rootElement.ElementsIgnoreCase(sourceName);
            foreach (var xElement in xElements)
            {
                var t = new T();
                foreach (var propertyInfo in properties.Where(p => p.PropertyType.Equals(typeof(string))))
                {
                    var attribute = xElement.AttributeIgnoreCase(propertyInfo.Name);
                    if (attribute != null)
                        t.SetPropertyValue(propertyInfo.Name, attribute.Value);
                }
                elements.Add(t);
            }
            return elements;
        }

        private void Init()
        {
            if (_document == null)
                LoadContent(Path.FullName);
        }

        // If you try to get a value of a property  
        // not defined in the class, this method is called. 
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            Init();

            var element = _rootElement.Element(binder.Name);
            if (element == null)
            {
                result = string.Empty;

            }
            else
            {
                result = element.Value;

                if (element.Value.Length == 0 &&
                    element.Attribute("defaultValue") != null &&
                    element.Attribute("defaultValue").Value.Length > 0)
                    result = element.Attribute("defaultValue").Value;
            }

            return true;
        }

        // If you try to set a value of a property that is 
        // not defined in the class, this method is called. 
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            Init();

            var element = _rootElement.Element(binder.Name);
            if (element == null)
            {
                _rootElement.Add(new XElement(binder.Name, value));
            }
            else
            {
                element.Value = value.ToString();
            }
            _document.Save(Path.FullName);
            return true;
        }
        public static ConfigFile Load(string path)
        {
            var configFile = new ConfigFile(path);
            configFile.LoadContent(path);
            return new ConfigFile(path);
        }

        private void LoadContent(string path)
        {
            if (File.Exists(path) == false)
                throw new IOException("path doesn't exist:" + path);

            _document = XDocument.Load(path);
            _rootElement = _document.Elements().FirstOrDefault();
        }
    }
}