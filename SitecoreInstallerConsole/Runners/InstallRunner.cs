using System;
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

    public override void Run(ProjectSettings projectSettings)
    {
      this.SetProjectName(projectSettings);

      this.SetSelectedSitecore(projectSettings);

      this.SetSelectedLicense(projectSettings);

      this.SetSelecteModules(projectSettings);

      Services.Pipelines.Run<InstallPipeline>(projectSettings, Dialogs.Off);
    }

    private void SetSelecteModules(ProjectSettings projectSettings)
    {
      var modules = this.CmdLine[SitecoreInstallerParameters.Modules.Name];

      var selectedModules = new List<SourceEntry>();

      foreach (var module in modules.Value.Split('|'))
      {
        selectedModules.Add(new SourceEntry(module, string.Empty));
      }

      projectSettings.BuildLibrarySelections.SelectedModules = selectedModules;

      Console.WriteLine("Modules: " + modules.Value);
    }

    private void SetSelectedLicense(ProjectSettings projectSettings)
    {
      var license = this.CmdLine[SitecoreInstallerParameters.License.Name];
      if (string.IsNullOrEmpty(license.Value))
      {
        license = SitecoreInstallerParameters.Latest;
      }

      if (license.Value == SitecoreInstallerParameters.Latest.Name)
      {
        projectSettings.BuildLibrarySelections.SelectedLicense = Services.BuildLibrary.List(SourceType.License).Last();
      }
      else
      {
        projectSettings.BuildLibrarySelections.SelectedLicense = new SourceEntry(license.Value, string.Empty);
      }


      Console.WriteLine("License: " + license.Value);
    }

    private void SetSelectedSitecore(ProjectSettings projectSettings)
    {
      var sitecore = this.CmdLine[SitecoreInstallerParameters.Sitecore.Name];

      if (string.IsNullOrEmpty(sitecore.Value))
      {
        sitecore = SitecoreInstallerParameters.Latest;
      }

      if (sitecore.Value == SitecoreInstallerParameters.Latest.Name)
      {
        projectSettings.BuildLibrarySelections.SelectedSitecore = Services.BuildLibrary.List(SourceType.Sitecore).Last();
      }
      else
      {
        projectSettings.BuildLibrarySelections.SelectedSitecore = new SourceEntry(sitecore.Value, string.Empty);
      }

      Console.WriteLine("Sitecore: " + sitecore.Value);
    }

    private void SetProjectName(ProjectSettings projectSettings)
    {
      var projectName = this.CmdLine[SitecoreInstallerParameters.Install.Name].Value;
      projectSettings.ProjectName = projectName;

      Console.WriteLine("Project name: " + projectName);
    }
  }
}