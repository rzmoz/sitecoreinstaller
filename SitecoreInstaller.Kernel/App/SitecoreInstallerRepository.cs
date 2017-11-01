using DotNet.Basics.Sys;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.Library;
using SitecoreInstaller.Domain.Library.Sitecores;
using SitecoreInstaller.Domain.Library.Licenses;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRepository : DirPath, IInitializable
    {
        public SitecoreInstallerRepository(LibraryConfig libraryConfig)
            : base(libraryConfig.DataDirRoot.Add("SitecoreInstaller").RawPath)
        {
            Licenses = new LicenseRepository(this);
            Sitecore9s = new Sitecore9Repository(this);
        }

        public LicenseRepository Licenses { get; }
        public Sitecore9Repository Sitecore9s { get; }
        

        public void Init()
        {
            
            Licenses.Init();
            Sitecore9s.Init();
        }
    }
}
