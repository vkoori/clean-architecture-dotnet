namespace Domain.Entities.Marketing;

using Domain.Entities;

public class AfterRegisterRules : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required bool Enable { get; set; }
    public bool? HasReferrer { get; set; }
    public DateOnly? StartAt { get; set; }
    public DateOnly? StopAt { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? StopTime { get; set; }
    public string? Platforms { get; set; }
    public string? MinVersion { get; set; }
    public string? MaxVersion { get; set; }
    public string? Cities { get; set; }

    public ICollection<AfterRegisterActions>? AfterRegisterRuleAfterRegister { get; set; }
}
