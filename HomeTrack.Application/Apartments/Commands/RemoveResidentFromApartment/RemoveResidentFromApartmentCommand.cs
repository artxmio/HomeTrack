using MediatR;

namespace HomeTrack.Application.Apartments.Commands.RemoveResidentFromApartment;

public class RemoveResidentFromApartmentCommand :
    IRequest
{
    public Guid ResidentId { get; set; }
    public Guid ApartmentId { get; set; }
}