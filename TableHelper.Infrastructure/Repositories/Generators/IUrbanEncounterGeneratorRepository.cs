using TableHelper.Models.Generators;

namespace TableHelper.Infrastructure.Repositories.Generators;

public interface IUrbanEncounterGeneratorRepository
{
    public Task<UrbanEncountersGeneratorData> GetUrbanEncounterData();
}