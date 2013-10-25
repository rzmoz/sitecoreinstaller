﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
  public class InstallPackages : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      var selectedModules = (Services.BuildLibrary.Get(args.ProjectSettings.BuildLibrarySelections.SelectedModules, SourceType.Module)).ToList();
      Services.Website.InstallPackages(args.ProjectSettings.Iis.Url, selectedModules.OfType<BuildLibraryDirectory>());
      Services.Website.InstallPackages(args.ProjectSettings.Iis.Url, selectedModules.OfType<BuildLibraryFile>());
    }
  }
}
