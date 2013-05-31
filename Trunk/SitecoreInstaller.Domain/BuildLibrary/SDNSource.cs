﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.BuildLibrary
{
  public class SdnSource : ISource
  {
    public SdnSource(string name)
    {
      this.Name = name ?? this.GetType().Name + Guid.NewGuid();
    }

    public event EventHandler<EventArgs> Updating;
    public event EventHandler<EventArgs> Updated;

    public bool Enabled { get; set; }
    public string Name { get; private set; }
    public string Parameters { get; set; }

    public IEnumerable<SourceEntry> List(SourceType sourceType)
    {
      yield break;
    }

    public BuildLibraryResource Get(SourceEntry sourceEntry, SourceType sourceType)
    {
      return null;
    }

    public IEnumerable<BuildLibraryResource> Get(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType)
    {
      yield break;
    }

    public async Task Update()
    {
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
