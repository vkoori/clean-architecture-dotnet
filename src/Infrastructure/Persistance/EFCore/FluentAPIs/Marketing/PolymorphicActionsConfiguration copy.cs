namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProcessedOrdersConfiguration : IEntityTypeConfiguration<ProcessedOrders>
{
    public void Configure(EntityTypeBuilder<ProcessedOrders> builder)
    {
        builder.Property(property => property.OrderId).IsRequired();
        builder.Property(property => property.AfterOrderRuleId).IsRequired();
        builder.Property(property => property.ActionId).IsRequired();
        builder.Property(property => property.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.HasKey(property => property.CreatedAt);
        builder.HasIndex(property => property.OrderId);

        // Execute raw query to set up partitioning
        var now = DateTime.Now;
        builder.Metadata.SetAnnotation(
            "MySql:ExecuteSqlRaw",
            "ALTER TABLE `processed_orders` " +
            "PARTITION BY RANGE(YEAR(created_at) * 100 + MONTH(created_at)) " +
            "( " +
                "PARTITION " + ("p" + now.ToString("yyyyMM")) + " VALUES LESS THAN (" + (Int32.Parse(now.ToString("yyyy")) * 100 + Int32.Parse(now.ToString("MM"))).ToString() + "), " +
                "PARTITION " + ("p" + (Int32.Parse(now.ToString("yyyyMM")) + 1).ToString()) + " VALUES LESS THAN (" + (Int32.Parse(now.ToString("yyyy")) * 100 + Int32.Parse(now.ToString("MM")) + 1).ToString() + ") " +
            ");"
        );
    }
}
