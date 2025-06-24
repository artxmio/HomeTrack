using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.ResidentialComplex.Commands.UpdateResidentialComplex;
using HomeTrack.Application.Residents.Commands.CreateResident;

namespace HomeTrack.WebApi.Models;

public class UpdateResidentialComplexDto 
    : IMapWith<UpdateResidentialComplexCommand>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateResidentialComplexDto, UpdateResidentialComplexCommand>()
               .ForMember(residentComplexCommand => residentComplexCommand.Id,
               opt => opt.MapFrom(residentComplexDto => residentComplexDto.Id))
               .ForMember(residentComplexCommand => residentComplexCommand.Name,
               opt => opt.MapFrom(residentComplexDto => residentComplexDto.Name));
    }
}
