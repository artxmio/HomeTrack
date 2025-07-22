using AutoMapper;
using HomeTrack.Application.Apartments.Commands.UpdateApartment;
using HomeTrack.Application.Common.Mappings;

namespace HomeTrack.WebApi.Models;

public class UpdateApartmentDto : IMapWith<UpdateApartmentCommand>
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Entrance { get; set; }
    public int Floor { get; set; }
    public int Area { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateApartmentDto, UpdateApartmentCommand>()
            .ForMember(apartmentCommand => apartmentCommand.Id,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.Id))
            .ForMember(apartmentCommand => apartmentCommand.Number,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.Number))
            .ForMember(apartmentCommand => apartmentCommand.Entrance,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.Entrance))
            .ForMember(apartmentCommand => apartmentCommand.Floor,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.Floor))
            .ForMember(apartmentCommand => apartmentCommand.Area,
                       opt => opt.MapFrom(apartmentDto => apartmentDto.Area));
    }
}
