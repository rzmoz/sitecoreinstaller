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
    public class PipelinePreconditionAttribute : PreconditionAttribute
    {
    }
}
