using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System.Threading.Tasks;

  public abstract class WindowsSourceEntryRepository : IEnumerable<SourceEntry>
  {
    protected IDictionary<string, SourceEntry> Entries { get; private set; }

    protected WindowsSourceEntryRepository(DirectoryInfo root, BuildLibraryMode buildLibraryMode, SourceType sourceType)
    {
      if (root == null) { throw new ArgumentNullException("root"); }
      Root = root;
      Mode = buildLibraryMode;
      SourceType = sourceType;
      Entries = new Dictionary<string, SourceEntry>();
    }

    public DirectoryInfo Root { get; private set; }
    public BuildLibraryMode Mode { get; private set; }
    public SourceType SourceType { get; private set; }

    public abstract BuildLibraryResource Get(SourceEntry sourceEntry);

    public abstract Task Update(string sourceName);

    public IEnumerator<SourceEntry> GetEnumerator()
    {
      return Entries.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public bool ContainsKey(string key)
    {
      return Entries.ContainsKey(key.ToLower());
    }
  }
}
