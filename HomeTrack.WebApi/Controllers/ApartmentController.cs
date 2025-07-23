using Microsoft.AspNetCore.Mvc;
using HomeTrack.Application.Apartments.Queries.GetApartmentList;
using HomeTrack.Application.Apartments.Queries.GetApartmentDetails;
using HomeTrack.Application.Apartments.Commands.DeleteApartment;
using HomeTrack.WebApi.Models;
using AutoMapper;
using HomeTrack.Application.Apartments.Commands.CreateApartment;
using HomeTrack.Application.Apartments.Commands.UpdateApartment;
using HomeTrack.Application.Apartments.Queries.GetResidentsByApartment;
using HomeTrack.Application.Apartments.Commands.AddResidentToApartment;
using HomeTrack.Application.Apartments.Commands.RemoveResidentFromApartment;
using Microsoft.AspNetCore.Authorization;

namespace HomeTrack.WebApi.Controllers;

[Route("api/apartment")]
public class ApartmentController(IMapper mapper) : BaseController
{
    private readonly IMapper _mapper = mapper;

    [HttpGet("get-all")]
    [Authorize]
    public async Task<ActionResult<ApartmentListVm>> GetAll()
    {
        var query = new GetApartmentListQuery();

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("get")]
    [Authorize]
    public async Task<ActionResult<ApartmentDetailsVm>> Get([FromQuery] Guid id)
    {
        var query = new GetApartmentDetailsQuery()
        {
            Id = id
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("get-residents")]
    [Authorize]
    public async Task<ActionResult<ResidentsByApartmentVm>> GetResidents([FromQuery] Guid id)
    {
        var query = new GetResidentsByApartmentQuery()
        {
            ApartmentId = id
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateApartmentDto createApartmentDto)
    {
        var command = _mapper.Map<CreateApartmentCommand>(createApartmentDto);

        var apartmentId = await Mediator.Send(command);

        return Ok(apartmentId);
    }

    [HttpPatch("add-resident")]
    [Authorize]
    public async Task<ActionResult> AddResident([FromBody] AddResidentDto addResidentDto)
    {
        var command = _mapper.Map<AddResidentToApartmentCommand>(addResidentDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPatch("remove-resident")]
    public async Task<ActionResult> RemoveResidentFromApartment([FromBody] RemoveResidentDto removeResidentDto)
    {
        var command = _mapper.Map<RemoveResidentFromApartmentCommand>(removeResidentDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("update")]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateApartmentDto updateApartmentDto)
    {
        var command = _mapper.Map<UpdateApartmentCommand>(updateApartmentDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete")]
    [Authorize]
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
