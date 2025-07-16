using MediatR;

namespace HomeTrack.Application.ResidentialComplex.RemoveHouseFromResidentialComplex;

public class RemoveHouseFromResidentialComplexCommand
    : IRequest
{
    public Guid HouseId { get; set; }
    public Guid ResidentialComplexId{ get; set; }
}