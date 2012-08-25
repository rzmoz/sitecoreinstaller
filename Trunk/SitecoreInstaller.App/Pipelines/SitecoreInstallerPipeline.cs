using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SitecoreInstaller.App.Pipelines.Preconditions;

    public abstract class SitecoreInstallerPipeline : IPipeline
    {
        public IEnumerable<IPrecondition> Preconditions { get; protected set; }

        protected readonly Func<AppSettings> GetAppSettings;

        public AppSettings AppSettings { get;private set; }

        protected SitecoreInstallerPipeline(Func<AppSettings> getAppSettings)
        {
            Contract.Requires<ArgumentNullException>(getAppSettings != null);

            GetAppSettings = getAppSettings;
        }

        public virtual void Init()
        {
            AppSettings = GetAppSettings();
            var preconditions = new List<IPrecondition> { new CheckProjectNameIsSet(AppSettings) };
            Preconditions = preconditions;
        }
    }
}
