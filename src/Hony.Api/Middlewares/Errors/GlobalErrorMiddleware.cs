using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Hony.Api.Middlewares.Errors;

public class GlobalErrorMiddleware(ILogger<GlobalErrorMiddleware> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception e, CancellationToken token)
    {
        logger.LogError(e, e.Message);
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Title = "Internal Server Error",
            Detail = "Ha ocurrido un error interno contacte con servicio al cliente para obtener una respuesta",
            Status = StatusCodes.Status500InternalServerError
        }, token);

        return true;
    }
}