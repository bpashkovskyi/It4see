using Microsoft.AspNetCore.Diagnostics;

namespace It4see.Web
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        {
        }

        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;

            // Return false to continue with the default behavior
            // - or - return true to signal that this exception is handled

            return ValueTask.FromResult(false);
        }
    }
}