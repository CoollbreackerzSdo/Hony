using System.Security.Claims;

using Ardalis.Result.AspNetCore;

using Hony.Api.Endpoints.Filters.Validation;
using Hony.Api.Models;
using Hony.Api.Models.Token;
using Hony.Api.Services.Authentication.Jwt;
using Hony.Api.Services.Authentication.Providers;
using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers;
using Hony.Application.Services.Handlers.Create;
using Hony.Application.Services.Handlers.Validation;

namespace Hony.Api.Endpoints.Auth;

public class AuthEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("auth");

        api.MapPost("v1/sign-up", async (CreateAccountCommandHandler command, IJwtManager jwtManager, IJwtServices jwtServices, IHandlerAsync<CreateAccountCommandHandler, AccountCredentials> handler, CancellationToken token) =>
        {
            Result<AccountCredentials> handleResult = await handler.HandleAsync(command, token);
            if (handleResult.IsSuccess)
            {
                TokenEntity jwt = await jwtServices.CreateTokenAsync(handleResult.Value, RolesProviderDefault.USER, token);
                jwtManager.Add(jwt);
                return Results.Ok(jwt.ToTransport());
            }
            return handleResult.ToMinimalApiResult();
        }).AddEndpointFilter<GenericFluentValidatorFilter<CreateAccountCommandHandler>>()
        // .Accepts<CreateAccountCommandHandler>("application/json")
        .ProducesProblem(StatusCodes.Status409Conflict)
        .Produces<TokenTransport>(StatusCodes.Status200OK)
        .WithDescription("Endpoint de registro del sitio")
        .WithTags(["Authentication"])
        .WithOpenApi();

        api.MapPost("v1/sign-in", async (ValidateAccountCommandHandler command, IJwtManager jwtManager, IJwtServices jwtServices, IHandler<ValidateAccountCommandHandler, AccountCredentials> handler, CancellationToken token) =>
        {
            Result<AccountCredentials> handleResult = handler.Handle(command);
            if (handleResult.IsSuccess)
            {
                TokenEntity jwt = await jwtServices.CreateTokenAsync(handleResult.Value, RolesProviderDefault.USER, token);
                jwtManager.Add(jwt);
                return Results.Ok(jwt.ToTransport());
            }
            return handleResult.Status switch
            {
                ResultStatus.Invalid => Results.BadRequest(),
                _ => handleResult.ToMinimalApiResult()
            };
        }).AddEndpointFilter<GenericFluentValidatorFilter<ValidateAccountCommandHandler>>()
        // .Accepts<ValidateAccountCommandHandler>("application/json")
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .Produces<TokenTransport>(StatusCodes.Status200OK)
        .WithDescription("Endpoint de login del sitio")
        .WithTags(["Authentication"])
        .WithOpenApi();

        api.MapGet("v1/sign-out", (ClaimsPrincipal userClaims, IJwtManager jwtManager) =>
        {
            var idClaim = userClaims.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(idClaim)) return Results.NotFound();

            var id = Guid.Parse(idClaim);
            jwtManager.Delete(x => x.AccountId == id);
            return Results.Ok();
        }).RequireAuthorization([PoliciesProviderDefault.USER_VALORICE])
        .WithDescription("Endpoint de cerrar sesión en el token utilizado para esta solicitud")
        .WithTags(["Authentication"])
        .ProducesProblem(StatusCodes.Status203NonAuthoritative)
        .Produces(StatusCodes.Status200OK)
        .WithOpenApi();

        api.MapGet("v1/sign-out-all", (ClaimsPrincipal userClaims, IJwtManager jwtManager) =>
        {
            var idClaim = userClaims.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(idClaim)) return Results.NotFound();

            var id = Guid.Parse(idClaim);
            jwtManager.Delete(x => x.AccountId == id);
            return Results.Ok();
        }).RequireAuthorization([PoliciesProviderDefault.USER_VALORICE])
        .WithDescription("Endpoint de cerrar sesión en todos los tokens activos")
        .WithTags(["Authentication"])
        .ProducesProblem(StatusCodes.Status203NonAuthoritative)
        .Produces(StatusCodes.Status200OK)
        .WithOpenApi();
    }
}