using AutoMapper;
using HomeTrack.Application.ResidentialComplex.Commands.CreateResidentialComplex;
using HomeTrack.Application.ResidentialComplex.Commands.DeleteResidentialComplex;
using HomeTrack.Application.ResidentialComplex.Commands.UpdateResidentialComplex;
using HomeTrack.Application.ResidentialComplex.Queries.GetResidentialComplexDetails;
using HomeTrack.Application.ResidentialComplex.Queries.GetResidentialComplexesList;
using HomeTrack.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeTrack.WebApi.Controllers;

[Route("api/residential-complex")]
public class ResidentialComplexController(IMapper mapper) : BaseController
{
    public readonly IMapper _mapper = mapper;

    [HttpGet("get-all")]
    public async Task<ActionResult<ResidentialComplexListVm>> GetAll()
    {
        var query = new GetResidentialComplexListQuery();

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("get")]
    public async Task<ActionResult<ResidentialComplexListVm>> Get([FromQuery] Guid id)
    {
        var query = new GetResidentialComplexDetailsQuery()
        {
            Id = id
        };

        var vm = await Mediator.Send(query);

        return Ok(vm);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateResidentialComplexDto createResidentComplexDto)
    {
        var command = _mapper.Map<CreateResidentialComplexCommand>(createResidentComplexDto);

        var residentId = await Mediator.Send(command);

        return Ok(residentId);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateResidentialComplexDto updateResidentialComplexDto)
    {
        var command = _mapper.Map<UpdateResidentialComplexCommand>(updateResidentialComplexDto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var command = new DeleteResidentialComplexCommand()
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
