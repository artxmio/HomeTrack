using MediatR;

namespace HomeTrack.Application.Apartments.Queries.GetApartmentDetails;

public class GetApartmentDetailsQuery : IRequest<ApartmentDetailsVm>
{
    public Guid Id { get; set; }
}