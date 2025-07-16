using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Domain;

namespace HomeTrack.Application.ResidentialComplex.Queries.GetHouseByResidentialComplex;

public class HouseByResidentialComplexLookupDto : IMapWith<House>
{
    public Guid Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public int NumberOfFloors { get; set; }
    public int NumberOfEntrances { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<House, HouseByResidentialComplexLookupDto>()
            .ForMember(houseVm => houseVm.Id,
                      opt => opt.MapFrom(house => house.Id))
            .ForMember(houseVm => houseVm.Street,
                      opt => opt.MapFrom(house => house.Street))
            .ForMember(houseVm => houseVm.City,
                      opt => opt.MapFrom(house => house.City))
            .ForMember(houseVm => houseVm.Number,
                      opt => opt.MapFrom(house => house.Number))
            .ForMember(houseVm => houseVm.NumberOfFloors,
                      opt => opt.MapFrom(house => house.NumberOfFloors))
            .ForMember(houseVm => houseVm.NumberOfEntrances,
                      opt => opt.MapFrom(house => house.NumberOfEntrances));
    }
}