using System.Collections.Immutable;

using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Models;

namespace Hony.Application.Services.Handlers.Pagination;

internal sealed class PaginationPublicBlogHandler(IUnitOfWord word) : IHandler<PaginationEntity, ImmutableList<BlogPublicView>>
{
    public Result<ImmutableList<BlogPublicView>> Handle(PaginationEntity command)
        => word.BlogRepository.Pagination(command, x => x.RegisterDate)
            .Select(x => new BlogPublicView(
                x.Id,
                x.Name,
                x.Content,
                x.RegisterDate.ToDateTime(x.RegisterTime),
                x.Comments.Count,
                x.Creator!.UserName)).ToImmutableList();
}