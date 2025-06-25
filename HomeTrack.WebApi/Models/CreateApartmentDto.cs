using AutoMapper;
using HomeTrack.Application.Apartments.Commands.CreateApartment;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Residents.Commands.CreateResident;

namespace HomeTrack.WebApi.Models;

public class CreateApartmentDto : IMapWith<CreateApartmentCommand>
{
    public string Number { get; set; } = string.Empty;
    public int Entrance { get; set; }
    public int Floor { get; set; }
    public int Area { get; set; }
    public Guid HouseId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateApartmentDto, CreateApartmentCommand>()
            .ForMember(apartmentCommand => apartmentCommand.Number,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.Number))
            .ForMember(apartmentCommand => apartmentCommand.Entrance,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.Entrance))
            .ForMember(apartmentCommand => apartmentCommand.Floor,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.Floor))
            .ForMember(apartmentCommand => apartmentCommand.Area,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.Area))
            .ForMember(apartmentCommand => apartmentCommand.HouseId,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.HouseId));
    }
}
