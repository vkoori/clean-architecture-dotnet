namespace Infrastructure.Observer;

using System;
using System.Collections.Generic;

public class ListenerCollector
{
    public required IObserver<KeyValuePair<string, object>> Observer { get; set; }
    public required IDisposable DisposableObserver { get; set; }
}
