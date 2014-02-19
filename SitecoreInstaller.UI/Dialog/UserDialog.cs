using System;
using System.Threading.Tasks;
using CSharp.Basics.Forms;
using CSharp.Basics.Forms.Viewport;
using CSharp.Basics.Sys.Tasks;
using SitecoreInstaller.App;

namespace SitecoreInstaller.UI.Dialog
{
    public partial class UserDialog : BasicsUserControl
    {
        private readonly AwaitTask<bool> _userAcceptAwaitTask;
        private readonly AwaitTask _informationAwaitTask;

        public UserDialog()
        {
            InitializeComponent();
            _userAcceptAwaitTask = new AwaitTask<bool>();
            _informationAwaitTask = new AwaitTask();
        }

        public void Init()
        {
            BackColor = Styles.Theme.Light.Controls.BackColor;
            tbxText.BackColor = Styles.Theme.Light.Controls.BackColor;
            tbxText.Font = Styles.Fonts.LblRegular;
            lblTitle.Font = Styles.Fonts.H1;
        }

        public Task<bool> UserAcceptAsync(string question, params object[] arguments)
        {
            this.CrossThreadSafe(() =>
            {
                pnlUserAccept.Visible = true;
                pnlUserAccept.BringToFront();
                UiServices.ViewportStack.Show(this);
                lblTitle.Text = "Are you sure?";
                tbxText.Text = string.Format(question, arguments) + "?";
            });
            return _userAcceptAwaitTask.AwaitAsync();
        }
        public Task MessageAsync(DialogIcon dialogIcon, string title, string textFormat, params object[] arguments)
        {
            this.CrossThreadSafe(() =>
            {
                pnlModalDialog.Visible = true;
                pnlModalDialog.BringToFront();
                UiServices.ViewportStack.Show(this);
                lblTitle.Text = title;
                tbxText.Text = string.Format(textFormat, arguments);
            });
            return _informationAwaitTask.AwaitAsync();
        }

        private void btnAcceptYes_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Hide(this);
            _userAcceptAwaitTask.IsDone(true);
        }

        private void btnAcceptNo_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Hide(this);
            _userAcceptAwaitTask.IsDone(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Hide(this);
            _informationAwaitTask.IsDone();
        }
    }
}
