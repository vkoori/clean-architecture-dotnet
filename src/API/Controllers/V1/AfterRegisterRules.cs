namespace API.Controllers.V1;

using Application.DTOs.V1;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v{version:apiVersion}/sample")]
[ApiVersion("1.0")]
public class AfterRegisterRules
{
    [HttpGet()]
    public async Task Index([FromQuery] SampleFilterV1 filter)
    {
        // return await sampleGetAllService.GetByFilterAsync(filter);
    }
}
