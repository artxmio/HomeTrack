using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.ResidentialComplex.Commands.AddHouseToResidentialComplex;

namespace HomeTrack.WebApi.Models;

public class AddHouseDto : IMapWith<AddHouseToResidentialComplexCommand>
{
    public Guid HouseId { get; set; }
    public Guid ResidentialComplexId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AddHouseDto, AddHouseToResidentialComplexCommand>()
            .ForMember(addHouseCommand => addHouseCommand.HouseId,
                       opt => opt.MapFrom(addHouseDto => addHouseDto.HouseId))
            .ForMember(addApartmentCommand => addApartmentCommand.ResidendialComplexId,
                       opt => opt.MapFrom(addApartmenttDto => addApartmenttDto.ResidentialComplexId));
    }
}