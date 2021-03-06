﻿using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using SitecoreInstaller.Databases;

namespace SitecoreInstaller.Pipelines.LocalInstall
{
    public class AttachSqlhDatabasesStep : PipelineStep<InstallLocalArgs>
    {
        private readonly SqlDbService _dbService;

        public AttachSqlhDatabasesStep(SqlDbService dbService)
        {
            _dbService = dbService;
        }

        protected override Task RunImpAsync(InstallLocalArgs args, TaskIssueList issues, CancellationToken ct)
        {
            _dbService.AttacSqlhDatabases(args.SqlDatabaseFiles);
            return Task.CompletedTask;
        }
    }
}
