using System.Net.Http.Json;
using TableHelper.Models;
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
        try
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfPatrons);
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
}