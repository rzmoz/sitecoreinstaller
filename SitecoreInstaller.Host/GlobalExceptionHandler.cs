using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using DotNet.Basics.NLog;

namespace SitecoreInstaller.Host
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            this.NLog().Error(context.ExceptionContext.Exception, context.ExceptionContext.Exception.ToString());
            await base.HandleAsync(context, cancellationToken).ConfigureAwait(false);
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            this.NLog().Error(context.ExceptionContext.Exception, context.ExceptionContext.Exception.ToString());
            base.Handle(context);
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true; //always true if we got this far
        }
    }
}
