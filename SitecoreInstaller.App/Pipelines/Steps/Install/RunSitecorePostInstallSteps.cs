﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class RunSitecorePostInstallSteps : Step<PipelineEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineEventArgs args)
        {
            Services.Website.ExecutePostInstallSteps(args.ProjectSettings.Iis.Url, args.ProjectSettings.ProjectFolder.Website.Directory);
        }
    }
}