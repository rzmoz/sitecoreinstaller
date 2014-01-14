using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SitecoreInstaller.App;
using SitecoreInstaller.UI.Forms;

namespace SitecoreInstaller.UI.SDN
{
    public class SdnLoginButton : SISystemButton
    {
        public SdnLoginButton()
        {
            FlatAppearance.BorderSize = 0;
            this.Image = SdnResources.Login_Failed;
            this.ImageActive = SdnResources.Login_Ok;
            this.Text = string.Empty;
            this.Click += SdnLoginButton_Click;
        }

        public SdnLogin SdnLogin { get; private set; }

        public void Init(SdnLogin sdnLogin, ToolTip toolTip = null)
        {
            SdnLogin = sdnLogin;
            base.Init(toolTip);
        }

        void SdnLoginButton_Click(object sender, EventArgs e)
        {
            if (Services.PipelineWorker.IsBusy())
                return;

            this.OpenOrCloseControlDependingOnCurrentState(SdnLogin);
        }
    }
}
