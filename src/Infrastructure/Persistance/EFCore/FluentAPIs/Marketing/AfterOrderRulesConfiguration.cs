namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Infrastructure.Persistance.EFCore.FluentAPIs;
using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AfterOrderRulesConfiguration : BaseEntityConfiguration<AfterOrderRules>, IEntityTypeConfiguration<AfterOrderRules>
{
    public void Configure(EntityTypeBuilder<AfterOrderRules> builder)
    {
        BaseConfigure(builder);

        builder.Property(property => property.Name).IsRequired().HasMaxLength(100);
        builder.Property(property => property.Description).IsRequired().HasMaxLength(255);
        builder.Property(property => property.Enable).IsRequired();
        builder.Property(property => property.IgnoreVoucher).IsRequired();
        builder.Property(property => property.VoucherIds).IsRequired(false).HasMaxLength(255);
        builder.Property(property => property.FirstVoucherUse).IsRequired(false);
        builder.Property(property => property.StartAt).IsRequired(false);
        builder.Property(property => property.StopAt).IsRequired(false);
        builder.Property(property => property.StartTime).IsRequired(false);
        builder.Property(property => property.StopTime).IsRequired(false);
        builder.Property(property => property.Platforms).IsRequired(false).HasMaxLength(255);
        builder.Property(property => property.MinVersion).IsRequired(false).HasMaxLength(20);
        builder.Property(property => property.MaxVersion).IsRequired(false).HasMaxLength(20);
        builder.Property(property => property.MinBasketValue).IsRequired(false);
        builder.Property(property => property.MaxBasketValue).IsRequired(false);
        builder.Property(property => property.Cities).IsRequired(false).HasMaxLength(255);
        builder.Property(property => property.FirstOrder).IsRequired(false);
        builder.Property(property => property.Vendors).IsRequired(false).HasMaxLength(255);
        builder.Property(property => property.CategoryIds).IsRequired(false).HasMaxLength(255);
        builder.Property(property => property.VendorSuperTypes).IsRequired(false).HasMaxLength(255);
        builder.Property(property => property.Services).IsRequired(false).HasMaxLength(255);

        builder.HasMany(property => property.AfterOrderRuleAfterOrder)
                .WithOne(relation => relation.AfterOrderRuleBelong)
                .HasForeignKey(relation => relation.AfterOrderRuleId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
