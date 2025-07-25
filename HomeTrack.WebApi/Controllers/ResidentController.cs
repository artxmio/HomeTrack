﻿using AutoMapper;
using HomeTrack.Application.Residents.Commands.CreateResident;
using HomeTrack.Application.Residents.Commands.DeleteResident;
using HomeTrack.Application.Residents.Commands.UpdateResident;
using HomeTrack.Application.Residents.Queries.GetResidentDetails;
using HomeTrack.Application.Residents.Queries.GetResidentList;
using HomeTrack.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeTrack.WebApi.Controllers;

[Route("api/resident")]
public class ResidentController(IMapper mapper) : BaseController
{
    private readonly IMapper _mapper = mapper;

    [HttpGet("get-all")]
    [Authorize]
    public async Task<ActionResult<ResidentListVm>> GetAll()
    {
        var query = new GetResidentListQuery();

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("get")]
    [Authorize]
    public async Task<ActionResult<ResidentDetailsVm>> Get([FromQuery] Guid id)
    {
        var query = new GetResidentDetailsQuery()
        {
            Id = id
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpPost("create")]
    [Authorize]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateResidentDto createResidentDto)
    {
        var command = _mapper.Map<CreateResidentCommand>(createResidentDto);

        var residentId = await Mediator.Send(command);

        return Ok(residentId);
    }

    [HttpPut("update")]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] UpdateResidentDto updateResidentDto)
    {
        var command = _mapper.Map<UpdateResidentCommand>(updateResidentDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete")]
    [Authorize]
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
