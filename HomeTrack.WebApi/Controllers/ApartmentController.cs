using Microsoft.AspNetCore.Mvc;
using HomeTrack.Application.Apartments.Queries.GetApartmentList;
using HomeTrack.Application.Apartments.Queries.GetApartmentDetails;
using HomeTrack.Application.Apartments.Commands.DeleteApartment;
using HomeTrack.WebApi.Models;
using AutoMapper;
using HomeTrack.Application.Apartments.Commands.CreateApartment;
using HomeTrack.Application.Apartments.Commands.UpdateApartment;

namespace HomeTrack.WebApi.Controllers;

[Route("api/apartment")]
public class ApartmentController(IMapper mapper) : BaseController
{
    private readonly IMapper _mapper = mapper;

    [HttpGet("get-all")]
    public async Task<ActionResult<ApartmentListVm>> GetAll()
    {
        var query = new GetApartmentListQuery();

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("get")]
    public async Task<ActionResult<ApartmentDetailsVm>> Get([FromQuery] Guid id)
    {
        var query = new GetApartmentDetailsQuery()
        {
            Id = id
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateApartmentDto createApartmentDto)
    {
        var command = _mapper.Map<CreateApartmentCommand>(createApartmentDto);

        var apartmentId = await Mediator.Send(command);

        return Ok(apartmentId);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateApartmentDto updateApartmentDto)
    {
        var command = _mapper.Map<UpdateApartmentCommand>(updateApartmentDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var command = new DeleteApartmentCommand()
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
