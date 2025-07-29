using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;

namespace HomeTrack.Application.Residents.Commands.CreateResident;

public class CreateResidentCommandHandler(IHomeTrackDbContext dbContext)
        : IRequestHandler<CreateResidentCommand, Guid>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task<Guid> Handle(CreateResidentCommand request, CancellationToken cancellationToken)
    {
        var resident = new Resident()
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Surname = request.Surname,
            CreateDate = DateTime.Now,
            UpdateDate = null
        };

        await _dbContext.Residents.AddAsync(resident, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return resident.Id;
    }
}
