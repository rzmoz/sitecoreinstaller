using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.App.Pipelines.Preconditions;
using SitecoreInstaller.App.Pipelines.Steps;
using SitecoreInstaller.App.Pipelines.Steps.Install;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
  public class ReAttachPipeline : Pipeline<PipelineApplicationEventArgs>
  {
    public ReAttachPipeline()
    {
      //Init preconditions
      AddPrecondition<CheckProjectNameIsSet>();
      AddPrecondition<CheckWritePermissionToHostFile>();
      AddPrecondition<CheckSqlConnection>();

      //Init steps
      AddStep<AttachDatabases>();
      AddStep<AddSitenameToHostFile>();
      AddStep<CreateIisSiteAndAppPool>();
      AddStep<WarmUpSite>();
    }
  }
}
