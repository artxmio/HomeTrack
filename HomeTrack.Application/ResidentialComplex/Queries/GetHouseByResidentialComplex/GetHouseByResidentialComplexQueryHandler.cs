using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeTrack.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.ResidentialComplex.Queries.GetHouseByResidentialComplex;

public class GetHouseByResidentialComplexQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper)
    : IRequestHandler<GetHouseByResidentialComplexQuery, HouseByResidentialComplexVm>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<HouseByResidentialComplexVm> Handle(GetHouseByResidentialComplexQuery request, CancellationToken cancellationToken)
    {
        var houses = await _dbContext.Houses
            .Where(h => h.ResidentialСomplexId == request.ResidentialComplexId)
            .ProjectTo<HouseByResidentialComplexLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new HouseByResidentialComplexVm() { Houses = houses };
    }
}