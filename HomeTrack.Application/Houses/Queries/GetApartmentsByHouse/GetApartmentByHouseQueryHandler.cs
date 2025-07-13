using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeTrack.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Houses.Queries.GetApartmentsByHouse;

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