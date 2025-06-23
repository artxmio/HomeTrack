using MediatR;

namespace HomeTrack.Application.ResidentialComplex.Queries.GetResidentialComplexDetails;

public class GetResidentialComplexDetailsQuery :
    IRequest<ResidentialComplexVm>
{
    public Guid Id { get; set; }
}