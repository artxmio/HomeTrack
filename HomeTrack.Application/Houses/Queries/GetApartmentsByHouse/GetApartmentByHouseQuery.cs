using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Houses.Queries.GetApartmentsByHouse;

public class GetApartmentByHouseQuery : 
    IRequest<ApartmentByHouseVm>
{
    public Guid HouseId { get; set; }
}

public class ApartmentByHouseVm
{
    public IList<ApartmentByHouseLookupDto> Apartments { get; set; } = null!;
}

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

public class GetApartmentByHouseQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper) :
    IRequestHandler<GetApartmentByHouseQuery, ApartmentByHouseVm>
{
    private readonly IMapper _mapper = mapper;
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task<ApartmentByHouseVm> Handle(GetApartmentByHouseQuery request, CancellationToken cancellationToken)
    {
        var apartments = await _dbContext.Apartments
            .Where(a => a.HouseId == request.HouseId)
            .ProjectTo<ApartmentByHouseLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ApartmentByHouseVm() { Apartments = apartments };
    }
}