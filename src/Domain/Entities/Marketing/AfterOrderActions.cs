namespace Domain.Entities.Marketing;

using Domain.Entities;

public class AfterOrderActions : BaseEntity
{
    public required ulong ActionId { get; set; }
    public required ulong AfterOrderRuleId { get; set; }

    public Actions? ActionBelong { get; set; }
    public AfterOrderRules? AfterOrderRuleBelong { get; set; }
}
