﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class InstallRuntimeServices : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      Services.Website.InstallRuntimeServices(args.ProjectSettings.ProjectFolder.Website);
    }
  }
}
