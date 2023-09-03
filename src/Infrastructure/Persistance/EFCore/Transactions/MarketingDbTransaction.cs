namespace Infrastructure.Persistance.EFCore.Transactions;

using System;
using Application.DbTransaction;
using Microsoft.EntityFrameworkCore.Storage;

public class MarketingDbTransaction : IMarketingTransactionProvider
{
    private readonly MarketingDbContext _dbContext;

    public MarketingDbTransaction(MarketingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Transaction(Func<Task> action)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            await action.Invoke();
            await CommitTransactionAsync(transaction: transaction);
        }
        catch
        {
            await RollbackTransactionAsync(transaction: transaction);
            throw;
        }
    }

    protected MarketingDbContext GetDbContext()
    {
        return _dbContext;
    }

    protected virtual async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.CommitAsync();
    }

    protected virtual async Task RollbackTransactionAsync(IDbContextTransaction transaction)
    {
        await transaction.RollbackAsync();
    }
}
