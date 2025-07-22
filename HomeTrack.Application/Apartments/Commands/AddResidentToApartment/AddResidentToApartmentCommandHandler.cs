using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Apartments.Commands.AddResidentToApartment;

public class AddResidentToApartmentCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<AddResidentToApartmentCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(AddResidentToApartmentCommand request, CancellationToken cancellationToken)
    {
        var resident = await _dbContext.Residents.FirstOrDefaultAsync(r => r.Id == request.ResidentId, cancellationToken) ?? 
            throw new NotFoundException(nameof(Resident), request.ResidentId);

        resident.ApartmentId = request.ApartmentId;
        resident.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}