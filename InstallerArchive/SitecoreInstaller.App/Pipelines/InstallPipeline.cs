using SitecoreInstaller.App.Pipelines.Preconditions;
using SitecoreInstaller.App.Pipelines.Steps;
using SitecoreInstaller.App.Pipelines.Steps.Install;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class InstallPipeline : Pipeline<PipelineApplicationEventArgs>
    {
        public InstallPipeline()
        {
            //Init preconditions
            AddPrecondition<CheckProjectNameIsSet>();
            AddPrecondition<CheckProjectDoesNotExist>();
            AddPrecondition<CheckSitecore>();
            AddPrecondition<CheckBinding>();
            AddPrecondition<CheckSqlConnection>();
            AddPrecondition<CheckLicense>();
            AddPrecondition<CheckWritePermissionToHostFile>();

            //Init steps
            AddStep<CreateProjectFolder>();
            AddStep<GrantPermissions>();
            AddStep<SaveProjectSettings>();
            AddStep<CopySitecore>();
            AddStep<Copy64BitAssemblies>();
            AddStep<CopyLicenseFile>();
            AddStep<SetDataFolder>();
            AddStep<CopyModuleFiles>();
            AddStep<FixReportingDatabaseNameWhichIsWronglyNamedAnalyticsInSevenPointFive>();
            AddStep<RunPreInstallPowerShellScripts>();
            AddStep<SetConnectionStrings>();
            AddStep<TransformConfigFiles>();
            AddStep<SetSitecoreSettings>();
            AddStep<AttachDatabases>();
            AddStep<AddSitenameToHostFile>();
            AddStep<CreateIisSiteAndAppPool>();
            AddStep<InstallRuntimeServices>();
            AddStep<InstallPackages>();
            AddStep<ConfigureFinishingTasks>();
            AddStep<DeserializeItems>();
            AddStep<TransformConfigFiles>();
            AddStep<RunPostInstallPowerShellScripts>();
            AddStep<WarmUpSite>();
        }
    }
}
