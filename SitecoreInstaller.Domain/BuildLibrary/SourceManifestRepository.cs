namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System;
  using System.Collections;
  using System.Linq;
  using System.Collections.Generic;
  using System.IO;
  using System.Net;
  using System.Threading.Tasks;
  using Framework.Configuration;
  using Framework.Web;

  public class SourceManifestRepository : IEnumerable<SourceManifest>
  {
    private List<SourceManifest> _manifests;
    private static readonly object _manifestsLock = new object();

    public event EventHandler ExternalManifestsLoaded;


    public SourceManifestRepository(FileInfo sourceFile)
    {
      _manifests = new List<SourceManifest>();
      SourceFile = sourceFile;
    }

    public void UpdateLocal()
    {
      _manifests = LoadManifests(SourceFile, GetLocalManifests).ToList();
    }

    public void UpdateExternalAsync()
    {
      var externalManifests = LoadManifests(SourceFile, GetExternalManifests).ToList();
      if (externalManifests.Count > 0)
      {
        var localManifests = LoadManifests(SourceFile, GetLocalManifests).ToList();
        var joinedManifests = localManifests.Concat(externalManifests.Distinct()).ToList();
        lock (_manifestsLock)
        {
          _manifests = joinedManifests;
        }
        if (ExternalManifestsLoaded != null)
          ExternalManifestsLoaded(this, EventArgs.Empty);
      }
    }

    private IEnumerable<SourceManifest> LoadManifests(FileInfo sourceFile, Func<ConfigFile<SourceManifestConfig>, IEnumerable<SourceManifest>> getManifestsFunc)
    {
      var manifests = new List<SourceManifest>();
      var sources = new ConfigFile<SourceManifestConfig>(sourceFile);
      sources.Load();
      manifests.AddRange(getManifestsFunc(sources));
      return manifests.Distinct();
    }

    private IEnumerable<SourceManifest> GetLocalManifests(ConfigFile<SourceManifestConfig> sources)
    {
      return sources.Properties.Manifests;
    }

    private IEnumerable<SourceManifest> GetExternalManifests(ConfigFile<SourceManifestConfig> sources)
    {
      var files = new List<FileInfo>();
      foreach (var source in sources.Properties.ExternalSources)
      {
        switch (source.Type)
        {
          case ExternalSourcetype.HttpGet:
            var file = DownloadExternalSourceFile(source);
            if (file != null)
              files.Add(file);
            break;
        }
      }

      var manifests = new List<SourceManifest>();
      foreach (var fileInfo in files)
      {
        manifests.AddRange(LoadManifests(fileInfo, GetLocalManifests));
      }
      return manifests.Distinct();
    }

    private static FileInfo DownloadExternalSourceFile(ExternalSource source)
    {
      var sourceFile = new FileInfo(Path.GetTempFileName());
      try
      {
        TheWww.DownloadFile(source.Uri, sourceFile);
        return sourceFile;
      }
      catch (WebException e)
      {
        sourceFile.Delete();
        Framework.Diagnostics.Log.This.Warning("Failed getting external source file from {0}{1}{2}", source.Uri, Environment.NewLine, e.Message);
        return null;
      }
    }

    public FileInfo SourceFile { get; private set; }

    public IEnumerable<SourceManifest> Enabled
    {
      get { return _manifests.Where(x => x.Enabled); }
    }


    public SourceManifest Get(string name)
    {
      return _manifests.FirstOrDefault(manifest => manifest.Name == name);
    }

    public void Add(SourceManifest sourceManifest)
    {
      _manifests.Add(sourceManifest);
    }

    public IEnumerator<SourceManifest> GetEnumerator()
    {
      return _manifests.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }
  }
}
