namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System;
  using System.Collections;
  using System.Linq;
  using System.Collections.Generic;
  using System.IO;
  using SitecoreInstaller.Framework.Configuration;

  public class SourceManifestRepository : IEnumerable<SourceManifest>
  {
    private ConfigFile<SourceManifestConfig> _sources;

    public SourceManifestRepository(FileInfo sourceFile)
    {
      SourceFile = sourceFile;
    }

    public void Init()
    {
      _sources = new ConfigFile<SourceManifestConfig>(SourceFile);
      _sources.Load();
    }

    public FileInfo SourceFile { get; private set; }

    public IEnumerable<SourceManifest> Enabled
    {
      get { return _sources.Properties.Manifests.Where(x => x.Enabled); }
    }


    public SourceManifest Get(string name)
    {
      return _sources.Properties.Manifests.FirstOrDefault(manifest => manifest.Name == name);
    }

    public void Add(SourceManifest sourceManifest)
    {
      _sources.Properties.Manifests.Add(sourceManifest);
    }

    public IEnumerator<SourceManifest> GetEnumerator()
    {
      return _sources.Properties.Manifests.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
