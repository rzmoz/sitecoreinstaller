﻿namespace SitecoreInstaller.UI.UserSelections
{
  using System;
  using System.Windows.Forms;
  using SitecoreInstaller.App;

  public partial class SelectProjectName : UserControl
  {
    public SelectProjectName()
    {
      this.InitializeComponent();
    }

    public string ProjectName
    {
      get { return this.cbxProjectName.Text; }
      set
      {
        if (string.IsNullOrEmpty(value))
          return;

        this.cbxProjectName.Text = value;
      }
    }
    public ComboBoxStyle DropDownStyle
    {
      get { return this.cbxProjectName.DropDownStyle; }
      set { this.cbxProjectName.DropDownStyle = value; }
    }
    public void Init()
    {
      this.cbxProjectName.Text = string.Empty;
      this.UpdateList();
      Services.BuildLibrary.Updated += this.BuildLibraryUpdated;
    }
    public void FocusTextBox()
    {
      this.cbxProjectName.Focus();
    }
    void BuildLibraryUpdated(object sender, EventArgs e)
    {
      this.UpdateList();
    }

    public void UpdateList()
    {
      this.cbxProjectName.Items.Clear();
      var existingProjects = Services.Projects.GetExistingProjects();
      foreach (var existingProject in existingProjects)
      {
        this.cbxProjectName.Items.Add(existingProject);
      }
    }

    private void cbxProjectName_SelectedIndexChanged(object sender, EventArgs e)
    {
      Services.ProjectSettings.ProjectName = this.cbxProjectName.Text;
    }

    private void cbxProjectName_TextUpdate(object sender, EventArgs e)
    {
      Services.ProjectSettings.ProjectName = this.cbxProjectName.Text;
    }
  }
}