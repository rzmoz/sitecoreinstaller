using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller
{
    using SitecoreInstaller.UI;
    
    public partial class FrmPipelineResult : Form
    {
        public PipelineResult PipelineResult { get { return pipelineResult1; } }
        public FrmPipelineResult()
        {
            InitializeComponent();
            pipelineResult1.Resize += PipelineResult1Resize;
        }

        void PipelineResult1Resize(object sender, EventArgs e)
        {
            Height = pipelineResult1.Height + Dimensions.DialogOffsetHeight;
        }

        private void FrmPipelineResultLoad(object sender, EventArgs e)
        {
            Height = pipelineResult1.Height + Dimensions.DialogOffsetHeight;
        }
    }
}
