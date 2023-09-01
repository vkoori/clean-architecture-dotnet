namespace Domain.Entities.Marketing;

using Domain.Entities;
using Domain.Enums;

public class Reports : BaseEntity
{
    public required ulong UserId { get; set; }
    public required ActionTypeEnum ActionType { get; set; }
    public required string Extra { get; set; }
}
