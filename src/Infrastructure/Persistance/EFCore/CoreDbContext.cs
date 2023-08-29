namespace Infrastructure.Persistance.EFCore;

using Domain.Entities.Marketing;
using Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;
using Microsoft.EntityFrameworkCore;

public class CoreDbContext : DbContext
{
    // public required DbSet<AuditLog> Samples { get; set; }

    public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // builder.ApplyConfiguration(new AuditLogConfiguration());

        base.OnModelCreating(builder);
    }
}
