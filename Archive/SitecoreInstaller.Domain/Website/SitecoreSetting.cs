using System;

namespace SitecoreInstaller.Domain.Website
{
    public class SitecoreSetting
    {
        private const string _settingXmlFormat = @"<setting name=""{0}""><patch:attribute name=""value"">{1}</patch:attribute></setting>";

        public string Name { get; private set; }
        public string Value { get; private set; }
        
        public SitecoreSetting(string name)
            : this(name, string.Empty)
        {
        }

        public SitecoreSetting(string name, string value)
        {
            if (name == null) throw new ArgumentNullException("name");
            Name = name;
            Value = value ?? string.Empty;
        }

        public override string ToString()
        {
            return string.Format(_settingXmlFormat, Name, Value);
        }
    }
}
