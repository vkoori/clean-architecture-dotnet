namespace Application.DTOs.Input.V1.AfterOrder;

public class AfterOrderAddDtoV1
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
    public string? MinBasketValue { get; set; }
    public string? MaxBasketValue { get; set; }
    public string? Cities { get; set; }
    public bool? FirstOrder { get; set; }
    public string? Vendors { get; set; }
    public string? CategoryIds { get; set; }
    public string? VendorSuperTypes { get; set; }
    public string? Services { get; set; }
    public required List<int> Actions { get; set; }
}
