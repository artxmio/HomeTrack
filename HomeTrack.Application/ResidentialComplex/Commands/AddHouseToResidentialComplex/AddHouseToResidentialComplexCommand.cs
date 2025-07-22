using MediatR;

namespace HomeTrack.Application.ResidentialComplex.Commands.AddHouseToResidentialComplex;

public class AddHouseToResidentialComplexCommand
    : IRequest
{
    public Guid HouseId { get; set; }
    public Guid ResidentialComplexId { get; set; }
}