using Sitecore;
using Sitecore.VisualStudio.Commands;
using Sitecore.VisualStudio.ContentTrees;
using SitecoreInstaller.App;
using SitecoreInstaller.UI;

namespace SitecoreInstaller.Rocks.ContentTrees.Commands
{
    /// <summary>Defines the content tree command class.</summary>
    [Command]
    public class OpenInstaller : CommandBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenInstaller"/> class.
        /// </summary>
        public OpenInstaller()
        {
            this.Text = "SitecoreInstall";
            this.Group = "My Group of Commands";
            this.SortingValue = 1000;
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

        /// <summary>Execute the command.</summary>
        /// <param name="parameter">The parameter.</param>
        public override void Execute(object parameter)
        {
            var context = parameter as ContentTreeContext;
            if (context == null)
            {
                return;
            }

            Services.LoadUserPreferences();
            Services.Init();
            Services.SourceManifests.UpdateExternal();

            var mainCtrl = new MainCtrl();

            AppHost.OpenToolWindow(mainCtrl, "SitecoreInstaller.Rocks");

            mainCtrl.Init();
        }
    }
}