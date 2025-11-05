using TableHelper.Models.Generators.Problem;
using TableHelper.Models.Requests;

namespace TableHelper.Infrastructure.Repositories;

/// <summary>
/// Repository for the data used to generate problems
/// </summary>
public interface IProblemGeneratorRepository
{
    /// <summary>
    /// Get all the data for generating problems
    /// </summary>
    /// <returns></returns>
    public Task<ProblemGeneratorData> GetProblemGeneratorData();
}