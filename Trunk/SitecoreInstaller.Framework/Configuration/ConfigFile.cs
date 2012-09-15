using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Configuration
{
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


        public IEnumerable<T> GetElements<T>(string elementName) where T : new()
        {
            Init();
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Static);
            var xElements = GetElements(elementName);
            foreach (var xElement in xElements)
            {
                var t = new T();
                foreach (var propertyInfo in properties)
                {
                    if (propertyInfo.PropertyType.Equals(typeof(string)))
                        SetPropertyValue(t, propertyInfo.Name, xElement.Attribute(propertyInfo.Name).Value);
                }
                yield return t;
            }
        }

        private static void SetPropertyValue<T>(object obj, string propName, T val)
        {
            Type t = obj.GetType();
            if (t.GetProperty(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance) == null)
                throw new ArgumentOutOfRangeException("propName", string.Format("Property {0} was not found in Type {1}", propName, obj.GetType().FullName));
            t.InvokeMember(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, obj, new object[] { val });
        }

        private IEnumerable<XElement> GetElements(string elementName)
        {
            var elements = _rootElement.Elements(elementName);
            return elements;
        }

        // If you try to get a value of a property  
        // not defined in the class, this method is called. 
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            Init();

            var element = _rootElement.Element(binder.Name);
            if (element == null)
                result = null;
            else
                result = element.Value;
            return true;
        }

        private void Init()
        {
            if (_document == null)
                Load(Path.FullName);
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
        public void Load(string path)
        {
            if (File.Exists(path) == false)
                throw new IOException("path doesnt exist:" + path);

            _document = XDocument.Load(path);
            _rootElement = _document.Elements().FirstOrDefault();
        }

    }
}
