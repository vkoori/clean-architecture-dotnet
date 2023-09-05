namespace Infrastructure.Observer;

using System;
using System.Collections.Generic;
using Infrastructure.Enum;
using Microsoft.EntityFrameworkCore.Diagnostics;

/// <seealso href="https://github.com/getsentry/sentry-dotnet/blob/main/src/Sentry.DiagnosticSource/Internal/DiagnosticSource/SentryEFCoreListener.cs"/>
/// <seealso href="https://github.com/getsentry/sentry-dotnet/blob/main/src/Sentry.DiagnosticSource/Internal/DiagnosticSource/SentrySqlListener.cs"/>
public class EfCoreObserver : IObserver<KeyValuePair<string, object>>
{
    internal const string EFConnectionOpening = "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionOpening";
    internal const string EFConnectionClosed = "Microsoft.EntityFrameworkCore.Database.Connection.ConnectionClosed";
    internal const string EFCommandFailed = "Microsoft.EntityFrameworkCore.Database.Command.CommandError";
    internal const string EFCommandExecuted = "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuted";
    internal const string EFTransactionStarted = "Microsoft.EntityFrameworkCore.Database.Transaction.TransactionStarted";
    internal const string EFTransactionRolledBack = "Microsoft.EntityFrameworkCore.Database.Transaction.TransactionRolledBack";
    internal const string EFTransactionCommitted = "Microsoft.EntityFrameworkCore.Database.Transaction.TransactionCommitted";

    /// <summary>
    /// Used for EF Core 2.X and 3.X.
    /// <seealso href="https://docs.microsoft.com/dotnet/api/microsoft.entityframeworkcore.diagnostics.coreeventid.querymodelcompiling?view=efcore-3.1"/>
    /// </summary>
    internal const string EFQueryCompiled = "Microsoft.EntityFrameworkCore.Query.QueryExecutionPlanned";

    private bool _logCompilerEnabled = false;
    private bool _logConnectionEnabled = false;
    private bool _logQueryEnabled = true;

    private List<EventCollector> _events = new();

    public void OnNext(KeyValuePair<string, object> value)
    {
        switch (value.Key)
        {
            // Query compiler span
            case EFQueryCompiled when _logCompilerEnabled:
                _events.Add(new EventCollector{
                    DefaultMessage = value.Value.ToString() ?? "",
                    Event = EfCoreObserverEnum.QUERY_COMPILED
                });
                break;

            // Connection span (A transaction may or may not show a connection with it.)
            case EFConnectionOpening when value.Value is ConnectionEventData connectionOpening && _logConnectionEnabled:
                _events.Add(new EventCollector{
                    DefaultMessage = connectionOpening.ToString(),
                    Event = EfCoreObserverEnum.CONNECTION_OPENING
                });
                break;
            case EFConnectionClosed when value.Value is ConnectionEndEventData connectionClosed && _logConnectionEnabled:
                _events.Add(new EventCollector{
                    DefaultMessage = connectionClosed.ToString(),
                    Event = EfCoreObserverEnum.CONNECTION_CLOSED
                });
                break;

            // Query Execution span
            case EFCommandFailed when value.Value is CommandErrorEventData queryFailed && _logQueryEnabled:
                _events.Add(new EventCollector{
                    DefaultMessage = queryFailed.ToString(),
                    Event = EfCoreObserverEnum.QUERY_FAILED,
                    Query = queryFailed.Command.CommandText,
                    Exception = queryFailed.Exception.Message
                });
                break;
            case EFCommandExecuted when value.Value is CommandExecutedEventData queryExecuted && _logQueryEnabled:
                _events.Add(new EventCollector{
                    DefaultMessage = queryExecuted.ToString(),
                    Event = EfCoreObserverEnum.QUERY_Executed,
                    Query = queryExecuted.Command.CommandText
                });
                break;
            case EFTransactionStarted when value.Value is TransactionEventData openTransaction && _logQueryEnabled:
                _events.Add(new EventCollector{
                    DefaultMessage = openTransaction.ToString(),
                    Event = EfCoreObserverEnum.TRANSACTION_STARTED
                });
                break;
            case EFTransactionRolledBack when value.Value is TransactionEndEventData rolledbackTransaction && _logQueryEnabled:
                _events.Add(new EventCollector{
                    DefaultMessage = rolledbackTransaction.ToString(),
                    Event = EfCoreObserverEnum.TRANSACTION_ROLLED_BACK
                });
                break;
            case EFTransactionCommitted when value.Value is TransactionEndEventData committedTransaction && _logQueryEnabled:
                _events.Add(new EventCollector{
                    DefaultMessage = committedTransaction.ToString(),
                    Event = EfCoreObserverEnum.TRANSACTION_COMMITTED
                });
                break;
        }
    }

    public void OnCompleted() {}

    public void OnError(Exception error) {}

    public List<EventCollector> GetCollectedData()
    {
        return _events;
    }
}
