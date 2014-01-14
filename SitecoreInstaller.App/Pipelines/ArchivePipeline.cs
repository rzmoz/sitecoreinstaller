using SitecoreInstaller.App.Pipelines.Preconditions;
using SitecoreInstaller.App.Pipelines.Steps;
using SitecoreInstaller.App.Pipelines.Steps.Archiving;
using SitecoreInstaller.App.Pipelines.Steps.Install;
using SitecoreInstaller.App.Pipelines.Steps.Uninstall;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class ArchivePipeline : Pipeline<ArchiveEventArgs>
    {
        public ArchivePipeline()
        {
            //Init preconditions
            AddPrecondition<CheckProjectNameIsSet>();
            AddPrecondition<CheckWritePermissionToHostFile>();
            AddPrecondition<CheckProjectExists>();
            AddPrecondition<CheckSqlConnection>();

            //Init steps
            AddStep<StopApplication>();
            AddStep<DetachDatabases>();
            AddStep<CleanProjectForArchiving>();
            AddStep<ZipAndMoveToArchiveFolder>();
            AddStep<SaveProjectSettings>();
            AddStep<CopyLicensefile>();
            AddStep<AttachDatabases>();
            AddStep<StartApplication>();
            AddStep<WarmUpSite>();
        }
    }
}
