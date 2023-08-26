namespace Infrastructure.Persistance.EFCore.FluentAPIs;

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public abstract class BaseEntitySoftDeleteConfiguration<TEntity>: BaseEntityConfiguration<TEntity> where TEntity : BaseEntitySoftDelete
{
    protected override void BaseConfigure(EntityTypeBuilder<TEntity> builder)
    {
        base.BaseConfigure(builder: builder);

        // DeletedAt property
        builder.Property(property => property.DeletedAt)
            .HasColumnType("timestamp");
    }
}
