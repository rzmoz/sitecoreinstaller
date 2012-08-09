using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    using SitecoreInstaller.Framework.Diagnostics;
    
    public interface IPipeline
    {
        void Init(ILog log);
    }
}
