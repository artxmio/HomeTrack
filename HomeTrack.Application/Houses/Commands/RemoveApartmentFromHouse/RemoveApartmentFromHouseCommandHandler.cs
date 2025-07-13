using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Houses.Commands.RemoveApartmentFromHouse;

public class RemoveApartmentFromHouseCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<RemoveApartmentFromHouseCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(RemoveApartmentFromHouseCommand request, CancellationToken cancellationToken)
    {
        var apartment = await _dbContext.Apartments
            .FirstOrDefaultAsync(a => a.Id == request.ApartmentId, cancellationToken) ??
            throw new NotFoundException(nameof(Apartment), request.ApartmentId);

        apartment.HouseId = null;
        apartment.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}