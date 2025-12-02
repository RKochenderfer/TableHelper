using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TableHelper.Infrastructure.Database.Models;

[Table("XwnNpcs")]
[Index(nameof(FirstName))]
[Index(nameof(Surname))]
[Index(nameof(Gender))]
public class XwnNpc
{
    [Key] public int Id { get; init; }
    [MaxLength(50)] [Required] public required string FirstName { get; init; }
    [MaxLength(50)] public string? Surname { get; init; }
    [MaxLength(15)] [Required] public required string Gender { get; init; }
    [Required] public required string InitialManner { get; init; }
    public string? DefaultDealOutcome { get; init; }
    [Required] public required string TheirMotivation { get; init; }
    [Required] public required string TheirWant { get; init; }
    [Required] public required string TheirPower { get; init; }
    [Required] public required string TheirHook { get; init; }
    [Required] public required string TheirBackground { get; init; }
    [Required] public required string TheirRoleInSociety { get; init; }
    [Required] public required string TheirBiggestProblem { get; init; }
    [Required] public required string AgeDescription { get; init; }
    [Required] public required string TheirGreatestDesire { get; init; }
    [Required] public required string MostObviousCharacterTrait { get; init; }
}