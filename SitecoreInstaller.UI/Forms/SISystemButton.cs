using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI.Forms
{
    public class SISystemButton : SIButtonWithActiveState
    {
        public SISystemButton()
        {
            ToolTipWhenVisible = string.Empty;
            ToolTipWhenNotVisible = string.Empty;
        }

        protected string ToolTipWhenVisible { get; set; }
        protected string ToolTipWhenNotVisible { get; set; }

        protected bool OpenOrCloseControlDependingOnCurrentState(SIUserControl control)
        {
            var visible = ViewportStack.OpenOrCloseDependingOnCurrentState(control);
            if (visible)
                this.ToolTipTextActive = ToolTipWhenVisible;
            else
                this.ToolTipTextActive = ToolTipWhenNotVisible;

            return visible;
        }
    }
}
