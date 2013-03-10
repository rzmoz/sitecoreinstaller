namespace SitecoreInstaller.UI.ListBoxes
{
    using System.Windows.Forms;

    public class SourceEntryCheckedListBox : SourceEntryListControl<CheckedListBox>
    {
        public override void Init()
        {
            base.Init();
            if (ListBox.Items.Count > 0)
                ListBox.SelectedIndex = 0;
        }
    }
}
