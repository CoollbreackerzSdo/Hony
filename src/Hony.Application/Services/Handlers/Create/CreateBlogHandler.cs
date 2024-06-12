using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Mappers;
using Hony.Application.Common.Models;

namespace Hony.Application.Services.Handlers.Create;

/// <summary>
/// Manejador para la creación de un blog.
/// </summary>
/// <param name="word">Unidad de trabajo para interactuar con el repositorio.</param>
internal class CreateBlogHandler(IUnitOfWord word) : IHandlerAsync<(Guid, CreateBlogCommandHandler), BlogView>
{
    /// <summary>
    /// Maneja la creación de un nuevo blog de forma asincrónica.
    /// </summary>
    /// <param name="command">value tupla que contiene el identificador del creador y el comando de creación del blog.</param>
    /// <param name="token">Token de cancelación para la operación asincrónica.</param>
    /// <returns>Resultado de la operación que contiene la vista del blog creado.</returns>
    public async Task<Result<BlogView>> HandleAsync((Guid, CreateBlogCommandHandler) command, CancellationToken token)
    {
        var newBlog = BlogMapper.Map(command.Item1, command.Item2);
        word.BlogRepository.Add(newBlog);
        await word.SaveChangesAsync(token);
        return BlogMapper.ToView(newBlog);
    }
}

/// <summary>
/// Comando para la creación de un blog.
/// </summary>
/// <param name="Name">Nombre del blog.</param>
/// <param name="Content">Contenido del blog.</param>
public readonly record struct CreateBlogCommandHandler(string Name, string Content, Guid CategoryId);