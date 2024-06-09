using System.Collections.Immutable;

using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Models;

namespace Hony.Application.Services.Handlers.Pagination;
/// <summary>
/// Manejador para la paginación de categorías.
/// </summary>
public sealed class PaginationCategoryHandler(IUnitOfWord word) : IHandler<PaginationCommandHandler, ImmutableList<CategoryView>>
{
    /// <summary>
    /// Maneja la solicitud de paginación de categorías.
    /// </summary>
    /// <param name="command">El comando que contiene los parámetros de paginación.</param>
    /// <returns>Un resultado que contiene una lista inmutable de nombres de categorías.</returns>
    public Result<ImmutableList<CategoryView>> Handle(PaginationCommandHandler command)
        => word.CategoryRepository.ImmutablePagination(command, x => x.Name, x => new CategoryView(x.Name, x.Color));
}