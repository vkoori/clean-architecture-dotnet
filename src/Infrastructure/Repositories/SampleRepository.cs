namespace Infrastructure.Repositories;

using Domain.Entities.Marketing;
using Domain.Repositories;
using Infrastructure.Persistance.EFCore;

public class SampleRepository : EFBaseRepository<AfterOrderRules>, ISampleRepository
{
    public SampleRepository(MarketingDbContext marketingDbContext) : base(marketingDbContext)
    {

    }
}