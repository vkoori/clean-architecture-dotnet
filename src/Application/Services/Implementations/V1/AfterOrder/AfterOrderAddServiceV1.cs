namespace Application.Services.Implementations.V1.AfterOrder;

using System.Threading.Tasks;
using Application.DTOs.Input.V1.AfterOrder;
using Application.Services.Interfaces.V1.AfterOrder;
using Domain.Repositories.Marketing;
using FluentValidation;
using Application.Validations;

public class AfterOrderAddServiceV1 : IAfterOrderAddServiceV1
{
    IValidator<AfterOrderAddDtoV1> _validator;
    IAfterOrderRulesRepository _afterOrderRulesRepository;

    public AfterOrderAddServiceV1(IValidator<AfterOrderAddDtoV1> validator, IAfterOrderRulesRepository afterOrderRulesRepository)
    {
        _validator = validator;
        _afterOrderRulesRepository = afterOrderRulesRepository;
    }
    public async Task Handle(AfterOrderAddDtoV1 dto)
    {
        await _validator.Validated(payload: dto);

        throw new NotImplementedException();
    }
}
