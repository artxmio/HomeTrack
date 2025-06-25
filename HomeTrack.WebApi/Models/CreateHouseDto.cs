using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Houses.Commands.CreateHouse;
using HomeTrack.Application.Residents.Commands.CreateResident;

namespace HomeTrack.WebApi.Models;

public class CreateHouseDto: IMapWith<CreateHouseCommand>
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string Number { get; set; } 
    public required int NumberOfFloors { get; set; }
    public required int NumberOfEntrances { get; set; }
    public Guid ResidentialComplexId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHouseDto, CreateHouseCommand>()
            .ForMember(houseCommand => houseCommand.Street,
                       opt => opt.MapFrom(houseDto => houseDto.Street))
            .ForMember(houseCommand => houseCommand.City,
                       opt => opt.MapFrom(houseDto => houseDto.City))
            .ForMember(houseCommand => houseCommand.Number,
                       opt => opt.MapFrom(houseDto => houseDto.Number))
            .ForMember(houseCommand => houseCommand.NumberOfFloors,
                       opt => opt.MapFrom(houseDto => houseDto.NumberOfFloors))
            .ForMember(houseCommand => houseCommand.NumberOfEntrances,
                       opt => opt.MapFrom(houseDto => houseDto.NumberOfEntrances))
            .ForMember(houseCommand => houseCommand.ResidentialComplexId,
                       opt => opt.MapFrom(houseDto => houseDto.ResidentialComplexId));
    }
}
