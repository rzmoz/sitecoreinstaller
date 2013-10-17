namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System;
  using System.Collections;
  using System.Linq;
  using System.Collections.Generic;
  using System.IO;
  using System.Net;
  using System.Threading.Tasks;
  using System.Web.Security;
  using Sitecore.Configuration;
  using Sitecore.Diagnostics;
  using SitecoreInstaller.Framework.Configuration;
  using SitecoreInstaller.Framework.Web;
  using SitecoreInstaller.Framework.IO;

  public class SourceManifestRepository : IEnumerable<SourceManifest>
  {
    private List<SourceManifest> _manifests;

    public SourceManifestRepository(FileInfo sourceFile)
    {
      _manifests = new List<SourceManifest>();
      SourceFile = sourceFile;
    }

    public void Init()
    {
      _manifests = this.LoadManifests(SourceFile).ToList();
    }

    private IEnumerable<SourceManifest> LoadManifests(FileInfo sourceFile)
    {
      var manifests = new List<SourceManifest>();

      var sources = new ConfigFile<SourceManifestConfig>(sourceFile);
      sources.Load();
      manifests.AddRange(sources.Properties.Manifests);


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

      foreach (var fileInfo in files)
      {
        manifests.AddRange(this.LoadManifests(fileInfo));
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
