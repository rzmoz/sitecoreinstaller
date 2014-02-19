using System.Collections.Generic;
using SitecoreInstaller.Framework.Linguistics;

namespace SitecoreInstaller.Domain.Pipelines
{
    public abstract class Pipeline<T> : IPipeline where T : PipelineEventArgs, new()
    {
        private readonly IList<IPrecondition> _preconditions;
        private readonly IList<IStep> _steps;

        protected Pipeline()
        {
            Name = new Sentence(GetType().Name.Replace("Pipeline", string.Empty));
            Args = new T();
            _preconditions = new List<IPrecondition>();
            _steps = new List<IStep>();
        }

        public void RemovePrecondition<TK>() where TK : IPrecondition, new()
        {
            for (var i = 0; i < _preconditions.Count; i++)
            {
                if (_preconditions[i].GetType().FullName == typeof(TK).FullName)
                {
                    _preconditions.RemoveAt(i);
                    RemovePrecondition<TK>();
                    return;
                }
            }
        }

        public void AddPrecondition<TK>() where TK : IPrecondition, new()
        {
            AddPrecondition(new TK());
        }

        public void AddPrecondition(IPrecondition precondition)
        {
            _preconditions.Add(precondition);
        }

        public void AddPreconditions(IEnumerable<IPrecondition> preconditions)
        {
            foreach (var precondition in preconditions)
                AddPrecondition(precondition);
        }

        public void AddStep<TK>() where TK : IStep, new()
        {
            AddStep(new TK());
        }

        public void AddStep(IStep step)
        {
            step.Order = _steps.Count + 1;//we add one, since count is zero based and we want order to be 1 based
            _steps.Add(step);
        }

        public void AddSteps(IEnumerable<IStep> steps)
        {
            foreach (var step in steps)
                AddStep(step);
        }

        public void RemoveStep<TK>() where TK : IStep, new()
        {
            for (var i = 0; i < _steps.Count; i++)
            {
                if (_steps[i].GetType().FullName == typeof(TK).FullName)
                {
                    _steps.RemoveAt(i);
                    RemoveStep<TK>();
                    return;
                }
            }
        }

        public IEnumerable<IPrecondition> Preconditions { get { return _preconditions; } }

        public PipelineEventArgs Args { get; set; }

        public Sentence Name { get; private set; }

        public IEnumerable<IStep> Steps { get { return _steps; } }
    }
}
