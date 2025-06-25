using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;

namespace HomeTrack.Application.Apartments.Commands.CreateApartment;

public class CreateApartmentCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<CreateApartmentCommand, Guid>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task<Guid> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
    {
        var apartment = new Apartment()
        {
            Id = Guid.NewGuid(),
            Number = request.Number,
            Floor = request.Floor,
            Area = request.Area,
            Entrance = request.Entrance,
            HouseId = request.HouseId,
            CreateDate = DateTime.Now,
            UpdateDate = null
        };

        await _dbContext.Apartments.AddAsync(apartment, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return apartment.Id;
    }
}
