using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
  using System.Diagnostics;
  using SitecoreInstaller.App;
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.Framework.Sys;
  using SitecoreInstaller.UI.Viewport;

  public partial class MainDeveloper : SIUserControl
  {
    public MainDeveloper()
    {
      InitializeComponent();
    }

    public void Init()
    {
      selectProjectName1.Init();
      selectSitecore1.Init();
      selectLicense1.Init();
      selectModules1.Init();
    }

    public void BuildLibrarySelectionsUpdated(object sender, GenericEventArgs<BuildLibrarySelections> e)
    {
      selectSitecore1.BuildLibrarySelectionsUpdated(sender, e);
      selectLicense1.BuildLibrarySelectionsUpdated(sender, e);
      selectModules1.BuildLibrarySelectionsUpdated(sender, e);
    }

    public override void OnShow()
    {
      base.OnShow();
      selectProjectName1.UpdateList();
      selectProjectName1.FocusTextBox();
    }

    public override bool ProcessKeyPress(Keys keyData)
    {
      //we only activate key board shortcuts, if we're visible
      if (ViewportStack.IsVisible(this) == false)
        return false;

      switch (keyData)
      {
        case Keys.D | Keys.Control | Keys.Shift:
          selectProjectName1.ProjectName = string.Empty;
          ViewportStack.Show("SitecoreInstaller.UI.MainSimple");
          return true;
        case Keys.B | Keys.Control | Keys.Shift:
          if (selectProjectName1.ProjectName.Length == 0)
          {
            Services.Dialogs.Information("Please enter project name");
            return true;
          }
          this.UpdateBuildLibrarySelections();
          Services.Pipelines.Run<InstallPipeline>(UiServices.ProjectSettings);
          return true;
        case Keys.C | Keys.Control:
          selectProjectName1.ProjectName = string.Empty;
          this.BuildLibrarySelectionsUpdated(this, new GenericEventArgs<BuildLibrarySelections>(new BuildLibrarySelections()));
          return true;
        case Keys.U | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<UninstallPipeline>(UiServices.ProjectSettings);
          return true;
        case Keys.R | Keys.Control | Keys.Shift:
          this.UpdateBuildLibrarySelections();
          Services.Pipelines.Run<ReinstallPipeline>(UiServices.ProjectSettings, Dialogs.Off);
          return true;
        case Keys.A | Keys.Control | Keys.Shift:
          this.UpdateBuildLibrarySelections();
          Services.Pipelines.Run<ArchivePipeline>(UiServices.ProjectSettings);
          return true;
        case Keys.O | Keys.Control:
          Services.Website.OpenFrontend(UiServices.ProjectSettings.Iis.Url);
          return true;
        case Keys.O | Keys.Control | Keys.Shift:
          Services.Website.OpenSitecore(UiServices.ProjectSettings.Iis.Url, UiServices.ProjectSettings.ProjectFolder.Website.Directory);
          return true;
        case Keys.O | Keys.Control | Keys.Alt:
          Process.Start(UiServices.ProjectSettings.ProjectFolder.Directory.FullName);
          return true;
      }
      return false;
    }

    private void UpdateBuildLibrarySelections()
    {
      UiServices.ProjectSettings.BuildLibrarySelections.SelectedSitecore = this.selectSitecore1.SelectedItem;
      UiServices.ProjectSettings.BuildLibrarySelections.SelectedLicense = this.selectLicense1.SelectedItem;
      UiServices.ProjectSettings.BuildLibrarySelections.SelectedModules = this.selectModules1.SelectedModules;
    }
  }
}

