using Hony.Application.Common.Models;
using Hony.Application.Services.Handlers.Create;
using Hony.Domain.Models.Blogs;

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
    {
        var currentTime = DateTime.UtcNow;
        return new BlogEntity
        {
            CreatorId = id,
            Name = command.Name,
            Content = command.Content,
            RegisterDate = DateOnly.FromDateTime(currentTime),
            RegisterTime = TimeOnly.FromDateTime(currentTime)
        };
    }
    /// <summary>
    /// Convierte una entidad de blog en una vista de blog.
    /// </summary>
    /// <param name="blog">La entidad de blog a convertir.</param>
    /// <returns>Una vista de blog con la información de la entidad proporcionada.</returns>
    public static BlogView ToView(BlogEntity blog)
        => new(Id: blog.Id, Name: blog.Name, Content: blog.Content, Creation: blog.RegisterDate.ToDateTime(blog.RegisterTime), Cements: blog.Comments.Count);
}