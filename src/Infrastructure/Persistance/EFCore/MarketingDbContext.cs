namespace Infrastructure.Persistance.EFCore;

using Domain.Entities.Marketing;
using Infrastructure.Persistance.EFCore.FluentAPIs.Marketing;
using Microsoft.EntityFrameworkCore;

public class MarketingDbContext : DbContext
{
    public required DbSet<Actions> Actions { get; set; }
    public required DbSet<AfterOrderRules> AfterOrderRules { get; set; }
    public required DbSet<AfterOrderActions> AfterOrderActions { get; set; }
    public required DbSet<AfterRegisterRules> AfterRegisterRules { get; set; }
    public required DbSet<AfterRegisterActions> AfterRegisterActions { get; set; }
    public required DbSet<Campaigns> Campaigns { get; set; }
    public required DbSet<ProcessedOrders> ProcessedOrders { get; set; }
    public required DbSet<Reports> Reports { get; set; }

    public MarketingDbContext(DbContextOptions<MarketingDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ActionsConfiguration());
        builder.ApplyConfiguration(new AfterOrderRulesConfiguration());
        builder.ApplyConfiguration(new AfterOrderActionsConfiguration());
        builder.ApplyConfiguration(new AfterRegisterRulesConfiguration());
        builder.ApplyConfiguration(new AfterRegisterActionsConfiguration());
        builder.ApplyConfiguration(new CampaignsConfiguration());
        builder.ApplyConfiguration(new ProcessedOrdersConfiguration());
        builder.ApplyConfiguration(new ReportsConfiguration());

        base.OnModelCreating(builder);
    }
}
