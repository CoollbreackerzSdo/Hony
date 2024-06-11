using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Models;

namespace Hony.Application.Services.Handlers.Delete;

/// <summary>
/// Manejador para deshabilitar un blog.
/// </summary>
/// <param name="word">Unidad de trabajo para realizar operaciones de repositorio.</param>
internal sealed class DisableBlogHandler(IUnitOfWord word) : IHandler<AccountComponentValidation>
{
    /// <summary>
    /// Maneja la validación del componente de cuenta para deshabilitar un blog.
    /// </summary>
    /// <param name="componentValidation">La validación del componente de la cuenta.</param>
    /// <returns>El resultado de la operación.</returns>
    [TranslateResultToActionResult]
    public Result Handle(AccountComponentValidation componentValidation)
        => word.BlogRepository.ExecuteDisable(componentValidation.ComponentId, componentValidation.CreatorId) ?
            Result.Success() : Result.NotFound();
}