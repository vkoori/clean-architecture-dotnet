namespace Application.DbTransaction;

using System;

public interface ITransactionProvider
{
    Task Transaction(Func<Task> action);
}
