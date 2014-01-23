using CSharp.Basics.Forms.Viewport;

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

        protected bool OpenOrCloseControlDependingOnCurrentState(BasicsUserControl control)
        {
            var visible = UiServices.ViewportStack.OpenOrCloseDependingOnCurrentState(control);
            if (visible)
                this.ToolTipTextActive = ToolTipWhenVisible;
            else
                this.ToolTipTextActive = ToolTipWhenNotVisible;

            return visible;
        }
    }
}
