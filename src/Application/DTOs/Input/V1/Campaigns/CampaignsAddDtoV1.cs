namespace Application.DTOs.Input.V1.Campaigns;

public class CampaignsAddDtoV1
{
    public required string Name { get; set; }
    public required ushort From { get; set; }
    public required ushort To { get; set; }
}
