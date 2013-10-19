using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.UI.UserSelections
{
  using System;
  using System.Windows.Forms;
  using SitecoreInstaller.App;

  public partial class SelectProjectName : UserControl
  {
    public SelectProjectName()
    {
      InitializeComponent();
    }

    public string ProjectName
    {
      get { return cbxProjectName.Text; }
      set { cbxProjectName.Text = value ?? string.Empty; }
    }

    public ComboBoxStyle DropDownStyle
    {
      get { return cbxProjectName.DropDownStyle; }
      set { cbxProjectName.DropDownStyle = value; }
    }

    public void Init()
    {
      cbxProjectName.Font = Styles.Fonts.LblRegular;
      cbxProjectName.Text = string.Empty;
      UpdateList();
      Services.BuildLibrary.Updated += this.BuildLibraryUpdated;
    }

    public void FocusTextBox()
    {
      cbxProjectName.Focus();
    }

    void BuildLibraryUpdated(object sender, EventArgs e)
    {
      this.UpdateList();
    }

    public void UpdateList()
    {
      this.CrossThreadSafe(() =>
      {
        cbxProjectName.Items.Clear();
        var existingProjects = Services.Projects.GetExistingProjects();
        foreach (var existingProject in existingProjects)
        {
          cbxProjectName.Items.Add(existingProject);
        }
      });
    }

    private void cbxProjectName_SelectedIndexChanged(object sender, EventArgs e)
    {
      UiServices.ProjectSettings.ProjectName = this.cbxProjectName.Text;
    }

    private void cbxProjectName_TextUpdate(object sender, EventArgs e)
    {
      UiServices.ProjectSettings.ProjectName = this.cbxProjectName.Text;
    }
  }
}
