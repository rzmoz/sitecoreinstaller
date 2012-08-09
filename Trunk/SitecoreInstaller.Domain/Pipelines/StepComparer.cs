using System.Collections.Generic;
using System.Reflection;

namespace SitecoreInstaller.Domain.Pipelines
{
    internal class StepComparer : IComparer<MethodInfo>
    {
        public int Compare(MethodInfo x, MethodInfo y)
        {
            return x.GetStepNumber().CompareTo(y.GetStepNumber());
        }
    }
}
