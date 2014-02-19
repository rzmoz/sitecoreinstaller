using System;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                UiServices.ViewportStack.Show(this);
                Show(btnYes);
                Show(btnNo);
                lblTitle.Text = "Are you sure?";
                tbxText.Text = string.Format(question, arguments) + "?";
            });
            return _userAcceptAwaitTask.AwaitAsync(() =>
            {
                Hide(btnYes);
                Hide(btnNo);
            });
        }
        public Task MessageAsync(DialogIcon dialogIcon, string title, string textFormat, params object[] arguments)
        {
            this.CrossThreadSafe(() =>
            {
                UiServices.ViewportStack.Show(this);
                Show(btnOk);
                lblTitle.Text = title;
                tbxText.Text = string.Format(textFormat, arguments);
            });
            return _informationAwaitTask.AwaitAsync(() => Hide(btnOk));
        }

        private void Show(Control ctrl)
        {
            this.CrossThreadSafe(() =>
            {
                ctrl.BringToFront();
                ctrl.Visible = true;    
            });
        }
        private void Hide(Control ctrl)
        {
            this.CrossThreadSafe(() =>
            {
                ctrl.SendToBack();
                ctrl.Visible = false;    
            });
        }


        private void btnYes_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Hide(this);
            _userAcceptAwaitTask.IsDone(true);
        }

        private void btnNo_Click(object sender, EventArgs e)
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
