using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Apartments.Commands.DeleteApartment;

public class DeleteApartmentCommandHandler(IHomeTrackDbContext dbContext)
    : IRequestHandler<DeleteApartmentCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
    {
        var apartment = await _dbContext.Apartments
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken) 
            ?? throw new NotFoundException(nameof(Apartment), request.Id);

        _dbContext.Apartments.Remove(apartment);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}