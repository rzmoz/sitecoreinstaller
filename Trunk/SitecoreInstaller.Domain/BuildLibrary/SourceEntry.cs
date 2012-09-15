using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    using System.Diagnostics.Contracts;

    public class SourceEntry : IComparable<SourceEntry>
    {
        public SourceEntry(string key, string sourceName)
        {
            Contract.Requires<ArgumentNullException>(key != null);
            Contract.Requires<ArgumentNullException>(sourceName != null);

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

        public string ToSettingsString()
        {
            return string.Format("{0}|{1}", Key, SourceName);
        }
        public static SourceEntry ParseSettingsString(string settingsString)
        {
            if (string.IsNullOrEmpty(settingsString))
                throw new ArgumentException("settingsString is null or empty");

            var tokens = settingsString.Split('|');
            if (tokens.Length != 2)
                throw new ArgumentOutOfRangeException("Expected string in format <key>|<sourcename>");

            return new SourceEntry(tokens[0], tokens[1]);
        }
    }
}
