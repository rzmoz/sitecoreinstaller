using System;
using System.Threading.Tasks;
using SitecoreInstaller.Domain.Pipelines;

namespace SitecoreInstaller.App.Pipelines
{
    public class PipelineService
    {
        public Task RunAsync<T, TK>(ProjectSettings projectSettings, params Func<TK, Task>[] preProcessors)
            where TK : PipelineEventArgs, new()
            where T : Pipeline<TK>, new()
        {
            return Task.Factory.StartNew(() => Run<T, TK>(projectSettings, preProcessors));
        }

        private void Run<T, TK>(ProjectSettings projectSettings, params Func<TK, Task>[] preProcessors)
            where TK : PipelineEventArgs, new()
            where T : Pipeline<TK>, new()
        {
            if (projectSettings == null) { throw new ArgumentNullException("projectSettings"); }

            var runner = Get<T, TK>(projectSettings, preProcessors);

            Services.PipelineEngine.RunPipeline(runner);
        }

        public PipelineRunner<T, TK> Get<T, TK>(ProjectSettings projectSettings, params Func<TK, Task>[] preProcessors)
            where TK : PipelineEventArgs, new()
            where T : Pipeline<TK>, new()
        {
            var runner = new PipelineRunner<T, TK>(new T(), preProcessors);

            if (runner.Pipeline.Args is PipelineApplicationEventArgs == false)
                throw new TypeLoadException("pipeline args is not " + typeof(PipelineApplicationEventArgs));
            (runner.Pipeline.Args as PipelineApplicationEventArgs).ProjectSettings = projectSettings;

            return runner;
        }
    }
}
