namespace Infrastructure.Persistance.EFCore;

using System;
using Application.DbTransaction;

public class MarketingDb : ISampleDb
{
    private readonly MarketingDbContext _dbContext;

    public MarketingDb(MarketingDbContext dbContext)
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
