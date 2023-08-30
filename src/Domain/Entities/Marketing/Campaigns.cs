namespace Domain.Entities.Marketing;

using Domain.Entities;

public class Campaigns : BaseEntity
{
    public required string Name { get; set; }
    public required ushort From { get; set; }
    public required ushort To { get; set; }
}
