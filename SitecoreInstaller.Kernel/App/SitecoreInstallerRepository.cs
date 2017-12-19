using DotNet.Basics.Sys;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App
{
    public class SitecoreInstallerRepository : DirPath, IInitializable
    {
        public SitecoreInstallerRepository(string rootDir)
            : base(rootDir)
        {
        }

        public void Init()
        {


        }
    }
}
