namespace Domain.Entities.Marketing;

using Domain.Entities;

public class AfterRegisterActions : BaseEntity
{
    public required ulong ActionId { get; set; }
    public required ulong AfterRegisterRuleId { get; set; }
    public ushort? MaxExecution { get; set; }
    public ushort? CountExecuted { get; set; }

    public Actions? ActionBelong { get; set; }
    public AfterRegisterRules? AfterRegisterRuleBelong { get; set; }
}
