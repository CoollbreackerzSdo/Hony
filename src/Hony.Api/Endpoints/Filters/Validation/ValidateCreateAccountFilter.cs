using FluentValidation;
using FluentValidation.Results;

using Hony.Application.Services.Handlers.Create;

namespace Hony.Api.Endpoints.Filters.Validation;

public class ValidateCreateAccountFilter(IValidator<CreateAccountHandlerCommand> validator) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        ValidationResult? validation = validator.Validate(context.GetArgument<CreateAccountHandlerCommand>(0));
        return validation.IsValid ? await next(context) : Results.ValidationProblem(validation.ToDictionary());
    }
}