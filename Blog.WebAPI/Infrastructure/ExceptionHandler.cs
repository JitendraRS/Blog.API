using System.Net.Mime;

namespace Blog.WebAPI.Infrastructure;
/// <summary>
/// Middleware to handle exceptions that occur during the request processing pipeline.
/// </summary>
public class ExceptionHandler
{
    private readonly RequestDelegate _requestDelegate;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandler"/> class.
    /// </summary>
    /// <param name="requestDelegate">The next middleware in the request pipeline.</param>
    public ExceptionHandler(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    /// <summary>
    /// Invokes the middleware to handle exceptions.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task that represents the completion of request processing.</returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _requestDelegate(context);
        }
        catch (Exception e)
        {
            await HandleException(context, e);
        }
    }

    /// <summary>
    /// Handles the exception by setting the response status code and writing the error details to the response.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="ex">The exception that occurred.</param>
    /// <returns>A task that represents the completion of the exception handling.</returns>
    private async Task HandleException(HttpContext context, Exception ex)
    {
        var response = context.Response;

        response.Clear();
        response.StatusCode = StatusCodes.Status500InternalServerError;
        response.ContentType = MediaTypeNames.Application.Json;

        var error = new
        {
            Message = "An unexpected error occurred. Please try again later",
            ErrorCode = StatusCodes.Status500InternalServerError,
            Error = ex.Message,
        };

        await response.WriteAsJsonAsync(error);
    }
}
