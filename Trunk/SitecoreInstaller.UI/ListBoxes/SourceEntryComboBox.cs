namespace SitecoreInstaller.UI.ListBoxes
{
  using System.Windows.Forms;

  using SitecoreInstaller.Domain.BuildLibrary;

  public class SourceEntryComboBox : SourceEntryListControl<ComboBox>
  {
    public override void Init()
    {
      base.Init();
      ListBox.FlatStyle = Styles.ListBoxes.FlatStyle;
      ListBox.BackColor = Styles.ListBoxes.BackColor;
      ListBox.BackColor = Styles.ListBoxes.ForeColor;
      ListBox.SelectedIndex = ListBox.Items.Count - 1; //select last item
    }

    public SourceEntry SelectedItem
    {
      get { return (SourceEntry)ListBox.SelectedItem; }
    }
  }
}
