using AutoMapper;
using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Houses.Queries.GetHouseDetails;

public class GetHouseDetailsQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper)
        : IRequestHandler<GetHouseDetailsQuery, HouseDetailsVm>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<HouseDetailsVm> Handle(GetHouseDetailsQuery request, CancellationToken cancellationToken)
    {
        var house = await _dbContext.Houses.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken: cancellationToken) ??
            throw new NotFoundException(nameof(Apartment), request.Id);

        return _mapper.Map<HouseDetailsVm>(house);
    }
}