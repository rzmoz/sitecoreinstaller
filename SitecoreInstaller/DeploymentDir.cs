using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class DeploymentDir : DirPath
    {
        public DeploymentDir(DirPath fullPath) : base(fullPath.FullName)
        {
        }

        public DirPath Databases => Add(nameof(Databases));
        public WebsiteDir Website => new WebsiteDir(Add(nameof(Website)));
        public FilePath DeploymentInfo => this.ToFile("DeploymentInfo.json");
    }
}
