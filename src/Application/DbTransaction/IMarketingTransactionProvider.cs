namespace Application.DbTransaction;

using System;

public interface IMarketingTransactionProvider
{
    Task Transaction(Func<Task> action);
}
