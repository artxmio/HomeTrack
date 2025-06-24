using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Apartments.Commands.UpdateApartment;

public class UpdateApartmentCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<UpdateApartmentCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
    {
        var apartment = await _dbContext.Apartments
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Resident), request.Id);

        apartment.Entrance = request.Entrance;
        apartment.Floor = request.Floor;
        apartment.Area = request.Area;
        apartment.Number = request.Number;
        apartment.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}