using System;
using System.Collections.Generic;
using System.Text;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public class SitecoreZipIngress : IIngressAsset
    {
        public string Name { get; }
        public PathInfo Source { get; }
        public PathType SourceType { get; }
    }
}
