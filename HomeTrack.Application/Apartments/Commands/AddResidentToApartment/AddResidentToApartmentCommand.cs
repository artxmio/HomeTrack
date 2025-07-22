using MediatR;

namespace HomeTrack.Application.Apartments.Commands.AddResidentToApartment;

public class AddResidentToApartmentCommand :
    IRequest
{
    public Guid ResidentId { get; set; }
    public Guid ApartmentId { get; set; }
}