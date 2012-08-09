namespace SitecoreInstaller.UI.ListBoxes
{
    using System.Windows.Forms;

    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.UI.Properties;

    public class SourceEntryComboBox : SourceEntryListControl<ComboBox>
    {
        private readonly LinkLabel _lnkSelectedItem;
        private readonly ToolTip _toolTip;

        public SourceEntryComboBox()
        {
            _lnkSelectedItem = new LinkLabel();
            Controls.Add(_lnkSelectedItem);
            _toolTip = new ToolTip();
            _toolTip.SetToolTip(_lnkSelectedItem, "Click to change");
        }

        public override void Init()
        {
            _lnkSelectedItem.Top = 29;
            _lnkSelectedItem.Left = 1;
            _lnkSelectedItem.Width = 250;
            _lnkSelectedItem.Click += _lnkSelectedItem_Click;
            
            base.Init();
            ListBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            ListBox.SelectedIndex = ListBox.Items.Count - 1; //select last item
        }

        void ListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (UiUserSettings.Default.UseDeveloperMode)
            {
                _lnkSelectedItem.Visible = false;
                ListBox.Visible = true;
            }
            else
            {
                if (SelectedItem != null)
                    _lnkSelectedItem.Text = SelectedItem.Key;
                _lnkSelectedItem.Visible = true;
                ListBox.Visible = false;
            }
        }

        void _lnkSelectedItem_Click(object sender, System.EventArgs e)
        {
            _lnkSelectedItem.Visible = false;
            ListBox.Visible = true;
        }

        public SourceEntry SelectedItem
        {
            get { return (SourceEntry)ListBox.SelectedItem; }
        }
    }
}
