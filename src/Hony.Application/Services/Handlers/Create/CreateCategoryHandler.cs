using Hony.Application.Common.Externals.UnitOfWord;

namespace Hony.Application.Services.Handlers.Create;

public class CreateCategoryHandler(IUnitOfWord word) : IHandlerAsync<string>
{
    [TranslateResultToActionResult]
    public async Task<Result> HandleAsync(string name, CancellationToken token)
    {
        if (word.CategoryRepository.Any(x => x.Name == name))
            return Result.Conflict();
        
        word.CategoryRepository.Add(new()
        {
            Id = Guid.NewGuid(),
            Name = name
        });
        
        await word.SaveChangesAsync(token);
        
        return Result.Success();
    }
}