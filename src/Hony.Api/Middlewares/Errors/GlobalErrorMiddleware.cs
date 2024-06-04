using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using Serilog;

namespace Hony.Api.Middlewares.Errors;
/// <summary>
/// Clase que representa un middleware para manejar errores globales en la aplicación.
/// Implementa la interfaz <see cref="IMiddleware"/>.
/// </summary>
public class GlobalErrorMiddleware(ILogger<GlobalErrorMiddleware> logger) : IMiddleware
{
    /// <summary>
    /// Invoca el middleware para manejar errores globales en la aplicación.
    /// </summary>
    /// <param name="context">El contexto HTTP de la solicitud.</param>
    /// <param name="next">La función de solicitud siguiente en la canalización de middleware.</param>
    /// <returns>Una tarea que representa la operación asincrónica.</returns>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new ProblemDetails()
            {
                Title = "Internal Server Error",
                Detail = "Ha ocurrido un error interno contacte con servicio al cliente para obtener una respuesta",
                Status = StatusCodes.Status500InternalServerError
            });
        }
    }
}