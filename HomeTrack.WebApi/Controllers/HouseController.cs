using AutoMapper;
using AutoMapper.Configuration.Annotations;
using HomeTrack.Application.Houses.Commands.AddApartmentToHouse;
using HomeTrack.Application.Houses.Commands.CreateHouse;
using HomeTrack.Application.Houses.Commands.DeleteHouse;
using HomeTrack.Application.Houses.Commands.UpdateHouse;
using HomeTrack.Application.Houses.Queries.GetApartmentsByHouse;
using HomeTrack.Application.Houses.Queries.GetHouseDetails;
using HomeTrack.Application.Houses.Queries.GetHouseList;
using HomeTrack.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeTrack.WebApi.Controllers;

[Route("api/house")]
public class HouseController(IMapper mapper) : BaseController
{
    public readonly IMapper _mapper = mapper;

    [HttpGet("get-all")]
    public async Task<ActionResult<HouseListVm>> GetAll()
    {
        var query = new GetHouseListQuery();

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("get")]
    public async Task<ActionResult<HouseDetailsVm>> Get([FromQuery] Guid id)
    {
        var query = new GetHouseDetailsQuery()
        {
            Id = id
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("get-apartments")]
    public async Task<ActionResult<ApartmentByHouseVm>> GetApartments([FromQuery] Guid id)
    {
        var query = new GetApartmentByHouseQuery()
        {
            HouseId = id
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateHouseDto createHouseDto)
    {
        var command = _mapper.Map<CreateHouseCommand>(createHouseDto);
        
        var houseId = await Mediator.Send(command);

        return Ok(houseId);
    }

    [HttpPatch("add-apartment")]
    public async Task<ActionResult> AddApartment([FromBody] AddApartmentDto addApartmentDto)
    {
        var command = _mapper.Map<AddApartmentToHouseCommand>(addApartmentDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateHouseDto updateHouseDto)
    {
        var command = _mapper.Map<UpdateHouseCommand>(updateHouseDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var command = new DeleteHouseCommand()
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
