using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Residents.Commands.UpdateResident;

namespace HomeTrack.WebApi.Models;

public class UpdateResidentDto : IMapWith<UpdateResidentCommand>
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateResidentDto, UpdateResidentCommand>()
              .ForMember(residentCommand => residentCommand.Id,
               opt => opt.MapFrom(residentDto => residentDto.Id))
              .ForMember(residentCommand => residentCommand.Name,
               opt => opt.MapFrom(residentDto => residentDto.Name))
              .ForMember(residentCommand => residentCommand.Surname,
               opt => opt.MapFrom(residentDto => residentDto.Surname));
    }
}
