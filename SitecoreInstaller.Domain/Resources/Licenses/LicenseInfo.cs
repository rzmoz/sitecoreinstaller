using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.Resources.Licenses
{
    public class LicenseInfo
    {
        public const string ModuleName = "SiteCore.License";

        public LicenseInfo(string name, XDocument licenseContent)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (licenseContent == null) throw new ArgumentNullException(nameof(licenseContent));
            var moduleNode = licenseContent.Root.Descendants().FirstOrDefault(x => x.Name.LocalName == "Object" && x.Attribute("Id").Value == ModuleName);
            if (moduleNode == null)
                throw new ArgumentException($"License module: {ModuleName} not found in license info");

            var licenseNode = moduleNode.Descendants("license").FirstOrDefault();
            if (licenseNode == null)
                throw new ArgumentException($"License node not found in license module: {moduleNode.ToString(SaveOptions.DisableFormatting)}");
            Id = licenseNode.Descendants("id").FirstOrDefault().Value;
            Licensee = licenseNode.Descendants("licensee").FirstOrDefault().Value;
            Expiration = licenseNode.Descendants("expiration").FirstOrDefault().Value;
        }

        public static LicenseInfo Parse(string name, string licenseXml)
        {
            return new LicenseInfo(name, XDocument.Parse(licenseXml));
        }

        public static LicenseInfo Load(FilePath licensefile)
        {
            if (licensefile.Exists() == false)
                throw new IOException($"{licensefile} not found");
            var xml = XDocument.Parse(licensefile.ReadAllText());
            return new LicenseInfo(licensefile.Name, xml);
        }

        public string Name { get; }
        public string Id { get; }
        public string Licensee { get; }
        public string Expiration { get; }
    }
}
