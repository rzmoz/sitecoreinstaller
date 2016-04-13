using System;
using System.Linq;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    using System.IO;
    using System.Xml.Linq;

    public class LicenseFile : BuildLibraryFile
    {
        private readonly DateTime _referenceDate;

        public string Licensee { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public LicenseFile(string license, DateTime now)
            : base(null)
        {
            _referenceDate = now;
            var doc = XDocument.Parse(license);
            ProcessLicenseFile(doc);
        }

        internal LicenseFile(FileInfo file, DateTime now)
            : this(file, now, BuildLibraryMode.External)
        {
        }

        internal LicenseFile(FileInfo file, DateTime now, BuildLibraryMode buildLibraryMode)
            : base(file, buildLibraryMode)
        {
            _referenceDate = now;
            File = file;
            var doc = XDocument.Load(file.FullName);
            ProcessLicenseFile(doc);
        }



        public bool IsExpired { get; private set; }
        public int ExpiresIn { get; private set; }

        public bool ExpiresWithin(int days)
        {
            return ExpiresIn <= days;
        }

        private void ProcessLicenseFile(XDocument doc)
        {
            ParseContent(doc);
            IsExpired = ExpirationDate < _referenceDate;
            if (IsExpired)
                ExpiresIn = 0;
            else
                ExpiresIn = (int)Math.Ceiling((ExpirationDate - _referenceDate).TotalDays);
        }

        private void ParseContent(XDocument doc)
        {
            try
            {
                var licenseFile = doc.Descendants("license").Single();
                Licensee = licenseFile.Element("licensee").Value;
                var expirationString = licenseFile.Element("expiration").Value;
                ExpirationDate = DateTime.ParseExact(expirationString, "yyyyMMddThhmmss", null);
            }
            catch (InvalidOperationException)
            {
                throw new LicenseFileException("File doesn't seem to be a valid license file:  \r\n{0}\r\n", doc);
            }
        }

        public override string ToString()
        {
            return Licensee + " (" + ExpirationDate.ToString("yyyy-MM-dd") + ")";
        }

    }
}
