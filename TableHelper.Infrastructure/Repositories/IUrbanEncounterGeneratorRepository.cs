using TableHelper.Models.Generators;

namespace TableHelper.Infrastructure.Repositories;

public interface IUrbanEncounterGeneratorRepository
{
    public Task<UrbanEncountersGeneratorData> GetUrbanEncounterData();
}