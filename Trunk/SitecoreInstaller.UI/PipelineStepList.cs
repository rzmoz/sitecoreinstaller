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
    using SitecoreInstaller.App;

    public partial class PipelineStepList : UserControl
    {
        private const int _ButtonHeight = 21;
        private const int _ButtonWidth = 190;
        private const int _ButtonSpacing = 1;

        private Func<AppSettings> _getAppSettings;

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

        public void Init(IPipeline pipeline, Func<AppSettings> getAppSettings)
        {
            _getAppSettings = getAppSettings;

            foreach (var step in pipeline.Steps)
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
                var stepAsLocal = step;
                button.Click += delegate
                    {
                        Services.AppSettings = _getAppSettings();
                        stepAsLocal.Invoke(this, EventArgs.Empty);
                    };
                Controls.Add(button);
            }
        }
    }
}
