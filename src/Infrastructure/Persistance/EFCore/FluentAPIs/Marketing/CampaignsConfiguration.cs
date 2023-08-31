namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Infrastructure.Persistance.EFCore.FluentAPIs;
using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CampaignsConfiguration : BaseEntityConfiguration<Campaigns>, IEntityTypeConfiguration<Campaigns>
{
    public void Configure(EntityTypeBuilder<Campaigns> builder)
    {
        BaseConfigure(builder);

        builder.Property(property => property.Name).IsRequired().HasMaxLength(100);
        builder.Property(property => property.From).IsRequired();
        builder.Property(property => property.To).IsRequired();
    }
}
