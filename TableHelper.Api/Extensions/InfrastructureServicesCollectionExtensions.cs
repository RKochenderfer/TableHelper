using TableHelper.Infrastructure.Database.Context;
using TableHelper.Infrastructure.Repositories;
using TableHelper.Infrastructure.Repositories.Generators;
using TableHelper.Infrastructure.Services;
using TableHelper.Infrastructure.Services.Savers;

namespace Microsoft.Extensions.DependencyInjection;

public static class InfrastructureServicesCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<TableHelperContext>();
        services.AddScoped<XwnNpcsRepository>();
        services.AddScoped<XwnNpcService>();
        services.AddScoped(typeof(JsonFileDeserializer<>));
        services = services.AddGenerators();
        
        return services;
    }
    
    private static IServiceCollection AddGenerators(this IServiceCollection services)
    {
        services.AddScoped<INpcGeneratorRepository, JsonNameGeneratorRepository>();
        services.AddScoped<IAdventureSeedGeneratorRepository, JsonAdventureSeedGeneratorRepository>();
        services.AddScoped<IPatronGeneratorRepository, JsonPatronGeneratorRepository>();
        services.AddScoped<IProblemGeneratorRepository, JsonProblemGeneratorRepository>();
        services.AddScoped<IUrbanEncounterGeneratorRepository, JsonUrbanEncounterGeneratorRepository>();
        services.AddScoped<IWildernessEncounterGeneratorRepository, JsonWildernessEncounterGeneratorRepository>();
        return services;
    }
}