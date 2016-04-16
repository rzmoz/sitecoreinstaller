using DotNet.Basics.Diagnostics;
using DotNet.Basics.Ioc;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.Cmdlets
{
    public class SiRegistrations : IIocRegistrations
    {
        public void RegisterIn(IocContainer container)
        {
            container.Register<EventDiagnostics>();
            container.RegisterSingleton<PipelineRunner>(new PipelineRunner(container));
            container.Register<IBuildLibrary, IOBuildLibrary>();
        }
    }
}
