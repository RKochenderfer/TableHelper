using TableHelper.Models.Npc;

namespace TableHelper.Models.Responses;

public class NpcGenerateResponse : GenerateResponse
{
    public IEnumerable<NpcInfo> NpcInfo { get; }

    public NpcGenerateResponse(bool isSuccessful, string? errorMessage, IEnumerable<NpcInfo> npcInfo) : base(
        isSuccessful, errorMessage)
    {
        NpcInfo = npcInfo;
    }

    private NpcGenerateResponse(bool isSuccessful, IEnumerable<NpcInfo> npcInfo) : base(isSuccessful, null)
    {
        NpcInfo = npcInfo;
    }

    public static NpcGenerateResponse Success(IEnumerable<NpcInfo> npcInfo)
    {
        return new NpcGenerateResponse(isSuccessful: true, npcInfo: npcInfo);
    }

    public new static NpcGenerateResponse Failure(string errorMessage)
    {
        return new NpcGenerateResponse(isSuccessful: false, errorMessage: errorMessage, npcInfo: new List<NpcInfo>());
    }
}