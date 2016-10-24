using Autofac;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Deployments;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InstallPipeline : DeploymentDirPipeline<InstallArgs>
    {
        public InstallPipeline(IContainer container, DeploymentsService deploymentsService) : base(container, deploymentsService)
        {
            /*AddStep<CopyDeploymentFilesStep>();
            var installBlock = AddBlock("Install Block");
            installBlock.AddBlock("Databases Block", BlockRunType.Sequential)
                .AddStep<InitInstallConnectionStringsStep>()
                .AddStep<AttachSqlhDatabasesStep>();
            installBlock.AddBlock("Website Block")
                .AddStep<InitWebsiteStep>()
                .AddStep<AddSiteToHostFileStep>();
                */
            AddStep<AddSiteToHostFileStep>();
        }
    }
}
