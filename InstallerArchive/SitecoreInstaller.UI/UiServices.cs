using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.UI.Dialog;

namespace SitecoreInstaller.UI
{
    public static class UiServices
    {
        static UiServices()
        {
            ProjectSettings = new ProjectSettings();
            ViewportStack = new ViewportStack();
            Dialogs = new UserDialogs(null);
        }

        public static void Init(Control.ControlCollection controlCollection)
        {
            Dialogs = new UserDialogs(controlCollection);
        }

        public static ProjectSettings ProjectSettings { get; private set; }
        public static UserDialogs Dialogs { get; private set; }
        public static ViewportStack ViewportStack { get; private set; }
    }
}
