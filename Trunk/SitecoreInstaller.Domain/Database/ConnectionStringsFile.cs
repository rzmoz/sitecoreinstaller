using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain.Database
{
    using System.Collections;
    using System.Diagnostics.Contracts;

    using SitecoreInstaller.Framework.System;

    public class ConnectionStringsFile : IEnumerable<ConnectionStringEntry>
    {
        private readonly IDictionary<string, ConnectionStringEntry> _entries;

        public FileInfo File { get; private set; }

        public ConnectionStringsFile(FileInfo file)
        {
            Contract.Requires<ArgumentNullException>(file != null);
            File = file;
            _entries = new Dictionary<string, ConnectionStringEntry>();
        }

        public ConnectionStringEntry this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    return null;

                var key = name.ToLower();

                if (_entries.ContainsKey(key) == false)
                    return null;
                return _entries[key];
            }
        }

        public void Init()
        {
            File.TryBackup();
            InitConnectionStringEntries();
            LowerCaseConnectionStringNames();
            CreateIfNotExists();
        }
        
        private void InitConnectionStringEntries()
        {
            if (System.IO.File.Exists(File.FullName) == false)
                return;
            _entries.Clear();
            var connectionStrings = XDocument.Load(File.FullName);
            var entryElements = connectionStrings.Descendants("add");
            foreach (var entryElement in entryElements)
            {
                var name = entryElement.Attribute("name").Value;
                var connectionString = entryElement.Attribute("connectionString").Value;
                _entries.Add(name.ToLower(), new ConnectionStringEntry(name, connectionString));
            }
        }

        private void CreateIfNotExists()
        {
            if (System.IO.File.Exists(File.FullName))
                return;
            var emptyConnectionStrings = string.Format(DatabaseResource.ConnectionStringsFormat, String.Empty);
            emptyConnectionStrings.WriteToDisk(File);
        }

        private void LowerCaseConnectionStringNames()
        {
            var newEntryList = _entries.Values.Aggregate(string.Empty, (current, entry) => current + entry.ToString());
            var loweredConnectionStringFile = string.Format(DatabaseResource.ConnectionStringsFormat, newEntryList);
            loweredConnectionStringFile.WriteToDisk(File);
        }

        public IEnumerator<ConnectionStringEntry> GetEnumerator()
        {
            return _entries.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
