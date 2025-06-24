using AutoMapper;
using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Residents.Queries.GetResidentDetails;

public class GetResidentDetailsQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetResidentDetailsQuery, ResidentDetailsVm>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ResidentDetailsVm> Handle(GetResidentDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Residents.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken) ??
            throw new NotFoundException(nameof(Resident), request.Id);

        return _mapper.Map<ResidentDetailsVm>(entity);
    }
}
