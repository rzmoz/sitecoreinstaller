using DotNet.Basics.Sys;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.InstallerLib;
using SitecoreInstaller.Domain.InstallerLib.Licenses;
using SitecoreInstaller.Domain.InstallerLib.Sitecores;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRepository : DirPath, IInitializable
    {
        public SitecoreInstallerRepository(InstallerLibConfig sitecoeInstallerLibConfig)
            : base(sitecoeInstallerLibConfig.DataDirRoot.Add("SitecoreInstaller").RawPath)
        {
            Sitecore9s = new Sitecore9Repository(this);
            Licenses = new LicenseRepository(this);
        }

        public Sitecore9Repository Sitecore9s { get; }
        public LicenseRepository Licenses { get; }

        public void Init()
        {
            Sitecore9s.Init();
            Licenses.Init();
        }
    }
}
