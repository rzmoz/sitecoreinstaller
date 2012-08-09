using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    using System.Diagnostics.Contracts;

    using SitecoreInstaller.Framework.Diagnostics;

    public abstract class WindowsSourceEntryRepository : IEnumerable<SourceEntry>
    {
        protected IDictionary<string, SourceEntry> Entries { get; private set; }

        protected WindowsSourceEntryRepository(DirectoryInfo root, BuildLibraryMode buildLibraryMode)
        {
            Contract.Requires<ArgumentNullException>(root != null);

            Root = root;
            Mode = buildLibraryMode;
            Entries = new Dictionary<string, SourceEntry>();
        }

        public DirectoryInfo Root { get; private set; }
        public ILog Log { get; set; }
        public BuildLibraryMode Mode { get; private set; }


        public abstract BuildLibraryResource Get(SourceEntry sourceEntry);

        public abstract void Update(string sourceName);

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
