namespace SitecoreInstaller.UI.ListBoxes
{
    using System.Windows.Forms;

    public class SourceEntryCheckedListBox : SourceEntryListControl<CheckedListBox>
    {
        public override void Init()
        {
            ListBox.Font = Styles.Fonts.LblRegular;

            base.Init();
            if (ListBox.Items.Count > 0)
                ListBox.SelectedIndex = 0;
        }
    }
}
