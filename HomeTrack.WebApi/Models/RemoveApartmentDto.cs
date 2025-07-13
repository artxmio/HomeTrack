using AutoMapper;
using HomeTrack.Application.Apartments.Commands.RemoveResidentFromApartment;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Houses.Commands.RemoveApartmentFromHouse;

namespace HomeTrack.WebApi.Models;

public class RemoveApartmentDto : IMapWith<RemoveApartmentFromHouseCommand>
{
    public Guid ApartmentId { get; set; }
    public Guid HouseId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RemoveApartmentDto, RemoveApartmentFromHouseCommand>()
            .ForMember(removeApartmentCommand => removeApartmentCommand.HouseId,
                opt => opt.MapFrom(removeApartmentDto => removeApartmentDto.HouseId))
            .ForMember(removeApartmentCommand => removeApartmentCommand.ApartmentId,
                opt => opt.MapFrom(removeApartmentDto => removeApartmentDto.ApartmentId));
    }
}
