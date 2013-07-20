namespace SitecoreInstaller.UI.UserSelections
{
  using System;
  using System.Windows.Forms;
  using SitecoreInstaller.App;
  using SitecoreInstaller.UI.Viewport;

  public partial class SelectProjectName : UserControl
  {
    public SelectProjectName()
    {
      this.InitializeComponent();
    }

    public string ProjectName
    {
      get { return this.cbxProjectName.Text; }
      set { this.cbxProjectName.Text = value ?? string.Empty; }
    }

    public ComboBoxStyle DropDownStyle
    {
      get { return this.cbxProjectName.DropDownStyle; }
      set { this.cbxProjectName.DropDownStyle = value; }
    }
    
    public void Init()
    {
      this.cbxProjectName.Font = Styles.Fonts.LblRegular;
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
      UiServices.ProjectSettings.ProjectName = this.cbxProjectName.Text;
    }

    private void cbxProjectName_TextUpdate(object sender, EventArgs e)
    {
      UiServices.ProjectSettings.ProjectName = this.cbxProjectName.Text;
    }
  }
}
