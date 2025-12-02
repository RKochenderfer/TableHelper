using TableHelper.Api.Services.Randomizer;
using TableHelper.Infrastructure.Repositories;
using TableHelper.Infrastructure.Repositories.Generators;
using TableHelper.Models;
using TableHelper.Models.Generators;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services.Generators;

public class XwnPatronGeneratorService(
    IPatronGeneratorRepository repository,
    ISetRandomizer<string> randomizer)
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
        var trustworthiness = randomizer.GetRandomElement(data.Trustworthiness);
        var basicChallengesOfTheJob = randomizer.GetRandomElement(data.BasicChallengesOfTheJob);
        var mainCountervailingForces = randomizer.GetRandomElement(data.MainCountervailingForces);
        var patronEagernessToHire = randomizer.GetRandomElement(data.PatronEagernessToHire);
        var potentialNonCashRewards = randomizer.GetRandomElement(data.PotentialNonCashRewards);
        var complicationsToTheJob = randomizer.GetRandomElement(data.ComplicationsToTheJob);

        return new Patron(
            trustworthiness,
            basicChallengesOfTheJob,
            mainCountervailingForces,
            patronEagernessToHire,
            potentialNonCashRewards,
            complicationsToTheJob
        );
    }
}