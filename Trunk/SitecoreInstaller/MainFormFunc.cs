using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller
{
    using System.Windows.Forms;

    using SitecoreInstaller.App;
    using SitecoreInstaller.Framework.Diagnostics;

    internal abstract class MainFormFunc
    {
        protected MainFormFunc(FrmMain mainForm)
        {
            MainForm = mainForm;
            Log.ItAs.Clear();
        }

        public FrmMain MainForm { get; private set; }

        public void Resize(bool showLog)
        {
            MainForm.Height = SetContentHeight(showLog) + Dimensions.MenuFormOffsetHeight;
            MainForm.Width = SetContentWidth() + Dimensions.MenuFormOffsetWidth;
            MainForm.Logger.Top = MainForm.PanelMain.Bottom;
            MainForm.Logger.Height = Dimensions.LoggerHeight;
        }

        protected abstract int SetContentWidth();
        protected abstract int SetContentHeight(bool showLog);

        public abstract void Install(object sender, EventArgs e);
        public abstract void Uninstall(object sender, EventArgs e);
        public abstract void KeyUp(object sender, KeyEventArgs e);

        public abstract void OpenSitecore(object sender, EventArgs e);
        public abstract void OpenFrontend(object sender, EventArgs e);
    }
}
