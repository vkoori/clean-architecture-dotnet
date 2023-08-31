namespace Domain.Entities.Marketing;

public class ProcessedOrders
{
    public required ulong OrderId { get; set; }
    public required ulong AfterOrderRuleId { get; set; }
    public required ulong ActionId { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
}
