using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Residents.Commands.CreateResident;

namespace HomeTrack.WebApi.Models;

public class CreateResidentDto : IMapWith<CreateResidentCommand>
{
    public required string Name { get; set; }
    public required string Surname { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateResidentDto, CreateResidentCommand>()
            .ForMember(residentCommand => residentCommand.Name,
                       opt => opt.MapFrom(residentDto => Name))
            .ForMember(residentCommand => residentCommand.Surname,
                       opt => opt.MapFrom(residentDto => Surname));
    }
}
