namespace Application.DbTransaction;

using System;

public interface ICoreTransactionProvider
{
    Task Transaction(Func<Task> action);
}
