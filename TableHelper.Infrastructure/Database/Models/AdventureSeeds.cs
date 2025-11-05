namespace TableHelper.Infrastructure.Database.Models;

public class AdventureSeeds
{
    public int Id { get; init; }
    public required string Seed { get; init; }
    public Game Game { get; init; }
}