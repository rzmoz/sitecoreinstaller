namespace SitecoreInstaller.App.Pipelines
{
  using SitecoreInstaller.App.Pipelines.Preconditions;
  using SitecoreInstaller.App.Pipelines.Steps.Archiving;
  using SitecoreInstaller.App.Pipelines.Steps.Install;
  using SitecoreInstaller.App.Pipelines.Steps.Uninstall;
  using SitecoreInstaller.Domain.Pipelines;

  public class ArchivePipeline : Pipeline
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
    }
  }
}
