using System.Net.Http.Json;
using TableHelper.Models;
using TableHelper.Models.Requests;
using TableHelper.Models.Responses;

namespace TableHelper.Services;

public class TableHelperApiService(HttpClient httpClient)
{
    public async Task<List<AdventureSeed>> GetGeneratedAdventureSeeds(int numberOfSeeds)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfSeeds);
        var adventureSeedRequest = AdventureSeedGenerateRequest.From(numberOfSeeds);
        var request = XwnGenerationRequest.From(adventureSeedRequest);

        var response = await httpClient.PostAsJsonAsync(Constants.GenerateUrl, request);
        var content = await response.Content.ReadFromJsonAsync<AdventureSeedGenerateResponse>();

        var seeds = content?.AdventureSeeds;
        return seeds == null ? [] : seeds.ToList();
    }
}