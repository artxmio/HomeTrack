using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeTrack.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Houses.Queries.GetHouseList;

public class GetHouseListQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper) 
    : IRequestHandler<GetHouseListQuery, HouseListVm>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<HouseListVm> Handle(GetHouseListQuery request, CancellationToken cancellationToken)
    {
        var houses = await _dbContext.Houses
            .ProjectTo<HouseLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new HouseListVm() { Houses = houses };
    }
}