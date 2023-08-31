namespace Domain.Entities.Marketing;

using Domain.Entities;

public class AfterOrderRules : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool Enable { get; set; }
    public required bool IgnoreVoucher { get; set; }
    public string? VoucherIds { get; set; } // null = any voucher
    public bool? FirstVoucherUse { get; set; }
    public DateOnly? StartAt { get; set; }
    public DateOnly? StopAt { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? StopTime { get; set; }
    public string? Platforms { get; set; }
    public string? MinVersion { get; set; }
    public string? MaxVersion { get; set; }
    public uint? MinBasketValue { get; set; }
    public uint? MaxBasketValue { get; set; }
    public string? Cities { get; set; }
    public bool? FirstOrder { get; set; }
    public string? Vendors { get; set; }
    public string? CategoryIds { get; set; }
    public string? VendorSuperTypes { get; set; }
    public string? Services { get; set; }

    public ICollection<AfterOrderActions>? AfterOrderRuleAfterOrder { get; set; }

    // relations
    // public required string ProcessedOrders { get; set; } // accepted orders
    // after order to action
    // campaign
}
