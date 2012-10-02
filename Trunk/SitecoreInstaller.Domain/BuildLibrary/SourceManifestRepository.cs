namespace SitecoreInstaller.Domain.BuildLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SitecoreInstaller.Framework.Configuration;

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
            var sourcesConfig = ConfigFile.Load(SourceFileName);
            var sources = sourcesConfig.GetElements<SourceManifest>("source");
            _sources.Clear();
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
