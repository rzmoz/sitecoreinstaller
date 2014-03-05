using System.Diagnostics;
using CSharp.Basics.Sys;
using CSharp.Basics.Sys.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace SitecoreInstaller.Azure.Packaging.CsPkg
{
    public class ScaaSEntryPoint : RoleEntryPoint
    {
        //http://blogs.msdn.com/b/windowsazure/archive/2013/01/14/the-right-way-to-handle-azure-onstop-events.aspx
        public override void OnStop()
        {
            Trace.TraceInformation("OnStop called webrole");
            var prc = new PerformanceCounter("ASP.NET", "Requests Current", "");

            while (true)
            {
                var rc = prc.NextValue();
                Trace.TraceInformation("ASP.NET Requests Current: " + rc.ToString());
                if (rc <= 0)
                    break;
                Wait.For(1.Seconds());
            }
        }
    }
}
