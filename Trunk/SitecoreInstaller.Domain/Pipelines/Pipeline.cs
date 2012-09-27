using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public abstract class Pipeline : IPipeline
    {
        private readonly IDictionary<string, IPrecondition> _preconditions;
        private readonly IList<IStep> _steps;

        protected Pipeline()
        {
            Name = GetType().Name;
            _preconditions = new Dictionary<string, IPrecondition>();
            _steps = new List<IStep>();
        }
        public void RemovePrecondition<T>() where T : IPrecondition, new()
        {
            if (_preconditions.ContainsKey(typeof(T).FullName))
                _preconditions.Remove(typeof(T).FullName);
        }

        public void AddPrecondition<T>() where T : IPrecondition, new()
        {
            _preconditions.Add(typeof(T).FullName, new T());
        }

        public void AddPreconditions(IEnumerable<IPrecondition> preconditions)
        {
            foreach (var precondition in preconditions)
                _preconditions.Add(precondition.GetType().FullName, precondition);
        }
        public void AddStep<T>() where T : IStep, new()
        {
            AddStep(new T());
        }
        public void AddStep(IStep step)
        {
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

        public IEnumerable<IPrecondition> Preconditions { get { return _preconditions.Values; } }

        public Dialogs Dialogs { get; set; }

        public string Name { get; private set; }

        public IEnumerable<IStep> Steps { get { return _steps; } }
    }
}
