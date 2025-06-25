using AutoMapper;
using HomeTrack.Application.Apartments.Commands.AddResidentToApartment;
using HomeTrack.Application.Common.Mappings;

namespace HomeTrack.WebApi.Models;

public class AddResidentDto : IMapWith<AddResidentToApartmentCommand>
{
    public Guid ResidentId { get; set; }
    public Guid ApartmentId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddResidentDto, AddResidentToApartmentCommand>()
            .ForMember(addResidentCommand => addResidentCommand.ResidentId,
                       opt => opt.MapFrom(addResidentDto => addResidentDto.ResidentId))
            .ForMember(addResidentCommand => addResidentCommand.ApartmentId,
                       opt => opt.MapFrom(addResidentDto => addResidentDto.ApartmentId));
    }
}
