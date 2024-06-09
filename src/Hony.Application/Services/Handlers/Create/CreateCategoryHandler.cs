using Hony.Application.Common.Externals.UnitOfWord;
using Hony.Application.Common.Mappers;
using Hony.Domain.Models.Aggregates;

namespace Hony.Application.Services.Handlers.Create;

public class CreateCategoryHandler(IUnitOfWord word) : IHandlerAsync<CreateCategoryCommandHandler>
{
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

public readonly record struct CreateCategoryCommandHandler(string Name, OklhColor Color);