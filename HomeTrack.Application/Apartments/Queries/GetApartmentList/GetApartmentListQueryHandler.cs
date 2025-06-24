using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeTrack.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Apartments.Queries.GetApartmentList;

public class GetApartmentListQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper) :
    IRequestHandler<GetApartmentListQuery, ApartmentListVm>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ApartmentListVm> Handle(GetApartmentListQuery request, CancellationToken cancellationToken)
    {
        var apartments = await _dbContext.Apartments
            .ProjectTo<ApartmentLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ApartmentListVm { Apartments = apartments };
    }
}