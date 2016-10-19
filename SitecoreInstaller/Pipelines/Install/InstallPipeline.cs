﻿using Autofac;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Pipelines;

namespace SitecoreInstaller.Pipelines.Install
{
    public class InstallPipeline : Pipeline<EventArgs<ProjectSettings>>
    {
        public InstallPipeline(IContainer container) : base(container)
        {
            this.AddStep<InitProjectDirStep>();
        }
    }
}
