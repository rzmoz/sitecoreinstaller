namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.App.Pipelines.Steps.Archiving;
    using SitecoreInstaller.App.Pipelines.Steps.Uninstall;
    using SitecoreInstaller.Domain.Pipelines;

    public class ArchivePipeline : Pipeline
    {
        public ArchivePipeline()
        {
            var uninstallPipeline = new UninstallPipeline();

            //Init preconditions
            AddPreconditions(uninstallPipeline.Preconditions);

            //Init steps
            AddSteps(uninstallPipeline.Steps);
            AddStep<CleanProjectForArchiving>();
            AddStep<ZipProjectForArchiving>();
            AddStep<MoveZipToArchiveFolder>();
            RemoveStep<DeleteProject>();
        }
    }
}
