using System.Net.Mime;

namespace Blog.WebAPI.Infrastructure;
public class ExceptionHandler
{
    private readonly RequestDelegate _requestDelegate;

    public ExceptionHandler(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

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
