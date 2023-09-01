namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProcessedOrdersConfiguration : IEntityTypeConfiguration<ProcessedOrders>
{
    public static string TableName {get;} = "processed_orders";
    public void Configure(EntityTypeBuilder<ProcessedOrders> builder)
    {
        builder.ToTable(TableName);

        builder.Property(property => property.OrderId).IsRequired();
        builder.Property(property => property.AfterOrderRuleId).IsRequired();
        builder.Property(property => property.ActionId).IsRequired();
        builder.Property(property => property.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at")
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.HasKey(property => property.CreatedAt);
        builder.HasIndex(property => property.OrderId);
    }
}
