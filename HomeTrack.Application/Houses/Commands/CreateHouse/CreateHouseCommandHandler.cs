using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Houses.Commands.CreateHouse;

public class CreateHouseCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<CreateHouseCommand, Guid>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task<Guid> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
    {
        var complex = await _dbContext.ResidentialComplexes
            .FirstOrDefaultAsync(c => c.Id == request.ResidentialComplexId, cancellationToken) ??
            throw new NotFoundException(nameof(House), request.ResidentialComplexId);

        var house = new House()
        {
            Id = Guid.NewGuid(),
            Street = request.Street,
            City = request.City,
            Number = request.Number,
            NumberOfEntrances = request.NumberOfEntrances,
            NumberOfFloors = request.NumberOfFloors,
            ResidentialСomplex = complex,
            CreateDate = DateTime.Now,
            UpdateDate = null
        };

        await _dbContext.Houses.AddAsync(house, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return house.Id;
    }
}
