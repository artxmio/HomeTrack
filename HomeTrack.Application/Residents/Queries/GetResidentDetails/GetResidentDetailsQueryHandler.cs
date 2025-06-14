using AutoMapper;
using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Residents.Queries.GetResidentDetails;

public class GetResidentDetailsQueryHandler
    : IRequestHandler<GetResidentDetailsQuery, ResidentDetailsVm>
{
    private readonly IHomeTrackDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetResidentDetailsQueryHandler(
        IHomeTrackDbContext dbContext, 
        IMapper mapper)
    {
        this._dbContext = dbContext;
        this._mapper = mapper;
    }

    public async Task<ResidentDetailsVm> Handle(GetResidentDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Residents.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken) ??
            throw new NotFoundException(nameof(Resident), request.Id);

        return _mapper.Map<ResidentDetailsVm>(entity);
    }
}
