using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SitecoreInstaller.App.Pipelines.Preconditions;

    public abstract class SitecoreInstallerPipeline : Pipeline
    {
        protected SitecoreInstallerPipeline(Func<AppSettings> getAppSettings)
        {
            Contract.Requires<ArgumentNullException>(getAppSettings != null);
            
            GetAppSettings = getAppSettings;
            AppSettings = GetAppSettings();

            //Init Preconditions
            AddPrecondition(new CheckProjectNameIsSet(getAppSettings));
        }

        protected readonly Func<AppSettings> GetAppSettings;
        public AppSettings AppSettings { get; private set; }
    }
}
