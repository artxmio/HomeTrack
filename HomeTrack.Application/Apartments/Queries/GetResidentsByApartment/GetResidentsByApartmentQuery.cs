using MediatR;

namespace HomeTrack.Application.Apartments.Queries.GetResidentsByApartment;

public class GetResidentsByApartmentQuery : 
    IRequest<ResidentsByApartmentVm>
{
    public Guid ApartmentId { get; set; }
}