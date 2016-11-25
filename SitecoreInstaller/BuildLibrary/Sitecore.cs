using DotNet.Basics.IO;
using Newtonsoft.Json;

namespace SitecoreInstaller.BuildLibrary
{
    public class Sitecore : BuildLibraryResource
    {
        public Sitecore(DirPath path) : base(path)
        {
        }

        [JsonIgnore]
        public DirPath Databases => Path.ToDir(nameof(Databases));
        [JsonIgnore]
        public DirPath Data => Path.ToDir(nameof(Data));
        [JsonIgnore]
        public DirPath Website => Path.ToDir(nameof(Website));
    }
}
