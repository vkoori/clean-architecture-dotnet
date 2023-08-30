namespace Infrastructure.Persistance.EFCore;

using System;
using Application.DbTransaction;

public class CoreDb : ITransactionProvider
{
    private readonly CoreDbContext _dbContext;

    public CoreDb(CoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Transaction(Func<Task> action)
    {
        using var transaction = _dbContext.Database.BeginTransaction();

        try
        {
            await action.Invoke();
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }
}
