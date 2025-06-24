using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;

namespace HomeTrack.Application.Houses.Commands.CreateHouse;

public class CreateHouseCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<CreateHouseCommand, Guid>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task<Guid> Handle(CreateHouseCommand request, CancellationToken cancellationToken)
    {
        var house = new House()
        {
            Id = Guid.NewGuid(),
            Street = request.Street,
            City = request.City,
            Number = request.Number,
            NumberOfEntrances = request.NumberOfEntrances,
            NumberOfFloors = request.NumberOfFloors,
            CreateDate = DateTime.Now,
            UpdateDate = null
        };

        await _dbContext.Houses.AddAsync(house, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return house.Id;
    }
}
