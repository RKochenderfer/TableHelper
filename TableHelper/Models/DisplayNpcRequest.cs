using TableHelper.Models.Npc;

namespace TableHelper.Models;

public class DisplayNpcRequest
{
    public int Id { get; init; }
    public required NpcInfo NpcInfo { get; init; }
}