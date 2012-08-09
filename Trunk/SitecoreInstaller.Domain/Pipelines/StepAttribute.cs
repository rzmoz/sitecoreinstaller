using System;

namespace SitecoreInstaller.Domain.Pipelines
{
    [AttributeUsage(AttributeTargets.Method)]
    public class StepAttribute : Attribute
    {
        public StepAttribute(int order)
        {
            Order = order;
            Run = Run.Always;
        }
        public int Order { get; private set; }
        public Run Run { get; set; }
    }
}
