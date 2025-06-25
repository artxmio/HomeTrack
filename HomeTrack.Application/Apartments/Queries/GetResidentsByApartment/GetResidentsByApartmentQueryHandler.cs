using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeTrack.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Apartments.Queries.GetResidentsByApartment;

public class GetResidentsByApartmentQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper) :
    IRequestHandler<GetResidentsByApartmentQuery, ResidentsByApartmentVm>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ResidentsByApartmentVm> Handle(GetResidentsByApartmentQuery request, CancellationToken cancellationToken)
    {
        var residents = await _dbContext.Residents
            .Where(r => r.ApartmentId == request.ApartmentId)
            .ProjectTo<ResidentsByApartmentLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ResidentsByApartmentVm() { Residents = residents };
    }
}