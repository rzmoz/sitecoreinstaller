using System;
using System.Management.Automation;
using DotNet.Basics.Ioc;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.Cmdlets
{
    public abstract class SiCmdlet : Cmdlet
    {
        protected SiCmdlet()
        {
            var container = new SimpleContainer();
            container.Register(new SiRegistrations());
        }

        protected void Log()
        {

            throw new NotImplementedException();
        }
    }
}
