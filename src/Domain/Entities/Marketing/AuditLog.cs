namespace Domain.Entities.Marketing;

public class AuditLog
{
    public long Id { get; set; }
    public ulong? UserId { get; set; }
    public required string CorelationId { get; set; }
    public required string EventType { get; set; }
    public required string EventMessage { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
