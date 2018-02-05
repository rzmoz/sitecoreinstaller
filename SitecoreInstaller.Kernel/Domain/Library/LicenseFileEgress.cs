using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public class LicenseFileEgress : EgressAsset
    {
        public const string ModuleName = "SiteCore.License";
        private const string _extension = ".xml";

        public LicenseFileEgress(string name) : base(name, ContainerNames.Licenses, PathType.File)
        {
        }

        public override bool Load(DirPath containerDir)
        {
            var source = containerDir.ToFile(Name.EnsureSuffix(_extension));
            if (source.Exists() == false)
                throw new FileNotFoundException(source.FullName());

            var xml = XDocument.Parse(source.ReadAllText());

            var moduleNode = xml.Root?.Descendants().FirstOrDefault(x => x.Name.LocalName == "Object" && x.Attribute("Id")?.Value == ModuleName);
            if (moduleNode == null)
                throw new ArgumentException($"License module: {ModuleName} not found in license info");

            var licenseNode = moduleNode.Descendants("license").FirstOrDefault();
            if (licenseNode == null)
                throw new ArgumentException($"License node not found in license module: {moduleNode.ToString(SaveOptions.DisableFormatting)}");
            Id = licenseNode.Descendants("id").FirstOrDefault()?.Value;
            Licensee = licenseNode.Descendants("licensee").FirstOrDefault()?.Value;
            Expiration = licenseNode.Descendants("expiration").FirstOrDefault()?.Value;

            //all are set meaning we found the license and the content is valid
            return Id != null && Licensee != null && Expiration != null;
        }

        public string Id { get; private set; }
        public string Licensee { get; private set; }
        public string Expiration { get; private set; }
    }
}
