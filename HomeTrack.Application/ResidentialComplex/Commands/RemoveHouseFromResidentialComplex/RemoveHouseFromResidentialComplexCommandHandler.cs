using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.ResidentialComplex.Commands.RemoveHouseFromResidentialComplex;

public class RemoveHouseFromResidentialComplexCommandHandler(IHomeTrackDbContext dbContext)
    : IRequestHandler<RemoveHouseFromResidentialComplexCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(RemoveHouseFromResidentialComplexCommand request, CancellationToken cancellationToken)
    {
        var house = await _dbContext.Houses
            .FirstOrDefaultAsync(h => h.Id == request.HouseId, cancellationToken) ??
            throw new NotFoundException(nameof(House), request.HouseId);

        house.ResidentialСomplexId = null;
        house.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}