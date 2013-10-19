using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Domain.BuildLibrary
{
  public class SdnSource : ISource
  {
    public SdnSource(string name)
    {
      Name = name ?? GetType().Name + Guid.NewGuid();
    }

    public event EventHandler<EventArgs> Updating;
    public event EventHandler<EventArgs> Updated;

    public bool Enabled { get; set; }
    public string Name { get; private set; }
    public string Parameters { get; set; }

    public IEnumerable<SourceEntry> List(SourceType sourceType)
    {
      //read from local file
      //check for online update
      //download to local if online is updated
      yield break;
    }

    public BuildLibraryResource Get(SourceEntry sourceEntry, SourceType sourceType)
    {
      return null;
    }

    public IEnumerable<BuildLibraryResource> Get(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
    {
      return from sourceEntry in sourceEntries select Get(sourceEntry, sourceType);
    }

    public async Task UpdateAsync()
    {
      Log.This.Info("Initializing from {0}", Parameters);
      //dummy implementation
      await Task.Delay(1);
    }
    
    public bool Contains(string name, SourceType sourceType)
    {
      return false;
    }

    public BuildLibraryFile Add(string file, SourceType sourceType) { throw new NotImplementedException(); }
    public void Add(BuildLibraryFile buildLibraryFile, SourceType sourceType) { throw new NotImplementedException(); }
    public void Delete(SourceEntry sourceEntry, SourceType sourceType) { throw new NotImplementedException(); }
    public void Delete(IEnumerable<SourceEntry> keys, SourceType sourceType) { throw new NotImplementedException(); }
  }
}
