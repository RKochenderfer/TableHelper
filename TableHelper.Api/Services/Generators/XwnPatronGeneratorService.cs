using TableHelper.Infrastructure.Repositories;
using TableHelper.Models;
using TableHelper.Models.Generators;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services.Generators;

public class XwnPatronGeneratorService(
    IPatronGeneratorRepository repository,
    Random rnd)
{
    public async Task<IReadOnlyList<Patron>> GeneratePatrons(PatronGenerationRequest request)
    {
        var data = await repository.GetAllPatronData();

        var patrons = new List<Patron>();

        while (patrons.Count != request.PatronsToGenerate)
        {
            var patron = GeneratePatron(data);
            patrons.Add(patron);
        }

        return patrons;
    }

    private Patron GeneratePatron(PatronGeneratorData data)
    {
        var trustworthiness = GetRandomString(data.Trustworthiness);
        var basicChallengesOfTheJob = GetRandomString(data.BasicChallengesOfTheJob);
        var mainCountervailingForces = GetRandomString(data.MainCountervailingForces);
        var patronEagernessToHire = GetRandomString(data.PatronEagernessToHire);
        var potentialNonCashRewards = GetRandomString(data.PotentialNonCashRewards);
        var complicationsToTheJob = GetRandomString(data.ComplicationsToTheJob);

        return new Patron(
            trustworthiness,
            basicChallengesOfTheJob,
            mainCountervailingForces,
            patronEagernessToHire,
            potentialNonCashRewards,
            complicationsToTheJob
        );
    }

    private string GetRandomString(string[] data)
    {
        var index = rnd.Next(0, data.Length);
        return data[index];
    }
}