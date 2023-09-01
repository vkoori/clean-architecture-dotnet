namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Infrastructure.Persistance.EFCore.FluentAPIs;
using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AfterRegisterActionsConfiguration : BaseEntityConfiguration<AfterRegisterActions>, IEntityTypeConfiguration<AfterRegisterActions>
{
    public void Configure(EntityTypeBuilder<AfterRegisterActions> builder)
    {
        BaseConfigure(builder);

        builder.Property(property => property.ActionId).IsRequired();
        builder.Property(property => property.AfterRegisterRuleId).IsRequired();
        builder.Property(property => property.MaxExecution).IsRequired(false);
        builder.Property(property => property.CountExecuted).IsRequired(false);

        builder.HasOne(property => property.ActionBelong)
            .WithMany(relation => relation.ActionAfterRegister)
            .HasForeignKey(property => property.ActionId);
        builder.HasOne(property => property.AfterRegisterRuleBelong)
            .WithMany(relation => relation.AfterRegisterRuleAfterRegister)
            .HasForeignKey(property => property.AfterRegisterRuleId);
    }
}
