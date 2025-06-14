using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Domain;

namespace HomeTrack.Application.Residents.Queries.GetResidentDetails;

public class ResidentDetailsVm : IMapWith<Resident>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Resident, ResidentDetailsVm>()
            .ForMember(residentVm => residentVm.Id,
                       opt => opt.MapFrom(resident => resident.Id))
            .ForMember(residentVm => residentVm.Name,
                       opt => opt.MapFrom(resident => resident.Name))
            .ForMember(residentVm => residentVm.Surname,
                       opt => opt.MapFrom(resident => resident.Surname))
            .ForMember(residentVm => residentVm.CreateDate,
                       opt => opt.MapFrom(resident => resident.CreateDate))
            .ForMember(residentVm => residentVm.UpdateDate,
                       opt => opt.MapFrom(resident => resident.UpdateDate));
    }
}