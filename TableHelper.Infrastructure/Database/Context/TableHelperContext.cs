using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using TableHelper.Infrastructure.Database.Models;

namespace TableHelper.Infrastructure.Database.Context;

public class TableHelperContext : DbContext
{
    public DbSet<AdventureSeeds> AdventureSeeds { get; set; }

    public string DbPath { get; }

    public TableHelperContext(IConfiguration configuration)
    {
        DbPath = configuration["Config:ConnectionString:SqliteDatabase"]!;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=tablehelper.db");
}