namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Infrastructure.Persistance.EFCore.FluentAPIs;
using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AfterOrderActionsConfiguration : BaseEntityConfiguration<AfterOrderActions>, IEntityTypeConfiguration<AfterOrderActions>
{
    public void Configure(EntityTypeBuilder<AfterOrderActions> builder)
    {
        BaseConfigure(builder);

        builder.Property(property => property.ActionId).IsRequired();
        builder.Property(property => property.AfterOrderRuleId).IsRequired();

        builder.HasOne(property => property.ActionBelong)
            .WithMany(relation => relation.ActionAfterOrder)
            .HasForeignKey(property => property.ActionId);
        builder.HasOne(property => property.AfterOrderRuleBelong)
            .WithMany(relation => relation.AfterOrderRuleAfterOrder)
            .HasForeignKey(property => property.AfterOrderRuleId);
    }
}
