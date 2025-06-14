using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeTrack.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Residents.Queries.GetResidentList;

public class GetResidentListQueryHandler
    : IRequestHandler<GetResidentListQuery, ResidentListVm>
{
    private readonly IHomeTrackDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetResidentListQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper)
    {
        this._dbContext = dbContext;
        this._mapper = mapper;
    }

    public async Task<ResidentListVm> Handle(GetResidentListQuery request, CancellationToken cancellationToken)
    {
        var residents = await _dbContext.Residents
            .ProjectTo<ResidentLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ResidentListVm { Residents = residents };
    }
}
