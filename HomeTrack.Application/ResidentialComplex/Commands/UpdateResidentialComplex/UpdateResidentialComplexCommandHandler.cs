﻿using HomeTrack.Application.Exceptions;
using HomeTrack.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeTrack.Application.ResidentialComplex.Commands.UpdateResidentialComplex;

public class UpdateResidentialComplexCommandHandler(IHomeTrackDbContext dbContext)
    : IRequestHandler<UpdateResidentialComplexCommand>
{
    private readonly IHomeTrackDbContext _dbContext = dbContext;

    public async Task Handle(UpdateResidentialComplexCommand request, CancellationToken cancellationToken)
    {
        var complex = await _dbContext.ResidentialComplexes
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(ResidentialComplex), request.Id); 

        complex.Name = request.Name;
        complex.UpdateDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}