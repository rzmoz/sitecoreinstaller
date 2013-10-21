using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.UI.UserSelections
{
  using System;
  using System.Windows.Forms;
  using App;

  public partial class SelectProjectName : UserControl
  {
    public SelectProjectName()
    {
      InitializeComponent();
    }

    public event EventHandler<string> ProjectNameChanged;

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
    }

    public void FocusTextBox()
    {
      cbxProjectName.Focus();
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
      UiServices.ProjectSettings.ProjectName = cbxProjectName.Text;
    }

    void cbxProjectName_TextChanged(object sender, System.EventArgs e)
    {
      UiServices.ProjectSettings.ProjectName = cbxProjectName.Text;
      if (ProjectNameChanged != null)
        ProjectNameChanged(this, cbxProjectName.Text);
    }
  }
}
