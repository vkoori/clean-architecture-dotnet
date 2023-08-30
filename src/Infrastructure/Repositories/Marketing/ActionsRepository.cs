namespace Infrastructure.Repositories.Marketing;

using Infrastructure.Repositories;
using Infrastructure.Persistance.EFCore;
using Domain.Entities.Marketing;
using Domain.Repositories.Marketing;

public class ActionsRepository : BaseRepository<Actions>, IActionsRepository
{
    public ActionsRepository(MarketingDbContext marketingDbContext) : base(dbContext: marketingDbContext)
    { }
}
