using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    using SitecoreInstaller.App;

    public partial class UserSettingsDialog : UserControl
    {
        public UserSettingsDialog()
        {
            InitializeComponent();
        }

        public UserSettingsDialog Previous { get; set; }
        public UserSettingsDialog Next { get; set; }

        private UserSettingsMode _userSettingsMode;
        public UserSettingsMode UserSettingsMode
        {
            get { return _userSettingsMode; }
            set
            {
                _userSettingsMode = value;
                switch (value)
                {
                    case UserSettingsMode.Single:
                        pnlStepWizard.Hide();
                        pnlSingleOptions.Show();
                        pnlSingleOptions.BringToFront();
                        break;
                    case UserSettingsMode.StepWizard:
                        pnlSingleOptions.Hide();
                        pnlStepWizard.Show();
                        pnlStepWizard.BringToFront();
                        btnBack.Visible = Previous != null;
                        btnNext.Text = Next == null ? "Ok" : "Next";
                        break;
                }
            }
        }

        public virtual void Init()
        {
            UserSettingsMode = UserSettingsMode.Single;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Parent == null)
                return;
            Parent.SendToBack();
            Parent.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BtnSaveClick();
            btnCancel_Click(this, EventArgs.Empty);
        }
        public virtual void BtnSaveClick()
        { }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BtnSaveClick();
            Hide();
            Previous.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            BtnSaveClick();
            Hide();
            if (Next == null)
                btnCancel_Click(this, EventArgs.Empty);
            else
                Next.Show();
        }

        private void UserSettingsDialog_Load(object sender, EventArgs e)
        {
            switch (UserSettingsMode)
            {
                case UserSettingsMode.Single:
                    btnSave.Focus();
                    break;
                case UserSettingsMode.StepWizard:
                    btnNext.Focus();
                    break;
            }
        }
    }
}
