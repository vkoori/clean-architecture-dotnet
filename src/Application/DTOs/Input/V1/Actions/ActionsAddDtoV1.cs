namespace Application.DTOs.Input.V1.Actions;

using Domain.Enums;

public class ActionsAddDtoV1
{
    public required string Name { get; set; }
    public required ActionTypeEnum Type { get; set; }
    public required ushort DelayMinutes { get; set; } = 0;
    public required string Setting { get; set; }
}
