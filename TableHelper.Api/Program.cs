using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TableHelper.Infrastructure.Database.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

var app = builder.Build();
var runMigrationsOnStartEnv = Environment.GetEnvironmentVariable("RUN_MIGRATIONS_ON_START") ?? "FALSE";

if (runMigrationsOnStartEnv == "TRUE")
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<TableHelperContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    // app.MapOpenApi();
}

app.MapControllers();
app.UseStaticFiles();
app.UseBlazorFrameworkFiles();
app.MapFallbackToFile("index.html");
app.UseHttpsRedirection();

app.Run();
