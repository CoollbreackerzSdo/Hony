using System.Collections.Immutable;

using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Models;

namespace Hony.Application.Services.Handlers.Pagination;

internal sealed class PaginaciónBlogHandler(IUnitOfWord word) : IHandler<(Guid, PaginationEntity), ImmutableList<BlogView>>
{
    public Result<ImmutableList<BlogView>> Handle((Guid, PaginationEntity) command)
        => word.CategoryBlogsRepository
            .GetAll().GroupBy(x => x.BlogId)
                .Select()
}