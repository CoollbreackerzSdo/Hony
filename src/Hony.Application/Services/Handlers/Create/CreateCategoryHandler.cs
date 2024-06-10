using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Mappers;
using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Services.Handlers.Create;

/// <summary>
/// Manejador para crear una nueva categoría.
/// </summary>
/// <param name="word">Unidad de trabajo para realizar operaciones de repositorio.</param>
public class CreateCategoryHandler(IUnitOfWord word) : IHandlerAsync<CreateCategoryCommandHandler>
{
    /// <summary>
    /// Maneja el comando para crear una categoría de forma asíncrona.
    /// </summary>
    /// <param name="command">El comando para crear la categoría.</param>
    /// <param name="token">Token de cancelación.</param>
    /// <returns>El resultado de la operación.</returns>
    [TranslateResultToActionResult]
    public async Task<Result> HandleAsync(CreateCategoryCommandHandler command, CancellationToken token)
    {
        if (word.CategoryRepository.Any(x => x.Name == command.Name))
            return Result.Conflict();

        word.CategoryRepository.Add(CategoryMapper.Map(command));

        await word.SaveChangesAsync(token);

        return Result.Success();
    }
}

/// <summary>
/// Comando para crear una nueva categoría.
/// </summary>
/// <param name="Name">El nombre de la categoría.</param>
/// <param name="Color">El color de la categoría.</param>
public readonly record struct CreateCategoryCommandHandler(string Name, OklhColor Color);