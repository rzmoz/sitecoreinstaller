using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    using System.IO;

    public class LicenseFileSourceEntry : SourceEntry
    {
        public LicenseFileSourceEntry(FileInfo file, string sourceName)
            : base(string.Empty, sourceName)
        {
            LicenseFile = new LicenseFile(file, DateTime.Now);
            Key = LicenseFile.ToString();
        }

        public LicenseFile LicenseFile { get; private set; }

        public bool Equals(LicenseFileSourceEntry other)
        {
            return base.Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return Equals(obj as LicenseFileSourceEntry);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
