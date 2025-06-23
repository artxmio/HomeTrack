using AutoMapper;
using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.ResidentialComplex.Queries.GetResidentialComplexDetails;

public class GetResidentialComplexDetailsQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper) :
    IRequestHandler<GetResidentialComplexDetailsQuery, ResidentialComplexVm>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ResidentialComplexVm> Handle(GetResidentialComplexDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ResidentialComplexes.FirstOrDefaultAsync(rc => rc.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Resident), request.Id);

        return _mapper.Map<ResidentialComplexVm>(entity);
    }
}
