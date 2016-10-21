using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using DotNet.Basics.Collections;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Databases
{
    public class ConnectionStringsFile : IEnumerable<ConnectionStringEntry>
    {
        private readonly StringKeyDictionary<ConnectionStringEntry> _entries;
        private ConnectionStringEntryFactory _connectionStringEntryFactory = new ConnectionStringEntryFactory();

        public ConnectionStringsFile()
        {
            _entries = new StringKeyDictionary<ConnectionStringEntry>(DictionaryKeyMode.IgnoreKeyCase, KeyNotFoundMode.ReturnDefault);
        }
        public ConnectionStringsFile(string path)
            : this()
        {
            if (path == null) { throw new ArgumentNullException(nameof(path)); }

            File = path.ToFile();
        }

        public ConnectionStringEntry this[string name] => _entries[name];

        public void Clear()
        {
            _entries.Clear();
        }

        public void Upsert(ConnectionStringEntry entry)
        {
            if (entry == null)
                return;
            var key = entry.Name.DatabasePart.ToLower();

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

        public FilePath File { get; }

        private void InitConnectionStringEntries()
        {
            if (System.IO.File.Exists(File.FullName) == false)
                return;
            _entries.Clear();
            var connectionStrings = XDocument.Load(File.FullName);
            var entryElements = connectionStrings.Descendants("add");
            foreach (var entryElement in entryElements)
            {
                var name = entryElement.Attribute("name")?.Value;
                var connectionString = entryElement.Attribute("connectionString")?.Value;
                _entries.Add(name?.ToLower(), _connectionStringEntryFactory.Create(name, connectionString));
            }
        }

        private void CreateIfNotExists()
        {
            if (System.IO.File.Exists(File.FullName))
                return;
            var emptyConnectionStrings = string.Format(ConnectionStringFormats.ConnectionStringsFileFormat, string.Empty);
            emptyConnectionStrings.WriteAllText(File);
        }

        private void LowerCaseConnectionStringNames()
        {
            var newEntryList = _entries.Values.Aggregate(string.Empty, (current, entry) => current + entry.ToString());
            var loweredConnectionStringFile = string.Format(ConnectionStringFormats.ConnectionStringsFileFormat, newEntryList);
            loweredConnectionStringFile.WriteAllText(File);
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
