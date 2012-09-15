using System.Collections.Generic;
using System.Xml.Linq;

namespace SitecoreInstaller.Framework.Configuration
{
    public interface IConfiguration
    {
        void Load(string path);

        IEnumerable<XElement> GetElements(string elementName);

    }
}
