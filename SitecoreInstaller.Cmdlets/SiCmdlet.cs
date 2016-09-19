using System;
using System.Management.Automation;
using SitecoreInstaller.Runtime;

namespace SitecoreInstaller.Cmdlets
{
    public abstract class SiCmdlet : Cmdlet
    {
        private RuntimeBootstrapper _bootstrapper;

        protected SiCmdlet()
        {
            _bootstrapper = new RuntimeBootstrapper();
        }

        protected void Log()
        {
            throw new NotImplementedException();
        }
    }
}
