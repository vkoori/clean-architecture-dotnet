namespace API.Extensions.ServiceCollectionExt;

using Application.DTOs.Input.V1.AfterOrder;
using Application.Validations.V1.AfterOrder;
using FluentValidation;

public static class ValidatorServicesRegistration
{
    public static void AddValidatorServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<AfterOrderAddDtoV1>, AfterOrderAddValidationV1>();
    }
}
