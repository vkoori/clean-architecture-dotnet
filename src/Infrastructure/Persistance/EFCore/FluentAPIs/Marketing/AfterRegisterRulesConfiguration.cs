namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Infrastructure.Persistance.EFCore.FluentAPIs;
using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AfterRegisterRulesConfiguration : BaseEntityConfiguration<AfterRegisterRules>, IEntityTypeConfiguration<AfterRegisterRules>
{
    public void Configure(EntityTypeBuilder<AfterRegisterRules> builder)
    {
        BaseConfigure(builder);

        builder.Property(property => property.Name).IsRequired().HasMaxLength(100);
        builder.Property(property => property.Description).IsRequired().HasMaxLength(255);
        builder.Property(property => property.Enable).IsRequired();
        builder.Property(property => property.HasReferrer).IsRequired(false);
        builder.Property(property => property.StartAt).IsRequired(false);
        builder.Property(property => property.StopAt).IsRequired(false);
        builder.Property(property => property.StartTime).IsRequired(false);
        builder.Property(property => property.StopTime).IsRequired(false);
        builder.Property(property => property.Platforms).IsRequired(false).HasMaxLength(255);
        builder.Property(property => property.MinVersion).IsRequired(false).HasMaxLength(20);
        builder.Property(property => property.MaxVersion).IsRequired(false).HasMaxLength(20);
        builder.Property(property => property.Cities).IsRequired(false).HasMaxLength(255);

        builder.HasMany(property => property.AfterRegisterRuleAfterRegister)
                .WithOne(relation => relation.AfterRegisterRuleBelong)
                .HasForeignKey(relation => relation.AfterRegisterRuleId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
