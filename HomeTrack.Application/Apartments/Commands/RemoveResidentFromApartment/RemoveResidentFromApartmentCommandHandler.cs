using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Apartments.Commands.RemoveResidentFromApartment;

public class RemoveResidentFromApartmentCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<RemoveResidentFromApartmentCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(RemoveResidentFromApartmentCommand request, CancellationToken cancellationToken)
    {
        var resident = await _dbContext.Residents
            .FirstOrDefaultAsync(r =>  r.Id == request.ResidentId, cancellationToken) ?? 
            throw new NotFoundException(nameof(Apartment), request.ResidentId);

        resident.ApartmentId = null;
        resident.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}