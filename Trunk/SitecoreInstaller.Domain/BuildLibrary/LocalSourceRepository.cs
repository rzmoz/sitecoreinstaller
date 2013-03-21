using System;
using System.Collections.Generic;
using System.Linq;

namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System.Threading.Tasks;
  using SitecoreInstaller.Framework.Diagnostics;

  public class LocalSourceRepository : ISourceRepository
  {
    private WindowsFileSystemSource _localBuildLibrary;
    private IDictionary<string, ISource> _sources;

    public LocalSourceRepository(WindowsFileSystemSource localBuildLibrary, IEnumerable<ISource> sources)
    {
      Init(localBuildLibrary, sources);
    }

    public void Init(WindowsFileSystemSource localBuildLibrary, IEnumerable<ISource> sources)
    {
      _localBuildLibrary = localBuildLibrary;
      _localBuildLibrary.SetMode(BuildLibraryMode.Local);

      _sources = new Dictionary<string, ISource> { { _localBuildLibrary.Name, _localBuildLibrary } };
      foreach (var source in sources)
        _sources.Add(source.Name, source);
    }

    public BuildLibraryFile Add(string file, SourceType sourceType)
    {
      var buildLibraryFile = _localBuildLibrary.Add(file, sourceType);
      Update();
      return buildLibraryFile;
    }

    public void Add(BuildLibraryFile buildLibraryFile, SourceType sourceType)
    {
      _localBuildLibrary.Add(buildLibraryFile, sourceType);
      Update();
    }

    public void Delete(SourceEntry sourceEntry, SourceType sourceType)
    {
      _localBuildLibrary.Delete(sourceEntry, sourceType);
      Update();
    }

    public void Delete(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
    {
      _localBuildLibrary.Delete(sourceEntries, sourceType);
    }

    public IEnumerable<SourceEntry> List(SourceType sourceType)
    {
      var sourcesList = new List<SourceEntry>(_localBuildLibrary.List(sourceType));
      foreach (var source in _sources)
        sourcesList.AddRange(NotInLocalFilter(source.Value.List(sourceType), sourceType));
      return sourcesList;
    }

    private IEnumerable<SourceEntry> NotInLocalFilter(IEnumerable<SourceEntry> sourceList, SourceType sourceType)
    {
      return sourceList.Where(sourceEntry => !_localBuildLibrary.Contains(sourceEntry.Key, sourceType));
    }
    public event EventHandler<EventArgs> Updating;
    public event EventHandler<EventArgs> Updated;

    public BuildLibraryResource Get(SourceEntry sourceEntry, SourceType sourceType)
    {
      Log.This.Info("Getting {0}", sourceEntry.Key);

      BuildLibraryResource resource;

      if (_localBuildLibrary.Contains(sourceEntry.Key, sourceType))
        resource = _localBuildLibrary.Get(sourceEntry, sourceType);
      else
        resource = _sources[sourceEntry.SourceName].Get(sourceEntry, sourceType);

      resource.TargetDirectory = _localBuildLibrary.Getfolder(sourceType);

      Log.This.Info("Copying '{0}'", sourceEntry.Key);
      resource.CopyToTargetDir(BuildLibraryMode.Local);

      Log.This.Info("Extracting '{0}'", sourceEntry.Key);
      resource = resource.Unpack();

      Log.This.Info("Updating buildlibrary");
      _localBuildLibrary.Update();

      if (resource.Mode == BuildLibraryMode.Local)
        return resource;

      return Get(sourceEntry, sourceType);//We keep getting source entry until resource is in local repository
    }

    public IEnumerable<BuildLibraryResource> Get(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
    {
      return from module in sourceEntries select Get(module, SourceType.Module);
    }

    public async Task Update()
    {
      if (Updating != null)
        Updating(this, new EventArgs());
      
      await Task.WhenAll(_sources.Select(s => s.Value.Update()));

      if (Updated != null)
        Updated(this, new EventArgs());
    }
  }
}
