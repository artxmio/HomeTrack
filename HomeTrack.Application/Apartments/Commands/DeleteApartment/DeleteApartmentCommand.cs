using MediatR;

namespace HomeTrack.Application.Apartments.Commands.DeleteApartment;

public class DeleteApartmentCommand : IRequest
{
    public Guid Id { get; set; }
}