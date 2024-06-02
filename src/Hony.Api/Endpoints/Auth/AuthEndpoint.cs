using Ardalis.Result.AspNetCore;

using Hony.Api.Endpoints.Filters.Validation;
using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers;
using Hony.Application.Services.Handlers.Create;

using Microsoft.AspNetCore.Mvc;

namespace Hony.Api.Endpoints.Auth;

public class AuthEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("auth");

        api.MapPost("register", async (CreateAccountCommandHandler command, IHandlerAsync<CreateAccountCommandHandler, AccountCredentials> handler, CancellationToken token) =>
        {
            var handleResult = await handler.HandleAsync(command, token);
            if (handleResult.IsSuccess)
            {
                return Results.Ok();
            }
            return handleResult.ToMinimalApiResult();
        }).AddEndpointFilter<ValidateCreateAccountFilter>()
        .Accepts<CreateAccountCommandHandler>("application/json")
        .ProducesProblem(StatusCodes.Status409Conflict)
        .Produces<string>(StatusCodes.Status200OK)
        .WithDisplayName("Register")
        .WithDescription("Endpoint de registro del sitio")
        .WithTags(["Authentication"])
        .HasApiVersion(1)
        .WithOpenApi();
    }
}