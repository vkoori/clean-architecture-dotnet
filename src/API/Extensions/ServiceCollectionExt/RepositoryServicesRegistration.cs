namespace API.Extensions.ServiceCollectionExt;

using Domain.Repositories.Marketing;
using Infrastructure.Repositories.Marketing;

public static class RepositoryServicesRegistration
{
    public static void AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IAfterOrderRulesRepository, AfterOrderRulesRepository>();
    }
}
