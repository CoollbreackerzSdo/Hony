using Hony.Api;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvConfigurations();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/home", () => new {
    Title = "Coca Cola",
    Name = "Mons"
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();