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
            lblFinishTitle.Text =string.Format("{0} finished", args.PipelineName.TokenizeWhenCharIsUpper().ToDelimiteredString());
            tbxDetails.Text = string.Empty;
            foreach (var message in args.Messages)
            {
                tbxDetails.Text +=string.Format("<{0}> {1}\r\n", message.LogType, message.Message);
            }

            tbxDetails.Visible = args.Messages.Any();
            btnCopyToClipboard.Visible = args.Messages.Any();
        }

        private void PipelineResult_Load(object sender, EventArgs e)
        {
            Height = UiSettings.Default.PipelineStatusHeightCollapsed;

        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbxDetails.Text);
            Services.Dialogs.Information("Text copied to clipboard.");
        }
    }
}
