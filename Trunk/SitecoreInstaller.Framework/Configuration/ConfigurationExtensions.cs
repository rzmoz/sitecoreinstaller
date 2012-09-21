using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Configuration
{
    using global::System.Xml.Linq;

    public static class ConfigurationExtensions
    {
        public static IEnumerable<XElement> ElementsIgnoreCase(this XContainer container, XName name)
        {
            foreach (XElement element in container.Elements())
            {
                if (element.Name.NamespaceName == name.NamespaceName &&
                    String.Equals(element.Name.LocalName, name.LocalName, StringComparison.OrdinalIgnoreCase))
                {
                    yield return element;
                }
            }
        }

        public static XAttribute AttributeIgnoreCase(this XElement element, XName name)
        {
            foreach (XAttribute attr in element.Attributes())
            {
                if (attr.Name.NamespaceName == name.NamespaceName &&
                    String.Equals(attr.Name.LocalName, name.LocalName, StringComparison.OrdinalIgnoreCase))
                {
                    return attr;
                }
            }
            return null;
        }  
    }
}
