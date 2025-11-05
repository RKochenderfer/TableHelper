using System.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TableHelper.Infrastructure.Database.Models;

namespace TableHelper.Infrastructure.EFConfigurations;

public class AdventureSeedsConfiguration : IEntityTypeConfiguration<AdventureSeeds>
{
    public void Configure(EntityTypeBuilder<AdventureSeeds> builder)
    {
        builder.ToTable("AdventureSeeds");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Seed).IsRequired();
        builder.Property(x => x.Game)
            .HasConversion<string>();
    }
}