namespace TableHelper.Models.Generators.Problem;

public class ConflictGeneratorData
{
    public required string Type { get; init; }
    public required string[] Situations { get; init; }
    public required string[] SpecificFocus { get; init; }
}