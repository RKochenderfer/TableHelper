using TableHelper.Infrastructure.Database.Models;

namespace TableHelper.Models.Npc;

public static class NpcInfoExtensions
{
    public static XwnNpc ToDbModel(this NpcInfo npc)
    {
        return new XwnNpc
        {
            FirstName = npc.FirstName,
            Surname = npc.Surname,
            Gender = npc.Gender,
            InitialManner = npc.InitialManner,
            DefaultDealOutcome = npc.DefaultDealOutcome,
            TheirMotivation = npc.TheirMotivation,
            TheirWant = npc.TheirWant,
            TheirPower = npc.TheirPower,
            TheirHook = npc.TheirHook,
            TheirBackground = npc.TheirBackground,
            TheirRoleInSociety = npc.TheirRoleInSociety,
            TheirBiggestProblem =  npc.TheirBiggestProblem,
            AgeDescription = npc.AgeDescription,
            TheirGreatestDesire = npc.TheirGreatestDesire,
            MostObviousCharacterTrait = npc.MostObviousCharacterTrait,
        };
    }
    
    public static XwnNpc ToDbModel(this NpcInfo npc, int id)
    {
        return new XwnNpc
        {
            Id = id,
            FirstName = npc.FirstName,
            Surname = npc.Surname,
            Gender = npc.Gender,
            InitialManner = npc.InitialManner,
            DefaultDealOutcome = npc.DefaultDealOutcome,
            TheirMotivation = npc.TheirMotivation,
            TheirWant = npc.TheirWant,
            TheirPower = npc.TheirPower,
            TheirHook = npc.TheirHook,
            TheirBackground = npc.TheirBackground,
            TheirRoleInSociety = npc.TheirRoleInSociety,
            TheirBiggestProblem =  npc.TheirBiggestProblem,
            AgeDescription = npc.AgeDescription,
            TheirGreatestDesire = npc.TheirGreatestDesire,
            MostObviousCharacterTrait = npc.MostObviousCharacterTrait,
        };
    }
}