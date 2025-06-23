using AutoMapper;
using AutoMapper.QueryableExtensions;
using HomeTrack.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.ResidentialComplex.Queries.GetResidentialComplexesList;

public class GetResidentialComplexListQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper) :
    IRequestHandler<GetResidentialComplexListQuery, ResidentialComplexListVm>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ResidentialComplexListVm> Handle(GetResidentialComplexListQuery request, CancellationToken cancellationToken)
    {
        var residentComplexes = await _dbContext.ResidentialComplexes
                            .ProjectTo<ResidentialComplexLookupDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);

        return new ResidentialComplexListVm { ResidentialComplexes = residentComplexes };
    }
}
