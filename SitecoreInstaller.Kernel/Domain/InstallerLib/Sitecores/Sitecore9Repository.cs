using System.Collections.Generic;
using System.Linq;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.InstallerLib.Sitecores
{
    public class Sitecore9Repository : DirPath, IInitializable
    {
        public Sitecore9Repository(DirPath parent)
            : base(parent.Add("Sitecore9s").RawPath)
        {
        }

        public IEnumerable<Sitecore9> GetAll()
        {
            return EnumerateDirectories().Select(d => new Sitecore9(d.ToDir()));
        }

        public Sitecore9 Get(string name)
        {
            var sc9 = new Sitecore9(this.Add(name));
            return sc9.Path.Exists() ? sc9 : null;
        }

        public void Init()
        {
            CreateIfNotExists();
        }
    }
}
