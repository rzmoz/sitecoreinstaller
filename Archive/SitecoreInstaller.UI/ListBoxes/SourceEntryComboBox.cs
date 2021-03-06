﻿using System.Windows.Forms;
using CSharp.Basics.Sys;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.UI.ListBoxes
{
    public abstract class SourceEntryComboBox : SourceEntryListControl<ComboBox>
    {
        public override void Init()
        {
            base.Init();
            ListBox.Font = Styles.Fonts.LblRegular;
            ListBox.FlatStyle = Styles.ListBoxes.FlatStyle;
            ListBox.BackColor = Styles.ListBoxes.BackColor;
            ListBox.BackColor = Styles.ListBoxes.ForeColor;
            ListBox.SelectedIndex = ListBox.Items.Count - 1; //select last item
        }

        public void BuildLibrarySelectionsUpdated(object sender, GenericEventArgs<ProjectSettings> e)
        {
            var relevanteSourceentry = GetRelevantSourceEntry(e.Arg.BuildLibrarySelections);
            for (var i = 0; i < ListBox.Items.Count; i++)
            {
                if (((SourceEntry)ListBox.Items[i]).Key == relevanteSourceentry.Key)
                {
                    ListBox.SelectedIndex = i;
                    return;
                }
            }

            if (ListBox.Items.Count > 0)
                ListBox.SelectedIndex = 0;
        }

        protected abstract SourceEntry GetRelevantSourceEntry(BuildLibrarySelections buildLibrarySelections);

        public SourceEntry SelectedItem
        {
            get { return (SourceEntry)ListBox.SelectedItem; }
        }
    }
}
