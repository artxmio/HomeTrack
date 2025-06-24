using MediatR;

namespace HomeTrack.Application.ResidentialComplex.Commands.DeleteResidentialComplex;

public class DeleteResidentialComplexCommand : IRequest
{
    public Guid Id { get; set; }
}