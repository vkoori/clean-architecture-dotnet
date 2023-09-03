namespace API.Extensions.ServiceCollectionExt;

using Domain.Repositories.Marketing;
using Infrastructure.Repositories.Marketing;

public static class RepositoryServicesRegistration
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IActionsRepository, ActionsRepository>();
        services.AddScoped<IAfterOrderActionsRepository, AfterOrderActionsRepository>();
        services.AddScoped<IAfterOrderRulesRepository, AfterOrderRulesRepository>();
        services.AddScoped<ICampaignsRepository, CampaignsRepository>();
        services.AddScoped<IProcessedOrdersRepository, ProcessedOrdersRepository>();
    }
}
