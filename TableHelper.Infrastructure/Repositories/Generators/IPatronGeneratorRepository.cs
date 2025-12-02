using TableHelper.Models.Generators;

namespace TableHelper.Infrastructure.Repositories.Generators;

/// <summary>
/// Repository for the data used to generate Patrons
/// </summary>
public interface IPatronGeneratorRepository
{
    /// <summary>
    /// Retrieve all the generation data for patrons
    /// </summary>
    /// <returns></returns>
    public Task<PatronGeneratorData> GetAllPatronData();
}