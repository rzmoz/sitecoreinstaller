using System;

namespace SitecoreInstaller.Framework.Sys
{
    using System.Windows.Forms;

    public static class ControlExtensions
    {
        public static void CrossThreadSafe(this Control control, Action code)
        {
            if (control.InvokeRequired || control.IsHandleCreated)
            {
                control.BeginInvoke(code);
                return;
            }
            code.Invoke();
        }
    }
}
