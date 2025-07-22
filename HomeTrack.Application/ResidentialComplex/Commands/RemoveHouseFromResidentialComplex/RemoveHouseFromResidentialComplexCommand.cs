using MediatR;

namespace HomeTrack.Application.ResidentialComplex.Commands.RemoveHouseFromResidentialComplex;

public class RemoveHouseFromResidentialComplexCommand
    : IRequest
{
    public Guid HouseId { get; set; }
    public Guid ResidentialComplexId{ get; set; }
}