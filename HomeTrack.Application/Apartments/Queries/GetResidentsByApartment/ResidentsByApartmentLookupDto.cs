using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Domain;

namespace HomeTrack.Application.Apartments.Queries.GetResidentsByApartment;

public class ResidentsByApartmentLookupDto :
    IMapWith<Resident>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Resident, ResidentsByApartmentLookupDto>()
           .ForMember(residentVm => residentVm.Id,
                      opt => opt.MapFrom(resident => resident.Id))
           .ForMember(residentVm => residentVm.Name,
                      opt => opt.MapFrom(resident => resident.Name))
           .ForMember(residentVm => residentVm.Surname,
                      opt => opt.MapFrom(resident => resident.Surname));
    }
}