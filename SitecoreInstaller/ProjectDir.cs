using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class ProjectDir : DirPath
    {
        public ProjectDir(DirPath fullPath) : base(fullPath.FullName)
        {
        }

        public DirPath Databases => this.Add(nameof(Databases));
        public WebsiteDir Website => new WebsiteDir(Add(nameof(Website)));
    }
}
