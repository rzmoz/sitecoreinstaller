using System;
using System.Threading.Tasks;
using CSharp.Basics.Forms;
using CSharp.Basics.Forms.Viewport;

namespace SitecoreInstaller.UI.Dialog
{
    public partial class UserDialog : BasicsUserControl
    {
        private readonly InputTask<bool> _acceptInputTask;

        public UserDialog()
        {
            InitializeComponent();
            _acceptInputTask = new InputTask<bool>();
        }

        public void Init()
        {
            BackColor = Styles.Theme.Light.Controls.BackColor;
        }

        public Task<bool> UserAccept(string question, params object[] arguments)
        {
            this.CrossThreadSafe(() =>
            {
                UiServices.ViewportStack.Show(this);
                lblText.Text = string.Format(question, arguments) + "?";
            });
            return _acceptInputTask.WaitForInputAsync(() => { });
        }

        private void btnAcceptYes_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Hide(this);
            _acceptInputTask.SetResult(true);
        }

        private void btnAcceptNo_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Hide(this);
            _acceptInputTask.SetResult(false);
        }
    }
}
