﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.WebServer;

namespace SitecoreInstallerConsole.Runners
{
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.Domain.Pipelines;

  public class InstallRunner : ConsolePipelineRunner
  {
    public InstallRunner()
    {
      CmdLine.RegisterParameter(SitecoreInstallerParameters.Install);
      CmdLine[SitecoreInstallerParameters.Install.Name].Required = true;
      CmdLine.RegisterParameter(SitecoreInstallerParameters.Sitecore);
      CmdLine.RegisterParameter(SitecoreInstallerParameters.License);
      CmdLine.RegisterParameter(SitecoreInstallerParameters.Modules);
    }

    public override void Run()
    {
      var projectName = CmdLine[SitecoreInstallerParameters.Install.Name].Value;
      var sitecore = CmdLine[SitecoreInstallerParameters.Sitecore.Name];

      if (string.IsNullOrEmpty(sitecore.Value))
        sitecore = SitecoreInstallerParameters.Latest;

      var license = CmdLine[SitecoreInstallerParameters.License.Name];
      if (string.IsNullOrEmpty(license.Value))
        license = SitecoreInstallerParameters.Latest;
      

      var modules = CmdLine[SitecoreInstallerParameters.Modules.Name];

      Console.WriteLine("Project name: " + projectName);
      Console.WriteLine("Sitecore: " + sitecore.Value);
      Console.WriteLine("License: " + license.Value);
      Console.WriteLine("Modules: " + modules.Value);

      var selectedModules = new List<SourceEntry>();

      foreach (var module in modules.Value.Split('|'))
        selectedModules.Add(new SourceEntry(module, string.Empty)); 

      Install(projectName, sitecore.Value, license.Value, selectedModules);
    }

    private void Install(string projectName, string sitecore, string license, IEnumerable<SourceEntry> selectedModules)
    {
      Services.ProjectSettings.ProjectName = projectName;
      Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = new SourceEntry(sitecore, string.Empty);
      Services.ProjectSettings.BuildLibrarySelections.SelectedLicense = new SourceEntry(license, string.Empty);
      if (sitecore == SitecoreInstallerParameters.Latest.Name)
        Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = Services.BuildLibrary.List(SourceType.Sitecore).Last();
      else
        Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = new SourceEntry(sitecore, string.Empty);
      if (license == SitecoreInstallerParameters.Latest.Name)
        Services.ProjectSettings.BuildLibrarySelections.SelectedLicense = Services.BuildLibrary.List(SourceType.License).Last();
      else
        Services.ProjectSettings.BuildLibrarySelections.SelectedLicense = new SourceEntry(license, string.Empty);
      Services.ProjectSettings.BuildLibrarySelections.SelectedModules = selectedModules;

      Services.Pipelines.Run<InstallPipeline>(Dialogs.Off);
    }
  }
}