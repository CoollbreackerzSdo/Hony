using Ardalis.Result.AspNetCore;

using Hony.Api.Endpoints.Filters.Validation;
using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers;
using Hony.Application.Services.Handlers.Create;

namespace Hony.Api.Endpoints.Auth;

public class AuthEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("auth");

        api.MapPost("register", async (CreateAccountHandlerCommand command, IHandlerAsync<CreateAccountHandlerCommand, AccountCredentials> handler, CancellationToken token) =>
        {
            
            var handleResult = await handler.HandleAsync(command, token);
            if (handleResult.IsSuccess)
            {
                return Results.Ok();
            }
            return handleResult.ToMinimalApiResult();
        }).AddEndpointFilter<ValidateCreateAccountFilter>().WithOpenApi(apiDescription =>
        {
            apiDescription.Description = "Endpoint de autenticación principalmente para el registro al servicio";
            return apiDescription;
        });
    }
}