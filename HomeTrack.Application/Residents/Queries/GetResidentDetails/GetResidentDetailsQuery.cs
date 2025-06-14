using MediatR;

namespace HomeTrack.Application.Residents.Queries.GetResidentDetails;

public class GetResidentDetailsQuery : IRequest<ResidentDetailsVm>
{
    public Guid Id { get; set; }
}
