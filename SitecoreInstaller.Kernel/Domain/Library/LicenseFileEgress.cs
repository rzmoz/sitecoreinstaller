using System;
using System.Linq;
using System.Xml.Linq;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public class LicenseFileEgress
    {
        public const string ModuleName = "SiteCore.License";

        public LicenseFileEgress(string name, XDocument licenseContent)
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

        public static LicenseFileEgress Parse(string name, string licenseXml)
        {
            return new LicenseFileEgress(name, XDocument.Parse(licenseXml));
        }

        public static LicenseFileEgress Load(FilePath licensefile)
        {
            throw new NotImplementedException();
            /*
            if (licensefile.Exists() == false)
                throw new IOException($"{licensefile} not found");
            var xml = XDocument.Parse(licensefile.ReadAllText());
            return new LicenseFileEgress(licensefile.Name, xml);

    */
        }

        public string Name { get; }
        public string Id { get; }
        public string Licensee { get; }
        public string Expiration { get; }
    }
}
