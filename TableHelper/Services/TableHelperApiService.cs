using System.Net.Http.Json;
using TableHelper.Models;
using TableHelper.Models.Npc;
using TableHelper.Models.Requests;
using TableHelper.Models.Responses;

namespace TableHelper.Services;

public class TableHelperApiService(HttpClient httpClient)
{
    /// <summary>
    /// Calls the API to generate a list of adventure seeds
    /// </summary>
    /// <param name="numberOfSeeds"></param>
    /// <returns></returns>
    public async Task<List<AdventureSeed>> GetGeneratedAdventureSeeds(int numberOfSeeds)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfSeeds);
        try
        {
            var adventureSeedRequest = AdventureSeedGenerateRequest.From(numberOfSeeds);
            var request = XwnGenerationRequest.From(adventureSeedRequest);

            var response = await httpClient.PostAsJsonAsync(Constants.GenerateUrl, request);
            var content = await response.Content.ReadFromJsonAsync<AdventureSeedGenerateResponse>();

            var seeds = content?.AdventureSeeds;
            return seeds == null ? [] : seeds.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return [];
        }
        
    }
    
    /// <summary>
    /// Calls the API to generate a list of patrons
    /// </summary>
    /// <param name="numberOfPatrons"></param>
    /// <returns></returns>
    public async Task<List<Patron>> GetGeneratedPatrons(int numberOfPatrons)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfPatrons);
        try
        {
            var adventureSeedRequest = PatronGenerationRequest.From(numberOfPatrons);
            var request = XwnGenerationRequest.From(adventureSeedRequest);

            var response = await httpClient.PostAsJsonAsync(Constants.GenerateUrl, request);
            var content = await response.Content.ReadFromJsonAsync<PatronGenerationResponse>();

            var patrons = content?.Patrons;
            return patrons != null ? patrons.ToList() : [];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return [];
        }
    }

    public async Task<List<NpcInfo>> GetGeneratedNpcs(int numberOfNpcs, NameGender nameGender, PreferredNameOrigin nameOrigin)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfNpcs);
        try
        {
            var npcGenerationRequest = NpcGenerationRequest.From(
                npcsToGenerate: numberOfNpcs,
                preferredNameGender: nameGender,
                preferredNameOrigin: nameOrigin);
            var request = XwnGenerationRequest.From(npcGenerationRequest);

            var response = await httpClient.PostAsJsonAsync(Constants.GenerateUrl, request);
            var content = await response.Content.ReadFromJsonAsync<NpcGenerationResponse>();

            var npcs = content?.NpcInfo;

            return  npcs != null ? npcs.ToList() : [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return [];
        }
    }
}