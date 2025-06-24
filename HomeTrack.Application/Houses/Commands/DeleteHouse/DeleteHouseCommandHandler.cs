using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Houses.Commands.DeleteHouse;

public class DeleteHouseCommandHandler(IHomeTrackDbContext dbContext)
        : IRequestHandler<DeleteHouseCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(DeleteHouseCommand request, CancellationToken cancellationToken)
    {
        var house = await _dbContext.Houses.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken) ?? 
            throw new NotFoundException(nameof(House), request.Id);

        _dbContext.Houses.Remove(house);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}