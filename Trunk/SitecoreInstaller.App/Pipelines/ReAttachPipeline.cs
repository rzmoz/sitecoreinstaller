using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines
{
    using SitecoreInstaller.App.Pipelines.Preconditions;
    using SitecoreInstaller.App.Pipelines.Steps.Install;
    using SitecoreInstaller.Domain.Pipelines;

    public class ReAttachPipeline : Pipeline
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
        }
    }
}
