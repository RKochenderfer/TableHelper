using TableHelper.Models.Generators;

namespace TableHelper.Infrastructure.Repositories.Generators;

public interface IWildernessEncounterGeneratorRepository
{
    public Task<WildernessEncountersGeneratorData> GetWildernessEncounterData();
}