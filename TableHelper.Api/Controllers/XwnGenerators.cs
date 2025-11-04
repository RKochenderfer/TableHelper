using Microsoft.AspNetCore.Mvc;
using TableHelper.Api.Services;
using TableHelper.Models.Requests;
using TableHelper.Models.Responses;

namespace TableHelper.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class XwnGenerators(ILogger<XwnGenerators> logger, XwnNpcGeneratorService xwnNpcGeneratorService)
    : ControllerBase
{
    [HttpPost]
    public async Task<GenerateResponse> Post(XwnGenerationRequest request)
    {
        logger.LogDebug("Generating XWN Request");

        return request.Type switch
        {
            XwnGenerationType.Npc => await GenerateNpcData(request),
            XwnGenerationType.AdventureSeed or XwnGenerationType.Patron or XwnGenerationType.Place
                or XwnGenerationType.Problem
                or XwnGenerationType.UrbanEncounter => GenerateResponse.Failure(
                    $"Generate type {request.Type}, is not implemented yet"),
            _ => GenerateResponse.Failure($"Generate type {request.Type}, is not supported")
        };
    }

    private async Task<NpcGenerateResponse> GenerateNpcData(XwnGenerationRequest request)
    {
        if (request.NpcGenerationRequest == null)
        {
            return NpcGenerateResponse.Failure("NpcGenerationRequest cannot be null when generating an NPC");
        }

        var generatedNpcs = await xwnNpcGeneratorService.GenerateNpcs(request.NpcGenerationRequest);
        return NpcGenerateResponse.Success(generatedNpcs);
    }
}