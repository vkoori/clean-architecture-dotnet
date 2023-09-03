namespace Application.Services.Implementations.V1.AfterOrder;

using System.Threading.Tasks;
using Application.DTOs.Input.V1.AfterOrder;
using Application.Services.Interfaces.V1.AfterOrder;
using Domain.Repositories.Marketing;
using FluentValidation;
using Application.Validations;
using Application.DbTransaction;
using Domain.Entities.Marketing;

public class AfterOrderAddServiceV1 : IAfterOrderAddServiceV1
{
    private readonly IValidator<AfterOrderAddDtoV1> _validator;
    private readonly IAfterOrderRulesRepository _afterOrderRulesRepository;
    private readonly IMarketingTransactionProvider _marketingTransaction;

    public AfterOrderAddServiceV1(
        IValidator<AfterOrderAddDtoV1> validator,
        IAfterOrderRulesRepository afterOrderRulesRepository,
        IMarketingTransactionProvider marketingTransaction
    )
    {
        _validator = validator;
        _afterOrderRulesRepository = afterOrderRulesRepository;
        _marketingTransaction = marketingTransaction;
    }
    public async Task Handle(AfterOrderAddDtoV1 dto)
    {
        await _validator.Validated(payload: dto);

        var e = new AfterOrderRules{
            Name = "asd",
            Description = "asd",
            Enable = true,
            IgnoreVoucher = true
        };

        await _marketingTransaction.Transaction(async () => {
            await _afterOrderRulesRepository.AddAsync(entity: e);
            throw new Exception("kooooooriii");
        });

        throw new NotImplementedException();
    }
}
