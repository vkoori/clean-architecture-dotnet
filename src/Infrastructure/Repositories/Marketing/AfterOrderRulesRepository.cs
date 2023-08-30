namespace Infrastructure.Repositories.Marketing;

using Infrastructure.Repositories;
using Infrastructure.Persistance.EFCore;
using Domain.Entities.Marketing;
using Domain.Repositories.Marketing;

public class AfterOrderRulesRepository : BaseRepository<AfterOrderRules>, IAfterOrderRulesRepository
{
    public AfterOrderRulesRepository(MarketingDbContext marketingDbContext) : base(dbContext: marketingDbContext)
    { }
}
