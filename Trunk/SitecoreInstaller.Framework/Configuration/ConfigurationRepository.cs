using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Configuration
{
    public class ConfigurationRepository
    {
        private readonly IDictionary<string, IConfiguration> _configurations;

        public ConfigurationRepository()
        {
            _configurations = new Dictionary<string, IConfiguration>();
        }

        public IConfiguration this[string key]
        {
            get
            {
                if (_configurations.ContainsKey(key))
                    return _configurations[key];
                return null;
            }
        }

        public void Remove(string name)
        {
            if (_configurations.ContainsKey(name))
                _configurations.Remove(name);
        }

        public void Load(string path, string name)
        {
            var configuration = new ConfigFileConfiguration();
            configuration.Load(path);
            _configurations.Add(name, configuration);
        }
    }
}
