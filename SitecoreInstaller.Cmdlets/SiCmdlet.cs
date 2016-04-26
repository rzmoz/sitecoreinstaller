using System;
using System.Management.Automation;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.Ioc;
using DotNet.Basics.Pipelines;
using Microsoft.Extensions.Logging;

namespace SitecoreInstaller.Cmdlets
{
    public abstract class SiCmdlet : Cmdlet
    {
        private readonly IocContainer _container;
        private readonly ILogger _logger;

        protected SiCmdlet()
        {
            _container = new IocContainer(new SiRegistrations());
            var eventLogger = new EventLogger();
            eventLogger.EntryLogged += EventLogger_EntryLogged;
            _logger = eventLogger;
            PipelineRunner = new PipelineRunner(_logger);
        }

        private void EventLogger_EntryLogged(object sender, LogEntry e)
        {
            Log(e.Message, e.Level, e.Exception);
        }
        
        protected void Log(string message, LogLevel logLevel = LogLevel.Information, Exception e = null)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                case LogLevel.Error:
                case LogLevel.Warning:
                    //we only write to warning as all real erros should be handled in code outside cmdlets / PS
                    WriteWarning(e.Message);
                    break;
                case LogLevel.Information:
                    WriteInformation(new HostInformationMessage
                    {
                        Message = e.Message,
                        NoNewLine = false
                    }, new[] { "PSHOST" });
                    break;
                case LogLevel.Verbose:
                    WriteVerbose(e.Message);
                    break;
                case LogLevel.Debug:
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
