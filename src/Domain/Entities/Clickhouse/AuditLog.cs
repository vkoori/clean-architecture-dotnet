namespace Domain.Entities.Clickhouse;

public class AuditLog
{
    public required long Id { get; set; }
    public ulong? UserId { get; set; }
    public required string CorelationId { get; set; }
    public required string EventType { get; set; }
    public required string EventMessage { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
}
