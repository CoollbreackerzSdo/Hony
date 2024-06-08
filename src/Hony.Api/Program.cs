using Hony.Api;
using Hony.Application;
using Hony.Infrastructure;
using Hony.Infrastructure.Database;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvConfigurations();
builder.Services.AddEndpoints();
builder.Services.AddInfrastructure();
builder.Services.ApplicationServices();
builder.Services.AddSerilogServices();
builder.Services.AddOpenApi();
builder.Services.AddMiddlewares();
builder.Services.AddAuthenticationConfiguration();
builder.Services.AddJwtServices();

var app = builder.Build();

using var scopeContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<HonyAccountsNpSqlContext>();
scopeContext.Database.Migrate();
// app.UseExceptionHandler();
app.MapOpenApi();
app.MapScalarApiReference();
// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapMiddlewares();

app.MapAppEndpoints();

app.Run();