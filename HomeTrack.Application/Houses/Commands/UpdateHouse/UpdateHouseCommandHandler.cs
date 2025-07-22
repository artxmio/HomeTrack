using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Houses.Commands.UpdateHouse;

public class UpdateHouseCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<UpdateHouseCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(UpdateHouseCommand request, CancellationToken cancellationToken)
    {
        var house = await _dbContext.Houses.FirstOrDefaultAsync(h => h.Id == request.Id, cancellationToken) ??
            throw new NotFoundException(nameof(House), request.Id);

        house.Street = request.Street;
        house.City = request.City;
        house.Number = request.Number;
        house.NumberOfEntrances = request.NumberOfEntrances;
        house.NumberOfFloors = request.NumberOfFloors;
        house.ResidentialСomplexId = request.ResidentialComplexId;
        house.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}