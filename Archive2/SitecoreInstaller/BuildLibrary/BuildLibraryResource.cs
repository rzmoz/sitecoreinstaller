using DotNet.Basics.IO;
using Newtonsoft.Json;

namespace SitecoreInstaller.BuildLibrary
{
    public abstract class BuildLibraryResource
    {
        protected BuildLibraryResource(PathInfo path)
        {
            Path = path;
            Name = path.Name;
        }

        public string Name { get; }

        [JsonIgnore]
        public PathInfo Path { get; }
    }
}
