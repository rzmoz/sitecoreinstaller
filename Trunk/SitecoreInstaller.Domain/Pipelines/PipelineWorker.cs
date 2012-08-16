namespace SitecoreInstaller.Domain.Pipelines
{
    using System;
    using System.ComponentModel;

    using SitecoreInstaller.Framework.Diagnostics;

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

        public event EventHandler<PipelineStepEventArgs> StepExecuting;
        public event EventHandler<PipelineStepEventArgs> StepExecuted;

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
                _worker.RunWorkerCompleted += RunWorkerCompleted;
                _worker.RunWorkerAsync();
            }
        }

        void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Log.It.Error("{0}", e.Error.ToString());
            }
            else if (WorkerCompleted != null)
                WorkerCompleted(this, e);
            Log.It.Debug("Pipeline completed. Result: {0}", e.Result);
        }
    }
}
