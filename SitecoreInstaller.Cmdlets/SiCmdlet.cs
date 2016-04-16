using System;
using System.Management.Automation;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.Ioc;
using DotNet.Basics.Pipelines;

namespace SitecoreInstaller.Cmdlets
{
    public abstract class SiCmdlet : Cmdlet
    {
        private readonly IocContainer _container;
        private readonly EventDiagnostics _logger;

        protected SiCmdlet()
        {
            _container = new IocContainer();
            new SiRegistrations().RegisterIn(_container);

            _logger = new EventDiagnostics();
            _logger.LogLogged += Logger_LogLogged;
            PipelineRunner = new PipelineRunner(_logger);
        }

        private void Logger_LogLogged(object sender, LogEntry e)
        {
            switch (e.Level)
            {
                case LogLevel.Critical:
                case LogLevel.Error:
                    WriteError(new ErrorRecord(e.Exception, e.GetHashCode().ToString(), ErrorCategory.FromStdErr, e.Message));
                    break;
                case LogLevel.Warning:
                    WriteWarning(e.Message);
                    break;
                case LogLevel.Info:
                    WriteInformation(e.Message, new string[] { });
                    break;
                case LogLevel.Debug:
                    WriteVerbose(e.Message);
                    WriteDebug(e.Message);
                    break;
                default:
                    throw new NotSupportedException($"LogLevel not supportd: {e.Level}");
            }
        }

        protected PipelineRunner PipelineRunner { get; }
    }
}
