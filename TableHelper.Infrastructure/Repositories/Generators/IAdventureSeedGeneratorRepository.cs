using TableHelper.Models.Generators;

namespace TableHelper.Infrastructure.Repositories.Generators;

public interface IAdventureSeedGeneratorRepository
{
    /// <summary>
    /// Retrieves all of the adventure seeds from the database
    /// </summary>
    /// <returns></returns>
    public Task<AdventureSeedGeneratorData> GetAdventureSeeds();
}