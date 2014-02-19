using System;
using System.Threading.Tasks;
using CSharp.Basics.Forms.Viewport;

namespace SitecoreInstaller.UI.Dialogs
{
    public partial class UserDialog : BasicsUserControl
    {
        public UserDialog()
        {
            InitializeComponent();
        }

        public Task<bool> UserAccept(string question, params string[] arguments)
        {
            throw new NotImplementedException();
        }
    }
}
