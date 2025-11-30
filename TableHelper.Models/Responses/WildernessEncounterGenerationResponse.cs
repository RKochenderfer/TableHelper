namespace TableHelper.Models.Responses;

public class WildernessEncounterGenerationResponse : GenerateResponse
{
    public IEnumerable<WildernessEncounter> WildernessEncounters { get; set; }

    public WildernessEncounterGenerationResponse(bool isSuccessful, string? errorMessage, IEnumerable<WildernessEncounter> wildernessEncounters) : base(
        isSuccessful, errorMessage)
    {
        WildernessEncounters = wildernessEncounters;
    }
    
    public static WildernessEncounterGenerationResponse Success(IEnumerable<WildernessEncounter> urbanEncounters)
    {
        ArgumentNullException.ThrowIfNull(urbanEncounters);

        return new WildernessEncounterGenerationResponse(isSuccessful: true, errorMessage: null,
            wildernessEncounters: urbanEncounters);
    }

    public static WildernessEncounterGenerationResponse Fail(string errorMessage)
    {
        return new WildernessEncounterGenerationResponse(isSuccessful: false, errorMessage: errorMessage,
            wildernessEncounters: new List<WildernessEncounter>());
    }
}