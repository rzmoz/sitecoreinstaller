using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class TempDir : DirPath
    {
        public TempDir(DirPath fullPath) : base(fullPath.FullName)
        {
        }

        public RuntimeServicesDir RuntimeServices => new RuntimeServicesDir(Add("SI" + nameof(RuntimeServices)));
    }
}
