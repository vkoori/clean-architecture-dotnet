namespace Infrastructure.Observer;

using Infrastructure.Enum;

public class EventCollector
{
    public required string DefaultMessage { get; set; }
    public required EfCoreObserverEnum Event { get; set; }
    public string? Query { get; set; } = null;
    public string? Exception { get; set; } = null;
}
