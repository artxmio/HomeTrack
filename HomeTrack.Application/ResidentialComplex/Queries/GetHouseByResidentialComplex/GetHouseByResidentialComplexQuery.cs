using MediatR;

namespace HomeTrack.Application.ResidentialComplex.Queries.GetHouseByResidentialComplex;

public class GetHouseByResidentialComplexQuery
    : IRequest<HouseByResidentialComplexVm>
{
    public Guid ResidentialComplexId { get; set; }
}