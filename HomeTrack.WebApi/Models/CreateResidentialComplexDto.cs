using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.ResidentialComplex.Commands.CreateResidentialComplex;
using HomeTrack.Application.Residents.Commands.CreateResident;

namespace HomeTrack.WebApi.Models;

public class CreateResidentialComplexDto
    : IMapWith<CreateResidentialComplexCommand>
{
    public string Name { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateResidentialComplexDto, CreateResidentialComplexCommand>()
               .ForMember(residentialComplexCommand => residentialComplexCommand.Name,
               opt => opt.MapFrom(residentialComplexDto => residentialComplexDto.Name));

    }
}
