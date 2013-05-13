﻿using System;
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
  using SitecoreInstaller.Framework.System;

  public partial class MainDeveloper : UserControl
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

      selectProjectName1.FocusTextBox();
    }

    public void BuildLibrarySelectionsUpdated(object sender, GenericEventArgs<BuildLibrarySelections> e)
    {
      selectSitecore1.BuildLibrarySelectionsUpdated(sender, e);
      selectLicense1.BuildLibrarySelectionsUpdated(sender, e);
      selectModules1.BuildLibrarySelectionsUpdated(sender, e);
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case Keys.N | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<DoNothingPipeline>();
          break;
        case Keys.B | Keys.Control | Keys.Shift:
          this.UpdateBuildLibrarySelections();
          Services.Pipelines.Run<InstallPipeline>();
          break;
        case Keys.U | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<UninstallPipeline>();
          break;
        case Keys.R | Keys.Control | Keys.Shift:
          this.UpdateBuildLibrarySelections();
          Services.Pipelines.Run<ReinstallPipeline>(Dialogs.Off);
          break;
        case Keys.R | Keys.Control:
          Services.BuildLibrary.Update();
          break;
        case Keys.O | Keys.Control:
          Services.Website.OpenFrontend(Services.ProjectSettings.Iis.Url);
          break;
        case Keys.O | Keys.Control | Keys.Shift:
          Services.Website.OpenSitecore(Services.ProjectSettings.Iis.Url, Services.ProjectSettings.ProjectFolder.Website.Directory);
          break;
        case Keys.O | Keys.Control | Keys.Alt:
          Process.Start(Services.ProjectSettings.ProjectFolder.Directory.FullName);
          break;
        default:
          return base.ProcessCmdKey(ref msg, keyData);
      }
      return true;
    }

    private void UpdateBuildLibrarySelections()
    {
      Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = this.selectSitecore1.SelectedItem;
      Services.ProjectSettings.BuildLibrarySelections.SelectedLicense = this.selectLicense1.SelectedItem;
      Services.ProjectSettings.BuildLibrarySelections.SelectedModules = this.selectModules1.SelectedModules;
    }
  }
}