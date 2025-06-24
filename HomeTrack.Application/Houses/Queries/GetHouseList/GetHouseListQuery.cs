using AutoMapper;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Domain;
using MediatR;

namespace HomeTrack.Application.Houses.Queries.GetHouseList;

public class GetHouseListQuery : IRequest<HouseListVm>
{
}

public class HouseListVm
{
    public IList<House> Houses { get; set; } = null!;
}

public class HouseLookupDto : IMapWith<House>
{
    public Guid Id { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public int NumberOfFloors { get; set; }
    public int NumberOfEntrances { get; set; }

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

public class GetHouseListQueryHandler : IRequestHandler<GetHouseListQuery, HouseListVm>
{


    public async Task<HouseListVm> IRequestHandler<GetHouseListQuery, HouseListVm>.Handle(GetHouseListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}