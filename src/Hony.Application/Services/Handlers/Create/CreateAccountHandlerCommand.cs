namespace Hony.Application.Services.Handlers.Create;

public readonly record struct CreateAccountCommandHandler(string UserName, string Email, string Password, string? LastName = null, string? FirstName = null);