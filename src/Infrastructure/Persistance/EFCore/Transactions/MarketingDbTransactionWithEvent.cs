namespace Infrastructure.Persistance.EFCore.Transactions;

using Microsoft.EntityFrameworkCore.Storage;

public class MarketingDbTransactionWithEvent : MarketingDbTransaction
{
    public MarketingDbTransactionWithEvent(MarketingDbContext dbContext) : base(dbContext)
    { }

    protected override async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.CommitAsync();
    }

    protected override async Task RollbackTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.RollbackAsync();
    }
}
