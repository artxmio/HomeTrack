using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Houses.Commands.UpdateHouse;

namespace HomeTrack.WebApi.Models;

public class UpdateHouseDto : IMapWith<UpdateHouseCommand>
{
    public required Guid Id { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string Number { get; set; }
    public required int NumberOfFloors { get; set; }
    public required int NumberOfEntrances { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateHouseDto, UpdateHouseCommand>()
               .ForMember(houseCommand => houseCommand.Street,
               opt => opt.MapFrom(houseDto => houseDto.Street))
               .ForMember(houseCommand => houseCommand.City,
               opt => opt.MapFrom(houseDto => houseDto.City))
               .ForMember(houseCommand => houseCommand.Number,
               opt => opt.MapFrom(houseDto => houseDto.Number))
               .ForMember(houseCommand => houseCommand.NumberOfFloors,
               opt => opt.MapFrom(houseDto => houseDto.NumberOfFloors))
               .ForMember(houseCommand => houseCommand.NumberOfEntrances,
               opt => opt.MapFrom(houseDto => houseDto.NumberOfEntrances));
    }
}
