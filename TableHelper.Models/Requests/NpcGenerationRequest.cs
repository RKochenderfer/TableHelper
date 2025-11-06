using TableHelper.Models.Npc;

namespace TableHelper.Models.Requests;

/// <summary>
/// Request to generate random NPCs
/// </summary>
public class NpcGenerationRequest : IRequest
{
    public int NpcsToGenerate { get; init; }
    public NameGender PreferredNameGender { get; init; }
    public PreferredNameOrigin PreferredNameOrigin { get; init; }

    public static NpcGenerationRequest From(int npcsToGenerate, NameGender preferredNameGender,
        PreferredNameOrigin preferredNameOrigin)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(npcsToGenerate);

        return new NpcGenerationRequest
        {
            NpcsToGenerate = npcsToGenerate,
            PreferredNameGender = preferredNameGender,
            PreferredNameOrigin = preferredNameOrigin
        };
    }

    public bool Validate()
    {
        return NpcsToGenerate > 0;
    }
}