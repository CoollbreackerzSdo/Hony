using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Mappers;
using Hony.Application.Common.Models;

namespace Hony.Application.Services.Handlers.Create;

public class CreateBlogHandler(IUnitOfWord word) : IHandlerAsync<(Guid, CreateBlogCommandHandler), BlogView>
{
    public async Task<Result<BlogView>> HandleAsync((Guid, CreateBlogCommandHandler) command, CancellationToken token)
    {
        var newBlog = BlogMapper.Map(command.Item1, command.Item2);
        word.BlogRepository.Add(newBlog);
        await word.SaveChangesAsync(token);
        return BlogMapper.ToView(newBlog);
    }
}

public readonly record struct CreateBlogCommandHandler(string Name, string Content);