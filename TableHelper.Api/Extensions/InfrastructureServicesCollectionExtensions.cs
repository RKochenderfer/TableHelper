using TableHelper.Infrastructure.Repositories;
using TableHelper.Infrastructure.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureServicesCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(JsonFileDeserializer<>));
        services.AddScoped<INpcGeneratorRepository, JsonNameGeneratorRepository>();
        services.AddScoped<IAdventureSeedGeneratorRepository, JsonAdventureSeedGeneratorRepository>();
        services.AddScoped<IPatronGeneratorRepository, JsonPatronGeneratorRepository>();
        return services;
    }
}