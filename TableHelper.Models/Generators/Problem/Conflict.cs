namespace TableHelper.Models.Generators.Problem;

public class Conflict
{
    public required string Type { get; init; }
    public required string[] Situations { get; init; }
    public required string[] SpecificFocus { get; init; }
}