using DotNet.Basics.IO;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.Resources;
using SitecoreInstaller.Domain.Resources.Licenses;
using SitecoreInstaller.Domain.Resources.Sitecores;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRepository : DirPath, IInitializable
    {
        public SitecoreInstallerRepository(SitecoreInstallerConfig sitecoeInstallerConfig)
            : base(sitecoeInstallerConfig.DataDirRoot.Add("SitecoreInstaller").RawPath)
        {
            Sitecore9s = new Sitecore9Repository(this);
            Licenses = new LicenseRepository(this);
        }

        public Sitecore9Repository Sitecore9s { get; }
        public LicenseRepository Licenses { get; }

        public void Init()
        {
            CreateIfNotExists();
            Sitecore9s.Init();
            Licenses.Init();
        }
    }
}
