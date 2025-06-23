using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Domain;

namespace HomeTrack.Application.ResidentialComplex.Queries.GetResidentialComplexesList;

public class ResidentialComplexLookupDto : IMapWith<ResidentialСomplex>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ResidentialСomplex, ResidentialComplexLookupDto>()
            .ForMember(residentComplexVm => residentComplexVm.Id,
                       opt => opt.MapFrom(residentComplex => residentComplex.Id))
            .ForMember(residentComplexVm => residentComplexVm.Name,
                       opt => opt.MapFrom(residentComplex => residentComplex.Name));
    }
}