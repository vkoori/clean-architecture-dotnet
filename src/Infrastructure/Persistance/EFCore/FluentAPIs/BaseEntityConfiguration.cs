namespace Infrastructure.Persistance.EFCore.FluentAPIs;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public abstract class BaseEntityConfiguration<TEntity> where TEntity : BaseEntity
{
    protected virtual void BaseConfigure(EntityTypeBuilder<TEntity> builder)
    {
        // primary key property
        builder.HasKey(property => property.Id);

        // CreatedAt property
        builder.Property(property => property.CreatedAt)
            .IsRequired()
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        // UpdatedAt property
        builder.Property(property => property.UpdatedAt)
            .IsRequired()
            .HasColumnType("timestamp")
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();
    }
}
