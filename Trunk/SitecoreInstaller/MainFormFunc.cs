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
            Log.It.Clear();
        }

        public FrmMain MainForm { get; private set; }
        public void Resize(bool useAdvancedView)
        {
            MainForm.Height = SetContentHeight(useAdvancedView) + Dimensions.MenuFormOffsetHeight;
            MainForm.Width = SetContentWidth(useAdvancedView) + Dimensions.MenuFormOffsetWidth;
            MainForm.Logger.Top = MainForm.PanelMain.Bottom;
            MainForm.Logger.Height = Dimensions.LoggerHeight;
        }

        protected abstract int SetContentWidth(bool useAdvancedView);
        protected abstract int SetContentHeight(bool useAdvancedView);

        public abstract void Install(object sender, EventArgs e);
        public abstract void Uninstall(object sender, EventArgs e);
        public abstract void KeyUp(object sender, KeyEventArgs e);

        public abstract void OpenSitecore(object sender, EventArgs e);
        public abstract void OpenFrontend(object sender, EventArgs e);
    }
}
