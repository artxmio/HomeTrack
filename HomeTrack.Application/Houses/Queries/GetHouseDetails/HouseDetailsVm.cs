using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Houses.Queries.GetHouseList;
using HomeTrack.Domain;

namespace HomeTrack.Application.Houses.Queries.GetHouseDetails;

public class HouseDetailsVm : IMapWith<House>
{
    public Guid Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public int NumberOfFloors { get; set; }
    public int NumberOfEntrances { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<House, HouseLookupDto>()
            .ForMember(houseVm => houseVm.Id,
            opt => opt.MapFrom(houseVm => houseVm.Id))
            .ForMember(houseVm => houseVm.Street,
            opt => opt.MapFrom(houseVm => houseVm.Street))
            .ForMember(houseVm => houseVm.City,
            opt => opt.MapFrom(houseVm => houseVm.City))
            .ForMember(houseVm => houseVm.Number,
            opt => opt.MapFrom(houseVm => houseVm.Number))
            .ForMember(houseVm => houseVm.NumberOfFloors,
            opt => opt.MapFrom(houseVm => houseVm.NumberOfFloors))
            .ForMember(houseVm => houseVm.NumberOfEntrances,
            opt => opt.MapFrom(houseVm => houseVm.NumberOfEntrances));
    }
}
