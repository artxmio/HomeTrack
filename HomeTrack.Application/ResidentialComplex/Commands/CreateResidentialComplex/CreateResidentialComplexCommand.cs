using MediatR;

namespace HomeTrack.Application.ResidentialComplex.Commands.CreateResidentialComplex;

public class CreateResidentialComplexCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
}
