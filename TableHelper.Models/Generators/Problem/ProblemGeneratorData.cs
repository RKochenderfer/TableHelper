namespace TableHelper.Models.Generators.Problem;

public class ProblemGeneratorData
{
    public required string[] Restraints { get; init; }
    public required string[] Twists { get; init; }
    public required ConflictGeneratorData[] Conflicts { get; init; }
}