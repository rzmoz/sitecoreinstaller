using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class PreconditionAttribute : Attribute
    {
        protected PreconditionAttribute()
        {
            Run = Run.Always;
        }

        public Run Run { get; set; }
    }
}