namespace SitecoreInstaller.UI
{
  using System;
  using System.Linq;
  using System.Windows.Forms;

  using SitecoreInstaller.App;

  public partial class SelectProjectName : UserControl
  {
    public SelectProjectName()
    {
      InitializeComponent();
      lblProjectName.Font = Styles.Fonts.BaseRegular;
      lblProjectName.ForeColor = Styles.FontColors.LabelForeColor;
    }

    public string ProjectName
    {
      get { return cbxProjectName.Text; }
      set
      {
        if (string.IsNullOrEmpty(value))
          return;

        cbxProjectName.Text = value;
      }
    }
    public ComboBoxStyle DropDownStyle
    {
      get { return cbxProjectName.DropDownStyle; }
      set { cbxProjectName.DropDownStyle = value; }
    }
    public void Init()
    {
      cbxProjectName.Text = string.Empty;
      UpdateList();
      Services.BuildLibrary.Updated += BuildLibraryUpdated;
    }
    public void FocusTextBox()
    {
      cbxProjectName.Focus();
    }
    void BuildLibraryUpdated(object sender, EventArgs e)
    {
      UpdateList();
    }

    public void UpdateList()
    {
      cbxProjectName.Items.Clear();/*
      var existingProjects = Services.Projects.GetExistingProjects();
      foreach (var existingProject in existingProjects)
      {
        cbxProjectName.Items.Add(existingProject);
      }*/
    }
  }
}
