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

        public void Init()
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ParentForm == null)
                return;
            ParentForm.Close();
        }

        public void Result(PipelineEventArgs args)
        {
            lblFinishTitle.Text = args.PipelineName.TokenizeWhenCharIsUpper().ToDelimiteredString() + " finished";

            switch (args.Status)
            {
                case PipelineStatus.NoErrors:
                    lblResult.Text = "No errors detected.\r\n";
                    lblResult.ForeColor = Color.Black;
                    break;
                case PipelineStatus.SoftErrors:
                    lblResult.Text = "Error(s) detected!\r\n";
                    lblResult.ForeColor = Color.Red;
                    break;
                case PipelineStatus.HardErrors:
                    lblResult.Text = "Unrecoverable error(s) detected!\r\n";
                    lblResult.ForeColor = Color.Red;
                    break;
            }

            tbxDetails.Text = args.Messages.Aggregate(string.Empty, (current, message) => current + (message + "\r\n"));
            btnViewDetails.Visible = args.Messages.Any();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            tbxDetails.Visible = !tbxDetails.Visible;
            btnCopyToClipboard.Visible = tbxDetails.Visible;
            if (tbxDetails.Visible)
            {
                btnViewDetails.Text = "Hide details <<";
                Height = UiSettings.Default.PipelineStatusHeightExpanded;

            }
            else
            {
                btnViewDetails.Text = "Show details >>";
                Height = UiSettings.Default.PipelineStatusHeightCollapsed;
            }
        }

        private void PipelineResult_Load(object sender, EventArgs e)
        {
            tbxDetails.Visible = false;
            btnCopyToClipboard.Visible = false;
            btnViewDetails.Text = "Show details >>";
            Height = UiSettings.Default.PipelineStatusHeightCollapsed;
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbxDetails.Text);
            Services.Dialogs.Information("Text copied to clipboard.");
        }
    }
}
