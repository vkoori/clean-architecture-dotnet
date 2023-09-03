namespace Infrastructure.Persistance.EFCore.Transactions;

using System;
using Application.DbTransaction;

public class CoreDbTransaction : ICoreTransactionProvider
{
    private readonly CoreDbContext _dbContext;

    public CoreDbTransaction(CoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Transaction(Func<Task> action)
    {
        // this database not support transaction
        await action.Invoke();
    }
}
