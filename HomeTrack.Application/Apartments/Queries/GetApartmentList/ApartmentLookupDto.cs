using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Domain;

namespace HomeTrack.Application.Apartments.Queries.GetApartmentList;

public class ApartmentLookupDto : IMapWith<Apartment>
{
    public Guid Id { get; set; }
    public Guid HouseId { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Entrance { get; set; }
    public int Floor { get; set; }
    public int Area { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Apartment, ApartmentLookupDto>()
           .ForMember(apartmentVm => apartmentVm.Id,
                      opt => opt.MapFrom(apartment => apartment.Id))
           .ForMember(apartmentVm => apartmentVm.HouseId,
                      opt => opt.MapFrom(apartment => apartment.HouseId))
           .ForMember(apartmentVm => apartmentVm.Number,
                      opt => opt.MapFrom(apartmentVm => apartmentVm.Number))
           .ForMember(apartmentVm => apartmentVm.Floor,
                      opt => opt.MapFrom(apartmentVm => apartmentVm.Floor))
           .ForMember(apartmentVm => apartmentVm.Area,
                      opt => opt.MapFrom(apartmentVm => apartmentVm.Area))
           .ForMember(apartmentVm => apartmentVm.Entrance,
                      opt => opt.MapFrom(apartmentVm => apartmentVm.Entrance));
    }
}
