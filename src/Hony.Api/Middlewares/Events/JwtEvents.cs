using Hony.Api.Services.Authentication.Jwt;

using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Hony.Api.Middlewares.Events;
/// <summary>
/// Clase que contiene los eventos relacionados con JWT (JSON Web Tokens).
/// </summary>
public class JwtEvents
{
    /// <summary>
    /// Evento que se ejecuta cuando se recibe un mensaje con un token. 
    /// Verifica la validez y expiración del token.
    /// </summary>
    /// <param name="context">El contexto del mensaje recibido.</param>
    /// <returns>Una tarea completada.</returns>
    public static Task MessageReceivedToken(MessageReceivedContext context)
    {
        if (string.IsNullOrWhiteSpace(context.Request.Headers.Authorization))
            return Task.CompletedTask;
        var token = context.Request.Headers.Authorization.ToString().AsSpan();
        if (!token.StartsWith("Bearer ", StringComparison.InvariantCultureIgnoreCase))
        {
            context.Fail("Invalid Token");
            return Task.CompletedTask;
        }
        var tokenSlice = context.Request.Headers.Authorization.ToString()["bearer ".Length..];
        var isExpireResult = context.HttpContext.RequestServices.GetRequiredService<IJwtManager>()
            .IsExpired(x => x.AccessToken == tokenSlice);
        if (isExpireResult.IsSuccess)
        {
            if(isExpireResult.Value)
            {
                context.Fail("Expire Token");
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
        context.Fail("confuse Token");
        return Task.CompletedTask;
    }
}