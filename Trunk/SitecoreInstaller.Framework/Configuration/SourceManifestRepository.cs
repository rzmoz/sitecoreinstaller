using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Configuration
{
    public class SourceManifestRepository
    {
        private readonly IDictionary<string, SourceManifest> _sources;

        public SourceManifestRepository(string sourceFileName)
        {
            SourceFileName = sourceFileName;
            _sources = new Dictionary<string, SourceManifest>();
        }

        public void Init()
        {
            IConfiguration sourcesConfig = new ConfigFileConfiguration();
            sourcesConfig.Load(SourceFileName);
            var sources = sourcesConfig.GetElements("source").Select(source => new SourceManifest(source.Attribute("name").Value, source.Attribute("type").Value, source.Attribute("parameters").Value));
            foreach (var source in sources)
                _sources.Add(source.Name, source);
        }

        public string SourceFileName { get; private set; }

        public IEnumerable<SourceManifest> All()
        {
            return _sources.Values;
        }

        public SourceManifest Get(string name)
        {
            if (_sources.ContainsKey(name))
                return _sources[name];
            return null;
        }

        public void Add(SourceManifest sourceManifest)
        {
            throw new NotImplementedException();
        }
    }
}
