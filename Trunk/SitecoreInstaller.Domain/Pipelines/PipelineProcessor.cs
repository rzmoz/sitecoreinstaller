using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    using System.Reflection;

    using SitecoreInstaller.Framework.Diagnostics;

    public class PipelineProcessor<T> : IPipelineProcessor<T> where T : IPipeline
    {
        public PipelineProcessor(T pipeline)
        {
            Pipeline = pipeline;
        }

        public void Init()
        {
            Steps = GetSteps(Pipeline);
            var preConditionMethodInfos = GetPreconditions<PipelinePreconditionAttribute>(Pipeline.GetType().GetMethods());
            Preconditions = preConditionMethodInfos.Select(precondition => CreatePreconditionDelegate(Pipeline, precondition));
            PipelineName = Pipeline.GetType().Name;
        }

        public string PipelineName { get; private set; }
        public T Pipeline { get; private set; }
        public IEnumerable<ProfiledStep> Steps { get; private set; }
        public IEnumerable<Func<string, bool>> Preconditions { get; private set; }
        public bool IsInUiMode { get; set; }
        public bool InitOnStepInvoke { get; set; }

        private IEnumerable<ProfiledStep> GetSteps(object installerService)
        {
            var methods = installerService.GetType().GetMethods();

            var stepMethods = methods.Where(method => method.HasAttribute<StepAttribute>() && (ShouldApplyPrecondition(method.GetAttribute<StepAttribute>().Run) || method.GetAttribute<StepAttribute>().Run == Run.Always)).ToList();

            stepMethods.Sort(new StepComparer());

            foreach (var stepMethod in stepMethods)
            {
                var profiledStep = new ProfiledStep(stepMethod.GetStepText(), stepMethod.GetStepNumber(), CreateStepDelegate(installerService, stepMethod));
                var preconditions = GetStepPreconditions(methods, stepMethod.GetStepNumber());
                if (preconditions.Any())
                    profiledStep.Preconditions = preconditions.Select(precondition => CreatePreconditionDelegate(installerService, precondition));
                profiledStep.Profiler.ActionProfiled += Log.It.Profile;
                profiledStep.StepInvoking += ProfiledStepInvoking;
                yield return profiledStep;
            }
        }

        void ProfiledStepInvoking(object sender, EventArgs e)
        {
            if (InitOnStepInvoke == false)
                return;

            Pipeline.Init();
        }

        private IEnumerable<MethodInfo> GetStepPreconditions(IEnumerable<MethodInfo> methods, int stepNumber)
        {
            var stepPreconditions = GetPreconditions<StepPreconditionAttribute>(methods);

            foreach (var precondition in stepPreconditions)
            {
                if (precondition.GetAttribute<StepPreconditionAttribute>().TargetSteps.Count() == 0)
                    yield return precondition;
                if (precondition.GetAttribute<StepPreconditionAttribute>().AppliesToStep(stepNumber))
                    yield return precondition;
            }
        }
        private IEnumerable<MethodInfo> GetPreconditions<TPreconditionType>(IEnumerable<MethodInfo> methods) where TPreconditionType : PreconditionAttribute
        {
            var allPreconditions = from method in methods
                                   where method.HasAttribute<TPreconditionType>()
                                   && method.ReturnType.FullName == "System.Boolean"
                                   && method.GetParameters().Count() == 1
                                   select method;

            foreach (var precondition in allPreconditions)
            {
                if (precondition.GetAttribute<TPreconditionType>().Run != Run.Always)
                    if (ShouldApplyPrecondition(precondition.GetAttribute<TPreconditionType>().Run) == false)
                        continue;
                yield return precondition;
            }
        }
        private bool ShouldApplyPrecondition(Run run)
        {
            if (run == Run.Always)
                return true;
            if (run == Run.OnlyInUi && IsInUiMode)
                return true;
            return false;
        }

        private static Func<string, bool> CreatePreconditionDelegate(object @object, MethodInfo method)
        {
            return (Func<string, bool>)Delegate.CreateDelegate(typeof(Func<string, bool>), @object, method);
        }
        private static Action<object, EventArgs> CreateStepDelegate(object @object, MethodInfo method)
        {
            return (Action<object, EventArgs>)Delegate.CreateDelegate(typeof(Action<object, EventArgs>), @object, method);
        }
    }
}
