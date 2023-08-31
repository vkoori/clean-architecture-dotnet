namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Infrastructure.Persistance.EFCore.FluentAPIs;
using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PolymorphicActionsConfiguration : BaseEntityConfiguration<PolymorphicActions>, IEntityTypeConfiguration<PolymorphicActions>
{
    public void Configure(EntityTypeBuilder<PolymorphicActions> builder)
    {
        BaseConfigure(builder);

        builder.Property(property => property.ActionId).IsRequired();
        builder.Property(property => property.EntityType).IsRequired().HasMaxLength(255);
        builder.Property(property => property.EntityId).IsRequired();

        builder.HasIndex(property => new {property.EntityType, property.EntityId});

        // builder.HasOne(property => property.ActionBelong)
        //     .WithMany(relation => relation.ActionMorph)
        //     .HasForeignKey(property => property.ActionId);
    }
}
