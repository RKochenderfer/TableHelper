namespace TableHelper.Models.Responses;

public class WildernessEncounterGenerationResponse : GenerateResponse
{
    public IEnumerable<WildernessEncounter> WildernessEncounters { get; set; }

    public WildernessEncounterGenerationResponse(bool isSuccessful, string? errorMessage, IEnumerable<WildernessEncounter> urbanEncounters) : base(
        isSuccessful, errorMessage)
    {
        WildernessEncounters = urbanEncounters;
    }
    
    public static WildernessEncounterGenerationResponse Success(IEnumerable<WildernessEncounter> urbanEncounters)
    {
        ArgumentNullException.ThrowIfNull(urbanEncounters);

        return new WildernessEncounterGenerationResponse(isSuccessful: true, errorMessage: null,
            urbanEncounters: urbanEncounters);
    }

    public static WildernessEncounterGenerationResponse Fail(string errorMessage)
    {
        return new WildernessEncounterGenerationResponse(isSuccessful: false, errorMessage: errorMessage,
            urbanEncounters: new List<WildernessEncounter>());
    }
}