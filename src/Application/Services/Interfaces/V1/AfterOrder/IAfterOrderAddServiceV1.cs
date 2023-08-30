namespace Application.Services.Interfaces.V1.AfterOrder;

using System.Threading.Tasks;
using Application.DTOs.Input.V1.AfterOrder;

public interface IAfterOrderAddServiceV1
{
    Task Handle(AfterOrderAddDtoV1 dto);
}
