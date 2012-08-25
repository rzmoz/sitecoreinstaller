using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.UI
{
    public partial class PipelineStepList : UserControl
    {
        private const int _ButtonHeight = 21;
        private const int _ButtonWidth = 190;
        private const int _ButtonSpacing = 1;

        public PipelineStepList()
        {
            InitializeComponent();
        }

        private int VerticalPosition(IStep step)
        {
            var verticalPosition = 0;
            if (step.Order == 1)
                return verticalPosition;
            verticalPosition += (step.Order - 1) * _ButtonHeight + _ButtonSpacing;
            verticalPosition -= _ButtonSpacing;
            return verticalPosition;
        }

        public void Init<T>(PipelineRunner<T> pipelineRunner) where T : class,IPipeline
        {
            RenderSteps(pipelineRunner);
        }

        private void RenderSteps<T>(PipelineRunner<T> pipelineRunner) where T : class,IPipeline
        {
            foreach (var step in pipelineRunner.Pipeline.Steps)
            {
                var button = new Button();
                SuspendLayout();

                button.Location = new Point(0, VerticalPosition(step));
                button.Name = string.Format("btn{0}", step.GetType().Name);
                button.Size = new Size(_ButtonWidth, _ButtonHeight);
                button.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                button.TabIndex = step.Order;
                button.Text = string.Format("{0}.{1}", step.Order, step.GetType().Name);
                button.UseVisualStyleBackColor = true;
                button.Click += step.Invoke;
                Controls.Add(button);
            }
        }
    }
}
