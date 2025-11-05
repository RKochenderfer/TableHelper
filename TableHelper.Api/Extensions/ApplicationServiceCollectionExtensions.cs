using TableHelper.Api.Services;
using TableHelper.Api.Services.Generators;
using TableHelper.Api.Services.Randomizer;

namespace Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services = services.AddGeneratorServices();
        services.AddScoped<Random>();
        services.AddScoped<DieRoller>();
        services.AddScoped(typeof(IRandomizer<>), typeof(FisherYatesRandomRetrieval<>));
        return services;
    }
    
    private static IServiceCollection AddGeneratorServices(this IServiceCollection services)
    {
        services.AddScoped<XwnNpcGeneratorService>();
        services.AddScoped<XwnAdventureSeedGeneratorService>();
        services.AddScoped<XwnPatronGeneratorService>();
        return services;
    }
}