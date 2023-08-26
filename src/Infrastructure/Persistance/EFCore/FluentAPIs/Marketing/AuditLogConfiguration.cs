namespace Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;

using Domain.Entities.Marketing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.HasKey(property => property.Id);

        builder.Property(property => property.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(property => property.UserId).IsRequired(false);
        builder.Property(property => property.EventType).IsRequired().HasMaxLength(100);
        builder.Property(property => property.EventMessage).IsRequired().HasMaxLength(800);

        // builder
        //     .ConfigureDataPartitioning()
        //     .HasDataPartitionKey("created_date")
        //     .HasColumnType("datetime")
        //     .ByRange<DateTime>(partitionType: MySqlPartitionType.Linear, intervalExpression: "INTERVAL 1 MONTH")
        //     .HasSubPartition(p =>
        //     {
        //         p.ByLinear("sub_partition", interval: 1);
        //     });
    }
}
