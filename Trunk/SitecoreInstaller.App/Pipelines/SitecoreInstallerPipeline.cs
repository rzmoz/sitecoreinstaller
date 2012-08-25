using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;

    using SitecoreInstaller.App.Pipelines.Preconditions;

    public abstract class SitecoreInstallerPipeline : IPipeline
    {
        private readonly IList<IPrecondition> _preconditions;
        private readonly IList<IStep> _steps;

        protected SitecoreInstallerPipeline(Func<AppSettings> getAppSettings)
        {
            Contract.Requires<ArgumentNullException>(getAppSettings != null);
            Name = GetType().Name;
            _preconditions = new List<IPrecondition>();
            _steps = new List<IStep>();
            GetAppSettings = getAppSettings;
        }

        public void Init()
        {
            AppSettings = GetAppSettings();
            _preconditions.Add(new CheckProjectNameIsSet(AppSettings));
            InitPreconditions();
            InitSteps();
        }

        protected abstract void InitPreconditions();
        protected abstract void InitSteps();

        public void AddPrecondition(IPrecondition precondition)
        {
            _preconditions.Add(precondition);
        }
        public void AddStep(IStep step)
        {
            _steps.Add(step);
            for (var i = 0; i < _steps.Count; i++)
                _steps[i].Order = i + 1;
        }

        public IEnumerable<IPrecondition> Preconditions { get { return _preconditions; } }

        public bool IsInUiMode { get; set; }

        public string Name { get; private set; }

        public IEnumerable<IStep> Steps { get { return _steps; } }

        protected readonly Func<AppSettings> GetAppSettings;
        public AppSettings AppSettings { get; private set; }
    }
}
