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

    public class ConnectionStringsFile : IEnumerable<ConnectionStringEntry>
    {
        private readonly IDictionary<string, ConnectionStringEntry> _entries;

        public ConnectionStringsFile()
        {
            _entries = new Dictionary<string, ConnectionStringEntry>();
        }
        public ConnectionStringsFile(FileInfo file)
            : this()
        {
            Contract.Requires<ArgumentNullException>(file != null);
            File = file;
        }

        public ConnectionStringEntry this[string name]
        {
            get
            {
                if (string.IsNullOrEmpty(name.ToLower()))
                    return null;

                var key = name.ToLower();

                if (_entries.ContainsKey(key) == false)
                    return null;
                return _entries[key];
            }
        }

        public void Clear()
        {
            _entries.Clear();
        }

        public void Upsert(ConnectionStringEntry entry)
        {
            if (entry == null)
                return;
            var key = entry.Name.ToLower();

            if (_entries.ContainsKey(key))
                _entries[key] = entry;
            else
                _entries.Add(key, entry);
        }

        public void Remove(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;

            var key = name.ToLower();
            if (_entries.ContainsKey(key))
                _entries.Remove(key);
        }

        public void InitFromFile()
        {
            InitConnectionStringEntries();
            LowerCaseConnectionStringNames();
            CreateIfNotExists();
        }
        public void InitFromExistingDatabases(IEnumerable<string> databaseNames)
        {
            throw new NotImplementedException();
        }

        public FileInfo File { get; private set; }

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
            var emptyConnectionStrings = string.Format(ConnectionStringFormats.ConnectionStringDotConfig, String.Empty);
            emptyConnectionStrings.WriteToDisk(File);
        }

        private void LowerCaseConnectionStringNames()
        {
            var newEntryList = _entries.Values.Aggregate(string.Empty, (current, entry) => current + entry.ToString());
            var loweredConnectionStringFile = string.Format(ConnectionStringFormats.ConnectionStringDotConfig, newEntryList);
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
