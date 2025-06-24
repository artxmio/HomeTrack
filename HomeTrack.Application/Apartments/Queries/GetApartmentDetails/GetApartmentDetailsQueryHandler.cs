using AutoMapper;
using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Apartments.Queries.GetApartmentDetails;

public class GetApartmentDetailsQueryHandler(IHomeTrackDbContext dbContext, IMapper mapper)
    : IRequestHandler<GetApartmentDetailsQuery, ApartmentDetailsVm>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ApartmentDetailsVm> Handle(GetApartmentDetailsQuery request, CancellationToken cancellationToken)
    {
        var apartment = await _dbContext.Apartments
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken) ?? 
            throw new NotFoundException(nameof(Resident), request.Id);

        return _mapper.Map<ApartmentDetailsVm>(apartment);
    }
}