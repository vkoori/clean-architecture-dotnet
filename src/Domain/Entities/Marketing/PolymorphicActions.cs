namespace Domain.Entities.Marketing;

using Domain.Entities;

public class PolymorphicActions : BaseEntity
{
    public required ulong ActionId { get; set; }
    public required string EntityType { get; set; }
    public required ulong EntityId { get; set; }

    public Actions? ActionBelong { get; set; }
}
