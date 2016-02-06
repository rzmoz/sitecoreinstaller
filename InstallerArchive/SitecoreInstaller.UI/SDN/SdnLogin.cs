using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using CSharp.Basics.Sys;
using CSharp.Basics.Sys.Tasks;

namespace SitecoreInstaller.UI.SDN
{
    public partial class SdnLogin : BasicsUserControl
    {
        public SdnLogin()
        {
            InitializeComponent();
        }

        public void Init()
        {

        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            const string loginUrl = "http://sdn.sitecore.net/sdn5/misc/loginpage.aspx";

            var browser = new WebBrowser();

            browser.Navigate(loginUrl);

            while (browser.Document == null)
            {
                Wait.For(100.MilliSeconds());
            }

            var doc = browser.Document;

            var email = doc.GetElementById("ctl09_emailTextBox");
            if (email != null)
            {
                email.SetAttribute("value", tbxUsername.Text);
                doc.GetElementById("ctl09_passwordTextBox").SetAttribute("value", tbxPassword.Text);
                doc.GetElementById("ctl09_loginButton").InvokeMember("click");

            }
        }
    }
}
