using System;
using System.Windows.Forms;
using CSharp.Basics.Forms;

namespace SitecoreInstaller.UI.Forms
{
    public partial class SISelectFolder : UserControl
    {
        public SISelectFolder()
        {
            InitializeComponent();
        }

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public new string Text
        {
            get { return tbxFolder.Text; }
            set
            {
                this.CrossThreadSafe(() =>
                {
                    tbxFolder.Text = value;
                });
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string selectedFolder;
            if (UiServices.Dialogs.ChooseFolder(out selectedFolder, this.tbxFolder.Text))
                tbxFolder.Text = selectedFolder;
        }
    }
}
