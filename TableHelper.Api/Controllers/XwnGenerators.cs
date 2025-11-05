using Microsoft.AspNetCore.Mvc;
using TableHelper.Api.Services;
using TableHelper.Api.Services.Generators;
using TableHelper.Models.Requests;
using TableHelper.Models.Responses;

namespace TableHelper.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class XwnGenerators(
    ILogger<XwnGenerators> logger,
    XwnNpcGeneratorService xwnNpcGeneratorService,
    XwnAdventureSeedGeneratorService xwnAdventureSeedGeneratorService,
    XwnPatronGeneratorService xwnPatronGeneratorService)
    : ControllerBase
{
    /// <summary>
    /// Generates the requested data type
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<GenerateResponse> Post(XwnGenerationRequest request)
    {
        logger.LogDebug("Generating XWN Request");

        try
        {
            return request.Type switch
            {
                XwnGenerationType.Npc => await GenerateNpcData(request),
                XwnGenerationType.AdventureSeed => await GenerateAdventureSeedData(request),
                XwnGenerationType.Patron => await GeneratePatronData(request),
                XwnGenerationType.Place
                    or XwnGenerationType.Problem
                    or XwnGenerationType.UrbanEncounter => GenerateResponse.Failure(
                        $"Generate type {request.Type}, is not implemented yet"),
                _ => GenerateResponse.Failure($"Generate type {request.Type}, is not supported")
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to generate data");
            return GenerateResponse.Failure(ex.Message);
        }
    }

    private async Task<GenerateResponse> GeneratePatronData(XwnGenerationRequest request)
    {
        if (request.PatronGenerationRequest == null)
        {
            return GenerateResponse.Failure("Patron generation request data cannot be null when generating a Patron");
        }
        
        logger.LogDebug("Generating Patron Request");
        var patrons = await xwnPatronGeneratorService.GeneratePatrons(request.PatronGenerationRequest);
        logger.LogDebug("Completed generating patron data");
        return PatronGenerationResponse.Success(patrons);
    }

    private async Task<AdventureSeedGenerateResponse> GenerateAdventureSeedData(XwnGenerationRequest request)
    {
        if (request.AdventureSeedGenerationRequest == null)
        {
            return AdventureSeedGenerateResponse.Fail(
                "AdventureSeedRequest cannot be null when generating an Adventure Seed");
        }

        logger.LogDebug("Generating adventure Seed");
        var data =
            await xwnAdventureSeedGeneratorService.GenerateAdventureSeeds(request.AdventureSeedGenerationRequest);
        logger.LogDebug("Completed generating adventure seed");
        return AdventureSeedGenerateResponse.Success(data);
    }

    private async Task<NpcGenerationResponse> GenerateNpcData(XwnGenerationRequest request)
    {
        if (request.NpcGenerationRequest == null)
        {
            return NpcGenerationResponse.Failure("NpcGenerationRequest cannot be null when generating an NPC");
        }

        var generatedNpcs = await xwnNpcGeneratorService.GenerateNpcs(request.NpcGenerationRequest);
        return NpcGenerationResponse.Success(generatedNpcs);
    }
}