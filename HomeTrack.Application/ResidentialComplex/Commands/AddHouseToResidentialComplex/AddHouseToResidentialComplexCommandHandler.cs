using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.ResidentialComplex.Commands.AddHouseToResidentialComplex;

public class AddHouseToResidentialComplexCommandHandler(IHomeTrackDbContext dbContext)
    : IRequestHandler<AddHouseToResidentialComplexCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(AddHouseToResidentialComplexCommand request, CancellationToken cancellationToken)
    {
        var house = await _dbContext.Houses
            .FirstOrDefaultAsync(h => h.Id == request.HouseId, cancellationToken)
            ?? throw new NotFoundException(nameof(House), request.HouseId);

        if (house.ResidentialСomplexId == request.ResidentialComplexId)
            throw new AlreadyExistException(nameof(House), nameof(house.ResidentialСomplex), request.ResidentialComplexId);

        house.ResidentialСomplexId = request.ResidentialComplexId;
        house.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}