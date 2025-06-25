using AutoMapper;
using HomeTrack.Application.Apartments.Commands.AddResidentToApartment;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Houses.Commands.AddApartmentToHouse;

namespace HomeTrack.WebApi.Models;

public class AddApartmentDto : IMapWith<AddApartmentToHouseCommand>
{
    public Guid ApartmentId { get; set; }
    public Guid HouseId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddApartmentDto, AddApartmentToHouseCommand>()
            .ForMember(addApartmentCommand => addApartmentCommand.ApartmentId,
                       opt => opt.MapFrom(addApartmenttDto => addApartmenttDto.ApartmentId))
            .ForMember(addApartmentCommand => addApartmentCommand.ApartmentId,
                       opt => opt.MapFrom(addApartmenttDto => addApartmenttDto.ApartmentId));
    }
}
