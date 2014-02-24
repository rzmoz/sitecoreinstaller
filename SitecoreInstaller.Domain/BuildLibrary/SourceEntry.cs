using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class SourceEntry : IComparable<SourceEntry>
    {
        public SourceEntry(string key, string sourceName)
        {
            if (key == null) { throw new ArgumentNullException("key"); }
            if (sourceName == null) { throw new ArgumentNullException("sourceName"); }
            Key = key;
            SourceName = sourceName;
        }

        public string Key { get; protected set; }
        public string SourceName { get; protected set; }

        public int CompareTo(SourceEntry other)
        {
            var keyComparison = Key.CompareTo(other.Key);
            return keyComparison != 0 ? keyComparison : SourceName.CompareTo(other.SourceName);
        }

        public bool Equals(SourceEntry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Key, Key);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(SourceEntry)) return false;
            return Equals((SourceEntry)obj);
        }

        public override int GetHashCode()
        {
            return (Key != null ? Key.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return string.Format("{0}", Key);
        }

        public static SourceEntry ParseString(string settingsString)
        {
            if (settingsString == null) throw new ArgumentNullException("settingsString");

            return new SourceEntry(settingsString, string.Empty);
        }
    }
}
