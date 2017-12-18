using System;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Kernel.Domain.Library
{
    public class Sitecore8Ingress : DirPath, IIngressAsset
    {
        public Sitecore8Ingress(string path) : base(path)
        {
        }

        public PathInfo Source => this;
        public void Extract(DirPath targetDir)
        {
            throw new NotImplementedException();
        }
    }
}
