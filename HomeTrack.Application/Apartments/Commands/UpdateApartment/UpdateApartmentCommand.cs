using MediatR;

namespace HomeTrack.Application.Apartments.Commands.UpdateApartment;

public class UpdateApartmentCommand : IRequest
{
    public Guid Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public int Entrance { get; set; }
    public int Floor { get; set; }
    public int Area { get; set; }
}