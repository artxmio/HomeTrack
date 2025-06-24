using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces; 
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.ResidentialComplex.Commands.DeleteResidentialComplex;

public class DeleteResidentialComplexCommandHandler(IHomeTrackDbContext dbContext) : IRequestHandler<DeleteResidentialComplexCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(DeleteResidentialComplexCommand request, CancellationToken cancellationToken)
    {
        var complex = await _dbContext.ResidentialComplexes
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(ResidentialComplex), request.Id); 

        _dbContext.ResidentialComplexes.Remove(complex);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}