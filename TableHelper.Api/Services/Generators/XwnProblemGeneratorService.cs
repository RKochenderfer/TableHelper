using TableHelper.Api.Services.Randomizer;
using TableHelper.Infrastructure.Repositories;
using TableHelper.Infrastructure.Repositories.Generators;
using TableHelper.Models.Generators.Problem;
using TableHelper.Models.Problem;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services.Generators;

public class XwnProblemGeneratorService(
    IProblemGeneratorRepository repository,
    ISetRandomizer<ConflictGeneratorData> randomizer,
    ISetRandomizer<string> stringRandomizer)
{
    public async Task<IReadOnlyList<ProblemInfo>> GenerateProblems(ProblemGenerationRequest request)
    {
        var data = await repository.GetProblemGeneratorData();

        var problems = new List<ProblemInfo>();

        while (problems.Count != request.NumberOfProblems)
        {
            var problem = GenerateProblem(data);
            problems.Add(problem);
        }

        return problems;
    }

    private ProblemInfo GenerateProblem(ProblemGeneratorData data)
    {
        var restraint = stringRandomizer.GetRandomElement(data.Restraints);
        var twists = stringRandomizer.GetRandomElement(data.Twists);
        var conflict = GenerateRandomConflict(data.Conflicts);

        return new ProblemInfo(restraint, twists, conflict);
    }

    private Conflict GenerateRandomConflict(ConflictGeneratorData[] data)
    {
        var conflictGeneratorData = randomizer.GetRandomElement(data);
        var situation = stringRandomizer.GetRandomElement(conflictGeneratorData.Situations);
        var specificFocus = stringRandomizer.GetRandomElement(conflictGeneratorData.SpecificFocus);

        return new Conflict(conflictGeneratorData.Type, situation, specificFocus);
    }
}