namespace TableHelper.Models.Responses;

public class UrbanEncounterGenerationResponse : GenerateResponse
{
    public IEnumerable<UrbanEncounter> UrbanEncounters { get; set; }

    public UrbanEncounterGenerationResponse(bool isSuccessful, string? errorMessage, IEnumerable<UrbanEncounter> urbanEncounters) : base(
        isSuccessful, errorMessage)
    {
        UrbanEncounters = urbanEncounters;
    }
    
    public static UrbanEncounterGenerationResponse Success(IEnumerable<UrbanEncounter> urbanEncounters)
    {
        ArgumentNullException.ThrowIfNull(urbanEncounters);

        return new UrbanEncounterGenerationResponse(isSuccessful: true, errorMessage: null,
            urbanEncounters: urbanEncounters);
    }

    public static UrbanEncounterGenerationResponse Fail(string errorMessage)
    {
        return new UrbanEncounterGenerationResponse(isSuccessful: false, errorMessage: errorMessage,
            urbanEncounters: new List<UrbanEncounter>());
    }
}