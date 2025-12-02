using TableHelper.Infrastructure.Database.Context;
using TableHelper.Infrastructure.Database.Models;
using TableHelper.Models.Npc;

namespace TableHelper.Infrastructure.Repositories;

public class XwnNpcsRepository(TableHelperContext context)
{
    public async Task<XwnNpc> AddAsync(XwnNpc npc)
    {
        var result = await context.XwnNpcs.AddAsync(npc);
        await context.SaveChangesAsync();
        return result.Entity;
    }
}