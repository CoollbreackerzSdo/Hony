using System.Collections.Immutable;

using Ardalis.Result.AspNetCore;

using Hony.Api.Endpoints.Filters.Validation;
using Hony.Api.Services.Authentication.Providers;
using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers;
using Hony.Application.Services.Handlers.Create;

namespace Hony.Api.Endpoints.Managers;

public class CategoryEndpoint : IEndpoint
{
    public void Map(IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("categories");

        api.MapPost("", async (CreateCategoryCommandHandler command, IHandlerAsync<CreateCategoryCommandHandler> handler, CancellationToken token)
                    => (await handler.HandleAsync(command, token)).ToMinimalApiResult())
        .AddEndpointFilter<GenericFluentValidator<CreateCategoryCommandHandler>>()
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status409Conflict)
        .WithDescription("Endpoint de creación de tags para blogs")
        .WithTags(["Category"])
        .RequireAuthorization([PoliciesProviderDefault.USER_VALORICE])
        .WithOpenApi();

        api.MapPost("pagination-name", (PaginationCommandHandler command, [FromKeyedServices("category-page-name")] IHandler<PaginationCommandHandler, ImmutableList<string>> handler)
            => Results.Ok(handler.Handle(command).Value))
        .AddEndpointFilter<GenericFluentValidator<PaginationCommandHandler>>()
        .Produces<ImmutableList<string>>(StatusCodes.Status200OK)
        .WithDescription("Endpoint de paginación de tags")
        .WithTags(["Category", "Pagination"])
        .RequireAuthorization([PoliciesProviderDefault.USER_VALORICE])
        .WithOpenApi();
    }
}