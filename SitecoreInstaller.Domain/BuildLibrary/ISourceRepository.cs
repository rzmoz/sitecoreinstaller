using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.BuildLibrary
{
  public interface ISourceRepository
    {
        event EventHandler<EventArgs> Updating;
        event EventHandler<EventArgs> Updated;

        BuildLibraryFile Add(string file, SourceType sourceType);
        void Add(BuildLibraryFile buildLibraryFile, SourceType sourceType);
        void Delete(SourceEntry sourceEntry, SourceType sourceType);
        void Delete(IEnumerable<SourceEntry> keys, SourceType sourceType);

        IEnumerable<SourceEntry> List(SourceType sourceType);
        BuildLibraryResource Get(SourceEntry sourceEntry, SourceType sourceType);
        IEnumerable<BuildLibraryResource> Get(IEnumerable<SourceEntry> sourceEntries, SourceType sourceType);
        void Update();
    }
}
