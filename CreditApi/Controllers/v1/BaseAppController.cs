using AutoMapper;
using Common.ActionResult;
using Microsoft.AspNetCore.Mvc;

namespace CreditApi.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BaseAppController : ControllerBase
{
    protected readonly IMapper _mapper;
    protected readonly ILogger<BaseAppController> _logger;

    public BaseAppController(IMapper mapper, ILogger<BaseAppController> logger)
    {
        _logger = logger;
        _mapper = mapper;
    }

    protected ActionResult CreatedResult(ActionResponse response)
    {
        if (response.IsSuccess)
        {
            return Ok(response);
        }
        return BadRequest(response);
    }
}

