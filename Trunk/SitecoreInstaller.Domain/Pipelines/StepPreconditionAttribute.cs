using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    /// <summary>
    /// Must ONLY be set on Func<string, bool>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class StepPreconditionAttribute : PreconditionAttribute
    {
        private readonly HashSet<int> _targetSteps;

        public StepPreconditionAttribute(params int[] targetSteps)
        {
            _targetSteps = new HashSet<int>();

            foreach (var targetStep in targetSteps)
            {
                if (_targetSteps.Contains(targetStep))
                    continue;
                _targetSteps.Add(targetStep);
            }
        }

        public bool AppliesToStep(int stepNumber) { return _targetSteps.Contains(stepNumber); }
        public IEnumerable<int> TargetSteps { get { return _targetSteps; } }

    }
}
