using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using NLog;

namespace SitecoreInstaller.RestHost
{
    public class GlobalExceptionHandler : ExceptionHandler
    {

        public override async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var logger = LogManager.GetLogger(nameof(context.Request.RequestUri.AbsoluteUri));
            logger.Error(context.ExceptionContext.Exception, context.ExceptionContext.Exception.ToString());
            await base.HandleAsync(context, cancellationToken).ConfigureAwait(false);
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            var logger = LogManager.GetLogger(nameof(context.Request.RequestUri.AbsoluteUri));
            logger.Error(context.ExceptionContext.Exception, context.ExceptionContext.Exception.ToString());
            base.Handle(context);
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            //we always handle exceptions if we got this far
            return true;
        }
    }
}
