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
            _container = new IocContainer(new SiRegistrations());
            _logger = new EventDiagnostics();
            _logger.LogLogged += Logger_LogLogged;
            PipelineRunner = new PipelineRunner(_logger);
        }

        private void Logger_LogLogged(object sender, LogEntry e)
        {
            Log(e.Message, e.Level, e.Exception);
        }

        protected void Log(string message, LogLevel logLevel = LogLevel.Info, Exception e = null)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                case LogLevel.Error:
                case LogLevel.Warning:
                    //we only write to warning as all real erros should be handled in code outside cmdlets / PS
                    WriteWarning(e.Message);
                    break;
                case LogLevel.Info:
                    WriteInformation(new HostInformationMessage
                    {
                        Message = e.Message,
                        NoNewLine = false
                    }, new[] { "PSHOST" });
                    break;
                case LogLevel.Debug:
                    WriteVerbose(e.Message);
                    WriteDebug(e.Message);
                    break;
                default:
                    throw new NotSupportedException($"LogLevel not supportd: {logLevel}");
            }
        }


        protected PipelineRunner PipelineRunner
        { get; }
    }
}
