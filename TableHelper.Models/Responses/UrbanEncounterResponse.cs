namespace TableHelper.Models.Responses;

public class UrbanEncounterResponse : GenerateResponse
{
    public IEnumerable<UrbanEncounter> UrbanEncounters { get; set; }

    public UrbanEncounterResponse(bool isSuccessful, string? errorMessage, IEnumerable<UrbanEncounter> urbanEncounters) : base(
        isSuccessful, errorMessage)
    {
        UrbanEncounters = urbanEncounters;
    }
    
    public static UrbanEncounterResponse Success(IEnumerable<UrbanEncounter> urbanEncounters)
    {
        ArgumentNullException.ThrowIfNull(urbanEncounters);

        return new UrbanEncounterResponse(isSuccessful: true, errorMessage: null,
            urbanEncounters: urbanEncounters);
    }

    public static UrbanEncounterResponse Fail(string errorMessage)
    {
        return new UrbanEncounterResponse(isSuccessful: false, errorMessage: errorMessage,
            urbanEncounters: new List<UrbanEncounter>());
    }
}