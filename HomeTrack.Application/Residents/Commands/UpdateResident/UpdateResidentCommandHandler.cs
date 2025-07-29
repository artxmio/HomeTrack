using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Residents.Commands.UpdateResident;

public class UpdateResidentCommandHandler(IHomeTrackDbContext dbContext)
        : IRequestHandler<UpdateResidentCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(UpdateResidentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Residents
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken) 
            ?? throw new NotFoundException(nameof(Resident), request.Id);

        entity.Name = request.Name;
        entity.Surname = request.Surname;
        entity.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
