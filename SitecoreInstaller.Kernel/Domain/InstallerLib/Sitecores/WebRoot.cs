using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.InstallerLib.Sitecores
{
    public class WebRoot : DirPath
    {
        public WebRoot(string path, params string[] segments) : base(path, segments)
        {
        }

        public WebRoot(string path, char pathSeparator, params string[] segments) : base(path, pathSeparator, segments)
        {
        }

        public DirPath Data => this.Add("Data");
        public DirPath Website => this.Add("Website");
    }
}
