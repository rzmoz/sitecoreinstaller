using System;
using System.Linq;
using System.Reflection;
using System.Text;
using SitecoreInstaller.Framework.System;

namespace SitecoreInstaller.Domain.Pipelines
{
    internal static class PipelineRunnerExtensions
    {
        internal static bool HasAttribute<T>(this MethodInfo methodInfo) where T : Attribute
        {
            var attributes = methodInfo.GetCustomAttributes(typeof(T), true);
            return attributes.Any();
        }

        internal static int GetStepNumber(this MethodInfo methodInfo)
        {
            return methodInfo.GetStepAttribute().Order;
        }

        internal static string GetStepText(this MemberInfo methodInfo)
        {
            return methodInfo.Name.TokenizeWhenCharIsUpper().ToDelimiteredString();
        }

        internal static T GetAttribute<T>(this MethodInfo methodInfo) where T : Attribute
        {
            var attributes = methodInfo.GetCustomAttributes(typeof(T), true);
            return ((T)attributes.First());
        }

        internal static StepAttribute GetStepAttribute(this MethodInfo methodInfo)
        {
            return GetAttribute<StepAttribute>(methodInfo);
        }
    }
}
