using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Pipelines;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.System;
    using SitecoreInstaller.UI.Properties;

    public partial class PipelineResult : UserControl
    {
        public PipelineResult()
        {
            InitializeComponent();
        }

        public Button Ok { get { return btnOk; } }

        public void Init()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Hide();
            SendToBack();
        }

        public void Result(PipelineEventArgs args)
        {
            lblFinishTitle.Text = string.Format("{0} finished", args.PipelineName.TokenizeWhenCharIsUpper().ToDelimiteredString());

            lblFinishTitle.Left = (Width / 2) - (lblFinishTitle.Width / 2);
            btnOk.Left = Width / 2 - btnOk.Width / 2;
        }
    }
}
