namespace Infrastructure.Observer;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

/// <seealso href="https://github.com/getsentry/sentry-dotnet/blob/main/src/Sentry.DiagnosticSource/Internal/DiagnosticSource/SentryDiagnosticSubscriber.cs"/>
public class AuditLogObserver : IObserver<DiagnosticListener>
{
    private List<ListenerCollector> _pollListeners = new();

    public void OnNext(DiagnosticListener value)
    {
        if (value.Name == DbLoggerCategory.Name) // "Microsoft.EntityFrameworkCore"
        {
            EfCoreObserver efCoreObserver = new();
            IDisposable disposableEfCoreObserver = value.Subscribe(observer: efCoreObserver!);
            _pollListeners.Add(new ListenerCollector { Observer = efCoreObserver, DisposableObserver = disposableEfCoreObserver });
        }
    }

    public void OnCompleted()
    {
        foreach(ListenerCollector listener in _pollListeners)
        {
            if(listener.Observer is EfCoreObserver efCoreObserver)
            {
                EfCoreCompleted(queries: efCoreObserver.GetCollectedData());
            }
            listener.DisposableObserver.Dispose();
        }
    }

    public void OnError(Exception error) { }

    private void EfCoreCompleted(List<EventCollector> queries)
    {
        foreach (var query in queries)
        {
            System.Console.WriteLine(query);
        }
    }
}
