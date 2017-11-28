using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using Microsoft.Extensions.Logging;

namespace SitecoreInstaller.Host
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        private static readonly ILogger _logger = new ColoredConsoleLogger();

        public override async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            _logger.LogError(context.ExceptionContext.Exception, context.ExceptionContext.Exception.ToString());
            await base.HandleAsync(context, cancellationToken).ConfigureAwait(false);
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            _logger.LogError(context.ExceptionContext.Exception, context.ExceptionContext.Exception.ToString());
            base.Handle(context);
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            //we always handle exceptions if we got this far
            return true;
        }
    }
}
