using TableHelper.Infrastructure.Database.Models;
using TableHelper.Models.Npc;

namespace TableHelper.Infrastructure.Repositories;

public static class XwnNpcExtensions
{
    public static NpcInfo ToNpcInfo(this XwnNpc xwnNpc)
    {
        return new NpcInfo(
            xwnNpc.FirstName,
            xwnNpc.Surname,
            xwnNpc.Gender,
            xwnNpc.InitialManner,
            xwnNpc.DefaultDealOutcome,
            xwnNpc.TheirMotivation,
            xwnNpc.TheirWant,
            xwnNpc.TheirPower,
            xwnNpc.TheirHook,
            xwnNpc.TheirBackground,
            xwnNpc.TheirRoleInSociety,
            xwnNpc.TheirBiggestProblem,
            xwnNpc.AgeDescription,
            xwnNpc.TheirGreatestDesire,
            xwnNpc.MostObviousCharacterTrait
        );
    }
}