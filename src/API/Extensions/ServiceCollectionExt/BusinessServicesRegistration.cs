namespace API.Extensions.ServiceCollectionExt;

using Application.Services.Implementations.V1.AfterOrder;
using Application.Services.Interfaces.V1.AfterOrder;

public static class BusinessServicesRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAfterOrderAddServiceV1, AfterOrderAddServiceV1>();

    }
}
