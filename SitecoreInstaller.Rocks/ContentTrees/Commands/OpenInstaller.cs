using Sitecore;
using Sitecore.VisualStudio.Commands;
using Sitecore.VisualStudio.ContentTrees;
using SitecoreInstaller.App;
using SitecoreInstaller.UI;

namespace SitecoreInstaller.Rocks.ContentTrees.Commands
{
    [Command]
    public class OpenInstaller : CommandBase
    {
        public OpenInstaller()
        {
            Text = "SitecoreInstaller";
            Group = "My Group of Commands";
            SortingValue = 1000;

            Services.LoadUserPreferences();
            Services.Init();
            Services.SourceManifests.UpdateExternal();
        }

        /// <summary>Defines the method that determines whether the command can execute in its current state.</summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        public override bool CanExecute(object parameter)
        {
            var context = parameter as ContentTreeContext;
            if (context == null)
            {
                return false;
            }

            return true;
        }

        public override void Execute(object parameter)
        {
            var context = parameter as ContentTreeContext;
            if (context == null)
            {
                return;
            }

            var mainCtrl = new MainCtrl();
            
            AppHost.OpenToolWindow(mainCtrl, "SitecoreInstaller");

            mainCtrl.Init();
        }
    }
}