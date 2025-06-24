using MediatR;

namespace HomeTrack.Application.ResidentialComplex.Commands.UpdateResidentialComplex;

public class UpdateResidentialComplexCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
