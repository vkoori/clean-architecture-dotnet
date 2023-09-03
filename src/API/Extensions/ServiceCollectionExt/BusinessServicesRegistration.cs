namespace API.Extensions.ServiceCollectionExt;

using Application.DbTransaction;
using Application.Scheduling;
using Application.Services.Implementations.V1.AfterOrder;
using Application.Services.Interfaces.V1.AfterOrder;
using Infrastructure.Persistance.EFCore.Transactions;

public static class BusinessServicesRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        // service
        services.AddScoped<IAfterOrderAddServiceV1, AfterOrderAddServiceV1>();


        // infrastructure
        services.AddScoped<ICoreTransactionProvider, CoreDbTransaction>();
        services.AddScoped<IMarketingTransactionProvider, MarketingDbTransactionWithEvent>();

        // scheduling
        services.AddTransient<DbPartitioning>();
    }
}
