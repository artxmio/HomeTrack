using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Domain;

namespace HomeTrack.Application.Houses.Queries.GetApartmentsByHouse;

public class ApartmentByHouseLookupDto : IMapWith<Apartment>
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Entrance { get; set; }
    public int Floor { get; set; }
    public int Area { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Apartment, ApartmentByHouseLookupDto>()
           .ForMember(apartmentVm => apartmentVm.Id,
                      opt => opt.MapFrom(apartment => apartment.Id))
           .ForMember(apartmentVm => apartmentVm.Number,
                      opt => opt.MapFrom(apartment => apartment.Number))
           .ForMember(apartmentVm => apartmentVm.Entrance,
                      opt => opt.MapFrom(apartment => apartment.Entrance))
           .ForMember(apartmentVm => apartmentVm.Floor,
                      opt => opt.MapFrom(apartment => apartment.Floor))
           .ForMember(apartmentVm => apartmentVm.Area,
                      opt => opt.MapFrom(apartment => apartment.Area));
    }
}
