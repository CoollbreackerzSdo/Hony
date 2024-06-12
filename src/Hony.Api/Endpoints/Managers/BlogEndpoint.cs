
using System.Collections.Immutable;
using System.Security.Claims;

using Ardalis.Result.AspNetCore;

using Hony.Api.Endpoints.Filters.Validation;
using Hony.Api.Services.Authentication.Providers;
using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers;
using Hony.Application.Services.Handlers.Create;

namespace Hony.Api.Endpoints.Managers;

public class BlogEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("blogs").RequireAuthorization([PoliciesProviderDefault.USER_VALORICE,]);

        api.MapPost("", async (CreateBlogCommandHandler command, ClaimsPrincipal userClaims, IHandlerAsync<(Guid, CreateBlogCommandHandler), BlogView> handler, CancellationToken token) =>
        {
            var handleResult = await handler.HandleAsync((new(userClaims.FindFirstValue(ClaimTypes.NameIdentifier)!), command), token);
            return handleResult.IsSuccess ? Results.Ok(handleResult.Value) : Results.NotFound();
        }).AddEndpointFilter<GenericFluentValidatorFilter<CreateBlogCommandHandler>>()
        .WithDescription("Endpoint de creación de blogs")
        .Produces<BlogView>(StatusCodes.Status200OK)
        .WithTags(["Blogs"])
        .WithOpenApi();

        api.MapPost("pagination-public", (PaginationEntity command, IHandler<PaginationEntity, ImmutableList<BlogPublicView>> handler)
            => Results.Ok(handler.Handle(command))).AddEndpointFilter<GenericFluentValidatorFilter<PaginationEntity>>()
        .WithTags(["Blogs", "Pagination"])
        .Produces<ImmutableList<BlogView>>(StatusCodes.Status200OK)
        .WithDescription("Endpoint de paginación de blogs públicos")
        .WithOpenApi();

        api.MapPost("pagination", (PaginationEntity command, ClaimsPrincipal userClaims) =>
        {

        }).WithTags(["Blogs", "Pagination"])
        .Produces<ImmutableList<BlogView>>(StatusCodes.Status200OK)
        .WithDescription("Endpoint de paginación de blogs privados del usuario")
        .WithOpenApi();

        api.MapDelete("{id}", (Guid id, IHandler<AccountComponentValidation> handler, ClaimsPrincipal claims)
            => handler.Handle(new(id, new Guid(claims.FindFirstValue(ClaimTypes.NameIdentifier)!))).ToMinimalApiResult())
            .WithDescription("Endpoint de desactivación de blogs")
            .WithTags(["Blogs", "Disable"])
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi();
    }
}