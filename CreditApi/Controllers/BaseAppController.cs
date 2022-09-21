using AutoMapper;
using Common.ActionResult;
using Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Dto;
using Services;

namespace CreditApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseAppController : ControllerBase
{
    protected readonly IMapper _mapper;
    protected readonly ILogger<BaseAppController> _logger;

    public BaseAppController( IMapper mapper, ILogger<BaseAppController> logger)
    {
        _logger = logger;
        _mapper = mapper;
    }

    protected async Task<ActionResult> CreatedResult(ActionResponse response)
    {
        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }

}

