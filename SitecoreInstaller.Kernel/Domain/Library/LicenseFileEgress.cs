using System;
using System.Linq;
using System.Xml.Linq;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Kernel.Domain.Library
{
    public class LicenseFileEgress : FilePath, IEgressAsset
    {
        public const string ModuleName = "SiteCore.License";

        public LicenseFileEgress(string path, XDocument licenseContent) : base(path)
        {
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

        public string Id { get; }
        public string Licensee { get; }
        public string Expiration { get; }
    }
}
