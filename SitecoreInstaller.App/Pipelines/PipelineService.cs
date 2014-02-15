using System.Threading.Tasks;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    using System;

    public class PipelineService
    {
        public Task RunAsync<T, TK>(ProjectSettings projectSettings, params Action<TK>[] preProcessors)
            where TK : PipelineEventArgs
            where T : class,IPipeline, new()
        {
            return Task.Factory.StartNew(() => Run<T, TK>(projectSettings, preProcessors));
        }


        private void Run<T, TK>(ProjectSettings projectSettings, params Action<TK>[] preProcessors)
            where TK : PipelineEventArgs
            where T : class,IPipeline, new()
        {
            if (projectSettings == null) { throw new ArgumentNullException("projectSettings"); }

            var runner = Get<T, TK>(projectSettings, preProcessors);

            Services.PipelineEngine.RunPipeline(runner);
        }


        public PipelineRunner<T, TK> Get<T, TK>(ProjectSettings projectSettings, params Action<TK>[] preProcessors)
            where T : class,IPipeline, new()
            where TK : PipelineEventArgs
        {
            var runner = new PipelineRunner<T, TK>(new T(), preProcessors);

            if (runner.Pipeline.Args is PipelineApplicationEventArgs == false)
                throw new TypeLoadException("pipeline args is not " + typeof(PipelineApplicationEventArgs));
            (runner.Pipeline.Args as PipelineApplicationEventArgs).ProjectSettings = projectSettings;

            return runner;
        }
    }
}
