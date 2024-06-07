using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers.Create;
using Hony.Domain.Models.Blogs;

using Riok.Mapperly.Abstractions;

namespace Hony.Application.Common.Mappers;
/// <summary>
/// Mapper class for mapping between CreateBlogCommandHandler and BlogEntity.
/// </summary>
[Mapper(EnumMappingStrategy = EnumMappingStrategy.ByValue, EnumMappingIgnoreCase = true)]
internal static partial class BlogMapper
{
    /// <summary>
    /// Maps a CreateBlogCommandHandler to a BlogEntity.
    /// </summary>
    /// <param name="id">The identifier of the blog creator.</param>
    /// <param name="command">The command containing blog details.</param>
    /// <returns>A new instance of BlogEntity populated with the command data.</returns>
    public static BlogEntity Map(Guid id, CreateBlogCommandHandler command)
        => new()
        {
            CreatorId = id,
            Name = command.Name,
            Content = command.Content
        };
    public static partial BlogView ToView(BlogEntity blog);
    [ObjectFactory]
    private static BlogView ViewFactory(BlogEntity blog)
        => new(Id: blog.Id, Name: blog.Name, Content: blog.Content, Creation: blog.RegisterDate.ToDateTime(blog.RegisterTime), Cements: blog.Comments.Count);
}