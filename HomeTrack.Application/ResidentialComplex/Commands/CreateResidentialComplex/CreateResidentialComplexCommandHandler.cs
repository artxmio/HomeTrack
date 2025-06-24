using MediatR;
using HomeTrack.Domain;
using HomeTrack.Application.Interfaces;

namespace HomeTrack.Application.ResidentialComplex.Commands.CreateResidentialComplex;

public class CreateResidentialComplexCommandHandler(IHomeTrackDbContext dbContext) :
    IRequestHandler<CreateResidentialComplexCommand, Guid>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task<Guid> Handle(CreateResidentialComplexCommand request, CancellationToken cancellationToken)
    {
        var complex = new ResidentialСomplex()
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        await _dbContext.ResidentialComplexes.AddAsync(complex, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return complex.Id;
    }
}
