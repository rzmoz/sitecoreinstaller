using System.Management.Automation;
using DotNet.Basics.Ioc;

namespace SitecoreInstaller.Cmdlets
{
    public abstract class SiCmdlet : Cmdlet
    {
        protected IDotNetContainer Container { get; }

        protected SiCmdlet()
        {
            Container = new DotNetContainer(new SiRegistrations());
        }
    }
}
