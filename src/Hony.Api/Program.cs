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
builder.Services.AddSerilogConsole();



builder.Services.AddOpenApi();

var app = builder.Build();

using var scopeContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<HonyNpSqlContext>();
scopeContext.Database.Migrate();

app.MapOpenApi();
app.MapScalarApiReference();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapAppEndpoints();

app.Run();