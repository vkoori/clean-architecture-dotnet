namespace Domain.Entities.Marketing;

using Domain.Entities;
using Domain.Enums;

public class Actions : BaseEntity
{
    public required string Name { get; set; }
    public required ActionTypeEnum Type { get; set; }
    public required ushort DelayMinutes { get; set; } = 0;
    public required string Setting { get; set; }
    // public required DateTimeOffset ExpireAt { get; set; } // use for voucher
    // public required int Duration { get; set; } // use for vip package
    // public required string MessageTemplate { get; set; }
}
