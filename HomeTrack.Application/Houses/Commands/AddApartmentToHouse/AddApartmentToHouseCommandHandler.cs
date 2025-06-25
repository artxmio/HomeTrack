using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Houses.Commands.AddApartmentToHouse;

public class AddApartmentToHouseCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<AddApartmentToHouseCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext; 

    public async Task Handle(AddApartmentToHouseCommand request, CancellationToken cancellationToken)
    {
        var apartment = await _dbContext.Apartments
            .FirstOrDefaultAsync(a => a.Id == request.ApartmentId, cancellationToken)
            ?? throw new NotFoundException(nameof(Apartment), request.ApartmentId);

        if(apartment.HouseId == request.HouseId)
            throw new AlreadyExistException(nameof(Apartment), nameof(apartment.HouseId), request.HouseId);

        apartment.HouseId = request.HouseId;
        apartment.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}