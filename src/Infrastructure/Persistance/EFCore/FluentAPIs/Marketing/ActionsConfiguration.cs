namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Infrastructure.Persistance.EFCore.FluentAPIs;
using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ActionsConfiguration : BaseEntityConfiguration<Actions>, IEntityTypeConfiguration<Actions>
{
    public void Configure(EntityTypeBuilder<Actions> builder)
    {
        BaseConfigure(builder);

        builder.Property(property => property.Name).IsRequired().HasMaxLength(100);
        builder.Property(property => property.Type).IsRequired();
        builder.Property(property => property.DelayMinutes).IsRequired().HasMaxLength(2880);
        builder.Property(property => property.Setting).IsRequired();

        builder.HasMany(property => property.ActionAfterOrder)
                .WithOne(relation => relation.ActionBelong)
                .HasForeignKey(relation => relation.ActionId)
                .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(property => property.ActionAfterRegister)
                .WithOne(relation => relation.ActionBelong)
                .HasForeignKey(relation => relation.ActionId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
