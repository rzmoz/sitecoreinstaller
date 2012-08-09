﻿using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System;
    using System.Diagnostics.Contracts;

    using SitecoreInstaller.Framework.Diagnostics;

    public abstract class SitecoreInstallerPipeline : IPipeline
    {
        private readonly Func<AppSettings> _getAppSettings;
        protected ILog Log { get; private set; }
        protected AppSettings AppSettings { get; private set; }

        public void GetAppSettings()
        {
            AppSettings = _getAppSettings();
        }
        protected SitecoreInstallerPipeline(Func<AppSettings> getAppSettings)
        {
            Contract.Requires<ArgumentNullException>(getAppSettings != null);

            _getAppSettings = getAppSettings;
            AppSettings = getAppSettings.Invoke();
            Log = new Log();
        }

        public void Init(ILog log)
        {
            Log = log ?? new Log();
            GetAppSettings();
        }

        [PipelinePrecondition(Run = Run.OnlyInUi)]
        public bool CheckProjectNameIsSetUi(string taskName = "")
        {
            if (AppSettings.ProjectNameIsSet == false)
            {
                Services.Dialogs.Information("Please enter project name");
                return false;
            }
            return true;
        }
        [PipelinePrecondition]
        public bool CheckProjectNameIsSet(string taskName = "")
        {
            if (AppSettings.ProjectNameIsSet == false)
            {
                const string message = "'{0}' not executed because project name isn't set. Please set Project name";
                Log.Error(message, taskName);
                return false;
            }
            return true;
        }
    }
}
