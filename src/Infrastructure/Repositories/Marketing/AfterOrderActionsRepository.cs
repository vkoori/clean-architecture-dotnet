namespace Infrastructure.Repositories.Marketing;

using Infrastructure.Repositories;
using Infrastructure.Persistance.EFCore;
using Domain.Entities.Marketing;
using Domain.Repositories.Marketing;

public class AfterOrderActionsRepository : BaseRepository<AfterOrderActions>, IAfterOrderActionsRepository
{
    public AfterOrderActionsRepository(MarketingDbContext marketingDbContext) : base(dbContext: marketingDbContext)
    { }
}
