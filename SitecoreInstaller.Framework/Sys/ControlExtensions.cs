using System;

namespace SitecoreInstaller.Framework.Sys
{
    using System.Windows.Forms;

    public static class ControlExtensions
    {
        public static void CrossThreadSafe(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(code);
                return;
            }
            code.Invoke();
        }

        public static void CrossThreadSafeInvoke(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(code);
                return;
            }
            code.Invoke();
        }
    }
}
