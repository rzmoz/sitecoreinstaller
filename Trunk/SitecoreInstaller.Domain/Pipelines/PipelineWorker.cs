namespace SitecoreInstaller.Domain.Pipelines
{
    using System;
    using System.ComponentModel;

    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.System;

    public class PipelineWorker
    {
        private static readonly object _syncRoot = new object();
        private BackgroundWorker _worker = new BackgroundWorker();

        public bool IsBusy()
        {
            lock (_syncRoot)
            {
                return _worker.IsBusy;
            }
        }

        public event EventHandler<RunWorkerCompletedEventArgs> WorkerCompleted;

        public event EventHandler<PipelineEventArgs> AllStepsExecuting;
        public event EventHandler<PipelineEventArgs> AllStepsExecuted;

        public event EventHandler<PipelineStepInfoEventArgs> StepExecuting;
        public event EventHandler<PipelineStepInfoEventArgs> StepExecuted;

        public event EventHandler<GenericEventArgs<string>> PreconditionNotMet;

        public void RunPipeline(IPipelineRunner runner)
        {
            lock (_syncRoot)
            {
                if (IsBusy())
                    return; //we abort if worker is already busy
                _worker = new BackgroundWorker();
                _worker.DoWork += runner.ExecuateAllSteps;
                _worker.WorkerReportsProgress = true;

                runner.StepExecuting += StepExecuting;
                runner.StepExecuted += StepExecuted;
                runner.AllStepsExecuting += AllStepsExecuting;
                runner.AllStepsExecuted += AllStepsExecuted;
                runner.PreconditionNotMet += PreconditionNotMet;
                _worker.RunWorkerCompleted += RunWorkerCompleted;
                _worker.RunWorkerAsync();
            }
        }

        void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Log.As.Error("{0}", e.Error.ToString());
            }
            else if (WorkerCompleted != null)
                WorkerCompleted(this, e);
            Log.As.Debug("Pipeline completed. Result: {0}", e.Result);
        }
    }
}
