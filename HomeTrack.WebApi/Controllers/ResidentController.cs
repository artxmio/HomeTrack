using AutoMapper;
using HomeTrack.Application.Residents.Commands.CreateResident;
using HomeTrack.Application.Residents.Commands.DeleteResident;
using HomeTrack.Application.Residents.Commands.UpdateResident;
using HomeTrack.Application.Residents.Queries.GetResidentDetails;
using HomeTrack.Application.Residents.Queries.GetResidentList;
using HomeTrack.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeTrack.WebApi.Controllers;

[Route("api/[controller]")]
public class ResidentController : BaseController
{
    private readonly IMapper _mapper;

    public ResidentController(IMapper mapper)
    {
        this._mapper = mapper;
    }


    [HttpGet("get_all")]
    public async Task<ActionResult<ResidentListVm>> GetAll()
    {
        var query = new GetResidentListQuery();

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("get")]
    public async Task<ActionResult<ResidentListVm>> Get([FromQuery] Guid id)
    {
        var query = new GetResidentDetailsQuery()
        {
            Id = id
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateResidentDto createResidentDto)
    {
        var command = _mapper.Map<CreateResidentCommand>(createResidentDto);

        var residentId = await Mediator.Send(command);

        return Ok(residentId);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateResidentDto updateResidentDto)
    {
        var command = _mapper.Map<UpdateResidentCommand>(updateResidentDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var command = new DeleteResidentCommand()
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
