using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SitecoreInstaller.Framework.System
{
    public static class XDocumentExtensions
    {
        public static IEnumerable<string> GetValues(this XDocument document, string elementName, string propertyName)
        {
            var elements = document.Descendants(elementName);
            if (elements.Any() == false)
                yield break;

            foreach (var xElement in elements)
            {
                yield return xElement.Attribute(propertyName).Value;
            }
        }
        public static string GetFirstValue(this XDocument document, string elementName, string keyName, string key, string valueName)
        {
            var elements = document.GetElements(elementName, keyName, key);
            if (elements.Any() == false)
                return string.Empty;
            return elements.First().Attribute(valueName).Value;
        }

        public static void SetValues(this XDocument document, string elementName, string keyName, string key, string valueName, string value)
        {
            var elements = document.GetElements(elementName, keyName, key);
            foreach (var xElement in elements)
            {
                xElement.Attribute(valueName).SetValue(value); ;
            }
        }

        public static IEnumerable<XElement> GetElements(this XDocument document, string elementName, string KeyName, string key)
        {
            var elements = document.Descendants(elementName).Where(x => x.Attribute(KeyName).Value.Equals(key));
            return elements;
        }
    }
}
