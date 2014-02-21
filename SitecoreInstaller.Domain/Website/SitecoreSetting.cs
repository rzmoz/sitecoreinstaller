using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.Website
{
    public class SitecoreSetting
    {
        private const string _settingXmlFormat = @"<setting name=""{0}""><patch:attribute name=""value"">{1}</patch:attribute></setting>";

        public string Name { get; private set; }
        public string Value { get; private set; }

        public SitecoreSetting(string name, string value)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (value == null) throw new ArgumentNullException("value");
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return string.Format(_settingXmlFormat, Name, Value);
        }
    }
}
