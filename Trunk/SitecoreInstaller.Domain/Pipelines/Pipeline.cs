using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public abstract class Pipeline : IPipeline
    {
        private readonly IList<IPrecondition> _preconditions;
        private readonly IList<IStep> _steps;

        protected Pipeline()
        {
            Name = GetType().Name;
            _preconditions = new List<IPrecondition>();
            _steps = new List<IStep>();
        }

        public void AddPrecondition<T>() where T : IPrecondition, new()
        {
            _preconditions.Add(new T());
        }

        public void AddPreconditions(IEnumerable<IPrecondition> preconditions)
        {
            foreach (var precondition in preconditions)
                _preconditions.Add(precondition);
        }
        public void AddStep<T>() where T : IStep, new()
        {
            var step = new T();
            _steps.Add(step);
            step.Order = _steps.Count;
        }

        public void AddSteps(IEnumerable<IStep> steps)
        {
            foreach (var step in steps)
            {
                step.Order = _steps.Count;
                _steps.Add(step);
            }
        }

        public IEnumerable<IPrecondition> Preconditions { get { return _preconditions; } }

        public bool IsInUiMode { get; set; }

        public string Name { get; private set; }

        public IEnumerable<IStep> Steps { get { return _steps; } }
    }
}
