using Microsoft.AspNetCore.Diagnostics;

namespace It4see.Web
{
    public class CustomExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(ILogger<CustomExceptionHandler> logger)
        {
            _logger = logger;
        }

        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            string exceptionMessage = exception.Message;

            _logger.LogError("Error Message: {exceptionMessage}, Time of occurrence {time}", exceptionMessage, DateTime.UtcNow);

            // Return false to continue with the default behavior
            // - or - return true to signal that this exception is handled

            return ValueTask.FromResult(false);
        }
    }
}