namespace It4see.Web;

public class ExceptionHandlingMiddleware(
    RequestDelegate requestDelegate,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await requestDelegate(httpContext).ConfigureAwait(false);
        }
        catch (Exception exception)
        {
            var exceptionMessage = exception.Message;

            logger.LogError("Error Message: {exceptionMessage}, Time of occurrence {time}", exceptionMessage, DateTime.UtcNow);

            httpContext.Response.StatusCode = 500;
            httpContext.Response.ContentType = "text/plain";

            await httpContext.Response.WriteAsync("Internal Server Error!").ConfigureAwait(false);
        }
    }
}