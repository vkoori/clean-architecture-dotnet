namespace Application.Validations.V1.AfterOrder;

using FluentValidation;
using Application.Validations.Rules;
using Application.DTOs.Input.V1.AfterOrder;

public class AfterOrderAddValidationV1 : AbstractValidator<AfterOrderAddDtoV1>
{
    public AfterOrderAddValidationV1()
    {
        // RuleFor(dto => dto.From).DateTimeFormat();
        // RuleFor(dto => dto.To).DateTimeFormat().GreaterThanDate(dto => dto.From);
    }
}