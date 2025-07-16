using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.ResidentialComplex.RemoveHouseFromResidentialComplex;

namespace HomeTrack.WebApi.Models;

public class RemoveHouseDto 
    : IMapWith<RemoveHouseFromResidentialComplexCommand>
{
    public Guid HouseId { get; set; }
    public Guid ResidentialComplexId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RemoveHouseDto, RemoveHouseFromResidentialComplexCommand>()
            .ForMember(removeHouseDto => removeHouseDto.HouseId,
                    opt => opt.MapFrom(removeHouseCommand => removeHouseCommand.HouseId))
            .ForMember(removeHouseDto => removeHouseDto.ResidentialComplexId,
                    opt => opt.MapFrom(removeHouseCommand => removeHouseCommand.ResidentialComplexId));
    }
}
