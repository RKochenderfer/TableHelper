using TableHelper.Api.Services.Randomizer;
using TableHelper.Infrastructure.Repositories;
using TableHelper.Infrastructure.Repositories.Generators;
using TableHelper.Models;
using TableHelper.Models.Requests;

namespace TableHelper.Api.Services.Generators;

public class XwnUrbanGeneratorService(IUrbanEncounterGeneratorRepository repository, ISetRandomizer<string> randomizer)
{
    public async Task<IReadOnlyList<UrbanEncounter>> GenerateUrbanEncounters(UrbanEncounterGenerationRequest generationRequest)
    {
        var generatorData = await repository.GetUrbanEncounterData();

        var encounters = new List<UrbanEncounter>();
        while (encounters.Count != generationRequest.EncountersToGenerate)
        {
            var generalVenueOfTheEvent = randomizer.GetRandomElement(generatorData.GeneralVenueOfTheEvent);
            var whyAreThePcsInvolved = randomizer.GetRandomElement(generatorData.WhyAreThePcsInvolved);
            var whatsTheNatureOfTheEvent = randomizer.GetRandomElement(generatorData.WhatsTheNatureOfTheEvent);
            var whatsTheConflictAbout = randomizer.GetRandomElement(generatorData.WhatsTheConflictAbout);
            var whatAntagonistsAreInvolved = randomizer.GetRandomElement(generatorData.WhatAntagonistsAreInvolved);
            var relevantUrbanFeatures = randomizer.GetRandomElement(generatorData.RelevantUrbanFeatures);
            var encounter = new UrbanEncounter(generalVenueOfTheEvent, whyAreThePcsInvolved, whatsTheNatureOfTheEvent,
                whatsTheConflictAbout, whatAntagonistsAreInvolved, relevantUrbanFeatures);
            
            encounters.Add(encounter);
        }
        
        return encounters;
    }
}