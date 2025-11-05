using TableHelper.Infrastructure.Repositories;
using TableHelper.Models.Generators.Problem;
using TableHelper.Models.Problem;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services.Generators;

public class XwnProblemGeneratorService(IProblemGeneratorRepository repository, Random rnd)
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
        var restraint = GenerateRandomString(data.Restraints);
        var twists = GenerateRandomString(data.Twists);
        var conflict = GenerateRandomConflict(data.Conflicts);
        
        return new ProblemInfo(restraint, twists, conflict);
    }

    private string GenerateRandomString(string[] data)
    {
        var index = rnd.Next(0, data.Length);
        return data[index];
    }

    private Conflict GenerateRandomConflict(ConflictGeneratorData[] data)
    {
        var conflictIndex = rnd.Next(0, data.Length);
        var conflictGeneratorData = data[conflictIndex];
        var situationIndex = rnd.Next(0, conflictGeneratorData.Situations.Length);
        var situation = conflictGeneratorData.Situations[situationIndex];
        var specificFocusIndex = rnd.Next(0, conflictGeneratorData.SpecificFocus.Length);
        var specificFocus = conflictGeneratorData.SpecificFocus[specificFocusIndex];

        return new Conflict(conflictGeneratorData.Type, situation, specificFocus);
    }
}