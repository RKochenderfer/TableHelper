using TableHelper.Infrastructure.Repositories;
using TableHelper.Models.Generators.Npc;
using TableHelper.Models.Npc;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services.Generators;

public class XwnNpcGeneratorService(DieRoller dieRoller, Random rnd, INpcGeneratorRepository npcGeneratorRepository)
{
    /// <summary>
    /// Generates a list of NPCs
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<IReadOnlyList<NpcInfo>> GenerateNpcs(NpcGenerationRequest request)
    {
        var allNameOptions = await npcGeneratorRepository.GetAllNameOptions();
        var allMakeupOptions = await npcGeneratorRepository.GetAllMakeupOptions();
        var preferredNameOrigins = GetPreferredNameOrigins(request, allNameOptions);

        var npcs = new List<NpcInfo>();
        while (npcs.Count != request.NpcsToGenerate)
        {
            var npc = GenerateNpc(nameOptions: preferredNameOrigins, makeupOptions: allMakeupOptions, request: request);
            npcs.Add(npc);
        }

        return npcs;
    }

    private NpcInfo GenerateNpc(NameOption[] nameOptions, NpcMakeupOptions makeupOptions, NpcGenerationRequest request)
    {
        var preferredNameGender = GetPreferredNameGender(request);
        var firstName = GenerateFirstName(nameOptions, preferredNameGender);
        var surname = GenerateSurname(nameOptions);
        var initialManner = GenerateMakeupOption(makeupOptions.InitialManner);
        var defaultDealOutcome = GenerateMakeupOption(makeupOptions.DefaultDealOutcome);
        var theirMotivation = GenerateMakeupOption(makeupOptions.TheirMotivation);
        var theirWant = GenerateMakeupOption(makeupOptions.TheirWant);
        var theirPower = GenerateMakeupOption(makeupOptions.TheirPower);
        var theirHook = GenerateMakeupOption(makeupOptions.TheirHook);
        var theirBackground = GenerateMakeupOption(makeupOptions.TheirBackground);
        var theirRoleInSociety = GenerateMakeupOption(makeupOptions.TheirRoleInSociety);
        var theirBiggestProblem = GenerateMakeupOption(makeupOptions.TheirBiggestProblem);
        var ageDescription = GenerateMakeupOption(makeupOptions.Age);
        var theirGreatestDesire = GenerateMakeupOption(makeupOptions.TheirGreatestDesire);
        var mostObviousCharacterTrait = GenerateMakeupOption(makeupOptions.MostObviousCharacterTrait);

        return new NpcInfo(
            FirstName: firstName,
            Surname: surname,
            Gender: preferredNameGender == NameGender.Female ? "Female" : "Male",
            InitialManner: initialManner,
            DefaultDealOutcome: defaultDealOutcome,
            TheirMotivation: theirMotivation,
            TheirWant: theirWant,
            TheirPower: theirPower,
            TheirHook: theirHook,
            TheirBackground: theirBackground,
            TheirRoleInSociety: theirRoleInSociety,
            TheirBiggestProblem: theirBiggestProblem,
            AgeDescription: ageDescription,
            TheirGreatestDesire: theirGreatestDesire,
            MostObviousCharacterTrait: mostObviousCharacterTrait);
    }

    private string GenerateMakeupOption(string[] options)
    {
        var roll = rnd.Next(0, options.Length);
        return options[roll];
    }

    private string GenerateFirstName(NameOption[] nameOption, NameGender preferredNameNameGender)
    {
        var index = rnd.Next(0, nameOption.Length);
        var option = nameOption[index];

        return preferredNameNameGender switch
        {
            NameGender.Male => option.Male,
            NameGender.Female => option.Female,
            _ => throw new ArgumentOutOfRangeException(nameof(preferredNameNameGender))
        };
    }

    private string GenerateSurname(NameOption[] nameOption)
    {
        var index = rnd.Next(0, nameOption.Length);
        var option = nameOption[index];

        return option.Surname;
    }

    private NameOption[] GetPreferredNameOrigins(NpcGenerationRequest request, NpcNameOptions nameOptions)
    {
        return request.PreferredNameOrigin switch
        {
            PreferredNameOrigin.Arabic => nameOptions.Arabic,
            PreferredNameOrigin.Chinese => nameOptions.Chinese,
            PreferredNameOrigin.English => nameOptions.English,
            PreferredNameOrigin.Greek => nameOptions.Greek,
            PreferredNameOrigin.Indian => nameOptions.Indian,
            PreferredNameOrigin.Japanese => nameOptions.Japanese,
            PreferredNameOrigin.Latin => nameOptions.Latin,
            PreferredNameOrigin.Nigerian => nameOptions.Nigerian,
            PreferredNameOrigin.Russian => nameOptions.Russian,
            PreferredNameOrigin.Spanish => nameOptions.Spanish,
            _ => nameOptions.Arabic
                .Concat(nameOptions.Chinese)
                .Concat(nameOptions.English)
                .Concat(nameOptions.Greek)
                .Concat(nameOptions.Indian)
                .Concat(nameOptions.Japanese)
                .Concat(nameOptions.Latin)
                .Concat(nameOptions.Nigerian)
                .Concat(nameOptions.Russian)
                .Concat(nameOptions.Spanish)
                .ToArray()
        };
    }

    private NameGender GetPreferredNameGender(NpcGenerationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.PreferredNameGender != NameGender.Unknown) return request.PreferredNameGender;

        return dieRoller.RollD2() % 2 == 0 ? NameGender.Male : NameGender.Female;
    }
}