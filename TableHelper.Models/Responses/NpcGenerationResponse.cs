using TableHelper.Models.Npc;

namespace TableHelper.Models.Responses;

public class NpcGenerationResponse : GenerateResponse
{
    public IEnumerable<NpcInfo> NpcInfo { get; }

    public NpcGenerationResponse(bool isSuccessful, string? errorMessage, IEnumerable<NpcInfo> npcInfo) : base(
        isSuccessful, errorMessage)
    {
        NpcInfo = npcInfo;
    }

    private NpcGenerationResponse(bool isSuccessful, IEnumerable<NpcInfo> npcInfo) : base(isSuccessful, null)
    {
        NpcInfo = npcInfo;
    }

    public static NpcGenerationResponse Success(IEnumerable<NpcInfo> npcInfo)
    {
        return new NpcGenerationResponse(isSuccessful: true, npcInfo: npcInfo);
    }

    public new static NpcGenerationResponse Failure(string errorMessage)
    {
        return new NpcGenerationResponse(isSuccessful: false, errorMessage: errorMessage, npcInfo: new List<NpcInfo>());
    }
}