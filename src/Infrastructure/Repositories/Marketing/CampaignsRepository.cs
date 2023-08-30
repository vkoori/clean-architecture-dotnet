namespace Infrastructure.Repositories.Marketing;

using Infrastructure.Repositories;
using Infrastructure.Persistance.EFCore;
using Domain.Entities.Marketing;
using Domain.Repositories.Marketing;

public class CampaignsRepository : BaseRepository<Campaigns>, ICampaignsRepository
{
    public CampaignsRepository(MarketingDbContext marketingDbContext) : base(dbContext: marketingDbContext)
    { }
}
