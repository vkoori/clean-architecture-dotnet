namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Infrastructure.Persistance.EFCore.FluentAPIs;
using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ReportsConfiguration : BaseEntityConfiguration<Reports>, IEntityTypeConfiguration<Reports>
{
    public void Configure(EntityTypeBuilder<Reports> builder)
    {
        BaseConfigure(builder);

        builder.Property(property => property.UserId).IsRequired();
        builder.Property(property => property.ActionType).IsRequired();
        builder.Property(property => property.Extra).IsRequired(false).HasMaxLength(255);
    }
}
