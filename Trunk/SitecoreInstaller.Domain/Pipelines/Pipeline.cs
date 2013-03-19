using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
  public abstract class Pipeline : IPipeline
  {
    private readonly IDictionary<string, IPrecondition> _preconditions;
    private readonly IDictionary<string, IStep> _steps;

    protected Pipeline()
    {
      Name = GetType().Name;
      _preconditions = new Dictionary<string, IPrecondition>();
      _steps = new Dictionary<string, IStep>();
    }
    public void RemovePrecondition<T>() where T : IPrecondition, new()
    {
      var key = typeof(T).FullName;
      if (_preconditions.ContainsKey(key))
        _preconditions.Remove(key);
    }

    public void AddPrecondition<T>() where T : IPrecondition, new()
    {
      AddPrecondition(new T());
    }
    public void AddPrecondition(IPrecondition precondition)
    {
      _preconditions.Add(precondition.GetType().FullName, precondition);
    }

    public void AddPreconditions(IEnumerable<IPrecondition> preconditions)
    {
      foreach (var precondition in preconditions)
        AddPrecondition(precondition);
    }
    public void AddStep<T>() where T : IStep, new()
    {
      AddStep(new T());
    }
    public void AddStep(IStep step)
    {
      var key = step.GetType().FullName;

      if (_steps.ContainsKey(key))
        return;
      step.Order = _steps.Count + 1;//we add one, since count is zero based and we want order to be 1 based
      _steps.Add(key, step);
    }

    public void AddSteps(IEnumerable<IStep> steps)
    {
      foreach (var step in steps)
        AddStep(step);
    }
    public void RemoveStep<T>() where T : IStep, new()
    {
      var key = typeof(T).FullName;
      if (_steps.ContainsKey(key))
        _steps.Remove(key);
    }

    public IEnumerable<IPrecondition> Preconditions { get { return _preconditions.Values; } }

    public Dialogs Dialogs { get; set; }

    public string Name { get; private set; }

    public IEnumerable<IStep> Steps { get { return _steps.Values; } }
  }
}
