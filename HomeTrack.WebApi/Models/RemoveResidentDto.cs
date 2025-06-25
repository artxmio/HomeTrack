using AutoMapper;
using HomeTrack.Application.Apartments.Commands.RemoveResidentFromApartment;
using HomeTrack.Application.Common.Mappings;

namespace HomeTrack.WebApi.Models;

public class RemoveResidentDto : IMapWith<RemoveResidentFromApartmentCommand>
{
    public Guid ResidentId { get; set; }
    public Guid ApartmentId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RemoveResidentDto, RemoveResidentFromApartmentCommand>()
            .ForMember(addResidentCommand => addResidentCommand.ResidentId,
                opt => opt.MapFrom(addResidentDto => addResidentDto.ResidentId))
            .ForMember(addResidentCommand => addResidentCommand.ApartmentId,
                opt => opt.MapFrom(addResidentDto => addResidentDto.ApartmentId));
    }
}
