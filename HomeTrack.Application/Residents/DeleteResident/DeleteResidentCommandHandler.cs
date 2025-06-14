using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using HomeTrack.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.Residents.DeleteResident;

public class DeleteResidentCommandHandler
    : IRequestHandler<DeleteResidentCommand>
{
    private readonly IHomeTrackDbContext _dbContext;

    public DeleteResidentCommandHandler(IHomeTrackDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task Handle(DeleteResidentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Residents
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Resident), request.Id);

        _dbContext.Residents.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
