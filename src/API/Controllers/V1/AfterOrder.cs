namespace API.Controllers.V1;

using Application.DTOs.Input.V1.AfterOrder;
using Application.Services.Interfaces.V1.AfterOrder;
using Microsoft.AspNetCore.Mvc;
using API.Extensions.MvcOptionsExt;

[ApiController]
[Route("api/v{version:apiVersion}/after-order")]
[ApiVersion("1.0")]
public class AfterOrder
{
    [QueryLoggerAction]
    [HttpPost()]
    public async Task Store([FromBody] AfterOrderAddDtoV1 body, IAfterOrderAddServiceV1 serviceV1)
    {
        /* return  */await serviceV1.Handle(dto: body);
    }
}
