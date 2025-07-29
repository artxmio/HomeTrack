using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Domain;

namespace HomeTrack.Application.Residents.Queries.GetResidentList;

public class ResidentLookupDto : IMapWith<Resident>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Resident, ResidentLookupDto>()
            .ForMember(residentVm => residentVm.Id,
                       opt => opt.MapFrom(resident => resident.Id))
            .ForMember(residentVm => residentVm.Name,
                       opt => opt.MapFrom(resident => resident.Name))
            .ForMember(residentVm => residentVm.Surname,
                       opt => opt.MapFrom(resident => resident.Surname));
    }
}