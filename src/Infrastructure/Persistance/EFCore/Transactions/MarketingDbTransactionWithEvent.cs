namespace Infrastructure.Persistance.EFCore.Transactions;

using Coravel.Events.Interfaces;
using Infrastructure.Events;
using Microsoft.EntityFrameworkCore.Storage;

public class MarketingDbTransactionWithEvent : MarketingDbTransaction
{
    private IDispatcher _dispatcher;

    public MarketingDbTransactionWithEvent(MarketingDbContext dbContext, IDispatcher dispatcher) : base(dbContext)
    {
        _dispatcher = dispatcher;
    }

    protected override async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.CommitAsync();
        await _dispatcher.Broadcast(
            toBroadcast: new TransactionCommitted(
                dbContext: GetDbContext()
            )
        );
    }

    protected override async Task RollbackTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.RollbackAsync();
        await _dispatcher.Broadcast(
            toBroadcast: new TransactionRollbacked(
                dbContext: GetDbContext()
            )
        );
    }
}
