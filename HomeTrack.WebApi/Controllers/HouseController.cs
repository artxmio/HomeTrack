﻿using AutoMapper;
using AutoMapper.Configuration.Annotations;
using HomeTrack.Application.Apartments.Commands.RemoveResidentFromApartment;
using HomeTrack.Application.Houses.Commands.AddApartmentToHouse;
using HomeTrack.Application.Houses.Commands.CreateHouse;
using HomeTrack.Application.Houses.Commands.DeleteHouse;
using HomeTrack.Application.Houses.Commands.RemoveApartmentFromHouse;
using HomeTrack.Application.Houses.Commands.UpdateHouse;
using HomeTrack.Application.Houses.Queries.GetApartmentsByHouse;
using HomeTrack.Application.Houses.Queries.GetHouseDetails;
using HomeTrack.Application.Houses.Queries.GetHouseList;
using HomeTrack.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeTrack.WebApi.Controllers;

[Route("api/house")]
public class HouseController(IMapper mapper) : BaseController
{
    public readonly IMapper _mapper = mapper;

    [HttpGet("get-all")]
    [Authorize]
    public async Task<ActionResult<HouseListVm>> GetAll()
    {
        var query = new GetHouseListQuery();

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("get")]
    [Authorize]
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
    [Authorize]
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
    [Authorize]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateHouseDto createHouseDto)
    {
        var command = _mapper.Map<CreateHouseCommand>(createHouseDto);
        
        var houseId = await Mediator.Send(command);

        return Ok(houseId);
    }

    [HttpPatch("add-apartment")]
    [Authorize]
    public async Task<ActionResult> AddApartment([FromBody] AddApartmentDto addApartmentDto)
    {
        var command = _mapper.Map<AddApartmentToHouseCommand>(addApartmentDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPatch("remove-apartment")]
    [Authorize]
    public async Task<ActionResult> RemoveResidentFromApartment([FromBody] RemoveApartmentDto removeApartmentDto)
    {
        var command = _mapper.Map<RemoveApartmentFromHouseCommand>(removeApartmentDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("update")]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateHouseDto updateHouseDto)
    {
        var command = _mapper.Map<UpdateHouseCommand>(updateHouseDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete")]
    [Authorize]
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
